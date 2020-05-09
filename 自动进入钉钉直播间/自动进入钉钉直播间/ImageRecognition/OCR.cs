using Newtonsoft.Json;
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
using System.Windows.Input;

namespace 自动进入钉钉直播间
{
    class OCR
    {
        private static string API_KEY = "ABHVET3G06m8RAmvE7lHCpkn";
        private static string SECRET_KEY = "3vv0bG0P9MkAI0SRgabEgS3Hac8vHQPC";


        // 通过关键字判断钉钉是否在直播
        public static bool Live(string picturePath)
        {
            //判断是否有自定义关键字文件
            DirectoryInfo dir = new DirectoryInfo(AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
            FileInfo[] files = dir.GetFiles("*.txt");//查找目录下时txt的文件
            foreach (var f in files)
            {
                if (f.ToString().ToLower() == "关键字.txt")
                {
                    if (Live_File(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "关键字.txt", picturePath) == true)
                    {
                        return true;
                    }
                }
            }

            string word;
            string err = GeneralBasic(picturePath, out word);
            if (err != null)
                throw new Exception(err);

            foreach (char c in word)
            {
                if (c == '小' || c == '初' || c == '高' || c == '大' || c == '班' || c == '中' ||
                    c == '学' || c == '群' || c == '正' || c == '在' || c == '直' || c == '播')
                    return true;
            }
            return false;
        }

        private static bool Live_File(string FilePath, string picturePath)
        {
            StreamReader sr = new StreamReader(FilePath);
            string cont = sr.ReadToEnd();
            string word;
            string err = GeneralBasic(picturePath, out word);
            if (err != null)
                throw new Exception(err);

            foreach (char c in word)
            {
                foreach (char ch in cont)
                {
                    if (c == ch)
                        return true;
                }
            }
            return false;
        }

        // 获取access_token
        private static string GetAccessToken(out string key)
        {
            string authHost = "https://aip.baidubce.com/oauth/2.0/token";
            HttpClient client = new HttpClient();
            List<KeyValuePair<string, string>> paraList = new List<KeyValuePair<string, string>>();
            paraList.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            paraList.Add(new KeyValuePair<string, string>("client_id", API_KEY));
            paraList.Add(new KeyValuePair<string, string>("client_secret", SECRET_KEY));

            HttpResponseMessage response = client.PostAsync(authHost, new FormUrlEncodedContent(paraList)).Result;
            string result = response.Content.ReadAsStringAsync().Result;

            Token rt = JsonConvert.DeserializeObject<Token>(result);//JSON反序列化
            key = rt.access_token;

            if (rt.error != null)
                return "错误码：" + rt.error + "\n原因：" + rt.error_description;
            else
                return null;
        }


        // 通用文字识别
        private static string GeneralBasic(string path, out string res)
        {
            string err, token;

            if ((err = GetAccessToken(out token)) != null)
            {
                res = null;
                return err;
            }

            string host = "https://aip.baidubce.com/rest/2.0/ocr/v1/general_basic?access_token=" + token;

            Encoding encoding = Encoding.Default;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
            request.Method = "post";
            request.KeepAlive = true;

            string base64 = getFileBase64(path); // 图片的base64编码
            string str = "image=" + HttpUtility.UrlEncode(base64);
            byte[] buffer = encoding.GetBytes(str);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string result = reader.ReadToEnd();
            StringBuilder builder = new StringBuilder(result.Length);

            Json.Root rt = JsonConvert.DeserializeObject<Json.Root>(result);//JSON反序列化
            for (int i = 0; i < rt.words_result.Count; i++)
                builder.Append(rt.words_result[i].words);

            if (rt.error_code != null)
            {
                res = null;
                return "错误码：" + rt.error_code + "\n原因：" + rt.error_msg;
            }

            res = builder.ToString();
            return null;
        }



        private static string getFileBase64(string fileName)
        {
            FileStream filestream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
            byte[] arr = new byte[filestream.Length];
            filestream.Read(arr, 0, (int)filestream.Length);
            string baser64 = Convert.ToBase64String(arr);
            filestream.Close();
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
            /// <summary>
            /// 精确识别图片上的文字
            /// </summary>
            public string words { get; set; }
        }

        public class Root
        {
            public string error_code { get; set; }
            public string error_msg { get; set; }
            /// <summary>
            ///
            /// </summary>
            public List<Words_resultItem> words_result { get; set; }
        }
    }
}
