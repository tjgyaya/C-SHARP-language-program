using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace 自动进入钉钉直播
{
    class ScreenCapture
    {
        static ScreenCapture()
        {
            // 读取自定义颜色文件
            string rgbPath = Application.StartupPath + "\\color.txt";
            ReadFile(rgbPath);
        }
        private static List<Color> rgbList = new List<Color>();// 从文件读取的rgb数据

        // 令人丧心病狂的RGB数据
        private static readonly Color[] Argbs = {
            Color.FromArgb(255, 148, 62), Color.FromArgb(255, 148, 99),
            Color.FromArgb(255, 185, 132), Color.FromArgb(255, 167, 62),
            Color.FromArgb(255, 201, 158), Color.FromArgb(255, 162, 103),
            Color.FromArgb(255, 184, 145), Color.FromArgb(255, 203, 162),
            Color.FromArgb(255, 179, 121), Color.FromArgb(255, 175, 123),
            Color.FromArgb(255, 201, 144) , Color.FromArgb(255, 175, 128),
            Color.FromArgb(255, 211, 162), Color.FromArgb(255, 193, 177),
            Color.FromArgb(255, 202, 177), Color.FromArgb(255, 203, 99)
        };

        /// <summary>
        /// 从指定坐标截取指定大小区域
        /// </summary>
        public static Bitmap Screenshot(Rectangle rect)
        {
            Bitmap bit = new Bitmap(rect.Width, rect.Height);
            using (Graphics g = Graphics.FromImage(bit))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;// 质量设为最高
                g.CopyFromScreen(rect.Location, Point.Empty, rect.Size);
            }
            return bit;
        }

        /// <summary>
        /// 判断图片中的rgb是否含有钉钉正在直播时的rgb
        /// </summary>
        /// <param name="bit"></param>
        /// <returns></returns>
        public static bool Is_LiveRgb(Bitmap bit)
        {
            Color c;
            // 遍历图片像素点，判断颜色是否正确
            for (int x = 0; x < bit.Width; x++)
            {
                for (int y = 0; y < bit.Height; y++)
                {
                    c = bit.GetPixel(x, y);// 获取一个像素点的颜色
                    if (Array.IndexOf(Argbs, c) != -1)// 如果这个RGB数据能在“令人丧心病狂的RGB数据”中找到
                        return true;
                    if (rgbList.Count > 0 && rgbList.Contains(c))// rgbList.Count > 0表示从文件中读取到了自定义rgb数据，查找当前rgb数据是否在文件中
                        return true;
                }
            }
            return false;
        }

        // 将文件中的RGB数据读到列表中
        private static void ReadFile(string path)
        {
            if (!File.Exists(path))
                return;
            using (StreamReader sr = new StreamReader(path))
            {
                string str;
                while ((str = sr.ReadLine()) != null)// 读取一行
                {
                    rgbList.Add(ColorTranslator.FromHtml(str));
                }
            }
            //try
            //{

            //    sr.Close();
            //}
            //catch
            //{
            //    sr.Close();
            //    // 重命名RGB文件
            //    string newFileName = Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) + "（重命名）自定义RGB关键字文件有误" + Path.GetExtension(path);
            //    FileInfo fi = new FileInfo(path);
            //    fi.MoveTo(newFileName);// 重命名文件
            //    throw new Exception("自定义RGB关键字文件有误！");
            //}
            //finally
            //{
            //    if (sr != null)
            //    {
            //        sr.Dispose();
            //    }
            //}
        }
    }
}
