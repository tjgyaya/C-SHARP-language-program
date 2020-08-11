using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace 自动进入钉钉直播
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // 删除配置文件
            if (args.Length > 0 && args[0] == "del")
            {
                try
                {
                    string configFileDir = Path.Combine(Environment.GetEnvironmentVariable("APPDATA"), "自动进入钉钉直播间");
                    if (Directory.Exists(configFileDir))
                    {
                        Directory.Delete(configFileDir, true);
                        MessageBox.Show("删除配置文件成功！", "自动进入钉钉直播间", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("未找到配置文件！", "自动进入钉钉直播间", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Environment.Exit(0);// 退出
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除配置文件失败！\n原因：" + ex.Message, "删除配置文件失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(-1);// 退出
                }
            }

            if (!IsRun())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                //已经有一个实例在运行      
                MessageBox.Show("当前程序已经在运行！", "自动进入钉钉直播间", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(-1);
            }
        }


        /// <summary>
        /// 判断当前实例是否已经运行
        /// </summary>
        /// <returns></returns>
        private static bool IsRun()
        {
            Process current = Process.GetCurrentProcess();
            //遍历进程列表
            foreach (var p in Process.GetProcessesByName(current.ProcessName))
            {
                if (p.Id != current.Id)//如果实例已经存在则忽略当前进程   
                {
                    //判断要打开的进程和已经存在的进程是否来自同一路径                                                                                                                        
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
