using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自动进入钉钉直播间
{
    class ScreenCapture
    {

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
            Bitmap bmp = new Bitmap(width, height);//得到要截取的区域大小
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(new Point(x, y), new Point(0, 0), bmp.Size);
            g.Dispose();//释放资源
            return bmp;
        }


        /// <summary>
        /// 判断图片rgb是否是钉钉正在直播时的rgb
        /// </summary>
        /// <param name="bit"></param>
        /// <returns></returns>
        public static bool GetPixel(Bitmap bit)
        {
            Color c;
            Color c1 = Color.FromArgb(255, 148, 62);
            Color c2 = Color.FromArgb(255, 148, 99);
            Color c3 = Color.FromArgb(255, 185, 132);
            Color c4 = Color.FromArgb(255, 167, 62);

            //遍历图片像素点，判断颜色是否正确
            for (int x = 0; x < bit.Width; x++)
            {
                for (int y = 0; y < bit.Height; y++)
                {
                    c = bit.GetPixel(x, y);//获取一个像素点的颜色
                    if (c == c1 || c == c2 | c == c3 || c == c4)
                        return true;
                }
            }
            return false;
        }

        public static bool GetPixel(Bitmap bit, out int X, out int Y)
        {
            Color c;
            Color c1 = Color.FromArgb(255, 148, 62);
            Color c2 = Color.FromArgb(255, 148, 99);
            Color c3 = Color.FromArgb(255, 185, 132);
            Color c4 = Color.FromArgb(255, 167, 62);
            int x = 0, y = 0;

            //遍历图片像素点，判断颜色是否正确
            for (; x < bit.Width; x++)
            {
                for (; y < bit.Height; y++)
                {
                    c = bit.GetPixel(x, y);//获取一个像素点的颜色
                    if (c == c1 || c == c2 | c == c3 || c == c4)
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
    }

}
