using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;

namespace 截图翻译
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
        } = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\截图翻译\截图翻译.ini";

        const int SIZE = 20;


        /// <summary>
        /// 写入配置文件
        /// </summary>
        /// <param name="names">键名数组</param>
        /// <param name="Values">值数组</param>
        public static void WriteFile(string[] names, string[] Values)
        {
            // 判断目录是否存在
            if (!Directory.Exists(Path.GetDirectoryName(ConfigPath)))
                Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath));

            int[] ret = new int[Values.Length];
            for (int i = 0; i < Values.Length; i++)
            {
                ret[i] = 1;
                // 写入配置文件
                ret[i] = WritePrivateProfileString(Section, names[i], Values[i], ConfigPath);
            }

            // 如果数组中有0出现，则写入文件错误
            if (Array.IndexOf(ret, 0) != -1)
            {
                if (File.Exists(ConfigPath))
                    File.Delete(ConfigPath);
                throw new Exception("写入文件错误！");
            }
        }


        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="names">键名数组</param>
        /// <param name="Values">值数组</param>
        public static void ReadFile(string[] names, ref string[] Values)
        {
            // 判断文件是否存在
            if (!File.Exists(ConfigPath))
                return;

            // 存放读取的数据
            StringBuilder[] sb = new StringBuilder[Values.Length];

            for (int i = 0; i < Values.Length; i++)
            {   // 初始化数组
                sb[i] = new StringBuilder(SIZE);
                // 读取配置文件
                GetPrivateProfileString(Section, names[i], "Error", sb[i], SIZE, ConfigPath);
            }

            // 如果数组中有Error出现，则读取文件错误
            if (Array.IndexOf(sb, "Error") != -1)
            {
                if (File.Exists(ConfigPath))
                    File.Delete(ConfigPath);
                throw new Exception("读取配置文件错误，\n请重新设置热键！");
            }

            // 赋值
            for (int i = 0; i < Values.Length; i++)
                Values[i] = sb[i].ToString();
        }
    }
}
