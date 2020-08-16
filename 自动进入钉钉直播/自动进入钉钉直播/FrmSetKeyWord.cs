using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace 自动进入钉钉直播
{
    public partial class FrmSetKeyWord : Form
    {
        private string RGBMth = Path.Combine(Application.StartupPath + "\\", "RGB.mht");
        private string OCRMth = Path.Combine(Application.StartupPath + "\\", "OCR.mht");
        private string currentWindow = "";  // 当前显示的窗口
        private Point local;

        public FrmSetKeyWord(int x, int y)
        {
            InitializeComponent();
            local = new Point(x - this.Width / 2, y - this.Height / 2);// 设置窗口在主窗口居中
            DelFile();                                                 // 删除残余文件
        }

        private void button2_RGBExamples_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentWindow == "RGB")
                    return;

                currentWindow = "RGB";
                if (!File.Exists(RGBMth))
                {
                    File.WriteAllBytes(RGBMth, Properties.Resources.RGB);// 将资源文件（*.mht）写入到磁盘
                    FileInfo fi = new FileInfo(RGBMth);
                    fi.Attributes = FileAttributes.Temporary | FileAttributes.Hidden;
                }
                webBrowser1.Navigate(RGBMth);                            // 用webBrowser控件加载“mth”文件
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "自动进入钉钉直播", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_OCRExamples_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentWindow == "OCR")
                    return;

                currentWindow = "OCR";
                if (!File.Exists(OCRMth))
                {
                    File.WriteAllBytes(OCRMth, Properties.Resources.OCR);// 将资源文件（*.mht）写入到磁盘
                    FileInfo fi = new FileInfo(OCRMth);
                    fi.Attributes = FileAttributes.Temporary | FileAttributes.Hidden;
                }
                webBrowser1.Navigate(OCRMth);                            // 用webBrowser控件加载“mth”文件
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message ,"自动进入钉钉直播", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_SetRgbKey_Click(object sender, EventArgs e)
        {
            try
            {
                string colorPath = Path.Combine(Application.StartupPath + "\\", "color.txt");
                if (!FileIsExists(colorPath))// 判断文件是否存在
                    File.WriteAllText(colorPath, "");

                Process.Start(colorPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message ,"自动进入钉钉直播", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_SetOcrKey_Click(object sender, EventArgs e)
        {
            try
            {
                string keyWordPath = Path.Combine(Application.StartupPath + "\\", "关键字.txt");

                if (!FileIsExists(keyWordPath))
                    File.WriteAllText(keyWordPath, "");

                Process.Start(keyWordPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message ,"自动进入钉钉直播", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmSetKeyWord_Load(object sender, EventArgs e)
        {
            if (local.X >= 0 && local.Y >= 0)
                this.Location = local;

            button2_RGBExamples_Click(null, null);
        }

        private void FrmSetKeyWord_FormClosing(object sender, FormClosingEventArgs e)
        {
            DelFile();
            webBrowser1.Dispose();
        }

        private void DelFile()
        {
            if (File.Exists(RGBMth))
                File.Delete(RGBMth);
            if (File.Exists(OCRMth))
                File.Delete(OCRMth);
        }

        private bool FileIsExists(string filePath)
        {
            // 判断当前目录是否已存在指定文件
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);
            FileInfo[] files = dir.GetFiles("*" + Path.GetExtension(filePath));// 查找目录下的txt的文件
            foreach (var f in files)
            {
                if (f.ToString().ToLower() == Path.GetFileName(filePath).ToLower())
                    return true;
            }
            return false;
        }
    }
}
