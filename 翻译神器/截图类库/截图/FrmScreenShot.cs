using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScreenShot
{
    /// <summary>
    /// 截图类
    /// </summary>
    public partial class FrmScreenShot : Form
    {
        /// <summary>
        /// 截图完成委托
        /// </summary>
        /// <param name="img"></param>
        public delegate void CapturedDelegate(Image img);
        /// <summary>
        /// 截图完成事件
        /// </summary>
        public event CapturedDelegate CapturedEvent;

        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmScreenShot()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除窗口背景  
            SetStyle(ControlStyles.DoubleBuffer, true);         // 双缓冲
            this.Cursor = Cursors.Cross;
            InitializeComponent();
        }

        private Point startPos;          // 起始点位置
        private Rectangle selectedArea;  // 选择的区域大小坐标 
        private Image screenImage;       // 截取的全屏图像
        private IntPtr windowHandle;     // 要截图的目标窗口句柄

        /// <summary>
        /// 截图完成后的图像
        /// </summary>
        public Image CaptureImage { get; private set; }

        /// <summary>
        /// 选取的矩形大小和坐标（截图大小和坐标）
        /// </summary>
        public Rectangle SelectedArea
        {
            get { return selectedArea; }
            private set { selectedArea = value; }
        }

        /// <summary>
        /// 开始截图
        /// </summary> 
        public DialogResult Start(IntPtr windowHandle = default)
        {
            this.windowHandle = windowHandle;
            if (windowHandle != IntPtr.Zero)
            {
                GetWindowRect(out Size size, out Point point);
                screenImage = CopyScreen(point.X, point.Y, size.Width, size.Height);
            }
            else
                screenImage = CopyScreen();
            return this.ShowDialog();
        }

        // 通过窗体句柄获取窗体大小和坐标
        private void GetWindowRect(out Size size, out Point point)
        {
            bool result = Api.GetWindowRect(windowHandle, out Api.TagRECT rect);
            if (!result)
                throw new Exception("无法获取窗口大小和坐标信息！");
            size = new Size(rect.right - rect.left, rect.bottom - rect.top);
            point = new Point(rect.left, rect.top);
        }

        // 设置窗口大小
        private void FrmScreenShot_Load(object sender, EventArgs e)
        {
            if (windowHandle != IntPtr.Zero)
            {
                GetWindowRect(out Size size, out Point point);
                this.Size = size;
                this.Location = point;
            }
            else
                this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
        }

        // 鼠标右键按下退出截图
        private void FrmScreenShot_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                Cancel();
        }

        // 按下esc键退出截图
        private void FrmScreenShot_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
                Cancel();
        }

        // 取消截图
        private void Cancel()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // 开始截图
        private void FrmScreenShot_MouseDown(object sender, MouseEventArgs e) => startPos = e.Location; // 获取鼠标起点位置

        // 把选择的矩形的大小坐标记录下来，并绘制选择的矩形
        private void FrmScreenShot_MouseMove(object sender, MouseEventArgs e)
        {
            LockMouseMove();
            if (screenImage == null)
                Cancel();
            if (e.Button == MouseButtons.Left)
            {
                selectedArea.X = e.Location.X > startPos.X ? startPos.X : e.Location.X;
                selectedArea.Y = e.Location.Y > startPos.Y ? startPos.Y : e.Location.Y;
                selectedArea.Width = Math.Abs(e.Location.X - startPos.X);
                selectedArea.Height = Math.Abs(e.Location.Y - startPos.Y);
                this.Invalidate();  // 使窗口重绘引发Paint事件
            }
        }

        // 锁定鼠标光标
        private void LockMouseMove()
        {
            Cursor.Clip = new Rectangle(new Point(this.Location.X, this.Location.Y), new Size(this.Width, this.Height));
        }

        // 窗体重绘事件
        private void FrmScreenShot_Paint(object sender, PaintEventArgs e)
        {
            if (screenImage == null)
                Cancel();
            // 将原图显示到窗体
            e.Graphics.DrawImage(this.screenImage, 0, 0, this.screenImage.Width, this.screenImage.Height);
            using (SolidBrush sb = new SolidBrush(Color.FromArgb(100, 0, 0, 0)))
                e.Graphics.FillRectangle(sb, this.ClientRectangle); // 对窗体显示的图片进行灰度处理
                                                                    // 绘制选择的矩形
            DrawLargeRect(e.Graphics);
        }

        // 绘制四周的小矩形
        private void DrawSmallRect(Graphics g)
        {
            RectangleF[] rects = new RectangleF[]// 四周的小矩形参数
                {
                    new RectangleF(selectedArea.Left - 2.5F, selectedArea.Top - 2.5F, 5, 5),// 左上角小矩形
                    new RectangleF(selectedArea.Right / 2F + selectedArea.Left / 2F - 2.5F, selectedArea.Top - 2.5F, 5, 5),// 顶部中间小矩形
                    new RectangleF(selectedArea.Right - 2.5F, selectedArea.Top - 2.5F, 5, 5), // 右上角小矩形
                    new RectangleF(selectedArea.Right - 2.5F, selectedArea.Bottom / 2F + selectedArea.Top / 2F - 2.5F, 5, 5),
                    new RectangleF(selectedArea.Right - 2.5F, selectedArea.Bottom - 2.5F, 5, 5),
                    new RectangleF(selectedArea.Right / 2F + selectedArea.Left / 2F - 2.5F, selectedArea.Bottom - 2.5F, 5, 5),
                    new RectangleF(selectedArea.Left - 2.5F, selectedArea.Bottom - 2.5F, 5, 5),
                    new RectangleF(selectedArea.Left - 2.5F, selectedArea.Bottom / 2F + selectedArea.Top / 2F - 2.5F, 5, 5)
                };
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(30, 144, 255)))
            {
                for (int i = 0; i < rects.Length; i++)
                {
                    g.FillRectangle(brush, rects[i]);
                    g.DrawRectangle(Pens.DodgerBlue, rects[i].X, rects[i].Y, rects[i].Width, rects[i].Height);
                }
            }
        }

        // 获取坐标大小等信息
        private string GetInfo()
        {
            // 不是相对坐标截图
            if (windowHandle == IntPtr.Zero)
                return string.Format($"按鼠标右键或ESC取消\n起始坐标:{this.startPos.X},{this.startPos.Y} 鼠标坐标:{MousePosition.X},{MousePosition.Y}\n截图大小:{this.selectedArea.Width}x{this.selectedArea.Height}");
            // 是相对坐标截图
            Point mousePoint = new Point(MousePosition.X, MousePosition.Y);
            // 屏幕坐标转为客户端窗口坐标
            mousePoint = this.PointToClient(mousePoint);
            return string.Format($"按鼠标右键或ESC取消\n起始坐标(相对):{this.startPos.X},{this.startPos.Y} 鼠标坐标(相对):{mousePoint.X},{mousePoint.Y}\n截图大小:{this.selectedArea.Width}x{this.selectedArea.Height}");
        }

        // 绘制大矩形
        private void DrawLargeRect(Graphics g)
        {
            Font font = new Font("微软雅黑", 10f);
            g.DrawImage(this.screenImage, this.selectedArea, this.selectedArea, GraphicsUnit.Pixel);
            g.DrawRectangle(Pens.DodgerBlue, this.selectedArea.Left, this.selectedArea.Top, this.selectedArea.Width - 1, this.selectedArea.Height - 1);
            // 绘制四周的小矩形
            DrawSmallRect(g);
            // 绘制文字
            string showText = GetInfo();
            // 测量显示字体需要的尺寸
            Size sizeRequired = g.MeasureString(showText, font).ToSize();
            // 字体的坐标
            Point displayPos = new Point(this.selectedArea.Left, this.selectedArea.Top - sizeRequired.Height - 5);
            displayPos.Y = (displayPos.Y <= 0) ? 5 : displayPos.Y;
            displayPos.X = (displayPos.X + sizeRequired.Width > this.Width) ? this.Width - sizeRequired.Width : displayPos.X;
            displayPos.X = (displayPos.X <= 0) ? 5 : displayPos.X;
            // 在指定坐标绘制字体
            using (SolidBrush Brush = new SolidBrush(Color.FromArgb(125, 0, 0, 0)))
            {
                // 在矩形内部填充半透明黑色
                g.FillRectangle(Brush, new Rectangle(displayPos, sizeRequired));
                g.DrawString(showText, font, Brushes.Orange, displayPos);
            }
        }

        // 鼠标弹起，截图完成
        private void FrmScreenShot_MouseUp(object sender, MouseEventArgs e)
        {
            if (screenImage == null)
                Cancel();
            if (e.Button != MouseButtons.Left)
                return;
            // 使窗口的整个画面无效并重绘控件
            this.Invalidate();
            // 复制图片到剪切板
            Rectangle area = new Rectangle(selectedArea.X, selectedArea.Y, selectedArea.Width, selectedArea.Height);
            if (area.Height > 0 && area.Width > 0) // 宽度和高度必须大于零
            {
                using (Bitmap bmpImage = new Bitmap(screenImage))
                    CaptureImage = bmpImage.Clone(area, bmpImage.PixelFormat);
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
            OnCapturedEvent();
        }

        // 拷贝整个屏幕
        private Bitmap CopyScreen()
        {
            // 创建一个和屏幕一样大的空白图片
            Bitmap bmp = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            using (Graphics g = Graphics.FromImage(bmp)) // 把屏幕图片拷贝到创建的空白图片中
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height));
            return bmp;
        }

        // 拷贝部分屏幕
        private Bitmap CopyScreen(int x, int y, int w, int h)
        {
            // 创建一个和屏幕一样大的空白图片
            Bitmap bmp = new Bitmap(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
                g.CopyFromScreen(x, y, 0, 0, new Size(w, h));
            return bmp;
        }

        // 引发 截图完成 事件
        private void OnCapturedEvent()
        {
            CapturedEvent?.Invoke((Image)CaptureImage.Clone());
        }


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                screenImage?.Dispose();
                CaptureImage?.Dispose();
            }
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
