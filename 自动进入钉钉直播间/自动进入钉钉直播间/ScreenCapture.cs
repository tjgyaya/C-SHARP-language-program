using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
            Bitmap image = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(image);
            g.CopyFromScreen(new Point(x, y), new Point(0, 0), new Size(width, height));
            g.Dispose();//释放资源
            return image;
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
            int x = 0, y = 0;

            //判断是否有自定义颜色文件
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
            FileInfo[] files = dir.GetFiles("*.txt");//查找目录下时txt的文件
            foreach (var f in files)
            {
                if (f.ToString().ToLower() == "color.txt")
                {
                    if (File_GetPixel(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "color.txt", bit, out x, out y) == true)
                    {
                        X = x;
                        Y = y;
                        return true;
                    }
                }
            }


            Color c;
            Color c1 = Color.FromArgb(255, 148, 62);
            Color c2 = Color.FromArgb(255, 148, 99);
            Color c3 = Color.FromArgb(255, 185, 132);
            Color c4 = Color.FromArgb(255, 167, 62);
            Color c5 = Color.FromArgb(255, 201, 158);
            Color c6 = Color.FromArgb(255, 188, 151);
            Color c7 = Color.FromArgb(255, 162, 103);
            Color c8 = Color.FromArgb(255, 184, 145);
            Color c9 = Color.FromArgb(255, 203, 162);
            Color c10 = Color.FromArgb(255, 179, 121);
            Color c11 = Color.FromArgb(255, 175, 123);
            Color c12 = Color.FromArgb(255, 201, 144);
            Color c13 = Color.FromArgb(255, 175, 128);
            Color c14 = Color.FromArgb(255, 211, 162);
            Color c15 = Color.FromArgb(255, 193, 177);
            Color c16 = Color.FromArgb(255, 202, 177);
            Color c17 = Color.FromArgb(255, 203, 99);




            //遍历图片像素点，判断颜色是否正确
            for (x = 0; x < bit.Width; x++)
            {
                for (y = 0; y < bit.Height; y++)
                {


                    c = bit.GetPixel(x, y);//获取一个像素点的颜色
                    if (c == c1 || c == c2 | c == c3 || c == c4 || c == c5 || c == c6 || c == c7 || c == c8 ||
                        c == c9 || c == c10 || c == c11 || c == c12 || c == c13 || c == c14 || c == c15 ||
                        c == c16 || c == c17)
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

        private static bool File_GetPixel(string path, Bitmap bit, out int X, out int Y)
        {
            int x = 0, y = 0;


            StreamReader sr = new StreamReader(path);
            string str;
            Color c;

            try
            {
                while ((str = sr.ReadLine()) != null)//读取一行
                {
                    //遍历图片像素点，判断颜色是否正确
                    for (y = 0; y < bit.Height; y++)
                    {
                        for (x = 0; x < bit.Width; x++)
                        {
                            c = bit.GetPixel(x, y);//获取一个像素点的颜色
                            if (c == ColorTranslator.FromHtml(str))
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
