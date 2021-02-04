using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 鹰眼OCR
{
    class Api
    {
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
            public POINT(int x,int y)
            {
                this.X = x;
                this.Y = y;
            }
            public int X;
            public int Y;
        }


        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);// 注册热键


        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);// 释放注册的的热键

        // 获取窗口句柄，并判断是否有效，无效则抛出异常
        public static IntPtr FindWindowHandle(string windowName,string windowClass)
        {
            IntPtr hwnd;
            if (!string.IsNullOrEmpty(windowName))
                hwnd = FindWindow(null, windowName);
            else if (!string.IsNullOrEmpty(windowClass))
                hwnd = FindWindow(windowClass, null);
            else
                throw new Exception("请设置窗口标题或窗口类名！");
            if (IntPtr.Zero == hwnd)
                throw new Exception("找不到对应的窗口句柄！");
            return hwnd;
        }
    }
}
