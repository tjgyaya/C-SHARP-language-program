using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 鹰眼OCR.PDF
{
    class PDFOperation
    {
        public class PdfToImage
        {
            // 获取完一页的图像时引发事件
            public delegate void GetOnePageHandler(Image img, int pageNumber);
            public event GetOnePageHandler GetOnePageEvent;

            public void ToImage(string fileName, int sleepTime)
            {
                sleepTime = sleepTime <= 0 ? 100 : sleepTime;
                if (!File.Exists(fileName))
                    throw new Exception("文件不存在");

                using (PdfDocument pdf = PdfDocument.Load(fileName))
                {
                    for (int i = 1; i <= pdf.PageCount; i++)
                    {
                        int w = (int)pdf.PageSizes[i - 1].Width;
                        int h = (int)pdf.PageSizes[i - 1].Height;
                        Size size = new Size(w, h);
                        using (Image img = GetPdfImage(fileName, i, size))
                            OnGetOnePage(img, i);// 获取完一页的图像时引发事件
                        System.Threading.Thread.Sleep(sleepTime);
                    }
                }
            }

            // 获取完一页的图像时引发事件
            private void OnGetOnePage(Image img, int pageNumber) => GetOnePageEvent(img, pageNumber);

            /// <summary>
            /// 将pdf文件转为图片
            /// </summary>
            /// <param name="fileName">pdf文件名</param>
            /// <param name="pageNumber">pdf文件页数</param>
            /// <param name="size">pdf文件尺寸大小</param>
            private Image GetPdfImage(string fileName, int pageNumber, Size size)
            {
                using (var pdf = PdfDocument.Load(fileName))
                    return pdf.Render(pageNumber - 1, size.Width, size.Height, 300, 300, PdfRenderFlags.Annotations);
            }
        }

        public static bool IsPDFile(string fileName)
        {
            if (!File.Exists(fileName))
                return false;

            using (StreamReader sr = new StreamReader(fileName))
                return sr.ReadLine().ToLower().IndexOf("pdf") != -1;
        }
    }
}