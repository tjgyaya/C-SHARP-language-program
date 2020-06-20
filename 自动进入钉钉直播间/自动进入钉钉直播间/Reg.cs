using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace 自动进入钉钉直播间
{
    class Reg
    {
        /// <summary>
        /// 从注册表获取钉钉安装路径
        /// </summary>
        /// <returns>返回钉钉安装路径</returns>
        public static string GetDingDingPath()
        {
            // 64位系统注册表路径
            string Key = "SOFTWARE\\WOW6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\钉钉";
            string DingDeskPath;

            // 如果是32位系统
            if (!Environment.Is64BitOperatingSystem)
                Key = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\钉钉";// 32位系统注册表路径

            // 从注册表获取钉钉路径
            RegistryKey key = Registry.LocalMachine.OpenSubKey(Key, false);// 打开注册表
            if (key != null)// 如果打开成功
            {
                string val = key.GetValue("UninstallString").ToString();
                if (val != null)
                {
                    int index;
                    if ((index = val.LastIndexOf("\\")) != -1)// 分割路径
                    {
                        DingDeskPath = val.Substring(0, index + 1) + "DingtalkLauncher.exe";
                        if (File.Exists(DingDeskPath))// 判断路径是否存在
                        {
                            return DingDeskPath;
                        }
                    }
                }
            }

            // 从注册表获取钉钉路径失败时 将会 从桌面获取钉钉快捷方式
            DingDeskPath = "C:\\Users\\Public\\Desktop\\钉钉.lnk";
            if (File.Exists(DingDeskPath))
            {
                return DingDeskPath;
            }
            else
            {
                throw new Exception("无法从注册表获取钉钉路径！\n无法获取桌面的钉钉快捷方式！");
            }
        }



        /// <summary>
        /// 修改注册表添加自启动
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <param name="KeyName">要添加的键值</param>
        /// <returns></returns>
        public static string AddStart(string Path, string KeyName)
        {
            try
            {
                // 打开注册表
                RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                // 判断键值是否存在
                if (key.GetValue(KeyName) != null)
                    key.DeleteValue(KeyName);
                // 设置值
                key.SetValue(KeyName, Path, RegistryValueKind.String);
                key.Close();
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        /// <summary>
        /// 修改注册表删除自启动
        /// </summary>
        /// <param name="KeyName">要删除的键值</param>
        /// <returns></returns>
        public static string DelStart(string KeyName)
        {
            try
            {
                // 打开注册表
                RegistryKey key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                // 删除值
                key.DeleteValue(KeyName);
                key.Close();
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
