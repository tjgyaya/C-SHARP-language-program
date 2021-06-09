using System;
using System.Drawing;
using System.IO;
using Tesseract;

namespace 自动进入钉钉直播.ImageRecognition
{
    class LocalOCR : IDisposable
    {
        private bool _isDisposed;
        public bool IsDisposed { get => _isDisposed; }

        private TesseractEngine engine;
        public LocalOCR(string datapath, string language)
        {
            engine = new TesseractEngine(datapath, language, EngineMode.LstmOnly)
            {
                //DefaultPageSegMode = PageSegMode.SingleLine// 设为单行识别
            };
        }

        public string GetText(Image img)
        {
            byte[] bArr = ImageToBytes(img);
            using (var img1 = Pix.LoadFromMemory(bArr))
            {
                using (var page = engine.Process(img1))
                {
                    return page.GetText();
                }
            }
        }

        private byte[] ImageToBytes(Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        ~LocalOCR()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_isDisposed)
                return;
            _isDisposed = true;
            engine?.Dispose();
        }
    }
}
