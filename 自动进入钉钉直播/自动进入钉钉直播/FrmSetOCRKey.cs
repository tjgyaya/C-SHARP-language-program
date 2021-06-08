using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 自动进入钉钉直播.ImageRecognition;

namespace 自动进入钉钉直播
{
    public partial class FrmSetOCRKey : Form
    {
        private Point local;
        private string apikeyPath = Application.StartupPath + "\\apikey.txt";
        private string OCR_KEYMth = Application.StartupPath + "\\OCR_KEYMth.mht";
        public FrmSetOCRKey(int x, int y)
        {
            InitializeComponent();
            // 在父窗口剧中显示
            local = new Point(x - this.Width / 2, y - this.Height / 2);
        }

        private void button1_ApplicationKey_Click(object sender, EventArgs e) => Process.Start("https://ai.baidu.com/tech/ocr/general");// 申请api

        private void button2_TestKey_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1_APIKey.Text))
                    throw new Exception("APIKey不能为空！");
                if (string.IsNullOrEmpty(textBox2_SecretKey.Text))
                    throw new Exception("SecretKey不能为空！");

                string tmp = BaiduOCR.GetAccessToken(textBox1_APIKey.Text, textBox2_SecretKey.Text);
                if (!string.IsNullOrEmpty(tmp))
                {
                    File.WriteAllText(apikeyPath, textBox1_APIKey.Text + Environment.NewLine + textBox2_SecretKey.Text);
                    MessageBox.Show("测试成功！", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    throw new Exception("测试失败！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmSetOCRKey_Load(object sender, EventArgs e)
        {
            this.Location = local;
            try
            {    // 加载mth文件（教程）
                File.WriteAllBytes(OCR_KEYMth, Properties.Resources.OCR_KEY);// 将资源文件（*.mht）写入到磁盘
                webBrowser1.Navigate(OCR_KEYMth);                            // 用webBrowser控件加载“mth”文件
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "自动进入钉钉直播", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // 加载ApiKey文件
            if (!File.Exists(apikeyPath))
                return;
            OCR.ReadApiKeyFile(apikeyPath, out string ak, out string sk);
            textBox1_APIKey.Text = ak;
            textBox2_SecretKey.Text = sk;
        }

        private void FrmSetOCRKey_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (File.Exists(OCR_KEYMth))
                File.Delete(OCR_KEYMth);
        }
    }
}
