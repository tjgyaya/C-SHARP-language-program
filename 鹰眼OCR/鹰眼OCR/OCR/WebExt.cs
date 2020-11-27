﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace 鹰眼OCR.OCR
{
    class WebExt
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
            request.Timeout = 30_000;
            request.ContentType = string.IsNullOrEmpty(contentType) ? "application/x-www-form-urlencoded" : contentType;
            request.KeepAlive = true;
            byte[] buffer = Encoding.UTF8.GetBytes(param);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                string result = reader.ReadToEnd();
                response.Dispose();
                return result;
            }
        }

        /// <summary>
        ///  Image转Base64
        /// </summary>
        /// <param name="img"></param>
        /// <returns>转换后的base64数据</returns>
        public static string ImageToBase64(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        /// <summary>
        /// 文件转Base64
        /// </summary>
        /// <param name="fileName">路径</param>
        /// <returns>转换后的base64数据</returns>
        public static string FileToBase64(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                byte[] arr = new byte[fs.Length];
                fs.Read(arr, 0, (int)fs.Length);
                string baser64 = Convert.ToBase64String(arr);
                return baser64;
            }
        }

        public static byte[] ImageToBytes(Image img)
        {
            using (MemoryStream ms=new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public static string GetMD5(string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;

            MD5 md5 = MD5.Create();
            // 字符串转换为字节数组并计算哈希数据  
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder builder = new StringBuilder(str.Length);
            // 循环遍历哈希数据的每一个字节并格式化为十六进制字符串  
            for (int i = 0; i < data.Length; i++)
                builder.Append(data[i].ToString("x2"));

            return builder.ToString().ToUpper();
        }

        /// <summary>
        /// 获取Unix时间戳
        /// </summary>
        /// <returns>Unix时间戳（单位：秒）</returns>
        public static string GetTimeSpan()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToString((long)ts.TotalMilliseconds / 1000);
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="savePath"></param>
        public static bool DownloadFile(string url, string savePath)
        {
            if (string.IsNullOrEmpty(url))
                return false;
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse; // 发送请求并获取响应
            Stream stream = response.GetResponseStream(); // 获取响应的数据流
            try
            {    // 将数据流写入到文件
                using (FileStream fs = new FileStream(savePath, FileMode.Create))
                {
                    byte[] bArr = new byte[4096];
                    int len = default;
                    while ((len = stream.Read(bArr, 0, bArr.Length)) > 0)
                        fs.Write(bArr, 0, len);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
                if (response != null)
                    response.Dispose();
            }
        }
    }
}
