using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using 翻译神器.SourceOfTranslation;

namespace 翻译神器
{
    public partial class FrmTranslate : Form
    {
        // **************************************翻译窗口**************************************

        public FrmTranslate(string sourceOfTran, string name, string Class)
        {
            InitializeComponent();

            this.sourceOfTran = sourceOfTran;
            comboBox1_SourceLang.SelectedIndex = FrmMain.AutoPressKey;
            comboBox2_DestLang.SelectedIndex = FrmMain.TranDestLang;
            checkBox1_AutoSend.Checked = FrmMain.AutoSend;

            textBox2_Dest.ReadOnly = true;
            windowName = name;
            windowClass = Class;
        }


        private string sourceOfTran, from, src, dst;
        private string[] Youdao_to = { "en", "ru", "ja" };  // 目标语言名称
        private string[] Baidu_to = { "en", "ru", "jp" };   // 目标语言名称
        private Keys[] Key = { Keys.T, Keys.Y };
        string windowName, windowClass;

        public Point Local { get; set; }


        // 获取窗口句柄，并判断是否有效，无效则抛出异常
        private IntPtr FindWindowHandle()
        {
            IntPtr hwnd;
            if (!string.IsNullOrEmpty(windowName))
            {
                hwnd = Api.FindWindow(null, windowName);
            }
            else if (!string.IsNullOrEmpty(windowClass))
            {
                hwnd = Api.FindWindow(windowClass, null);
            }
            else
                throw new Exception("请设置窗口标题或窗口类名！");

            if (IntPtr.Zero == hwnd)
                throw new Exception("找不到对应的窗口句柄！");
            return hwnd;
        }


        private void FrmTranslate_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Local.X - this.Width / 2, Local.Y - this.Height / 2);
            Api.SetForegroundWindow(this.Handle);// 激活本窗口
        }


        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Translate(true);
            }
        }


        private void textBox_TextChanged(object sender, EventArgs e)
        {
            bool visible;
            if (string.IsNullOrEmpty(textBox1_Source.Text))
                visible = true;
            else
                visible = false;

            label3_Source.Visible = visible;
            label4_Dest.Visible = visible;
        }


        #region 右键菜单
        private void textBox1_撤销ToolStripMenuItem_Click(object sender, EventArgs e) => textBox1_Source.Undo();

        private void textBox1_剪切ToolStripMenuItem_Click(object sender, EventArgs e) => textBox1_Source.Cut();

        private void textBox1_复制ToolStripMenuItem_Click(object sender, EventArgs e) => textBox1_Source.Copy();

        private void textBox1_粘贴ToolStripMenuItem_Click(object sender, EventArgs e) => textBox1_Source.Paste();

        private void textBox1_删除ToolStripMenuItem_Click(object sender, EventArgs e) => textBox1_Source.SelectedText = "";

        private void textBox1_全选ToolStripMenuItem_Click(object sender, EventArgs e) => textBox1_Source.SelectAll();

        private void textBox1_从右到左的顺序RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox1_Source.RightToLeft == RightToLeft.No)
            {
                textBox1_Source.RightToLeft = RightToLeft.Yes;
                textBox1_从右到左的顺序RToolStripMenuItem.Checked = true;
            }
            else
            {
                textBox1_Source.RightToLeft = RightToLeft.No;
                textBox1_从右到左的顺序RToolStripMenuItem.Checked = false;
            }
        }

        private void textBox2_撤销toolStripMenuItem1_Click(object sender, EventArgs e) => textBox2_Dest.Undo();

        private void textBox2_剪切toolStripMenuItem2_Click(object sender, EventArgs e) => textBox2_Dest.Cut();

        private void textBox2_复制toolStripMenuItem3_Click(object sender, EventArgs e) => textBox2_Dest.Copy();

        private void textBox2_粘贴toolStripMenuItem4_Click(object sender, EventArgs e) => textBox2_Dest.Paste();

        private void textBox2_删除toolStripMenuItem5_Click(object sender, EventArgs e) => textBox2_Dest.SelectedText = "";

        private void textBox2_全选toolStripMenuItem6_Click(object sender, EventArgs e) => textBox2_Dest.SelectAll();

        private void textBox2_从右到左的顺序toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (textBox2_Dest.RightToLeft == RightToLeft.No)
            {
                textBox2_Dest.RightToLeft = RightToLeft.Yes;
                toolStripMenuItem7.Checked = true;
            }
            else
            {
                textBox2_Dest.RightToLeft = RightToLeft.No;
                toolStripMenuItem7.Checked = false;
            }
        }
        #endregion


        private void button1_Tran_Click(object sender, EventArgs e)
        {
            textBox2_Dest.Text = Translate(false);
        }


        // 翻译
        private string Translate(bool sendToWindow)
        {
            try
            {
                if (textBox1_Source.Text == "")
                    return "";

                if (comboBox2_DestLang.SelectedItem.ToString() != "不翻译")
                {
                    if (sourceOfTran.IndexOf("有道") != -1)
                    {
                        from = "zh-CHS";
                        Youdao.YoudaoTran(textBox1_Source.Text, from, Youdao_to[comboBox2_DestLang.SelectedIndex], out src, out dst);
                    }
                    else
                    {
                        from = "zh";
                        Baidu.Translate(textBox1_Source.Text, from, Baidu_to[comboBox2_DestLang.SelectedIndex], out src, out dst);
                    }
                }
                else
                    dst = textBox1_Source.Text;

                // 保存当前选项
                FrmMain.TranDestLang = comboBox2_DestLang.SelectedIndex;
                FrmMain.AutoPressKey = comboBox1_SourceLang.SelectedIndex;
                FrmMain.AutoSend = checkBox1_AutoSend.Checked;

                if (!sendToWindow) // 不将译文发送到窗口
                    return dst;

                this.WindowState = FormWindowState.Minimized;

                // 查找窗口句柄
                IntPtr hwnd = FindWindowHandle();
                // 激活窗口
                if (!Api.SetForegroundWindow(hwnd))
                    throw new Exception("无法激活窗口！");

                Thread.Sleep(500);
                KeyBoard(Key[comboBox1_SourceLang.SelectedIndex]);
                Thread.Sleep(500);
                SendKeys.SendWait(dst);
                // SendKeys.Send(dst);    // 输入要发送的内容
                Thread.Sleep(1000);
                if (checkBox1_AutoSend.Checked) // 自动发送（按下回车键）
                {
                    KeyBoard(Keys.Enter);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "翻译", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sendToWindow) // 如果是不将译文发送到窗口，则不会关闭本窗口
                    this.Close();
            }

            return dst;
        }


        private void KeyBoard(Keys key)
        {
            // 模拟按下按键
            Api.keybd_event((byte)key, (byte)Api.MapVirtualKey((uint)key, Api.MAPVK_VK_TO_VSC), 0, 0);
            Thread.Sleep(50);
            Api.keybd_event((byte)key, (byte)Api.MapVirtualKey((uint)key, Api.MAPVK_VK_TO_VSC), Api.KEYEVENTF_KEYUP, 0);
        }
    }
}
