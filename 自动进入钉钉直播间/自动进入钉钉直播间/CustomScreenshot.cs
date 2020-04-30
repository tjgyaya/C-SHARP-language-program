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
        private bool SaveDesktop;
        public CustomScreenshot(bool SaveDesk)
        {
            SaveDesktop = SaveDesk;
            InitializeComponent();
        }

        private string iniDirectory = Environment.GetEnvironmentVariable("APPDATA") + @"\自动进入钉钉直播间";
        private string iniPath = Environment.GetEnvironmentVariable("APPDATA") + @"\自动进入钉钉直播间\截图.ini";
        private int DingDingX, DingDingY, DingDingWidth, DingDingHeight, PictureX, PictureY, PictureWidth, PictureHeight;



        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out Rect lpRect);

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
            //设置窗口透明
            pictureBox1.BackColor = Color.Red;
            this.TransparencyKey = Color.Red;
            this.BackColor = Color.Red;

            string DingDingPath;
            string err = Reg.GetDingDingPath(out DingDingPath);//获取钉钉路径
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
                Process.Start(DingDingPath);//打开钉钉

                for (int i = 1; i <= 20; i++)//寻找钉钉进程
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
                    System.Threading.Thread.Sleep(3000);//如未找到则等待3秒再查找
                }

                ////查找钉钉窗口句柄
                //IntPtr hwnd = FindWindow(null, "钉钉");
                //if (hwnd == IntPtr.Zero)
                //{
                //    MessageBox.Show("获取钉钉窗口句柄失败，请以管理员权限运行");
                //    this.Close();
                //}
                ////获取钉钉窗口坐标
                //Rect re;
                //if (GetWindowRect(hwnd, out re) == 0)
                //{
                //    MessageBox.Show("获取钉钉窗口坐标失败！");
                //    return;
                //}

                //DingDingX = re.Left;
                //DingDingY = re.Top;
                //DingDingWidth = re.Right - re.Left;
                //DingDingHeight = re.Bottom - re.Top;
                //PictureWidth = pictureBox1.Width;
                //PictureHeight = pictureBox1.Height;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误\n原因：" + ex.Message, "自动进入钉钉直播间", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                pictureBox1.Image = null;

                Point point = PointToScreen(pictureBox1.Location);//将控件相对于窗体坐标转为相对于屏幕坐标
                PictureX = point.X;
                PictureY = point.Y;

                //截取指定区域并显示到pictureBox1
                pictureBox1.Image = ScreenCapture.Screenshot(PictureX, PictureY, pictureBox1.Width, pictureBox1.Height);

                if (SaveDesktop)
                    pictureBox1.Image.Save(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\自动进入钉钉直播间" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);


                //判断图片rgb颜色是否是钉钉正在直播时的rgb
                if (ScreenCapture.GetPixel((Bitmap)pictureBox1.Image) != true)///////////////////////
                {
                    label1.Text = "验证失败！";
                    label2.Text = "";
                    return;
                }


                label1.Text = "验证成功！\n请退出并重新打开本软件";

                //查找钉钉窗口句柄
                IntPtr hwnd = FindWindow(null, "钉钉");
                if (hwnd == IntPtr.Zero)
                {
                    MessageBox.Show("获取钉钉窗口句柄失败！");
                    return;
                }

                //激活显示钉钉窗口
                SetForegroundWindow(hwnd);

                //获取钉钉窗口坐标
                Rect re;
                if (GetWindowRect(hwnd, out re) == 0)
                {
                    MessageBox.Show("获取钉钉窗口坐标失败！");
                    return;
                }

                DingDingX = re.Left;
                DingDingY = re.Top;
                DingDingWidth = re.Right - re.Left;
                DingDingHeight = re.Bottom - re.Top;
                PictureWidth = pictureBox1.Width;
                PictureHeight = pictureBox1.Height;

                this.Height = 185;

                label2.Text = string.Format($"图片左上角坐标：{PictureX}x{PictureY}\n图片高x宽：{PictureHeight}x{PictureWidth}\n" +
                   $"钉钉左上角坐标：{DingDingX}x{DingDingY}\n钉钉高x宽：{DingDingHeight}x{DingDingWidth}");

                this.Activate();

                if (!Directory.Exists(iniDirectory))
                    Directory.CreateDirectory(iniDirectory);

                //写入配置文件
                string err = ConfigFile.ScreenWriteFile(DingDingX, DingDingY, DingDingWidth, DingDingHeight,
                    PictureX, PictureY, PictureWidth, PictureHeight, iniPath);
                if (err != null)
                    MessageBox.Show("写入配置文件错误\n原因：" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                label1.Text = "截图失败！";
                label2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            label1.Text = "请将透明区移到钉钉左上角\nxx群正在直播区域并截图";
            label2.Text = "";
            this.Height = 130;
        }
    }
}