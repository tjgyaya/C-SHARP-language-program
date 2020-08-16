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
using System.Web.WebSockets;
using System.Windows.Forms;

namespace 自动进入钉钉直播
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
        const int LOGPIXELSX = 88;


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
            float scaleY = GetDeviceCaps(hdc, DESKTOPVERTRES) / GetDeviceCaps(hdc, VERTRES);
            ReleaseDC(IntPtr.Zero, hdc);
            return scaleY;
        }

        /// <summary>
        /// 从指定坐标截取指定大小区域
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
            using (Graphics g = Graphics.FromImage(bit))
            {
                g.CompositingQuality = CompositingQuality.HighQuality;// 质量设为最高
                g.CopyFromScreen((int)(x * scaleX), (int)(y * scaleY), 0, 0, new Size((int)(width * scaleX), (int)(height * scaleY)));
            }
            return bit;
        }

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
        /// 判断图片中的rgb是否含有钉钉正在直播时的rgb
        /// </summary>
        /// <param name="bit"></param>
        /// <returns></returns>
        public static bool Is_LiveRgb(Bitmap bit)
        {
            Color c;
            List<Color> rgbList = new List<Color>();// 从文件读取的rgb数据

            // 判断是否有自定义颜色文件
            string rgbPath;
            DirectoryInfo dir = new DirectoryInfo(Application.StartupPath);
            FileInfo[] files = dir.GetFiles("*.txt");// 查找目录下时txt的文件
            foreach (var f in files)
            {
                if (f.ToString().ToLower() == "color.txt")
                {
                    rgbPath = Path.Combine(Application.StartupPath + "\\", f.ToString());
                    rgbList = GetFileLiveRgb(rgbPath);
                }
            }

            // 遍历图片像素点，判断颜色是否正确
            for (int x = 0; x < bit.Width; x++)
            {
                for (int y = 0; y < bit.Height; y++)
                {
                    c = bit.GetPixel(x, y);// 获取一个像素点的颜色
                    if (Array.IndexOf(Argbs, c) != -1)// 如果这个RGB数据能在“令人丧心病狂的RGB数据”中找到
                    {
                        return true;
                    }
                    if (rgbList.Count > 0)// rgbList.Count > 0表示从文件中读取到了自定义rgb数据，查找当前rgb数据是否在文件中
                    {
                        if (rgbList.Contains(c))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        // 将文件中的RGB数据读到列表中
        private static List<Color> GetFileLiveRgb(string path)
        {
            List<Color> rgbList = new List<Color>();
            StreamReader sr = new StreamReader(path);

            try
            {
                string str;
                while ((str = sr.ReadLine()) != null)// 读取一行
                {
                    rgbList.Add(ColorTranslator.FromHtml(str));
                }
                sr.Close();
            }
            catch
            {
                sr.Close();
                // 重命名RGB文件
                string newFileName = Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) + "（重命名）自定义RGB关键字文件有误" + Path.GetExtension(path);
                FileInfo fi = new FileInfo(path);
                fi.MoveTo(newFileName);// 重命名文件
                throw new Exception("自定义RGB关键字文件有误！");
            }
            finally
            {
                if (sr != null)
                {
                    sr.Dispose();
                }
            }

            return rgbList;
        }
    }
}
