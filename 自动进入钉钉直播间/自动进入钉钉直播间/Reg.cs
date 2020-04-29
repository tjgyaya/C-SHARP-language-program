using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace 自动进入钉钉直播间
{
    class Reg
    {
        /// <summary>
        /// 从注册表获取钉钉安装路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetDingDingPath(out string path)
        {
            string Key = "SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\钉钉";
            string err = null;

            if (!Environment.Is64BitOperatingSystem)
                Key = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\钉钉";


            RegistryKey rk = Registry.LocalMachine;//设定打开“HKEY_LOCAL_MACHINE”分支
            RegistryKey soft = rk.OpenSubKey(Key, false);//打开注册表
            if (soft != null)//如果打开成功
            {
                string val = soft.GetValue("UninstallString").ToString();
                if (val != null)
                {
                    int index;
                    if ((index = val.LastIndexOf("\\")) != -1)//分割路径
                    {
                        string DingPath = val.Substring(0, index + 1) + "DingtalkLauncher.exe";
                        if (File.Exists(DingPath))//判断路径是否存在
                        {
                            path = DingPath;
                            return null;
                        }
                        else
                            err = "未能在注册表寻找到正确的钉钉安装路径！";
                    }
                    else
                        err = "从注册表读取到的钉钉安装路径无效！";
                }
                else
                    err = "从注册表读取键值“UninstallString”失败！";
            }
            else
                err = "打开注册表失败！";


            //从桌面寻找钉钉快捷方式
            string DingDeskPath = "C:\\Users\\Public\\Desktop\\钉钉.lnk";
            if (File.Exists(DingDeskPath))
            {
                path = DingDeskPath;
                return err;
            }
            else
            {
                path = null;
                err += "\n无法获取桌面的钉钉快捷方式！";
                return err;
            }
        }


        [DllImport("ReadOrWriteFile.dll", EntryPoint = "Add", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Add(string Path, string KeyName);
        public static string AddStart(string Path, string KeyName)
        {
            IntPtr p = Add(Path, KeyName);
            if (p != IntPtr.Zero)
            {
                return Marshal.PtrToStringAnsi(p);
            }

            return null;
        }


        [DllImport("ReadOrWriteFile.dll", EntryPoint = "Del", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Del(string KeyName);
        public static string DelStart(string KeyName)
        {
            IntPtr p = Del(KeyName);
            if (p != IntPtr.Zero)
            {
                return Marshal.PtrToStringAnsi(p);
            }

            return null;
        }
    }
}
