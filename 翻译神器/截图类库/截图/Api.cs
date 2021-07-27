using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShot
{
    class Api
    {
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        [DllImport("user32.dll", EntryPoint = "ClientToScreen")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT pt);
       
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ScreenToClient(IntPtr hWnd, ref POINT pt);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public POINT(Point p)
            {
                X = p.X;
                Y = p.Y;
            }
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

        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();// 获取桌面句柄
        [DllImport("user32.dll")]
        public static extern IntPtr ChildWindowFromPointEx(IntPtr pHwnd, Point pt, uint uFlgs);// 在父窗体中查找子窗体
        private const int CWP_SKIPDISABLED = 0x2;   // 忽略不可用窗体
        private const int CWP_SKIPINVISIBL = 0x1;   // 忽略隐藏的窗体
        private const int CWP_All = 0x0;    //一个都不忽略


        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        public const int SW_SHOWNORMAL = 1;// 激活并显示窗口。如果窗口最小化或最大化，系统将窗口恢复到其原始大小和位置。

        /// <summary>
        /// 根据鼠标所在的坐标获取窗口句柄
        /// </summary>
        /// <param name="mousePoint">鼠标坐标</param>
        /// <param name="form">当前窗体</param>
        /// <returns></returns>
        public static IntPtr GetWindowHandleByPos(Point mousePoint, Form form)
        {
            form.Enabled = false;// 禁用本窗体，防止阻挡其它窗体
            // 在桌面根据鼠标坐标查找窗口（此时被找到的窗口作为父窗口）
            IntPtr parentHwnd = ChildWindowFromPointEx(GetDesktopWindow(), mousePoint, CWP_SKIPDISABLED | CWP_SKIPINVISIBL);
            POINT lp = new POINT(mousePoint);
            IntPtr childHwnd = parentHwnd;
            // 在父窗口中继续查找子窗口句柄，直到为null
            while (true)
            {
                ScreenToClient(childHwnd, ref lp);  // 把屏幕坐标转换为窗口内部坐标
                // 在父窗口中继续查找子窗口句柄
                childHwnd = ChildWindowFromPointEx(childHwnd, new Point(lp.X, lp.Y), CWP_All);
                if (childHwnd == IntPtr.Zero || childHwnd == parentHwnd)
                    break;
                // 将找到的子窗口作为父窗口，继续查找子窗口中的子窗口
                parentHwnd = childHwnd;
                // 更新鼠标坐标
                lp = new POINT(Control.MousePosition);
            }
            form.Enabled = true;
            return parentHwnd;
        }

        /// <summary>
        /// 通过窗体句柄获取窗体矩形
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        public static Rectangle GetWindowRectByHandle(IntPtr hWnd)
        {
            GetWindowRect(hWnd, out TagRECT tagRect);
            return ToRectangle(tagRect);
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

        public static Rectangle ToRectangle(TagRECT rect) => new Rectangle(rect.left, rect.top, rect.right - rect.left, rect.bottom - rect.top);

        public static string GetClassNamebyHandle(IntPtr hWnd)
        {
            StringBuilder sb = new StringBuilder(260);
            GetClassName(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }
    }
}
