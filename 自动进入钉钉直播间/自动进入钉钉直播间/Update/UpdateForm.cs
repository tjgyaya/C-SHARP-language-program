using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自动进入钉钉直播间
{
    public partial class UpdateForm : Form
    {
        private string updateCont, updateVersion, currentVersion, fileUrl, fileMd5, temp_file, batPath, downFilePath;

        public UpdateForm(string CurVer, string UpdVer, string UpdCont, string FileUrl, string FileMd5, string TempFile, string BatPath, string DownFilePath)
        {
            currentVersion = CurVer;
            updateVersion = UpdVer;
            updateCont = UpdCont;
            fileUrl = FileUrl;
            fileMd5 = FileMd5;
            temp_file = TempFile;
            batPath = BatPath;
            downFilePath = DownFilePath;
            InitializeComponent();

            label1_CurrentVersion.Text = "当前版本：" + currentVersion;
            label2_UpdateVersion.Text = "最新版本：" + updateVersion;

            textBox1_UpdateCont.Text = "";
            string[] Array = updateCont.Split('\n');
            for (int i = 0; i < Array.Length; i++)
            {
                if (i == Array.Length - 1)
                    textBox1_UpdateCont.AppendText(Array[i]);
                else
                    textBox1_UpdateCont.AppendText(Array[i] + "\r\n");
            }
        }


        private void button1_Update_Click(object sender, EventArgs e)
        {
            System.Net.WebClient client = new System.Net.WebClient();
            // 下载更新文件
            client.DownloadFile(fileUrl, temp_file);
            // 判断下载的文件是否存在
            if (!File.Exists(temp_file))
                throw new Exception("下载更新文件失败！");


            // 判断下载的文件MD5是否和Xml文件中的一致
            if (!fileMd5.ToLower().Equals(AutoUpdate.GetMd5(temp_file).ToLower()))
                throw new Exception("下载的文件MD5不一致！");


            // 写脚本
            string bat =
                  "@ping -n 1 127.1 > nul\r\n"                                 // 延时2秒等待软件退出
                + "del /f \"" + downFilePath + "\"\r\n"                        // 删除原文件
                + "move /y \"" + temp_file + "\" \"" + downFilePath + "\"\r\n" // 重命名文件
                + "start \"自动进入钉钉直播间\" " + downFilePath + "\"\r\n"    // 打开新文件                                                
                + "del /f %0\r\n"
                + "exit\r\n";
            // + "pause";
            File.WriteAllText(batPath, bat, Encoding.GetEncoding("GB2312"));   // 写入bat文件
            FileInfo fi = new FileInfo(batPath);
            if (fi.Exists)
                fi.Attributes = FileAttributes.Hidden;

            // 运行脚本
            Process pro = new Process();
            pro.StartInfo.WorkingDirectory = Application.StartupPath;
            pro.StartInfo.FileName = batPath;
            //pro.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            pro.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            pro.Start();

            // 杀死当前进程
            Process.GetCurrentProcess().Kill();
        }

        private void button2_CancelUpdate_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
