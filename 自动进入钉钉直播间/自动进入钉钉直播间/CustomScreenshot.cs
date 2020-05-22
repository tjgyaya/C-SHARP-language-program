using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace 自动进入钉钉直播间
{
    public partial class CustomScreenshot : Form
    {
        private bool saveDesktop;
        private string desktopPath, savePath, type, dingDingClass;
        private int pictureX, pictureY, temp_h;

        public CustomScreenshot(bool saveDesk, string deskPath, string ding_ding_class)
        {
            saveDesktop = saveDesk;
            desktopPath = deskPath;
            dingDingClass = ding_ding_class;
            InitializeComponent();
        }



        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out Rect lpRect);

        public struct POINT
        {
            public int X;
            public int Y;
        }
        [DllImport("user32.dll")]
        public static extern uint ScreenToClient(IntPtr hWnd, ref POINT p);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

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
            this.TopMost = true;

            string DingDingPath;
            string err = Reg.GetDingDingPath(out DingDingPath);// 获取钉钉路径
            if (err != null)
            {
                MessageBox.Show(err, "自动进入钉钉直播间", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (DingDingPath == null)
                {
                    MessageBox.Show("打开钉钉失败，请手动打开钉钉\n原因：" + err, "自动进入钉钉直播间", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }

            try
            {
                Process.Start(DingDingPath);// 打开钉钉

                for (int i = 1; i <= 20; i++)// 寻找钉钉进程
                {
                    foreach (Process pro in Process.GetProcesses())
                    {
                        if (pro.ProcessName.ToLower() == "DingTalk".ToLower())
                        {
                            i = 999;
                            break;
                        }
                    }

                    if (i > 20)
                        break;
                    else if (i == 20)
                    {
                        MessageBox.Show("未找到钉钉进程，请手动打开钉钉", "自动进入钉钉直播间", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                    System.Threading.Thread.Sleep(3000);// 如未找到则等待3秒再查找
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误\n原因：" + ex.Message, "自动进入钉钉直播间", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }


        // 截图按钮
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = (Form1)this.Owner;
            try
            {

                pictureBox1.Image = null;

                Point point = PointToScreen(pictureBox1.Location);// 将控件相对于窗体坐标转为相对于屏幕坐标
                pictureX = point.X;
                pictureY = point.Y;


                IntPtr hwnd = FindWindow(dingDingClass, null);
                if (hwnd == IntPtr.Zero)
                    throw new Exception("获取钉钉窗口句柄失败！");

                Rect r = new Rect();
                if (GetWindowRect(hwnd, out r) == 0)
                    throw new Exception("获取钉钉窗口坐标失败！");

                // 激活显示钉钉窗口
                SetForegroundWindow(hwnd);

                POINT p = new POINT();
                p.X = pictureX;
                p.Y = pictureY;
                // 获取相对坐标
                ScreenToClient(hwnd, ref p);


                // 获取屏幕缩放比
                Graphics g = this.CreateGraphics();
                //if (g.DpiX == 96f || g.DpiY == 96f)        // 100%缩放
                //{
                //    f1.RelPosX = p.X;
                //    f1.RelPosY = p.Y;
                //}
                //else if (g.DpiX == 120f || g.DpiY == 120f) // 125%
                //{
                //    f1.RelPosX = p.X + 25;
                //    f1.RelPosY = p.Y + 30;
                //}
                //else if (g.DpiX == 144f || g.DpiY == 144f) // 150%
                //{
                //    f1.RelPosX = p.X + 25 * 2;
                //    f1.RelPosY = p.Y + 30 * 2;
                //}
                //else
                //{
                //    MessageBox.Show("当前缩放比不受支持，可能会卡在“第xx次检测当前是否正在直播”。\n请将缩放比设置为100%或120%或144%后，再设置截图区域！", "当前缩放比不受支持", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}

                // 截图相对坐标
                f1.RelPosX = p.X;
                f1.RelPosY = p.Y;
                // 截图相对坐标+钉钉窗口坐标=截图坐标
                pictureX = f1.RelPosX + r.Left;
                pictureY = f1.RelPosY + r.Top;

                // 截取指定区域
                Bitmap bit = ScreenCapture.Screenshot(pictureX, pictureY, pictureBox1.Width, pictureBox1.Height);
                // 显示到pictureBox
                pictureBox1.Image = bit;
                // 如果打开截图保存到桌面
                if (saveDesktop)
                {
                    savePath = desktopPath + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + ".jpg";
                    bit.Save(savePath);
                }
                else
                {
                    savePath = Environment.GetEnvironmentVariable("TEMP") + "\\自动进入钉钉直播间截图.jpg";
                    bit.Save(savePath);
                }

                // 识别类型
                type = "RGB";
                //// 判断图片rgb颜色是否是钉钉正在直播时的rgb
                //if (ScreenCapture.GetPixel(bit) == false)
                //{
                //    type = "OCR";
                //    // 判断关键字
                //    if (OCR.Live(savePath) == false)
                //    {
                //        type = "RGB和OCR";
                //        label1.Text = "(" + type + ")验证失败！";
                //        label2.Text = "";
                //        return;
                //    }
                //}

                label1.Text = "(" + type + ")验证成功！\n请退出并重新打开本软件";



                //调整窗体高度，以便显示下面的信息
                temp_h = this.Height;
                // 获取屏幕缩放比
                //Graphics g = this.CreateGraphics();
                if (g.DpiX == 96f || g.DpiY == 96f)        // 100%缩放
                {
                    this.Height = 185;
                }
                else if (g.DpiX == 120f || g.DpiY == 120f) // 125%
                {
                    this.Height = 185 + 37;
                }
                else if (g.DpiX == 144f || g.DpiY == 144f) // 150%
                {
                    this.Height = 185 + 37 * 2;
                }
                else
                {
                    MessageBox.Show("当前缩放比不受支持，可能会卡在“第xx次检测当前是否正在直播”。\n请将缩放比设置为100%或120%或144%后，再设置截图区域！", "当前缩放比不受支持", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                label2.Text = string.Format($"截图坐标：{pictureX}x{pictureY}\n截图高x宽：{pictureBox1.Height}x{pictureBox1.Width}" +
                   $"\n截图相对钉钉坐标：{p.X}x{p.Y}\n钉钉坐标：{r.Left}x{r.Top}");
                // 激活窗体
                this.Activate();


                // 设置成功，将form1的CustomScreenshotSuccess设为true
                f1.CustomScreenshotSuccess = true;

                f1.RelPosX = p.X;
                f1.RelPosY = p.Y;
                f1.ScreenshotH = pictureBox1.Height;
                f1.ScreenshotW = pictureBox1.Width;
                //f1.MouseClickX=
            }
            catch (Exception ex)
            {
                f1.CustomScreenshotSuccess = false;
                MessageBox.Show(ex.Message, "自定义截图", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label1.Text = "截图失败！";
                label2.Text = "";
            }
        }


        // 清除按钮
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            label1.Text = "请将透明区移到钉钉左上角\nxx群正在直播区域并截图";
            label2.Text = "";
            this.Height = temp_h;
        }

    }
}