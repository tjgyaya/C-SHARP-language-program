using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 翻译神器
{
    class Api
    {
        [DllImport("user32.dll")]
        public extern static uint MapVirtualKey(uint uCode, uint uMapType);
        
        public const int KEYEVENTF_KEYUP = 0x0002; // 释放按键
        public const int MAPVK_VK_TO_VSC = 0;      // 虚拟密钥代码转换为扫描代码


        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);


        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hwnd);


        [DllImport("user32.dll", EntryPoint = "FindWindow")]// 查找窗口句柄
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);


        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ScreenToClient(IntPtr hWnd, ref POINT pt);


        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT pt); // 屏幕坐标转窗口坐标


        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }


        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);// 注册热键


        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);// 释放注册的的热键
    }
}
