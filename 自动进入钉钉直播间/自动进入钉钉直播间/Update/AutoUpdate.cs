using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace 自动进入钉钉直播间
{
    class AutoUpdate
    {
        private static string UpdateVersion { get; set; }
        private static string FileName { get; set; }
        private static string FileUrl { get; set; }
        private static string FileMd5 { get; set; }
        private static string UpdateCont { get; set; }

        // 获取更新
        public static bool GetUpdate()
        {
            string currentVersion = Application.ProductVersion;                       // 当前程序版本
            string xmlUrl = "https://gitee.com/fuhohua/Web/raw/master/DD/Update.xml"; // XML文件下载地址
            string xmlPath = Environment.GetEnvironmentVariable("TEMP") + "\\自动进入钉钉直播间Update.xml"; // XML本地路径
            string downFilePath = Process.GetCurrentProcess().MainModule.FileName;    // 当前程序名称
            string temp_File = downFilePath + ".tmp";                                 // 临时文件
            string batPath = Application.StartupPath + "\\自动进入钉钉直播间ren.bat"; // 脚本文件

            // 删除上次残余文件
            if (File.Exists(temp_File))
                File.Delete(temp_File);
            if (File.Exists(batPath))
                File.Delete(batPath);
            if (File.Exists(xmlPath))
                File.Delete(xmlPath);


            // 下载Xml文件
            System.Net.WebClient client = new System.Net.WebClient();
            client.DownloadFile(xmlUrl, xmlPath);

            // 判断Xml文件是否存在
            if (!File.Exists(xmlPath))
                throw new Exception("下载XML文件失败！");

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
                FileName = nodeList.Item(0).InnerText;
                FileMd5 = nodeList.Item(1).InnerText;
                FileUrl = nodeList.Item(2).InnerText;
                UpdateCont = nodeList.Item(3).InnerText;
            }
            // 删除Xml文件
            if (File.Exists(xmlPath))
                File.Delete(xmlPath);


            // 比较版本号，如果当前版本小于升级版本
            if (string.Compare(currentVersion, UpdateVersion) < 0)
            {
                DialogResult result = MessageBox.Show("当前程序出新版啦！是否更新呢？"
                    + "\n当前版本：" + currentVersion
                    + "\n最新版本：" + UpdateVersion
                    + "\n更新内容：" + UpdateCont,
                    "发现新版本", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.No)
                    return false;

                MessageBox.Show("正在下载更新，下载完后会自动打开~", "正在下载更新", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    // 下载更新文件
                    client.DownloadFile(FileUrl, temp_File);
                    // 判断下载的文件是否存在
                    if (!File.Exists(temp_File))
                        throw new Exception("下载更新文件失败！");


                    // 判断下载的文件MD5是否和Xml文件中的一致
                    if (!FileMd5.ToLower().Equals(GetMd5(temp_File).ToLower()))
                        throw new Exception("下载的文件MD5不一致！");


                    // 写脚本
                    string bat = "@ping -n 1 127.1 >nul"                  // 延时1秒等待软件退出
                        + "\r\ndel " + downFilePath                       // 删除原文件
                        + "\r\nmove /y " + temp_File + " " + downFilePath // 重命名文件
                        + "\r\n" + "start " + downFilePath                // 打开新文件
                        + "\r\ndel %0";
                    //+ "\r\npause";
                    File.WriteAllText(batPath, bat, Encoding.GetEncoding("GB2312"));  // 写入bat文件

                    // 运行脚本
                    Process pro = new Process();
                    pro.StartInfo.WorkingDirectory = Application.StartupPath;
                    pro.StartInfo.FileName = batPath;
                    //pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    pro.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    pro.Start();

                    // 杀死当前进程
                    Process.GetCurrentProcess().Kill();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "更新失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
                return false;
        }


        // 获取文件MD5
        private static string GetMd5(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = md5.ComputeHash(fs);
            fs.Close();

            StringBuilder sb = new StringBuilder(data.Length);
            for (int i = 0; i < data.Length; i++)
                sb.Append(data[i].ToString("x2"));

            return sb.ToString();
        }

    }
}
