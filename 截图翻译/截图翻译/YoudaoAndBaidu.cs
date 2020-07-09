using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Windows.Forms;

namespace 截图翻译
{
    class Youdao
    {
        private static string appKey = "66e159162802383b";
        private static string appSecret = "2tnhsI5eYnOZPdMG9lzCfwPORgg8oCdM";

        /// <summary>
        /// 直接调用有道图片翻译
        /// </summary>
        /// <param name="path">图片路径</param>
        /// <param name="from">源语言</param>
        /// <returns></returns>
        public static void YoudaoTran(string path, string from, string to, out string src_text, out string dst_text)
        {
            Dictionary<String, String> dic = new Dictionary<String, String>();

            string url = "https://openapi.youdao.com/ocrtransapi";
            string q = LoadAsBase64(path);
            string salt = DateTime.Now.Millisecond.ToString();
            string type = "1";
            //string to = "zh-CHS";

            dic.Add("from", from);
            dic.Add("to", to);
            dic.Add("type", type);
            dic.Add("q", HttpUtility.UrlEncode(q, Encoding.UTF8));
            string signStr = appKey + q + salt + appSecret; ;
            string sign = ComputeHash(signStr, new MD5CryptoServiceProvider());
            dic.Add("appKey", appKey);
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
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }

        private static string LoadAsBase64(string filename)
        {
            using (FileStream filestream = new FileStream(filename, FileMode.Open))
            {
                byte[] arr = new byte[filestream.Length];
                filestream.Position = 0;
                filestream.Read(arr, 0, (int)filestream.Length);
                filestream.Close();
                return Convert.ToBase64String(arr);
            }
        }

        private static string Post(string url, Dictionary<String, String> dic)
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

    class Baidu
    {
        // 通用文字识别
        private static string general_basic_host = "https://aip.baidubce.com/rest/2.0/ocr/v1/general_basic?access_token=";
        private static string API_KEY = "ABHVET3G06m8RAmvE7lHCpkn";
        private static string SECRET_KEY = "3vv0bG0P9MkAI0SRgabEgS3Hac8vHQPC";
        // 翻译
        private static string appId = "20200424000429104";
        private static string password = "5mzyraBsLRk2yfGQMhXJ";

        /// <summary>
        /// 先调用百度文字识别再调用百度翻译API进行翻译
        /// </summary>
        /// <param name="path">图片路径</param>
        /// <param name="from">源语言</param>
        /// <returns></returns>
        /// 
        public static void BaiduTran(string path, string from, string to, out string src_text, out string dst_text)
        {
            // 调用百度文字识别
            string srcText = GeneralBasic(path);
            // 调用翻译
            Translate(srcText, from, to, out src_text, out dst_text);
        }

        // 翻译
        public static void Translate(string srcText, string from, string to, out string src_text, out string dst_text)
        {
            // 源语言
            string languageSrc = from;
            // 目标语言
            string languageTo = to;
            //string languageTo = "zh";
            // 随机数
            string randomNum = DateTime.Now.Millisecond.ToString();
            // md5编码
            string md5Enc = GetMD5(appId + srcText + randomNum + password);
            // url
            string url = string.Format("https://fanyi-api.baidu.com/api/trans/vip/translate?q={0}&from={1}&to={2}&appid={3}&salt={4}&sign={5}",
                HttpUtility.UrlEncode(srcText, Encoding.UTF8),
                languageSrc,
                languageTo,
                appId,
                randomNum,
                md5Enc
                );


            WebClient wc = new WebClient();
            string result = wc.DownloadString(url);

            JavaScriptSerializer js = new JavaScriptSerializer();// 实例化一个能够序列化数据的类
            Baidu.BaiduTranslate list = js.Deserialize<Baidu.BaiduTranslate>(result);  // 将json数据转化为对象类型并赋值给list
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

        // 获取AccessToken
        private static string GetAccessToken()
        {
            string authHost = "https://aip.baidubce.com/oauth/2.0/token";
            HttpClient client = new HttpClient();
            List<KeyValuePair<string, string>> paraList = new List<KeyValuePair<string, string>>();
            paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            paraList.Add(new KeyValuePair<string, string>("client_id", API_KEY));
            paraList.Add(new KeyValuePair<string, string>("client_secret", SECRET_KEY));

            HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
            string result = response.Content.ReadAsStringAsync().Result;

            JavaScriptSerializer js = new JavaScriptSerializer();// 实例化一个能够序列化数据的类
            Baidu.Token list = js.Deserialize<Baidu.Token>(result);// 将json数据转化为对象并赋值给list
            if (list.error != null)
                throw new Exception("获取AccessToken失败！" + "\n原因：" + list.error_description);

            return list.access_token;
        }

        // 调用百度API文字识别
        private static string GeneralBasic(string path)
        {
            // 获取文字识别AccessToken
            string token = GetAccessToken();

            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(general_basic_host + token);
            request.Method = "post";
            request.KeepAlive = true;

            string base64 = GetFileBase64(path); // 获取图片的base64编码
            string str = "image=" + HttpUtility.UrlEncode(base64);
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string result;
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            JavaScriptSerializer js = new JavaScriptSerializer();// 实例化一个能够序列化数据的类
            Baidu.BaiduOcrJson list = js.Deserialize<Baidu.BaiduOcrJson>(result);  // 将json数据转化为对象类型并赋值给list
            if (list.error_code != null) // 如果调用Api出现错误
                throw new Exception("OCR识别错误！" + "\n原因：" + list.error_msg);

            // 接收序列化后的数据
            StringBuilder builder = new StringBuilder();
            foreach (var item in list.words_result)
                builder.Append(item.words + "\r\n");

            // 查找最后一个换行符的位置
            int len = builder.ToString().LastIndexOf('\r');
            return builder.ToString().Remove(len);
        }

        private static string GetFileBase64(string fileName)
        {
            using (FileStream filestream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                byte[] arr = new byte[filestream.Length];
                filestream.Read(arr, 0, (int)filestream.Length);
                string baser64 = Convert.ToBase64String(arr);
                filestream.Close();
                return baser64;
            }
        }

        private static string GetMD5(string str)
        {
            if (str == null)
                return null;

            MD5 md5 = MD5.Create();
            //将输入字符串转换为字节数组并计算哈希数据  
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder builder = new StringBuilder();

            //循环遍历哈希数据的每一个字节并格式化为十六进制字符串  
            for (int i = 0; i < data.Length; i++)
                builder.Append(data[i].ToString("x2"));

            return builder.ToString();
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
    }

}

