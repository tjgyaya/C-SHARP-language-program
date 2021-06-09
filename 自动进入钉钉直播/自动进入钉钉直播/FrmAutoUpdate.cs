using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace 自动进入钉钉直播
{
    public partial class AutoUpdateForm : Form
    {
        private static string xmlUrl = "https://gitee.com/fuhohua/Web/raw/master/DD/Update.xml"; // XML文件下载地址
        private static string xmlPath = Environment.GetEnvironmentVariable("APPDATA") + "\\升级文件.xml"; // XML本地路径
        private static string downloadPath = Process.GetCurrentProcess().MainModule.FileName;    // 当前程序名称
        private static string temp_file = downloadPath + ".tmp";                             // 临时文件
        private static string batPath = Application.StartupPath + "\\重命名.bat"; // 脚本文件
        private int sec = 15;

        private static string UpdateVersion { get; set; }
        private static string FileUrl { get; set; }
        private static string FileMd5 { get; set; }
        private static string UpdateCont { get; set; }

        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private CancellationToken token;


        public AutoUpdateForm()
        {
            InitializeComponent();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            progressBar1.Visible = false;
            token = tokenSource.Token;
        }

        private void AutoUpdateForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            label1_CurrentVersion.Text = "当前版本：" + Application.ProductVersion;
            label2_UpdateVersion.Text = "最新版本：" + UpdateVersion;
            textBox1_UpdateCont.Text = "";
            string[] Array = UpdateCont.Split('\n');
            for (int i = 0; i < Array.Length; i++)
                textBox1_UpdateCont.AppendText(Array[i] + Environment.NewLine);
            textBox1_UpdateCont.Text.TrimEnd(Environment.NewLine.ToCharArray());
        }

        private void button1_Update_Click(object sender, EventArgs e)
        {
            DisableButton();
            timer1.Enabled = false;
            progressBar1.Visible = true;
            button1_Update.Enabled = false;
            this.Size = new System.Drawing.Size(325, 260);
            try
            {
                Task.Run(new Action(() =>
                  {
                      DownloadFile(FileUrl, temp_file);
                      if (tokenSource.IsCancellationRequested)
                          return;
                      // 判断下载的文件MD5是否和Xml文件中的一致
                      if (!FileMd5.ToLower().Equals(GetMd5(temp_file).ToLower()))
                          throw new Exception("下载的文件MD5不一致");
                      RunScript();
                  }),
                  token);
            }
            catch (Exception ex)
            {
                Clipboard.SetText(FileUrl); // 将下载链接复制到剪贴板
                MessageBox.Show("更新失败，已将下载链接复制到剪切板。\n原因：" + ex.Message, "更新失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CancelUpdate();
            }
        }

        // 禁用关闭按钮
        private void DisableButton()
        {
            IntPtr hMenu = Api.GetSystemMenu(this.Handle, false); // 获取程序窗体的句柄
            if (hMenu != IntPtr.Zero)
                Api.EnableMenuItem(hMenu, Api.SC_CLOSE, Api.MF_BYCOMMAND | Api.MF_GRAYED | Api.MF_DISABLED); // 禁用关闭按钮
        }

        private void button2_CancelUpdate_Click(object sender, EventArgs e) => CancelUpdate();

        // 运行修改文件名脚本
        private void RunScript()
        {
            string bat =
                  "@ping -n 2 127.1 > nul\r\n"                                 // 延时2秒等待软件退出
                + "del /f \"" + downloadPath + "\"\r\n"                        // 删除原文件
                + "move /y \"" + temp_file + "\" \"" + downloadPath + "\"\r\n" // 重命名文件
                + "start \"自动进入钉钉直播间\" " + downloadPath + "\"\r\n"    // 打开新文件                                                
               // + "pause\r\n del /f %0\r\n";
                + "del /f %0\r\n";
            File.WriteAllText(batPath, bat, Encoding.GetEncoding("GB2312"));   // 写入bat文件
            Process pro = new Process();           // 运行脚本
            pro.StartInfo.WorkingDirectory = Application.StartupPath;
            pro.StartInfo.FileName = batPath;
          //  pro.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pro.Start();
            // 杀死当前进程
            Process.GetCurrentProcess().Kill();
        }

        // 取消更新
        private void CancelUpdate()
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void ClearFile()
        {
            if (File.Exists(temp_file))
                File.Delete(temp_file);
            if (File.Exists(batPath))
                File.Delete(batPath);
            if (File.Exists(xmlPath))
                File.Delete(xmlPath);
        }

        /// <summary>
        /// 获取更新
        /// </summary>
        /// <returns></returns>
        public bool GetUpdate()
        {
            ClearFile();
            // 下载Xml文件
            using (WebClient client = new WebClient())
                client.DownloadFile(xmlUrl, xmlPath);
            // 加载Xml文件
            XmlDocument xml = new XmlDocument();
            xml.Load(xmlPath);
            // 得到根节点
            XmlNode node = xml.SelectSingleNode("AutoUpdate");
            XmlNodeList list = node.ChildNodes;
            foreach (XmlNode xn in list)
            {
                XmlElement element = (XmlElement)xn;// 将节点转为元素
                UpdateVersion = element.GetAttribute("Version");// 得到Version属性的值
                // 得到Update节点的所有子节点
                XmlNodeList nodeList = element.ChildNodes;
                FileMd5 = nodeList.Item(1).InnerText;
                FileUrl = nodeList.Item(2).InnerText;
                UpdateCont = nodeList.Item(3).InnerText;
            }
            // 删除Xml文件
            File.Delete(xmlPath);
            // 比较版本号，如果当前版本小于升级版本
            return (new Version(Application.ProductVersion) < new Version(UpdateVersion));
        }

        public void DownloadFile(string url, string fileName)
        {
            byte[] bArr = new byte[1024];
            int len;
            long totalSize, totalWrite = 0;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Stream stream = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                response = (HttpWebResponse)request.GetResponse();
                totalSize = response.ContentLength;
                stream = response.GetResponseStream();
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    while ((len = stream.Read(bArr, 0, bArr.Length)) > 0)
                    {
                        fs.Write(bArr, 0, len);
                        totalWrite += len;
                        int t = (int)((double)totalWrite / totalSize * 100);
                        if (!tokenSource.IsCancellationRequested&&!progressBar1.IsDisposed)
                            progressBar1.Invoke(new Action(() => UpdateProgress(t)));
                    }
                }
            }
            finally
            {
                response?.Dispose();
                stream?.Dispose();
            }
        }

        private void UpdateProgress(int progress)
        {
            if (progress < 0)
                progress = 0;
            this.progressBar1.Value = progress > 100 ? 100 : progress;
        }

        // 获取文件MD5
        private string GetMd5(string path)
        {
            byte[] data;
            using (FileStream fs = new FileStream(path, FileMode.Open))
            using (var md5 = new MD5CryptoServiceProvider())
                data = md5.ComputeHash(fs);
            StringBuilder sb = new StringBuilder(data.Length);
            for (int i = 0; i < data.Length; i++)
                sb.Append(data[i].ToString("x2"));
            return sb.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sec <= 0)// 15秒倒计时
                CancelUpdate();
            sec--;
        }

        private void AutoUpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            tokenSource.Cancel();
            timer1.Enabled = false;
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
