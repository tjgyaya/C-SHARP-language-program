using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using 自动进入钉钉直播.ImageRecognition;

namespace 自动进入钉钉直播
{
    class OCR
    {
        static OCR()
        {
            if (File.Exists(apikeyPath))
                ReadApiKeyFile(apikeyPath, out apiKey, out sercretKey);
            if (File.Exists(keyWordPath))
            {
                using (StreamReader sr = new StreamReader(keyWordPath))
                {
                    customKeyWords = new List<char>(sr.ReadToEnd());
                    while (customKeyWords.Remove('\r') || customKeyWords.Remove('\n'))
                        ; // 去掉读取的换行符
                }
            }
        }

        // OCR密钥
        private static string apiKey = "ABHVET3G06m8RAmvE7lHCpkn";
        private static string sercretKey = "3vv0bG0P9MkAI0SRgabEgS3Hac8vHQPC";
        // 文字识别关键字
        private static readonly char[] key_words = { '小', '初', '高', '大', '班', '中', '学', '群', '正', '在', '直', '播' };
        private static List<char> customKeyWords = new List<char>();
        private static string apikeyPath = Application.StartupPath + "\\apikey.txt";
        private static string keyWordPath = Application.StartupPath + "\\关键字.txt";// 自定义api和关键字文件路径

        // 通过关键字判断钉钉是否在直播
        public static bool Is_Live(Image img)
        {
            string word = BaiduOCR.GeneralBasic(img, apiKey, sercretKey); // 识别图片文字
            if (string.IsNullOrEmpty(word)) // 如果返回结果为空
                return false;
            foreach (char c in word)
            {
                // 如果自定义关键字文件存在且不为空，则从文件查找
                if (customKeyWords.Count > 0)
                {
                    if (customKeyWords.Contains(c))
                        return true;
                }
                // 从关键字数组中查找
                if (Array.IndexOf(key_words, c) != -1)
                    return true;
            }
            return false;
        }

        // 从文件读取文字识别密钥
        public static void ReadApiKeyFile(string path, out string ak, out string sk)
        {
            sk = ak = "";
            using (StreamReader sr = new StreamReader(path))
            {
                string str;
                for (int i = 1; (str = sr.ReadLine()) != null && i <= 2; i++)
                {
                    if (i == 1)
                        ak = str;
                    else if (i == 2)
                        sk = str;
                }
            }
        }
    }
}