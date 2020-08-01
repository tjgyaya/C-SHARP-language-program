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
        private string SourceOfTran, from, src, dst;
        private string[] Youdao_to = { "en", "ru", "ja" };
        private string[] Baidu_to = { "en", "ru", "jp" };
        private Keys[] Key = { Keys.T, Keys.Y };
        private string GtaWindowName = "Grand Theft Auto V";


        [DllImport("user32.dll")]
        public extern static uint MapVirtualKey(uint uCode, uint uMapType);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        private static extern bool SetForegroundWindow(IntPtr hwnd);

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private const int KEYEVENTF_KEYUP = 0x0002; // 释放按键
        private const int MAPVK_VK_TO_VSC = 0;      // 虚拟密钥代码转换为扫描代码

        public Translate(string sourceOfTran)
        {
            InitializeComponent();

            SourceOfTran = sourceOfTran;
            comboBox1.SelectedIndex = Form1.AutoPressKey;
            comboBox2.SelectedIndex = Form1.TranDestLang;
            checkBox1.Checked = Form1.AutoSend;
        }


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
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
                if (textBox1.Text == "")
                    return;

                if (comboBox2.SelectedItem.ToString() != "不翻译")
                {
                    if (SourceOfTran.IndexOf("有道") != -1)
                    {
                        from = "zh-CHS";
                        Youdao.YoudaoTran(textBox1.Text, from, Youdao_to[comboBox2.SelectedIndex], out src, out dst);
                    }
                    else
                    {
                        from = "zh";
                        Baidu.Translate(textBox1.Text, from, Baidu_to[comboBox2.SelectedIndex], out src, out dst);
                    }
                }
                else
                    dst = textBox1.Text;

                // 查找窗口句柄
                IntPtr hwnd = FindWindow(null, GtaWindowName);
                if (hwnd == IntPtr.Zero)
                    throw new Exception("查找GTA5窗口句柄失败！");

                // 激活窗口
                if (!SetForegroundWindow(hwnd))
                    throw new Exception("无法激活GTA5窗口！");

                Thread.Sleep(100);
                KeyBoard(Key[comboBox1.SelectedIndex]);
                Thread.Sleep(500);
                SendKeys.Send(dst);    // 输入要发送的内容
                Thread.Sleep(2000);
                if (checkBox1.Checked) // 自动发送（按下回车键）
                {
                    KeyBoard(Keys.Enter);
                }

                // 保存当前选项
                Form1.TranDestLang = comboBox2.SelectedIndex;
                Form1.AutoPressKey = comboBox1.SelectedIndex;
                Form1.AutoSend = checkBox1.Checked;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
                this.Dispose();
            }
        }


        private void KeyBoard(Keys key)
        {
            // 模拟按下按键
            keybd_event((byte)key, (byte)MapVirtualKey((uint)key, MAPVK_VK_TO_VSC), 0, 0);
            Thread.Sleep(50);
            keybd_event((byte)key, (byte)MapVirtualKey((uint)key, MAPVK_VK_TO_VSC), KEYEVENTF_KEYUP, 0);
        }
    }
}
