using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace 鹰眼OCR
{
    class AutoUpdate
    {
        private readonly string currentVersion = Application.ProductVersion;                       // 当前程序版本
        private readonly string xmlUrl = "https://gitee.com/fuhohua/Web/raw/master/OCR/Update.xml"; // XML文件下载地址
        private readonly string xmlPath = "鹰眼OCR_升级文件.xml"; // XML本地路径
        public string FileUrl { get; set; }
        public string UpdateVersion { get; set; }
        public string BuildTime { get; set; }
        public string UpdateInfo { get; set; }
        public string VersionInfo { get; set; }
        public string FileMd5 { get; set; }
        public string UpdateSize { get; set; }

        public bool GetUpdate()
        {
            if (File.Exists(xmlPath))
                File.Delete(xmlPath);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // 下载Xml文件
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(xmlUrl, xmlPath);
            }

            // 判断Xml文件是否存在
            if (!File.Exists(xmlPath))
                throw new Exception("下载更新XML文件失败");

            // 加载Xml文件
            XmlDocument xml = new XmlDocument();
            xml.Load(xmlPath);
            // 得到根节点
            XmlNode node = xml.SelectSingleNode("AutoUpdate");
            XmlNodeList list = node.ChildNodes;

            foreach (XmlNode xn in list)
            {
                // 将节点转为元素
                XmlElement element = (XmlElement)xn;
                // 得到Version属性的值
                UpdateVersion = element.GetAttribute("Version");
                // 得到Update节点的所有子节点
                XmlNodeList nodeList = element.ChildNodes;
                FileUrl = nodeList.Item(1).InnerText;
                BuildTime = nodeList.Item(2).InnerText;
                FileMd5 = nodeList.Item(3).InnerText;
                UpdateSize = nodeList.Item(4).InnerText;
                UpdateInfo = nodeList.Item(5).InnerText;
            }
            // 删除Xml文件
            if (File.Exists(xmlPath))
                File.Delete(xmlPath);
            VersionInfo = string.Format($"当前版本：{currentVersion}\r\n最新版本：{UpdateVersion}\r\n最新版编译时间：{BuildTime}\r\n");
            UpdateInfo += "\r\n手动下载链接：" + FileUrl;
            // 比较版本号，如果当前版本小于升级版本
            if (new Version(currentVersion) < new Version(UpdateVersion))
                return true;
            else
                return false;
        }

        public void ParsingURL(string url, out string parUrl, out string psd)
        {
            parUrl = "";
            psd = "";
            int index = url.LastIndexOf("密码");// 获得链接
            if (index != -1)
                parUrl = url.Substring(0, index);
            index = url.LastIndexOf(":");  // 获得密码
            if (index != -1)
                psd = url.Substring(index + 1);
        }

        // 获取文件MD5
        public string GetMd5(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = new byte[1];
            try
            {
                data = md5.ComputeHash(fs);
            }
            finally
            {
                md5.Dispose();
                fs.Close();
            }

            StringBuilder sb = new StringBuilder(data.Length);
            for (int i = 0; i < data.Length; i++)
                sb.Append(data[i].ToString("x2"));

            return sb.ToString();
        }
    }
}
