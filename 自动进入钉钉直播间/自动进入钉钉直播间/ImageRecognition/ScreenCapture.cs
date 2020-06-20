using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace 自动进入钉钉直播间
{
    class ScreenCapture
    {
        [DllImport("user32.dll")]
        private extern static IntPtr GetDC(IntPtr ptr);
        [DllImport("gdi32.dll")]
        private extern static int GetDeviceCaps(IntPtr hdc, int nIndex);
        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        private extern static IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);

        const int HORZRES = 8;
        const int VERTRES = 10;
        const int DESKTOPVERTRES = 117;
        const int DESKTOPHORZRES = 118;


        /// <summary>  
        /// 获取宽度缩放百分比  
        /// </summary>  
        public static float ScaleX()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            float scaleX = GetDeviceCaps(hdc, DESKTOPHORZRES) / GetDeviceCaps(hdc, HORZRES);
            ReleaseDC(IntPtr.Zero, hdc);
            return scaleX;
        }

        /// <summary>  
        /// 获取高度缩放百分比  
        /// </summary>  
        public static float ScaleY()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            float ScaleY = GetDeviceCaps(hdc, DESKTOPVERTRES) / GetDeviceCaps(hdc, VERTRES);
            ReleaseDC(IntPtr.Zero, hdc);
            return ScaleY;
        }

        /// <summary>
        /// 从指定坐标截取指定大小
        /// </summary>
        /// <param name="x">左上角横坐标</param>
        /// <param name="y">左上角纵坐标</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public static Bitmap Screenshot(int x, int y, int width, int height)
        {
            float scaleY = ScaleY();
            float scaleX = ScaleX();

            Bitmap bit = new Bitmap((int)(width * scaleY), (int)(height * scaleY));
            Graphics g = Graphics.FromImage(bit);
            g.CompositingQuality = CompositingQuality.HighQuality;// 质量设为最高
            g.CopyFromScreen((int)(x * scaleX), (int)(y * scaleY), 0, 0, new Size((int)(width * scaleX), (int)(height * scaleY)));
            return bit;
        }



        // 令人丧心病狂的RGB数据
        private static int[] Argbs = {
            Color.FromArgb(255, 148, 62).ToArgb(), Color.FromArgb(255, 148, 99).ToArgb(),
            Color.FromArgb(255, 185, 132).ToArgb(), Color.FromArgb(255, 167, 62).ToArgb(),
            Color.FromArgb(255, 201, 158).ToArgb(), Color.FromArgb(255, 162, 103).ToArgb(),
            Color.FromArgb(255, 184, 145).ToArgb(), Color.FromArgb(255, 203, 162).ToArgb(),
            Color.FromArgb(255, 179, 121).ToArgb(), Color.FromArgb(255, 175, 123).ToArgb(),
            Color.FromArgb(255, 201, 144).ToArgb() , Color.FromArgb(255, 175, 128).ToArgb(),
            Color.FromArgb(255, 211, 162).ToArgb(), Color.FromArgb(255, 193, 177).ToArgb(),
            Color.FromArgb(255, 202, 177).ToArgb(), Color.FromArgb(255, 203, 99).ToArgb()
        };


        /// <summary>
        /// 判断图片中的rgb是否含有钉钉正在直播时的rgb
        /// </summary>
        /// <param name="bit"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static bool Is_LiveRgb(Bitmap bit, out int X, out int Y)
        {
            int x = 0, y = 0, c;

            // 判断是否有自定义颜色文件
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
            FileInfo[] files = dir.GetFiles("*.txt");// 查找目录下时txt的文件
            foreach (var f in files)
            {
                if (f.ToString().ToLower() == "color.txt")
                {
                    if (File_Is_LiveRgb(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "color.txt", bit, out x, out y) == true)
                    {
                        X = x;
                        Y = y;
                        return true;
                    }
                }
            }

            // 遍历图片像素点，判断颜色是否正确
            for (x = 0; x < bit.Width; x++)
            {
                for (y = 0; y < bit.Height; y++)
                {
                    c = bit.GetPixel(x, y).ToArgb();// 获取一个像素点的颜色
                    if (Array.IndexOf(Argbs, c) != -1)
                    {
                        X = x;
                        Y = y;
                        return true;
                    }
                }
            }
            X = x;
            Y = y;
            return false;
        }

        private static bool File_Is_LiveRgb(string path, Bitmap bit, out int X, out int Y)
        {
            int x = 0, y = 0;

            StreamReader sr = new StreamReader(path);
            string str;

            try
            {
                while ((str = sr.ReadLine()) != null)// 读取一行
                {
                    // 遍历图片像素点，判断是否有与之匹配的RGB数据
                    for (y = 0; y < bit.Height; y++)
                    {
                        for (x = 0; x < bit.Width; x++)
                        {
                            // 获取一个像素点的RGB
                            if (bit.GetPixel(x, y).ToArgb() == ColorTranslator.FromHtml(str).ToArgb())
                            {
                                X = x;
                                Y = y;
                                return true;
                            }
                        }
                    }
                }
                X = x;
                Y = y;
                return false;
            }
            catch
            {
                X = x;
                Y = y;
                return false;
            }
        }
    }
}
