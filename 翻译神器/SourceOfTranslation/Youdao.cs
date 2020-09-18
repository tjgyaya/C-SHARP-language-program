using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace 翻译神器.SourceOfTranslation
{
    class Youdao
    {
        /// <summary>
        /// 直接调用有道图片翻译
        /// </summary>
        /// <param name="path">图片路径</param>
        /// <param name="from">源语言</param>
        /// <returns></returns>
        public static void YoudaoTran(string path, string from, string to, out string src_text, out string dst_text, Image img = null)
        {
            if (YoudaoKey.IsEmptyOrNull)
                throw new Exception("请设置有道图片翻译Key！");

            Dictionary<string, string> dic = new Dictionary<string, string>();

            string url = "https://openapi.youdao.com/ocrtransapi";
            string q;
            if (img != null)
                q = ImageToBase64(img);
            else
                q = LoadAsBase64(path);
            string salt = DateTime.Now.Millisecond.ToString();
            string type = "1";
            //string to = "zh-CHS";

            dic.Add("from", from);
            dic.Add("to", to);
            dic.Add("type", type);
            dic.Add("q", HttpUtility.UrlEncode(q, Encoding.UTF8));
            string signStr = YoudaoKey.AppKey + q + salt + YoudaoKey.AppSecret;
            string sign = ComputeHash(signStr, new MD5CryptoServiceProvider());
            dic.Add("appKey", YoudaoKey.AppKey);
            dic.Add("salt", salt);
            dic.Add("sign", sign);

            string result = Post(url, dic);
            JavaScriptSerializer js = new JavaScriptSerializer();// 实例化一个能够序列化数据的类
            YoudaoTranslate list = js.Deserialize<YoudaoTranslate>(result);  // 将json数据转化为对象类型并赋值给list
            if (list.errorCode != "0")
                throw new Exception("错误代码：" + list.errorCode);

            // 接收序列化后的数据
            StringBuilder dst = new StringBuilder();
            StringBuilder src = new StringBuilder();
            foreach (var item in list.resRegions)
            {
                src.Append(item.context + "\r\n");
                dst.Append(item.tranContent + "\r\n");
            }

            int sLen = src.ToString().LastIndexOf('\r');
            int dLen = dst.ToString().LastIndexOf('\r');
            src_text = src.ToString().Remove(sLen);
            dst_text = dst.ToString().Remove(dLen);
        }

        private static string ComputeHash(string input, HashAlgorithm algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }

        private static string ImageToBase64(Image img)
        {
            // 先转为byte数据
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        private static string LoadAsBase64(string filename)
        {
            using (FileStream filestream = new FileStream(filename, FileMode.Open))
            {
                byte[] arr = new byte[filestream.Length];
                filestream.Position = 0;
                filestream.Read(arr, 0, (int)filestream.Length);
                return Convert.ToBase64String(arr);
            }
        }

        private static string Post(string url, Dictionary<string, string> dic)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        // 测试有道key是否有效
        public static bool YoudaoKeyTest()
        {
            DialogResult result = MessageBox.Show("此次测试会上传一张图片进行识别，可能会造成扣费！\n\t\t是否继续？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
                return false;
            try
            {
                string s, d;
                YoudaoTran(null, "zh-CHS", "en", out s, out d, Properties.Resources.KeyTest);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // 有道翻译
        public class resRegions
        {
            // 原文
            public string tranContent { get; set; }
            // 译文
            public string context { get; set; }
        }

        public class YoudaoTranslate
        {
            // 有道翻译
            public string errorCode { get; set; }
            public List<resRegions> resRegions { get; set; }
        }
    }
}
