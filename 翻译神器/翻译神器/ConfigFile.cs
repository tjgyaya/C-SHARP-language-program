using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;

namespace 翻译神器
{
    class ConfigFile
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32")]
        private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);

        // 配置文件节点名称
        private static string Section = "截图翻译";

        // 配置文件路径
        public static string ConfigPath
        {
            get;
        } = Path.Combine(Environment.GetEnvironmentVariable("APPDATA") + @"\截图翻译\", "截图翻译.ini");

        const int SIZE = 100;


        // 写入配置文件
        public static void WriteFile(Dictionary<string, string> dict)
        {
            // 判断目录是否存在
            if (!Directory.Exists(Path.GetDirectoryName(ConfigPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath));

            int[] ret = new int[dict.Count];
            int i = 0;
            foreach (var item in dict)
            {
                ret[i] = 1;
                // 写入配置文件
                ret[i] = WritePrivateProfileString(Section, item.Key, item.Value, ConfigPath);
                i++;
            }

            // 如果数组中有0出现，则写入文件错误
            if (Array.IndexOf(ret, 0) != -1)
            {
                if (File.Exists(ConfigPath))
                    File.Delete(ConfigPath);
                throw new Exception("写入文件错误！");
            }
        }


        // 读配置文件
        public static void ReadFile(ref Dictionary<string, string> dict)
        {
            // 判断文件是否存在
            if (!File.Exists(ConfigPath))
                return;

            // 存放读取的数据
            StringBuilder[] sb = new StringBuilder[dict.Count];
            int i = 0;

            foreach (var item in dict)
            {
                // 初始化数组
                sb[i] = new StringBuilder(SIZE);
                // 读取配置文件
                GetPrivateProfileString(Section, item.Key, "Error", sb[i], SIZE, ConfigPath);
                i++;
            }

            // 如果数组中有Error出现，则读取文件错误
            if (Array.IndexOf(sb, "Error") != -1)
            {
                if (File.Exists(ConfigPath))
                    File.Delete(ConfigPath);
                throw new Exception("读取配置文件错误，\n请重新设置热键！");
            }

            Dictionary<string, string> tempDict = new Dictionary<string, string>(dict.Count);
            // 赋值
            i = 0;
            foreach (var item in dict)
            {
                tempDict.Add(item.Key, sb[i].ToString());
                i++;
            }
            dict = tempDict;
        }
    }
}
