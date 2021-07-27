using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShot
{
    public class WindowScreenShot : FrmScreenShot
    {
        public WindowScreenShot() : base(FormWindowState.Normal)
        {

        }
        IntPtr windowHandle;
        /// <summary>
        /// 开始截图(只针对某个窗口截图，而不是全屏截图)
        /// </summary> 
        public override DialogResult Start(IntPtr windowHandle = default)
        {
            this.windowHandle = windowHandle;
            if (windowHandle == IntPtr.Zero)
                throw new ArgumentNullException("窗口句柄为空。");
            Api.ShowWindowWait(windowHandle, Api.SW_SHOWNORMAL, 500);
            Rectangle rect = Api.GetWindowRectByHandle(windowHandle);
            screenImage = CopyScreen(rect.X, rect.Y, rect.Width, rect.Height);// 截取这个窗口的图片
            return this.ShowDialog();// 显示窗口

        }
    }
}
