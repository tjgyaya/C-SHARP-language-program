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
        private Point local;

        public FrmSetKeyWord(int x, int y)
        {
            InitializeComponent();
            local = new Point(x - this.Width / 2, y - this.Height / 2);
        }

        private void button2_RGBExamples_Click(object sender, EventArgs e)
        {
            File.WriteAllBytes(RGBMth, Properties.Resources.RGB);
            webBrowser1.Navigate(RGBMth);
        }

        private void button4_OCRExamples_Click(object sender, EventArgs e)
        {
            File.WriteAllBytes(OCRMth, Properties.Resources.OCR);
            webBrowser1.Navigate(OCRMth);
        }

        private void button1_SetRgbKey_Click(object sender, EventArgs e)
        {
            string colorPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "color.txt");
            File.WriteAllText(colorPath, "");
            Process.Start(colorPath);
        }

        private void button3_SetOcrKey_Click(object sender, EventArgs e)
        {
            string keyWordPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "关键字.txt");
            File.WriteAllText(keyWordPath, "");
            Process.Start(keyWordPath);
        }

        private void FrmSetKeyWord_Load(object sender, EventArgs e)
        {
            this.Location = local;
            button2_RGBExamples_Click(null, null);
        }

        private void FrmSetKeyWord_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (File.Exists(RGBMth))
                File.Delete(RGBMth);
            if (File.Exists(OCRMth))
                File.Delete(OCRMth);
        }
    }
}
