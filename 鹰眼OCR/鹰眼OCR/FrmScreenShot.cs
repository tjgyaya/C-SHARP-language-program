using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 鹰眼OCR
{
    /// <summary>
    /// 截图窗体
    /// </summary>
    public partial class FrmScreenShot : Form
    {
        public FrmScreenShot()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除窗口背景  
            SetStyle(ControlStyles.DoubleBuffer, true);         // 双缓冲

            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.Cursor = Cursors.Cross;
            InitializeComponent();

            // 拷贝全屏图像
            screenImage = CopyScreen();
        }


        private Point _StartPos;          // 起始点位置
        private Rectangle _SelectedArea;  // 选择的区域大小坐标
        private Image screenImage;        // 截图完成后的图像
        private Image _CaptureImage;

        /// <summary>
        /// 要截取的目标窗口句柄
        /// </summary>
        public IntPtr WindowHandle { get; set; }

        /// <summary>
        /// 获取目标图像（截图完成选取的图像）
        /// </summary>
        public Image CaptureImage
        {
            get
            {
                if (_CaptureImage == null)
                    throw new Exception("截图失败！");
                else
                    return _CaptureImage;
            }
        }

        /// <summary>
        /// 是否释放资源
        /// </summary>
        public bool IsMyDisposed { get; private set; }

        /// <summary>
        /// 获取鼠标左键按下时的坐标（截图开始时的坐标）
        /// </summary>
        public Point StartPos
        {
            get { return _StartPos; }
            private set { _StartPos = value; }
        }

        /// <summary>
        /// 获取选取的矩形（坐标、大小）
        /// </summary>
        public Rectangle SelectedArea
        {
            get { return _SelectedArea; }
            private set { _SelectedArea = value; }
        }


        private void FrmScreenShot_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                Cancel();
        }


        private void FrmScreenShot_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Cancel();
        }


        private void Cancel()
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        // 开始截图
        private void FrmScreenShot_MouseDown(object sender, MouseEventArgs e)
        {
            _StartPos = e.Location; // 获取鼠标起点位置
        }


        // 把选择的框框的大小坐标记录下来，并绘制选择的框框
        private void FrmScreenShot_MouseMove(object sender, MouseEventArgs e)
        {
            if (screenImage == null)
                Cancel();

            if (e.Button == MouseButtons.Left)
            {
                _SelectedArea.X = e.Location.X > _StartPos.X ? _StartPos.X : e.Location.X;
                _SelectedArea.Y = e.Location.Y > _StartPos.Y ? _StartPos.Y : e.Location.Y;
                _SelectedArea.Width = Math.Abs(e.Location.X - _StartPos.X);
                _SelectedArea.Height = Math.Abs(e.Location.Y - _StartPos.Y);
                this.Invalidate();  // 使窗口重绘引发Paint事件
            }
        }

        private void FrmScreenShot_Paint(object sender, PaintEventArgs e)
        {
            if (screenImage == null)
                Cancel();
            // 将原图显示到窗体
            e.Graphics.DrawImage(this.screenImage, 0, 0, this.screenImage.Width, this.screenImage.Height);
            using (SolidBrush sb = new SolidBrush(Color.FromArgb(50, 0, 0, 0)))
            {
                // 对窗体显示的图片进行灰度处理
                e.Graphics.FillRectangle(sb, this.ClientRectangle);
            }
            // 绘制选择的框框
            DrawSelectionBox(e.Graphics);
        }


        // 绘制选择的框框
        private void DrawSelectionBox(Graphics g)
        {
            Font font = new Font("微软雅黑", 12f);

            g.DrawImage(this.screenImage, this._SelectedArea, this._SelectedArea, GraphicsUnit.Pixel);
            g.DrawRectangle(Pens.DodgerBlue, this._SelectedArea.Left, this._SelectedArea.Top, this._SelectedArea.Width - 1, this._SelectedArea.Height - 1);
            string showText;
            if (WindowHandle != IntPtr.Zero)
            {
                Api.POINT p = new Api.POINT(this._SelectedArea.Left, this._SelectedArea.Top);
                // 屏幕坐标转为客户端窗口坐标
                Api.ScreenToClient(WindowHandle, ref p);
                showText = string.Format($"按住鼠标左键选取要截取的区域\n按鼠标右键或ESC取消\nX相对坐标:{p.X} Y相对坐标:{p.Y}  宽:{this._SelectedArea.Width} 高:{this._SelectedArea.Height}");
            }
            else
                showText = string.Format($"按住鼠标左键选取要截取的区域\n按鼠标右键或ESC取消\nX坐标:{this._SelectedArea.Left} Y坐标:{this._SelectedArea.Top}  宽:{this._SelectedArea.Width} 高:{this._SelectedArea.Height}");
            // 测量显示字体需要的尺寸
            Size sizeRequired = g.MeasureString(showText, font).ToSize();
            // 显示字体的坐标
            Point displayPos = new Point(this._SelectedArea.Left, this._SelectedArea.Top - sizeRequired.Height - 5);

            if (displayPos.Y < 0)
                displayPos.Y = this._SelectedArea.Top + 5;

            if (displayPos.X + sizeRequired.Width > this.Width)
                displayPos.X = this.Width - sizeRequired.Width;

            if (displayPos.X == 0)
                displayPos.X = 5;

            // 在指定坐标绘制字体
            using (SolidBrush Brush = new SolidBrush(Color.FromArgb(125, 0, 0, 0)))
            {
                // 在矩形内部填充半透明橙色
                g.FillRectangle(Brush, new Rectangle(displayPos, sizeRequired));
                // 绘制字体
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

            Rectangle area = new Rectangle(_SelectedArea.X, _SelectedArea.Y, _SelectedArea.Width, _SelectedArea.Height);
            if (area.Height > 0 && area.Width > 0) // 宽度和高度必须大于零
            {
                using (Bitmap bmpImage = new Bitmap(screenImage))
                {
                    using (Bitmap bmp = bmpImage.Clone(area, bmpImage.PixelFormat))
                        _CaptureImage = (Image)bmp.Clone();
                }
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
        }


        // 拷贝整个屏幕
        public Image CopyScreen()
        {
            // 创建一个和屏幕一样大的空白图片
            using (Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    // 把屏幕图片拷贝到创建的空白图片中
                    g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height));
                    return (Bitmap)bmp.Clone();
                }
            }
        }

        public void MyDispose()
        {
            try
            {
                if (IsMyDisposed)
                    return;

                if (screenImage != null)
                    screenImage.Dispose();
                if (_CaptureImage != null)
                    _CaptureImage.Dispose();
                WindowHandle = IntPtr.Zero;
                if (!this.IsDisposed)
                {
                    this.Close();
                    this.Dispose();
                }
            }
            finally
            {
                IsMyDisposed = true;
            }
        }

        private void FrmScreenShot_Shown(object sender, EventArgs e)
        {
            this.Activate();
        }
    }
}
