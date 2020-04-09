using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace 鼠连点
{
    public partial class Form1 : Form
    {
        protected delegate void UpdateControlText1();

        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);//模拟鼠标消息

        const int MOUSEEVENTF_LEFTDOWN = 0x0002;   //模拟鼠标左键按下      
        const int MOUSEEVENTF_LEFTUP = 0x0004;     //模拟鼠标左键抬起 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;  //模拟鼠标右键按下 
        const int MOUSEEVENTF_RIGHTUP = 0x0010;    //模拟鼠标右键抬起 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;   //模拟鼠标中键抬起 
                                                   // const int MOUSEEVENTF_WHEEL = 0x0800;      //模拟鼠标滚轮滚动操作，必须配合dwData参数

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);//注册热键

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);//释放注册的的热键
        public Form1()
        {
            InitializeComponent();
            if (!RegisterHotKey(this.Handle, 100, 0, Keys.F8)) //注册热键f8
            {
                DialogResult result = MessageBox.Show("注册热键失败，是否继续运行？", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.No)
                {
                    exit_Click(null, null);
                }
                else
                {
                    button1.Text = "点击此处开始连点";
                    label5.Text = "使用方法：\n1、点击上面按钮开始\n2、把鼠标移动到需要点击的地方";
                }
            }
        }




        private Thread newThread;
        private int number;
        double sec;
        bool start = false, infiniteNumber;

        /// <summary>
        /// 点击按钮或按F8开启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Start_Click(object sender, EventArgs e)
        {
            total = 0;//将按钮2显示的点击次数清零

            number = (int)numericUpDown1.Value;//获取要点击的次数，如果为0则为无限次数点击

            if (!double.TryParse(textBox1.Text, out sec))
            {
                MessageBox.Show("间隔时间输入错误", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "1";
                return;
            }
            if (sec < 0.001)
            {
                MessageBox.Show("间隔时间最小不能超过0.001秒", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "0.001";
                return;
            }
            sec *= 1000;//把秒化成毫秒


            //判断当前状态（启动|停止）
            if (start == false)
            {
                start = true;
                label8.Text = "已开启";
                button2.Enabled = true;
                Run();//启动
            }
            else
            {
                start = false;
                label8.Text = "已关闭";
                button2.Enabled = false;

                if (newThread != null)
                    newThread.Abort();//关闭线程
            }

        }

        private void Run()
        {
            //判断是否为无限次数点击
            if ((int)numericUpDown1.Value == 0)
                infiniteNumber = true;
            else
                infiniteNumber = false;


            if (comboBox1.Text == "鼠标左键")
                newThread = new Thread(LeftMouseButton);
            else if (comboBox1.Text == "鼠标右键")
                newThread = new Thread(RightMouseButton);
            else//鼠标中键
                newThread = new Thread(MiddleMouseButton);


            Thread.Sleep(1000);//延时1秒启动
            newThread.Start();//启动新线程
        }


        private void LeftMouseButton()
        {
            while (infiniteNumber == true)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                Thread.Sleep((int)sec);//延时
            }

            for (int i = 1; i <= number; i++)
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                Thread.Sleep((int)sec);//延时
            }

            UpdateControlText1 update = new UpdateControlText1(updateControlText);//定义委托
            this.Invoke(update);//调用窗体Invoke方法
        }

        private void MiddleMouseButton()
        {
            while (infiniteNumber == true)
            {
                mouse_event(MOUSEEVENTF_MIDDLEDOWN | MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
                Thread.Sleep((int)sec);//延时
            }


            for (int i = 1; i <= number; i++)
            {
                mouse_event(MOUSEEVENTF_MIDDLEDOWN | MOUSEEVENTF_MIDDLEUP, 0, 0, 0, 0);
                Thread.Sleep((int)sec);//延时
            }
            UpdateControlText1 update = new UpdateControlText1(updateControlText);//定义委托
            this.Invoke(update);//调用窗体Invoke方法
        }

        private void RightMouseButton()
        {
            while (infiniteNumber == true)
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                Thread.Sleep((int)sec);//延时
            }


            for (int i = 1; i <= number; i++)
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                Thread.Sleep((int)sec);//延时
            }
            UpdateControlText1 update = new UpdateControlText1(updateControlText);//定义委托
            this.Invoke(update);//调用窗体Invoke方法
        }


        /// <summary>
        /// 在多线程中刷新控件
        /// </summary>
        private void updateControlText()
        {
            label8.Text = "已关闭";
            start = false;
            button2.Enabled = false;
        }



        //通过监视系统消息，判断是否按下热键
        protected override void WndProc(ref Message m)//监视Windows消息
        {
            if (m.Msg == 0x0312)//如果m.Msg的值为0x0312那么表示用户按下了热键
            {
                button1_Start_Click(null, null);//调用button1_Start_Click()函数
            }

            base.WndProc(ref m);
        }




        long total = 0;

        //点击“启动后点击此处测试效果”按钮时计数
        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            total++;
            string str = null;

            if (e.Button == MouseButtons.Left)
                str = "鼠标左键按下，";
            else if (e.Button == MouseButtons.Right)
                str = "鼠标右键按下，";
            else if (e.Button == MouseButtons.Middle)
                str = "鼠标中键按下，";

            button2.Text = str + "已点击：" + total.ToString() + "次";
        }



        //当窗体大小改变时，任务栏图标出现或隐藏
        private void Form1_Resize(object sender, EventArgs e)
        {
            //关于选项  
            MenuItem about = new MenuItem("关于");
            about.Click += new EventHandler(new_about);

            //退出菜单项  
            MenuItem exit = new MenuItem("退出");
            exit.Click += new EventHandler(exit_Click);

            //关联托盘控件  
            MenuItem[] childen = new MenuItem[] { about, exit };
            notifyIcon1.ContextMenu = new ContextMenu(childen);

            //判断当前窗口是否最小化
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();//隐藏当前窗口
                notifyIcon1.Visible = true;//任务栏显示图标
                //托盘图标显示的内容  
                notifyIcon1.Text = "鼠连点，双击此图标显示窗口";
                //气泡显示的内容和时间（从 Windows Vista 开始，否决此参数。 现在通知显示时间是基于系统辅助功能设置。）  
                notifyIcon1.ShowBalloonTip(1, "鼠连点", "鼠连点正在后台运行...", ToolTipIcon.None);
            }
            else
            {
                notifyIcon1.Visible = false;
            }
        }



        //当用鼠标双击任务栏图标时显示窗口
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show(); //显示窗体
            this.WindowState = FormWindowState.Normal; //窗体恢复正常大小
        }



        //显示关于窗口
        private void About_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new_about(null, null);
        }



        //显示关于窗口
        private void new_about(object sender, EventArgs e)
        {
            About ab = new About();
            ab.ShowDialog();
        }



        //当窗口关闭时
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit_Click(null, null);
        }


        //退出程序
        private void exit_Click(object sender, EventArgs e)
        {
            UnregisterHotKey(this.Handle, 100);//卸载快捷键
            notifyIcon1.Dispose();//释放notifyIcon1的所有资源，保证托盘图标在程序关闭时立即消失
            Environment.Exit(0);//退出程序 
        }


        //当用户按下ESC时最小化窗口
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\u001b')
                this.WindowState = FormWindowState.Minimized;//最小化当前窗口
        }
    }
}