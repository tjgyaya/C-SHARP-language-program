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

namespace 截图翻译
{
    public partial class Translate : Form
    {
        private string SourceTran, from, src, dst;
        private string[] Youdao_to = { "en", "ja", "ru" };
        private string[] Baidu_to = { "en", "jp", "ru" };
        private Keys[] Key = { Keys.T, Keys.Y, Keys.Enter };
        private string GtaClass = "grcWindow";


        const uint KEYEVENTF_KEYUP = 0x0002;
        [DllImport("user32.dll", EntryPoint = "keybd_event")]
        private static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        private static extern bool SetForegroundWindow(IntPtr hwnd);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public Translate(string SrcTran)
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            this.TopMost = true;
            SourceTran = SrcTran;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                Environment.Exit(0);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text != "")
                    Tran();
            }
        }


        // 翻译
        private void Tran()
        {
            try
            {
                if (SourceTran.IndexOf("有道") != -1)
                {
                    from = "zh-CHS";
                    Youdao.YoudaoTran(textBox1.Text, from, Youdao_to[comboBox2.SelectedIndex], out src, out dst);
                }
                else
                {
                    from = "zh";
                    Baidu.Translate(textBox1.Text, from, Baidu_to[comboBox2.SelectedIndex], out src, out dst);
                }

                // 查找窗口句柄
                IntPtr hwnd = FindWindow(GtaClass, null);
                if (hwnd == IntPtr.Zero)
                    throw new Exception("查找GTA5窗口句柄失败！");
                // 激活窗口
                if (!SetForegroundWindow(hwnd))
                    throw new Exception("无法激活GTA5窗口！");

                Thread.Sleep(100);

                // 模拟按下按键
                //keybd_event(Key[comboBox1.SelectedIndex], 0, 0, 0);
                //Thread.Sleep(50);
                //keybd_event(Key[comboBox1.SelectedIndex], 0, KEYEVENTF_KEYUP, 0);
                SendKeys.Send("{T}");
                // SendKeys.Send("我们家有很多菜");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
