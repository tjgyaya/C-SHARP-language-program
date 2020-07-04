using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace 自动进入钉钉直播间
{
    public partial class CustomScreenshot : Form
    {
        private bool saveToDesktop;
        private string desktopPath, savePath, dingDingClass;
        private int pictureX, pictureY, temp_Height, screenNum = -1;

        public CustomScreenshot(bool save_to_desk, string desk_path, string ding_ding_class)
        {
            saveToDesktop = save_to_desk;
            desktopPath = desk_path;
            dingDingClass = ding_ding_class;
            InitializeComponent();
            //label2.Visible = false;
            label2.Text = "";
        }


        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private extern static int GetWindowRect(IntPtr hwnd, out Rect lpRect);

        public struct POINT
        {
            public int X;
            public int Y;
        }

        [DllImport("user32.dll")]
        public extern static uint ScreenToClient(IntPtr hWnd, ref POINT p);

        [DllImport("user32.dll")]
        private extern static bool SetForegroundWindow(IntPtr hWnd);

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // 设置窗口透明
            pictureBox1.BackColor = Color.Red;
            this.TransparencyKey = Color.Red;
            this.BackColor = Color.Red;
            this.TopMost = true;       // 设置当前窗口为顶层窗口      
            temp_Height = this.Height; // 保存窗体高度

            try
            {
                string DingDingPath = Reg.GetDingDingPath();// 获取钉钉路径
                Process.Start(DingDingPath);// 打开钉钉

                for (int i = 1; i <= 20; i++)// 寻找钉钉进程
                {
                    foreach (Process pro in Process.GetProcesses())
                    {
                        if (pro.ProcessName.ToLower() == "DingTalk".ToLower())
                        {
                            i = 999; // 为了跳出外层的for循环
                            break;
                        }
                    }

                    if (i > 20)
                        break;
                    else if (i == 20)
                    {
                        throw new Exception("未找到钉钉进程，请手动打开钉钉后重试！");
                    }
                    System.Threading.Thread.Sleep(3000);// 如未找到则等待3秒再查找
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误：" + ex.Message, "自动进入钉钉直播间", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
        }


        // 截图按钮
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = (Form1)this.Owner;
            try
            {
                Bitmap b = null;
                pictureBox1.Image = b;
                Rect r = new Rect();   // 钉钉窗口坐标
                POINT p = new POINT(); // 钉钉窗口坐标 距离 截图坐标 的相对坐标

                IntPtr hwnd = FindWindow(dingDingClass, null);
                if (hwnd == IntPtr.Zero)
                    throw new Exception("获取钉钉窗口句柄失败！");

                if (GetWindowRect(hwnd, out r) == 0)
                    throw new Exception("获取钉钉窗口坐标失败！");

                // 如果是“button1”控件触发
                if (((System.Windows.Forms.Control)sender).Name == "button1")
                {
                    // 将pictureBox1控件相对于窗体的坐标 转为 相对于屏幕的坐标
                    Point point = PointToScreen(pictureBox1.Location);
                    pictureX = point.X;
                    pictureY = point.Y;

                    // 激活显示钉钉窗口
                    SetForegroundWindow(hwnd);

                    p.X = pictureX;
                    p.Y = pictureY;
                    // 获取截图坐标 相对于 钉钉窗口坐标的距离
                    ScreenToClient(hwnd, ref p);

                    // 截图相对坐标
                    f1.RelPosX = p.X;
                    f1.RelPosY = p.Y;

                    screenNum = 0;
                }
                else // 否则 则为“numericUpDown”控件调用此函数
                {
                    // 截图相对坐标
                    f1.RelPosX = (int)numericUpDown1_X.Value;
                    f1.RelPosY = (int)numericUpDown2_Y.Value;
                }

                // 截图坐标 = 截图相对坐标（钉钉窗口坐标 距离 截图坐标 的距离） + 钉钉窗口坐标
                pictureX = f1.RelPosX + r.Left;
                pictureY = f1.RelPosY + r.Top;

                // 截取指定区域
                Bitmap bit = ScreenCapture.Screenshot(pictureX, pictureY, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = bit;

                // 如果打开截图保存到桌面
                if (saveToDesktop)
                {
                    savePath = desktopPath + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + ".bmp";
                    bit.Save(savePath, System.Drawing.Imaging.ImageFormat.Bmp);
                }
                else
                {
                    savePath = Environment.GetEnvironmentVariable("TEMP") + "\\自动进入钉钉直播间截图.bmp";
                    bit.Save(savePath, System.Drawing.Imaging.ImageFormat.Bmp);
                }

                label1.Text = "截图成功！\n请退出并重新打开本软件";
                label2.Text = "坐标微调前将本窗口移到其它区域";

                // 获取屏幕缩放比并设置窗口高度，以便完全显示所有内容
                Graphics g = this.CreateGraphics();
                int h = temp_Height + 63 + (int)(g.DpiX - 96f) / 24 * 18;
                if (h != this.Height)
                    this.Height = h;

                f1.DpiX = g.DpiX;
                f1.DpiY = g.DpiY;

                g.Dispose();


                //label2.Text = string.Format($"截图坐标：{pictureX}x{pictureY}\n\n截图高x宽：{pictureBox1.Height}x{pictureBox1.Width}" +
                //$"\n截图相对钉钉坐标：{f1.RelPosX}x{f1.RelPosY}");

                // 激活窗体
                this.Activate();
                numericUpDown1_X.Value = f1.RelPosX;
                numericUpDown2_Y.Value = f1.RelPosY;

                // 设置成功，将form1的CustomScreenshotSuccess设为true
                f1.CustScreenSuccess = true;
                f1.ScreenshotH = pictureBox1.Height;
                f1.ScreenshotW = pictureBox1.Width;
                f1.CurrentVersion = Application.ProductVersion;
            }
            catch (Exception ex)
            {
                f1.CustScreenSuccess = false;
                MessageBox.Show(ex.Message, "自定义截图", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label1.Text = "截图失败！";
                label2.Text = "";
            }
        }


        // 清除按钮
        private void button2_Click(object sender, EventArgs e)
        {
            screenNum = -1;
            numericUpDown1_X.Value = 0;
            numericUpDown2_Y.Value = 0;

            pictureBox1.Image = null;
            label1.Text = "请将透明区移到钉钉左上角\nxx群正在直播区域并截图";
            label2.Text = "";
            this.Height = temp_Height;
        }


        // 更改相对坐标的值时重新截图 
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (screenNum == -1)
            {
                numericUpDown1_X.Value = 0;
                numericUpDown2_Y.Value = 0;
                // MessageBox.Show("请先点击截图按钮", "自动进入钉钉直播间", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            screenNum++;
            if (screenNum > 2) // 因为截图后要给两个numericUpDown控件赋值，会调用两次此函数
                button1_Click(sender, null);

        }
    }
}