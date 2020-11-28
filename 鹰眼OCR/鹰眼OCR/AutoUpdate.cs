using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace 鹰眼OCR
{
    class AutoUpdate
    {
        private string currentVersion = Application.ProductVersion;                       // 当前程序版本
        private string xmlUrl = "https://gitee.com/fuhohua/Web/raw/master/OCR/Update.xml"; // XML文件下载地址
        private string xmlPath = "鹰眼OCR_升级文件.xml"; // XML本地路径
        public string FileUrl { get; set; }
        public string UpdateVersion { get; set; }

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
            }
            // 删除Xml文件
            if (File.Exists(xmlPath))
                File.Delete(xmlPath);
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
    }
}
