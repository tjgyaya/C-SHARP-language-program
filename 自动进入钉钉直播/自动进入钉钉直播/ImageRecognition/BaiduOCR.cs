using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace 自动进入钉钉直播.ImageRecognition
{
    class BaiduOCR
    {
        /// <summary>
        /// 发送post请求
        /// </summary>
        /// <param name="host">要发送请求的链接</param>
        /// <param name="token">验证令牌（可为null）</param>
        /// <param name="param">参数</param>
        /// <returns>响应数据</returns>
        public static string Request(string host, string token, string param, string contentType = null)
        {
            host += string.IsNullOrEmpty(token) ? "" : token;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.Timeout = 6000;
            request.ContentType = string.IsNullOrEmpty(contentType) ? "application/x-www-form-urlencoded" : contentType;
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
        public static string GetAccessToken(string ak, string sk)
        {
            string host = "https://aip.baidubce.com/oauth/2.0/token";
            string str = string.Format($"grant_type=client_credentials&client_id={ak}&client_secret={sk}");
            string result = Request(host, "", str);
            JavaScriptSerializer js = new JavaScriptSerializer();// 实例化一个能够序列化数据的类
            Token list = js.Deserialize<Token>(result);// 将json数据转化为对象并赋值给list
            if (list.error != null)
                throw new Exception("获取AccessToken失败！" + "\n原因：" + list.error_description);
            return list.access_token;
        }

        /// <summary>
        /// 调用百度API文字识别
        /// </summary>
        /// <param name="img">图像流</param>
        /// <param name="ak">ApiKey</param>
        /// <param name="sk">SercretKey</param>
        /// <returns></returns>
        public static string GeneralBasic(Image img, string ak, string sk)
        {
            // 通用文字识别
            string host = "https://aip.baidubce.com/rest/2.0/ocr/v1/general_basic?access_token=";
            string token = GetAccessToken(ak, sk);// 获取文字识别AccessToken
            string base64 = ImageToBase64(img);
            string str = "image=" + HttpUtility.UrlEncode(base64);
            string result = Request(host, token, str);
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

        private static string ImageToBase64(Image img)
        {
            // 先转为byte数据
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    class Token
    {
        public string error { get; set; }
        public string error_description { get; set; }
        public string access_token { get; set; }
    }

    // 百度文字识别
    public class BaiduOcrJson
    {
        public string error_code { get; set; }
        public string error_msg { get; set; }
        public List<Words_resultItem> words_result { get; set; }
        public class Words_resultItem
        {
            public string words { get; set; }
        }
    }
}
