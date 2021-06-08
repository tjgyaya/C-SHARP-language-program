using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自动进入钉钉直播
{
    class ConfigFile
    {
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32")]
        private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);
        // 配置文件节点名称
        private static readonly string Section = Application.ProductName;
        // 配置文件路径
        public static string ConfigPath
        {
            get;
        } = Environment.GetEnvironmentVariable("APPDATA") + $"\\{Application.ProductName}\\配置文件.ini";
        const int SIZE = 260;

        // 写入配置文件
        public static void WriteFile(string key, string val)
        {
            // 判断目录是否存在
            if (!Directory.Exists(Path.GetDirectoryName(ConfigPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath));
            // 写入配置文件
            WritePrivateProfileString(Section, key, val, ConfigPath);
        }

        // 读配置文件
        public static string ReadFile(string key)
        {
            // 判断文件是否存在
            if (!File.Exists(ConfigPath))
                return null;
            StringBuilder sb = new StringBuilder(SIZE);
            GetPrivateProfileString(Section, key, "", sb, SIZE, ConfigPath);
            return sb.ToString();
        }
    }
}

