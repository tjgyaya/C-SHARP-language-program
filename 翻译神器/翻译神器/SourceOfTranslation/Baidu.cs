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

namespace 翻译神器.SourceOfTranslation
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
        public static void BaiduTran(Image img, string from, out string src_text, out string dst_text)
        {
            if (BaiduKey.IsEmptyOrNull)
                throw new Exception("请设置百度文字识别和翻译Key！");

            // 调用百度文字识别
            string srcText = GeneralBasic(from, img);
            if (string.IsNullOrEmpty(srcText))
                throw new Exception("识别内容为空");

            // 调用翻译
            Translate(srcText, from, "zh", out src_text, out dst_text);
        }

        // 翻译
        public static void Translate(string srcText, string from, string to, out string src_text, out string dst_text)
        {
            if (BaiduKey.IsEmptyOrNull)
                throw new Exception("请设置百度文字识别和翻译Key！");

            // 源语言
            string languageSrc = from;
            // 目标语言
            string languageTo = to;
            //string languageTo = "zh";
            // 随机数
            string randomNum = DateTime.Now.Millisecond.ToString();
            // md5编码
            string md5Enc = GetMD5(BaiduKey.AppId + srcText + randomNum + BaiduKey.Password);
            // url
            string url = string.Format("https://fanyi-api.baidu.com/api/trans/vip/translate?q={0}&from={1}&to={2}&appid={3}&salt={4}&sign={5}",
                HttpUtility.UrlEncode(srcText, Encoding.UTF8), languageSrc, languageTo, BaiduKey.AppId, randomNum, md5Enc);
            string result;
            using (WebClient wc = new WebClient())
                result = wc.DownloadString(url);

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

        // 获取AccessToken，失败时抛出异常
        private static string GetAccessToken()
        {
            string authHost = "https://aip.baidubce.com/oauth/2.0/token";
            HttpClient client = new HttpClient();
            List<KeyValuePair<string, string>> paraList = new List<KeyValuePair<string, string>>();
            paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            paraList.Add(new KeyValuePair<string, string>("client_id", BaiduKey.ApiKey));
            paraList.Add(new KeyValuePair<string, string>("client_secret", BaiduKey.SecretKey));

            HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
            string result = response.Content.ReadAsStringAsync().Result;

            JavaScriptSerializer js = new JavaScriptSerializer();// 实例化一个能够序列化数据的类
            Token list = js.Deserialize<Token>(result);// 将json数据转化为对象并赋值给list
            if (list.error != null)
                throw new Exception("获取AccessToken失败！" + "\n原因：" + list.error_description);

            return list.access_token;
        }

        // 调用百度API文字识别
        private static string GeneralBasic(string from, Image img)
        {
            if (from == "ru")
                from = "RUS";
            else
                from = "CHN_ENG";
            // 获取文字识别AccessToken
            string token = GetAccessToken();

            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(accurate_basic_host + token);
            request.Method = "post";
            request.KeepAlive = true;

            string base64 = ImageToBase64(img);
            string str = "image=" + HttpUtility.UrlEncode(base64) + "&language_type=" + from;
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
                string s, r;
                Translate("Test", "en", "zh", out s, out r);// 测试百度翻译Key
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
