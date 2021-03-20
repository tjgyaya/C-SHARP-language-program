using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 翻译神器
{
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
        }


        private Point startPos;          // 起始点位置
        private Rectangle selectedArea;  // 选择的区域大小坐标 
        private Image screenImage;   // 截取的全屏图像

        // 要截图的目标窗口句柄
        public IntPtr WindowHandle { get; set; }   
        // 截图完成后的图像
        public Image CaptureImage { get; private set; }
        // 鼠标左键按下时的坐标
        public Point StartPos
        {
            get { return startPos; }
            private set { startPos = value; }
        }
        // 选取的矩形
        public Rectangle SelectedArea
        {
            get { return selectedArea; }
            private set { selectedArea = value; }
        }


        private void FrmScreenShot_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                Cancel();
        }


        private void FrmScreenShot_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
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
            startPos = e.Location; // 获取鼠标起点位置
        }


        // 把选择的框框的大小坐标记录下来，并绘制选择的框框
        private void FrmScreenShot_MouseMove(object sender, MouseEventArgs e)
        {
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

            g.DrawImage(this.screenImage, this.selectedArea, this.selectedArea, GraphicsUnit.Pixel);
            g.DrawRectangle(Pens.DodgerBlue, this.selectedArea.Left, this.selectedArea.Top, this.selectedArea.Width - 1, this.selectedArea.Height - 1);
            string showText;
            if (WindowHandle != IntPtr.Zero)
            {
                Api.POINT p = new Api.POINT();
                p.X = this.selectedArea.Left;
                p.Y = this.selectedArea.Top;

                // 屏幕坐标转为客户端窗口坐标
                Api.ScreenToClient(WindowHandle, ref p);
                showText = string.Format($"按住鼠标左键选取要截取的区域\n按鼠标右键或ESC取消\nX相对坐标:{p.X} Y相对坐标:{p.Y}  宽:{this.selectedArea.Width} 高:{this.selectedArea.Height}");
            }
            else
                showText = string.Format($"按住鼠标左键选取要截取的区域\n按鼠标右键或ESC取消\nX坐标:{this.selectedArea.Left} Y坐标:{this.selectedArea.Top}  宽:{this.selectedArea.Width} 高:{this.selectedArea.Height}");
            // 测量显示字体需要的尺寸
            Size sizeRequired = g.MeasureString(showText, font).ToSize();
            // 显示字体的坐标
            Point displayPos = new Point(this.selectedArea.Left, this.selectedArea.Top - sizeRequired.Height - 5);

            if (displayPos.Y < 0)
                displayPos.Y = this.selectedArea.Top + 5;

            if (displayPos.X + sizeRequired.Width > this.Width)
                displayPos.X = this.Width - sizeRequired.Width;

            if (displayPos.X == 0)
                displayPos.X = 5;

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
                Bitmap bmpImage = new Bitmap(screenImage);
                using (Bitmap bmp = bmpImage.Clone(area, bmpImage.PixelFormat))
                    CaptureImage = (Image)bmp.Clone();

                bmpImage.Dispose();
            }
            this.Close();
            this.DialogResult = DialogResult.OK;
        }


        // 拷贝整个屏幕
        public void CopyScreen()
        {
            // 创建一个和屏幕一样大的空白图片
            Bitmap bmp = new Bitmap(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // 把屏幕图片拷贝到创建的空白图片中
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height));
                screenImage = bmp;
            }
        }
    }
}
