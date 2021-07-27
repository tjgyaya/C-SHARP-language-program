using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace 翻译神器
{
    class Api
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct TagRECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        [DllImport("user32.dll", EntryPoint = "GetWindowRect")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect([In()] IntPtr hWnd, [Out()] out TagRECT lpRect);


        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int vKey);

        public const int VK_MENU = 0x12;
        public const int VK_CONTROL = 0x17;

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
            public POINT(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X;
            public int Y;
        }

        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        public const int SW_SHOWNORMAL = 1;// 激活并显示窗口。如果窗口最小化或最大化，系统将窗口恢复到其原始大小和位置。

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);// 注册热键


        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);// 释放注册的的热键


        /// <summary>
        /// 获取窗口句柄，并判断是否有效，无效则抛出异常
        /// </summary>
        /// <param name="windowName"></param>
        /// <param name="windowClass"></param>
        /// <returns></returns>
        public static IntPtr FindWindowHandle(string windowName, string windowClass)
        {
            IntPtr hwnd;
            if (!string.IsNullOrEmpty(windowName))
                hwnd = Api.FindWindow(null, windowName);
            else if (!string.IsNullOrEmpty(windowClass))
                hwnd = Api.FindWindow(windowClass, null);
            else
                throw new Exception("请设置窗口标题或窗口类名！");
            if (IntPtr.Zero == hwnd)
                throw new Exception("找不到对应的窗口句柄！");
            return hwnd;
        }

        /// <summary>
        /// 显示窗口并等待waitMillisec毫秒
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="nCmd"></param>
        /// <param name="waitMillisec"></param>
        public static void ShowWindowWait(IntPtr hwnd, int nCmd, int waitMillisec)
        {
            ShowWindow(hwnd, nCmd);
            Thread.Sleep(waitMillisec);
        }
    }
}
