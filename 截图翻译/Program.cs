using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace 截图翻译
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
          //  string str = File.ReadAllText(@"C:\Users\Administrator\Desktop\1.txt");
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
            //Application.Run(new Translate("百度翻译"));
            //ShowCont s = new ShowCont(5);
            //s.ContText(str);
            //Application.Run(s);
            //Application.Run(new ScreenShot(@"C:\Users\Administrator\Desktop\1.bmp"));
        }
    }
}
