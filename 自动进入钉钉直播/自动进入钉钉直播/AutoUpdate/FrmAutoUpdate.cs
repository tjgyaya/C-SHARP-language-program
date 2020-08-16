using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace 自动进入钉钉直播
{
    public partial class AutoUpdateForm : Form
    {
        private static string currentVersion = Application.ProductVersion;                       // 当前程序版本
        private static string xmlUrl = "https://gitee.com/fuhohua/Web/raw/master/DD/Update.xml"; // XML文件下载地址
        private static string xmlPath = Path.Combine(Environment.GetEnvironmentVariable("APPDATA") + "\\", "自动进入钉钉直播_升级文件.xml"); // XML本地路径
        private static string downloadPath = Process.GetCurrentProcess().MainModule.FileName;    // 当前程序名称
        private static string temp_filename = downloadPath + ".tmp";                             // 临时文件
        private static string batPath = Path.Combine(Application.StartupPath + "\\", "自动进入钉钉直播_重命名.bat"); // 脚本文件
        private int sec = 15;

        private static string UpdateVersion { get; set; }
        // private static string FileName { get; set; }
        private static string FileUrl { get; set; }
        private static string FileMd5 { get; set; }
        private static string UpdateCont { get; set; }

        public AutoUpdateForm()
        {
            InitializeComponent();
        }

        private void AutoUpdateForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            label1_CurrentVersion.Text = "当前版本：" + currentVersion;
            label2_UpdateVersion.Text = "最新版本：" + UpdateVersion;

            textBox1_UpdateCont.Text = "";
            string[] Array = UpdateCont.Split('\n');
            for (int i = 0; i < Array.Length; i++)
            {
                if (i == Array.Length - 1)
                    textBox1_UpdateCont.AppendText(Array[i]);
                else
                    textBox1_UpdateCont.AppendText(Array[i] + Environment.NewLine);
            }
        }

        private void button1_Update_Click(object sender, EventArgs e)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            WebClient client = new WebClient();
            try
            {
                // 下载更新文件
                client.DownloadFile(FileUrl, temp_filename);

                // 判断下载的文件是否存在
                if (!File.Exists(temp_filename))
                    throw new Exception("下载更新文件失败");

                // 判断下载的文件MD5是否和Xml文件中的一致
                if (!FileMd5.ToLower().Equals(GetMd5(temp_filename).ToLower()))
                    throw new Exception("下载的文件MD5不一致");

                // 写脚本
                string bat =
                      "@ping -n 2 127.1 > nul\r\n"                                 // 延时2秒等待软件退出
                    + "del /f \"" + downloadPath + "\"\r\n"                        // 删除原文件
                    + "move /y \"" + temp_filename + "\" \"" + downloadPath + "\"\r\n" // 重命名文件
                    + "start \"自动进入钉钉直播间\" " + downloadPath + "\"\r\n"    // 打开新文件                                                
                    + "del /f %0\r\n";
                //+ "pause";
                File.WriteAllText(batPath, bat, Encoding.GetEncoding("GB2312"));   // 写入bat文件
                FileInfo fi = new FileInfo(batPath);
                if (fi.Exists)
                    fi.Attributes = FileAttributes.Hidden;                        // 设置属性为隐藏

                // 运行脚本
                Process pro = new Process();
                pro.StartInfo.WorkingDirectory = Application.StartupPath;
                pro.StartInfo.FileName = batPath;
                pro.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                //pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                pro.Start();

                // 杀死当前进程
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                Clipboard.SetText(FileUrl); // 将下载链接复制到剪贴板
                MessageBox.Show("更新失败，已将下载链接复制到剪切板。\n原因：" + ex.Message, "自动进入钉钉直播间_更新失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button2_CancelUpdate_Click(null, null);
            }
            finally
            {
                client.Dispose();
            }
        }

        private void button2_CancelUpdate_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }


        // 获取更新
        public bool GetUpdate()
        {
            // 删除上次残余文件
            if (File.Exists(temp_filename))
                File.Delete(temp_filename);
            if (File.Exists(batPath))
                File.Delete(batPath);
            if (File.Exists(xmlPath))
                File.Delete(xmlPath);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // 下载Xml文件
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(xmlUrl, xmlPath);
            }

            // 判断Xml文件是否存在
            if (!File.Exists(xmlPath))
                throw new Exception("下载更新XML文件失败");

            // 加载Xml文件
            XmlDocument xml = new XmlDocument();
            xml.Load(xmlPath);
            // 得到根节点
            XmlNode node = xml.SelectSingleNode("AutoUpdate");
            XmlNodeList list = node.ChildNodes;

            foreach (XmlNode xn in list)
            {
                // 将节点转为元素
                XmlElement element = (XmlElement)xn;
                // 得到Version属性的值
                UpdateVersion = element.GetAttribute("Version");
                // 得到Update节点的所有子节点
                XmlNodeList nodeList = element.ChildNodes;
                //FileName = nodeList.Item(0).InnerText;
                FileMd5 = nodeList.Item(1).InnerText;
                FileUrl = nodeList.Item(2).InnerText;
                UpdateCont = nodeList.Item(3).InnerText;
            }
            // 删除Xml文件
            if (File.Exists(xmlPath))
                File.Delete(xmlPath);

            // 比较版本号，如果当前版本小于升级版本
            if (new Version(currentVersion) < new Version(UpdateVersion))
                return true;
            else
                return false;
        }

        // 获取文件MD5
        private string GetMd5(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = new byte[1];
            try
            {
                data = md5.ComputeHash(fs);
            }
            finally
            {
                md5.Dispose();
                fs.Close();
            }

            StringBuilder sb = new StringBuilder(data.Length);
            for (int i = 0; i < data.Length; i++)
                sb.Append(data[i].ToString("x2"));

            return sb.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sec <= 0)// 15秒倒计时
                button2_CancelUpdate_Click(null, null);
            sec--;
        }
    }
}
