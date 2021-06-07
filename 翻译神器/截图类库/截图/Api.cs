using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShot
{
    class Api
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ScreenToClient(IntPtr hWnd, ref POINT pt);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

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

        [DllImport("user32.dll", EntryPoint = "FindWindowExW")]
        public static extern IntPtr FindWindowExW([In()] IntPtr hWndParent, [In()] IntPtr hWndChildAfter, [In()][MarshalAs(UnmanagedType.LPWStr)] string lpszClass, [In()][MarshalAs(UnmanagedType.LPWStr)] string lpszWindow);
        [DllImport("user32.dll", EntryPoint = "GetWindowLongW")]
        public static extern int GetWindowLongW([In()] IntPtr hWnd, int nIndex);
        public const int GWL_STYLE = -16; // 获取窗口样式
        public const int GWL_EXSTYLE = -20;// 获取扩展窗口样式
        public const long WS_POPUP = 0x80000000;// 窗口是一个弹出窗口
        public const long WS_VISIBLE = 0x10000000; // 窗口是一个可见的窗口
        public const long WS_EX_TRANSPARENT = 0x20; // 窗口是一个透明窗口


        /// <summary>
        /// 根据鼠标所在的坐标获取窗口句柄
        /// </summary>
        /// <param name="p">坐标</param>
        /// <param name="exceptHandle">要排除的窗口句柄</param>
        /// <returns></returns>
        public static IntPtr GetWindowHandleByPos(Point p, IntPtr exceptHandle)
        {
            IntPtr parentHandle = IntPtr.Zero;
            IntPtr afterHandle = IntPtr.Zero;
            while ((afterHandle = FindWindowExW(parentHandle, afterHandle, null, null)) != IntPtr.Zero)
            {
                // 如果是排除的窗口句柄，则跳过
                if (afterHandle == exceptHandle)
                    continue;
                // 如果窗口是一个不可见的窗口，则跳过
                if ((Win32.GetWindowLong(afterHandle, GWL_STYLE) & WS_VISIBLE) == 0)
                    continue;
                // 如果窗口是透明窗口，跳过
                if ((Win32.GetWindowLong(afterHandle, GWL_EXSTYLE) & WS_EX_TRANSPARENT) != 0)
                    continue;
                // 一般这种窗体都是隐藏的，但有visible属性
                string className = GetClassNamebyHandle(afterHandle);
                if (className == "Windows.UI.Core.CoreWindow")
                    continue;
                GetWindowRect(afterHandle, out TagRECT rect);// 获取窗口大小
                if (p.X >= rect.left && p.X < rect.right && p.Y >= rect.top && p.Y < rect.bottom)
                {   // 无限查找子窗口里的子窗口
                    parentHandle = afterHandle;
                    afterHandle = IntPtr.Zero;
                }
            }
            return parentHandle;
        }

        public static Rectangle GetWindowRectByHandle(IntPtr hWnd)
        {
            GetWindowRect(hWnd, out TagRECT tagRect);
            return ToRectangle(tagRect);
        }

        public static Rectangle ToRectangle(TagRECT rect) => new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);

        public static string GetClassNamebyHandle(IntPtr hWnd)
        {
            StringBuilder sb = new StringBuilder(260);
            GetClassName(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }
    }
}
