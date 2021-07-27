using System;
using System.Drawing;

namespace ScreenShot
{
    /// <summary>
    /// 从指定坐标截取指定大小区域
    /// </summary>
    public class SpecifyScreenshot
    {
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
            Bitmap bit = new Bitmap(width, height);
            try
            {
                using (Graphics g = Graphics.FromImage(bit))
                {
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.CopyFromScreen(x, y, 0, 0, new Size(width, height));
                    return bit;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
