using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 截图翻译
{
    public partial class FrmScreenShot : Form
    {
        // **************************************截图窗口**************************************
        public FrmScreenShot(string save_path, bool isScreen)
        {
            InitializeComponent();

            if (!isScreen)
                return;

            savePath = save_path;

            // 设置窗体为无边框模式
            this.FormBorderStyle = FormBorderStyle.None;
            // 设置窗体显示的坐标
            this.Location = new Point(0, 0);
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            // 不在任务栏显示
            this.ShowInTaskbar = false;

            // 将窗体显示在最顶层
            this.TopMost = true;
            label_init_point = label1.Location;
        }


        // 鼠标按下左键时的坐标
        public Point MouseDownPoint { get; private set; }

        // 选取的矩形高度（截图高度）
        public int ScreenHeight { get; private set; }

        // 选取的矩形宽度
        public int ScreenWidth { get; private set; }


        private Bitmap screenBmp;      // 保存截取的全屏图像
        private Point screen_point;    // 鼠标左键松开时截图的坐标
        private Point label_init_point;// 保存label控件初始的坐标 
        private string savePath;       // 截图后保存图片的路径
        private bool mouse_down;       // 鼠标是否按下
        private bool left = true;      // label控件显示在屏幕上的位置（true显示在左边，false显示在右边）
        private List<object> objectList = new List<object>();// 保存被释放的对象

        private void ScreenShot_Load(object sender, EventArgs e)
        {
            // 截取屏幕内容
            screenBmp = CaptureFullScreen();
            // 将截取的屏幕内容显示到pictureBox
            pictureBox1.Image = (Bitmap)screenBmp.Clone();

            //Graphics g = Graphics.FromImage(pictureBox1.Image);
            //// 创建一个画笔
            //SolidBrush brush = new SolidBrush(Color.FromArgb(80, 0, 0, 0));
            //try
            //{
            //    // 用半透明黑色填充矩形区域（窗体）
            //    g.FillRectangle(brush, 0, 0, pictureBox1.Width, pictureBox1.Height);
            //}
            //finally
            //{
            //    brush.Dispose();
            //    g.Dispose();
            //}
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // 鼠标右键点击，退出截图
            if (e.Button == MouseButtons.Right)
                Exit();
        }


        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Exit();
        }


        private void Exit()
        {
            try
            {
                if (File.Exists(savePath))
                    File.Delete(savePath);
            }
            finally
            {
                this.DialogResult = DialogResult.Cancel;
                CloseForm();
            }
        }


        private void CloseForm()
        {
            MyDispose(pictureBox1.Image);
            MyDispose(screenBmp);
            this.Close();
        }


        // 当鼠标左键在窗体上按下时开始画矩形
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (!mouse_down)
            {
                mouse_down = true;
                MouseDownPoint = new Point(e.X, e.Y);// 记录鼠标按下时的坐标
            }
        }


        // 鼠标移动时绘制矩形区域
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            ChangePoint(MousePosition.X, MousePosition.Y);

            // 判断截图是否开始（鼠标左键按下即视为截图开始）
            if (!mouse_down)
                return;

            Bitmap newBmp = (Bitmap)screenBmp.Clone();
            // 新建画板和笔
            Graphics g = pictureBox1.CreateGraphics();
            Pen p = new Pen(Color.DeepSkyBlue, 2);
            try
            {
                // 清空画布
                pictureBox1.Refresh();


                // 获取矩形的长度（鼠标拖动时的坐标 - 鼠标左键按下时的坐标）
                ScreenWidth = Math.Abs(MousePosition.X - MouseDownPoint.X);
                ScreenHeight = Math.Abs(MousePosition.Y - MouseDownPoint.Y);

                // 如果是从右往左拖动或从下往上拖动
                screen_point.X = Math.Min(MousePosition.X, MouseDownPoint.X);
                screen_point.Y = Math.Min(MousePosition.Y, MouseDownPoint.Y);


                g.DrawRectangle(p, screen_point.X, screen_point.Y, ScreenWidth, ScreenHeight);
                g.Dispose();
                // 从当前窗体创建新的画板，防止闪烁（闪瞎眼的那种）
                g = this.CreateGraphics();
                g.DrawImage(newBmp, new Point(0, 0));
            }
            finally
            {
                // 释放资源
                g.Dispose();
                p.Dispose();
                p.Dispose();
                newBmp.Dispose();
            }
        }


        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            ChangePoint(MousePosition.X, MousePosition.Y);
        }


        // 改变label控件显示的位置
        private void ChangePoint(int mouse_x, int mouse_y)
        {
            if (mouse_x >= label1.Location.X && mouse_x <= (label1.Location.X + label1.Width) && mouse_y >= label1.Location.Y && mouse_y <= (label1.Location.Y + label1.Height))
            {
                if (left)
                {
                    label1.Location = new Point(this.Width - label1.Width - label_init_point.X, label1.Location.Y);
                    left = false;
                }
                else
                {
                    label1.Location = new Point(label_init_point.X, label1.Location.Y);
                    left = true;

                }
            }

            //label1.Text = string.Format($"鼠标坐标:{mouse_x}x{mouse_y}\n控件坐标：{label1.Location.X}x{label1.Location.Y}");

        }


        // 鼠标左键弹起时截取矩形图片
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // 如果弹起的不是鼠标左键或截图未开始
            if (e.Button != MouseButtons.Left || !mouse_down)
                return;

            Bitmap bmp = new Bitmap(ScreenWidth, ScreenHeight);
            Graphics g = Graphics.FromImage(bmp);
            Rectangle srcRect = new Rectangle(screen_point.X, screen_point.Y, ScreenWidth + 1, ScreenHeight + 1);
            Rectangle destRect = new Rectangle(0, 0, ScreenWidth + 1, ScreenHeight + 1);

            try
            {
                // 质量设为最高
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(screenBmp, destRect, srcRect, GraphicsUnit.Pixel);                 // 把选取的矩形区域绘制到空白位图上   
                bmp.Save(savePath, System.Drawing.Imaging.ImageFormat.Bmp);                    // 保存
            }
            finally
            {
                this.DialogResult = DialogResult.OK;
                // 释放资源
                MyDispose(g);
                MyDispose(bmp);
                CloseForm();
            }
            mouse_down = false;
        }


        private void MyDispose<T>(T target) where T : IDisposable
        {
            if (target != null)
            {
                if (!objectList.Contains(target))// 确保要释放的对象不在列表中，避免释放多次
                {
                    target.Dispose();
                    objectList.Add(target);// 将每一个释放了资源的对象存到列表中
                }
            }
        }


        /// <summary>
        /// 捕获全屏内容
        /// </summary>
        /// <returns></returns>
        public Bitmap CaptureFullScreen()
        {
            // 设置位图大小为当前屏幕大小
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, bmp.Size);   // 截取全屏幕
            }
            return bmp;
        }
    }
}
