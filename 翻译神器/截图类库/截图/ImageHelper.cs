using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenShot
{
    class ImageHelper
    {
        /// <summary>
        /// 缩放图像
        /// </summary>
        /// <param name="image"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static Image ZoomImage(Image image, float scale)
        {
            if (image == null)
                throw new ArgumentNullException("image cannot be null");
            if (scale <= 0)
                throw new ArgumentException("scale must be more than zero");
            Bitmap bmp = new Bitmap((int)Math.Ceiling(image.Width * scale), (int)Math.Ceiling(image.Height * scale));
            Bitmap bmpOld = image.Clone() as Bitmap;
            BitmapData bmpDataNew = bmp.LockBits(new Rectangle(Point.Empty, bmp.Size), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            BitmapData bmpDataOld = bmpOld.LockBits(new Rectangle(Point.Empty, image.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            byte[] byColorNew = new byte[bmpDataNew.Height * bmpDataNew.Stride];
            byte[] byColorOld = new byte[bmpDataOld.Height * bmpDataOld.Stride];
            Marshal.Copy(bmpDataOld.Scan0, byColorOld, 0, byColorOld.Length);
            for (int x = 0, lenX = bmpDataNew.Width; x < lenX; x++)
            {
                int srcX = (int)(x / scale) << 2;
                for (int y = 0, lenY = bmpDataNew.Height; y < lenY; y++)
                {
                    int offsetOld = (int)(y / scale) * bmpDataOld.Stride + srcX;
                    int offsetNew = y * bmpDataNew.Stride + (x << 2);
                    if (offsetOld < 0) offsetOld = 0;
                    else if (offsetOld >= byColorOld.Length) offsetOld = byColorOld.Length - 1;
                    if (offsetNew < 0) offsetNew = 0;
                    else if (offsetNew >= byColorNew.Length) offsetNew = byColorNew.Length - 1;
                    byColorNew[offsetNew] = byColorOld[offsetOld];
                    byColorNew[offsetNew + 1] = byColorOld[offsetOld + 1];
                    byColorNew[offsetNew + 2] = byColorOld[offsetOld + 2];
                    byColorNew[offsetNew + 3] = byColorOld[offsetOld + 3];
                }
            }
            bmpOld.UnlockBits(bmpDataOld);
            Marshal.Copy(byColorNew, 0, bmpDataNew.Scan0, byColorNew.Length);
            bmp.UnlockBits(bmpDataNew);
            bmpOld.Dispose();
            return bmp;
        }
    }
}
