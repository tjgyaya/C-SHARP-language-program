using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace 自动进入钉钉直播间
{
    class AutoUpdate
    {
        private static string UpdateVersion { get; set; }
        private static string FileName { get; set; }
        private static string FileUrl { get; set; }
        private static string FileMd5 { get; set; }
        private static string UpdateCont { get; set; }

        // 获取更新
        public static string GetUpdate()
        {
            string currentVersion = Application.ProductVersion;                       // 当前程序版本
            string xmlUrl = "https://gitee.com/fuhohua/Web/raw/master/DD/Update.xml"; // XML文件下载地址
            string xmlPath = Environment.GetEnvironmentVariable("TEMP") + "\\自动进入钉钉直播间Update.xml"; // XML本地路径
            string downFilePath = Process.GetCurrentProcess().MainModule.FileName;    // 当前程序名称
            string temp_File = downFilePath + ".tmp";                                 // 临时文件
            string batPath = Application.StartupPath + "\\自动进入钉钉直播间ren.bat"; // 脚本文件

            try
            {
                // 删除上次残余文件
                if (File.Exists(temp_File))
                    File.Delete(temp_File);
                if (File.Exists(batPath))
                    File.Delete(batPath);
                if (File.Exists(xmlPath))
                    File.Delete(xmlPath);


                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                // 下载Xml文件
                WebClient client = new WebClient();
                client.DownloadFile(xmlUrl, xmlPath);


                // 判断Xml文件是否存在
                if (!File.Exists(xmlPath))
                    throw new Exception("下载XML文件失败");

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
                    FileName = nodeList.Item(0).InnerText;
                    FileMd5 = nodeList.Item(1).InnerText;
                    FileUrl = nodeList.Item(2).InnerText;
                    UpdateCont = nodeList.Item(3).InnerText;
                }
                // 删除Xml文件
                if (File.Exists(xmlPath))
                    File.Delete(xmlPath);


                // 比较版本号，如果当前版本小于升级版本
                if (new Version(currentVersion) < new Version(UpdateVersion))
                {
                    UpdateForm updateForm = new UpdateForm(currentVersion, UpdateVersion, UpdateCont, FileUrl, FileMd5, temp_File, batPath, downFilePath);
                    try
                    {
                        updateForm.ShowDialog();
                        return null;
                    }
                    catch (Exception ex)
                    {
                        updateForm.Close();
                        Clipboard.SetText(FileUrl);
                        return "\r\n更新失败，已将下载链接复制到剪切板\r\n              原因：" + ex.Message + "\r\n";
                    }
                }
                else
                    return null;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        // 获取文件MD5
        public static string GetMd5(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = md5.ComputeHash(fs);
            fs.Close();

            StringBuilder sb = new StringBuilder(data.Length);
            for (int i = 0; i < data.Length; i++)
                sb.Append(data[i].ToString("x2"));

            return sb.ToString();
        }

    }
}
