using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Input;

namespace 自动进入钉钉直播
{
    class OCR
    {
        // OCR API_KEY
        private static string API_KEY = "ABHVET3G06m8RAmvE7lHCpkn";
        private static string SECRET_KEY = "3vv0bG0P9MkAI0SRgabEgS3Hac8vHQPC";


        // 通过关键字判断钉钉是否在直播
        public static bool Is_Live(string picturePath)
        {
            string apikeyPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "apikey.txt");
            string keyWordPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "关键字.txt");

            string word, keyword = null;
            // 关键字
            char[] key_words = { '小', '初', '高', '大', '班', '中', '学', '群', '正', '在', '直', '播' };

            // 读取自定义apikey文件
            if (File.Exists(apikeyPath))
            {
                ReadApiKeyFile(apikeyPath, out API_KEY, out SECRET_KEY);
            }

            // 读取自定义关键字文件
            if (File.Exists(keyWordPath))
            {
                using (StreamReader sr = new StreamReader(keyWordPath))
                {
                    keyword = sr.ReadToEnd();
                }
            }

            // 识别图片文字
            word = GeneralBasic(picturePath);
            if (word == null)// 如果返回结果为空
                return false;

            foreach (char c in word)
            {
                // 如果自定义关键字文件存在且不为空，则从文件查找
                if (string.IsNullOrEmpty(keyword))
                {
                    if (keyword.IndexOf(c) != -1)
                        return true;
                }
                // 从关键字数组中查找
                if (Array.IndexOf(key_words, c) != -1)
                    return true;
            }
            return false;
        }


        public static void ReadApiKeyFile(string path, out string ak, out string sk)
        {
            ak = "";
            sk = "";
            using (StreamReader sr = new StreamReader(path))
            {
                string str;
                for (int i = 1; (str = sr.ReadLine()) != null && i <= 2; i++)
                {
                    if (i == 1 && str != "\n")
                        ak = str;
                    else if (i == 2 && str != "\n")
                        sk = str;
                }
            }
        }


        // 获取AccessToken
        public static void GetAccessToken(out string token, string APIKey = null, string SecreTKey = null)
        {
            if (APIKey == null)
                APIKey = API_KEY;
            if (SecreTKey == null)
                SecreTKey = SECRET_KEY;

            string host = "https://aip.baidubce.com/oauth/2.0/token";

            HttpClient client = new HttpClient();
            List<KeyValuePair<string, string>> paraList = new List<KeyValuePair<string, string>>();
            paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            paraList.Add(new KeyValuePair<string, string>("client_id", APIKey));
            paraList.Add(new KeyValuePair<string, string>("client_secret", SecreTKey));

            HttpResponseMessage response = client.PostAsync(host, new FormUrlEncodedContent(paraList)).Result;
            string result = response.Content.ReadAsStringAsync().Result;

            response.Dispose();
            client.Dispose();

            JavaScriptSerializer js = new JavaScriptSerializer();// 实例化一个能够序列化数据的类
            Token list = js.Deserialize<Token>(result);          // 将json数据转化为对象并赋值给list
            token = list.access_token;
            if (list.error != null)
                throw new Exception("获取AccessToken失败！" + "\n原因：" + list.error_description);
        }


        // 通用文字识别
        private static string general_basic_host = "https://aip.baidubce.com/rest/2.0/ocr/v1/general_basic?access_token=";
        // 通用文字识别（含位置信息版）
        private static string basic_host = "https://aip.baidubce.com/rest/2.0/ocr/v1/general?access_token=";
        // 通用文字识别（高精度含位置版）
        private static string accurate_host = "https://aip.baidubce.com/rest/2.0/ocr/v1/accurate?access_token=";


        // 调用百度API文字识别
        private static string GeneralBasic(string path)
        {
            string host = null, token, result;

            // 获取文字识别AccessToken
            GetAccessToken(out token);

            for (int i = 1; i < 4; i++)
            {
                if (i == 1)
                    host = general_basic_host + token;
                else if (i == 2)
                    host = basic_host + token;
                else if (i == 3)
                    host = accurate_host + token;

                Encoding encoding = Encoding.Default;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
                request.Method = "post";
                request.KeepAlive = true;

                string base64 = GetFileBase64(path); // 获取图片的base64编码
                string str = "image=" + HttpUtility.UrlEncode(base64);
                byte[] buffer = encoding.GetBytes(str);
                request.ContentLength = buffer.Length;
                request.GetRequestStream().Write(buffer, 0, buffer.Length);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                    reader.Close();
                }
                response.Dispose();

                JavaScriptSerializer js = new JavaScriptSerializer();// 实例化一个能够序列化数据的类
                Json.Root list = js.Deserialize<Json.Root>(result);  // 将json数据转化为对象类型并赋值给list
                if (list.error_code != null) // 如果调用Api出现错误
                {
                    // 如果3个Api都调用了并且都出现了错误
                    if (i == 3)
                    {
                        throw new Exception("OCR识别错误！" + "\n原因：" + list.error_msg);
                    }
                    continue; // 否则继续调用下一个Api
                }

                // 接收序列化后的数据
                StringBuilder builder = new StringBuilder(result.Length);
                foreach (var item in list.words_result)
                    builder.Append(item.words);

                return builder.ToString();
            }
            throw new Exception("OCR识别错误！");
        }

        private static string GetFileBase64(string fileName)
        {
            string baser64;
            using (FileStream filestream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                byte[] arr = new byte[filestream.Length];
                filestream.Read(arr, 0, (int)filestream.Length);
                baser64 = Convert.ToBase64String(arr);
            }
            return baser64;
        }
    }

    class Token
    {
        public string error { get; set; }
        public string error_description { get; set; }
        public string access_token { get; set; }
    }

    class Json
    {
        public class Words_resultItem
        {
            public string words { get; set; }
        }

        public class Root
        {
            public string error_code { get; set; }
            public string error_msg { get; set; }
            public List<Words_resultItem> words_result { get; set; }
        }
    }
}
