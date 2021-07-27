using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace 翻译神器
{
    class Baidu
    {
        //  private static string general_basic_host = "https://aip.baidubce.com/rest/2.0/ocr/v1/general_basic?access_token=";
        private static string accurate_basic_host = "https://aip.baidubce.com/rest/2.0/ocr/v1/accurate_basic?access_token=";

        /// <summary>
        /// 先调用百度文字识别再调用百度翻译API进行翻译
        /// </summary>
        /// <param name="path">图片路径</param>
        /// <param name="from">源语言</param>
        /// <returns></returns>
        /// 
        public static void BaiduTran(Image img, string from, string to, out string src_text, out string dst_text)
        {
            if (BaiduKey.IsEmptyOrNull)
                throw new Exception("请设置百度文字识别和翻译Key！");
            //Picture(img, from, "zh", out src_text, out dst_text);
            // 调用百度文字识别
            string srcText = GeneralBasic(from, img);
            if (string.IsNullOrEmpty(srcText))
                throw new Exception("识别内容为空");
            // 调用翻译
            Translate(srcText, from, to, out src_text, out dst_text);
        }

        public static void Picture(Image img, string from, string to, out string src_text, out string dst_text)
        {
            string url = "https://fanyi-api.baidu.com/api/trans/sdk/picture?";
            string salt = new Random().Next(1024, 8192).ToString();
            string cuid = "APICUID";
            string mac = "mac";
            string base64;
            byte[] buffer;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                buffer = ms.ToArray();
                base64 = string.Join("", ms.ToArray());
            }
            string pictureMd5 = GetMD5(base64);
            string sign = GetMD5(BaiduKey.AppId + pictureMd5 + salt + cuid + mac + BaiduKey.Password);
            url += $"from={from}&to={to}&appid={BaiduKey.AppId}&salt={salt}&cuid={cuid}&mac={mac}&erase=0&sign={sign}";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "post";
            request.ContentType = "multipart/form-data;image/png";
            request.Timeout = 6000;
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string result = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            JavaScriptSerializer js = new JavaScriptSerializer();// 实例化一个能够序列化数据的类
            var list = js.Deserialize<PictureTranslate>(result);  // 将json数据转化为对象类型并赋值给list
            if (list.error_code != null) // 如果调用Api出现错误
                throw new Exception("调用百度翻译失败" + "\n原因：" + list.error_msg);
            // 接收序列化后的数据
            StringBuilder dst = new StringBuilder();
            StringBuilder src = new StringBuilder();
            foreach (var item in list.content)
            {
                src.Append(item.src + "\r\n");
                dst.Append(item.dst + "\r\n");
            }
            int sLen = src.ToString().LastIndexOf('\r');
            int dLen = dst.ToString().LastIndexOf('\r');
            src_text = src.ToString().Remove(sLen);
            dst_text = dst.ToString().Remove(dLen);
        }

        // 翻译
        /// <summary>
        /// 百度翻译
        /// </summary>
        /// <param name="srcText">源文本</param>
        /// <param name="from">源语言</param>
        /// <param name="to">目标语言</param>
        public static void Translate(string srcText, string from, string to, out string src_text, out string dst_text)
        {
            if (BaiduKey.IsEmptyOrNull)
                throw new Exception("请设置百度文字识别和翻译Key！");
            string salt = DateTime.Now.Millisecond.ToString();
            // 源语言
            string languageSrc = from;
            // 目标语言
            string languageTo = to;
            // 签名
            string sign = GetMD5(BaiduKey.AppId + srcText + salt + BaiduKey.Password);
            string url = "https://fanyi-api.baidu.com/api/trans/vip/translate";
            string str = string.Format($"q={HttpUtility.UrlEncode(srcText)}&from={languageSrc}&to={languageTo}" +
                 $"&appid={BaiduKey.AppId}&salt={salt}&sign={sign}");
            string result = Request(url, null, str);
            JavaScriptSerializer js = new JavaScriptSerializer();// 实例化一个能够序列化数据的类
            BaiduTranslate list = js.Deserialize<BaiduTranslate>(result);  // 将json数据转化为对象类型并赋值给list
            if (list.Error_code != null) // 如果调用Api出现错误
                throw new Exception("调用百度翻译失败" + "\n原因：" + list.Error_msg);

            // 接收序列化后的数据
            StringBuilder dst = new StringBuilder();
            StringBuilder src = new StringBuilder();
            foreach (var item in list.Trans_result)
            {
                src.Append(item.Src + "\r\n");
                dst.Append(item.Dst + "\r\n");
            }

            int sLen = src.ToString().LastIndexOf('\r');
            int dLen = dst.ToString().LastIndexOf('\r');
            src_text = src.ToString().Remove(sLen);
            dst_text = dst.ToString().Remove(dLen);
        }

        /// <summary>
        /// 发送post请求
        /// </summary>
        /// <param name="host">要发送请求的链接</param>
        /// <param name="token">验证令牌（可为null）</param>
        /// <param name="param">参数</param>
        /// <returns>响应数据</returns>
        public static string Request(string host, string token, string param, string contentType = "application/x-www-form-urlencoded")
        {
            host += string.IsNullOrEmpty(token) ? "" : token;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            // request.ServicePoint.BindIPEndPointDelegate = (ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount) => new IPEndPoint(IPAddress.Any, 0);
            request.Method = "post";
            request.Timeout = 6000;
            request.ContentType = contentType;
            request.KeepAlive = true;
            byte[] buffer = Encoding.UTF8.GetBytes(param);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                return reader.ReadToEnd();
        }

        /// <summary>
        /// 获取AccessToken，失败时抛出异常
        /// </summary>
        /// <returns></returns>
        public static string GetAccessToken()
        {
            string host = "https://aip.baidubce.com/oauth/2.0/token";
            string ak = BaiduKey.ApiKey;
            string sk = BaiduKey.SecretKey;
            string str = string.Format($"grant_type=client_credentials&client_id={ak}&client_secret={sk}");
            string result = Request(host, "", str);
            JavaScriptSerializer js = new JavaScriptSerializer();// 实例化一个能够序列化数据的类
            Token list = js.Deserialize<Token>(result);// 将json数据转化为对象并赋值给list
            if (list.error != null)
                throw new Exception("获取AccessToken失败！" + "\n原因：" + list.error_description);

            return list.access_token;
        }

        // 调用百度API文字识别
        private static string GeneralBasic(string from, Image img)
        {
            from = (from == "ru") ? "RUS" : "CHN_ENG";
            string token = GetAccessToken();// 获取文字识别AccessToken
            string base64 = ImageToBase64(img);
            string str = "image=" + HttpUtility.UrlEncode(base64) + "&language_type=" + from;
            string result = Request(accurate_basic_host, token, str);
            JavaScriptSerializer js = new JavaScriptSerializer();// 实例化一个能够序列化数据的类
            BaiduOcrJson list = js.Deserialize<BaiduOcrJson>(result);  // 将json数据转化为对象类型并赋值给list
            if (list.error_code != null) // 如果调用Api出现错误
                throw new Exception("OCR识别错误！" + "\n原因：" + list.error_msg);
            // 接收序列化后的数据
            StringBuilder builder = new StringBuilder();
            foreach (var item in list.words_result)
                builder.Append(item.words + "\r\n");
            // 查找最后一个换行符的位置
            int len = builder.ToString().LastIndexOf('\r');
            return len < 0 ? "" : builder.ToString().Remove(len);
        }

        // 测试百度key是否有效
        public static bool BaiduKeyTest()
        {
            try
            {
                GetAccessToken();// 测试文字识别Key只需要测试能否获得AccessToken就可以了
                Translate("Test", "en", "zh", out string s, out string r);// 测试百度翻译Key
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
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

        private static string GetMD5(string str)
        {
            MD5 md5 = MD5.Create();
            //将输入字符串转换为字节数组并计算哈希数据  
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in data)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
        private static string GetImageMD5(Image img)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                //将输入字符串转换为字节数组并计算哈希数据  
                byte[] data = md5.ComputeHash(ms.ToArray());
                StringBuilder sb = new StringBuilder();
                foreach (byte b in data)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        // 获取百度accesstoken
        class Token
        {
            public string error { get; set; }
            public string error_description { get; set; }
            public string access_token { get; set; }
        }

        // 百度翻译结果
        public class Translation
        {
            public string Src { get; set; }
            public string Dst { get; set; }
        }

        public class BaiduTranslate
        {
            // 百度翻译
            public string Error_code { get; set; }
            public string Error_msg { get; set; }
            public Translation[] Trans_result { get; set; }
        }

        // 百度文字识别
        public class Words_resultItem
        {
            public string words { get; set; }
        }
        public class BaiduOcrJson
        {
            // 百度文字识别
            public string error_code { get; set; }
            public string error_msg { get; set; }
            public List<Words_resultItem> words_result { get; set; }
        }

        public class PictureTranslate
        {
            public string error_code { get; set; }
            public string error_msg { get; set; }
            public List<Content> content { get; set; }
            public class Content
            {
                public string src { get; set; } //分段翻译的原文
                public string dst { get; set; }   //分段翻译译文
            }
            public string sumSrc { get; set; }
            public string sumDst { get; set; }
        }
    }
}
