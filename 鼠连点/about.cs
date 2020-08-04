using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 鼠连点
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            pictureBox1.Image = imageList1.Images[0];//显示图片
        }

        /// <summary>
        /// 关闭“关于”窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel4_CloseWindow(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_WebSite(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/cdmxz/C-SHARP-language-language-program");
        }
    }
}
