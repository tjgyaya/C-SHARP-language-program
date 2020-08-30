using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 截图翻译
{
    public partial class FrmMain : Form
    {
        // **************************************主窗口**************************************
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]// 查找窗口句柄
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT pt); // 屏幕坐标转窗口坐标
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);// 注册热键

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);// 释放注册的的热键

        const int hotKeyNum = 5;                                         // 要注册的热键个数


        public FrmMain()
        {
            InitializeComponent();

            // 显示窗口
            MenuItem show = new MenuItem("显示");
            show.Click += new EventHandler(ShowWin);
            // 隐藏窗口
            MenuItem hide = new MenuItem("隐藏");
            hide.Click += new EventHandler(HideWin);
            // 退出菜单项  
            MenuItem exit = new MenuItem("退出");
            exit.Click += new EventHandler(Exit);
            // 关联托盘控件  
            MenuItem[] childen = new MenuItem[] { show, hide, exit };
            notifyIcon1.ContextMenu = new ContextMenu(childen);
            notifyIcon1.Text = "点击此处显示窗口";
        }


        private Rectangle screenRect = new Rectangle();// 固定截图坐标
        private bool isEnToZh = true;                // 翻译模式 英译中、俄译中
        private bool isSpeak;                        // 翻译后是否朗读译文
        private bool isFixedScreen;                  // 是否为固定截图翻译
        private bool copySourceTextToClip, copyDestTextToClip;     // 翻译后是否复制到剪切板（源语言、目标语言）
        private int showTime = 5;                    // 翻译后延迟显示翻译后内容的时间（单位：秒）
        private string sourceOfTran = "百度翻译";    // 翻译来源（可选 百度 或 有道）
        private DateTime lastTime = DateTime.Now;    // 记录上次热键按下时间，避免多次按下热键造成卡死闪退
        private Thread newThread;                    // 新线程              
        private string showCont;                    // 要在ShowCont窗口显示的内容
        private TranMode tranMode;                   // 翻译模式（截图翻译并显示 或 不截图翻译只显示）
        private bool[] showWindow = { false, false };// 当前显示的窗口
        FrmHomePage homePage = new FrmHomePage();    // 主页窗口
        FrmSetting setting = new FrmSetting();       // 设置窗口

        // 翻译模式（tran：截图翻译并显示，show：不截图翻译只显示）
        enum TranMode
        {
            TranAndShowText,
            ShowText,
        }

        private void ShowWin(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal; // 窗体恢复正常大小
        }


        private void HideWin(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void Exit(object sender, EventArgs e)
        {
            for (int i = 0; i < hotKeyNum; i++)
            {
                UnregisterHotKey(this.Handle, 1000 + i); // 卸载热键
            }
            CloseThread(false);     // 关闭线程
            notifyIcon1.Dispose();  // 释放notifyIcon1的所有资源，保证托盘图标在程序关闭时立即消失
            this.Dispose();
            Environment.Exit(0);    // 退出
        }


        // 将窗体显示到tabControl1
        private void CreateForm(string form, object sender)
        {
            if (form == "首页")
            {
                homePage.TopLevel = false;//取消顶级窗口
                // 设置要显示窗口的父容器为当前的选项卡页
                homePage.Parent = ((TabControl)sender).SelectedTab;
                homePage.Dock = DockStyle.Fill;
                homePage.Show();//显示窗口
            }
            else
            {
                setting.TopLevel = false;//取消顶级窗口
                // 设置要显示窗口的父容器为当前的选项卡页
                setting.Parent = ((TabControl)sender).SelectedTab;
                setting.Dock = DockStyle.Fill;
                setting.Show();//显示窗口
            }
            showWindow[((TabControl)sender).SelectedIndex] = true;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            CreateForm("首页", tabControl1);

            // 判断文件是否存在
            if (!File.Exists(ConfigFile.ConfigPath))
            {
                MessageBox.Show("请先设定热键！", "截图翻译", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // 读取配置文件
                ConfigFile.ReadFile(FrmSetting.Names, ref FrmSetting.ReadValues);

                // 注册热键
                for (int i = 0; i < hotKeyNum; i++)
                {
                    Keys key;
                    uint fun1 = 0, fun2 = 0;

                    if (string.IsNullOrEmpty(FrmSetting.ReadValues[i]))
                        continue;

                    // 如果热键为空
                    string[] arr = FrmSetting.ReadValues[i].Split(',');

                    // 前一个键为单键（a-z）
                    key = (Keys)Enum.Parse(typeof(Keys), arr[0], true);
                    if (arr.Length == 3) // 三个键
                    {
                        // 后两个键为功能键（ctrl、alt...）
                        fun1 = GetKeyVal(arr[1]);
                        fun2 = GetKeyVal(arr[2]);
                    }
                    if (arr.Length == 2)// 两个键
                    {
                        // 后一个键为功能键（ctrl、alt...）
                        fun1 = GetKeyVal(arr[1]);
                    }
                    // 如果只有一个键就取第一个键就好了key = arr[0];
                    RegHotKey(fun1, fun2, key, 1000 + i);
                }

                // 翻译后延迟显示的时间（秒）
                showTime = Convert.ToInt32(FrmSetting.ReadValues[5]);
                // 翻译后是否复制到剪切板
                copySourceTextToClip = Convert.ToBoolean(FrmSetting.ReadValues[6]);
                copyDestTextToClip = Convert.ToBoolean(FrmSetting.ReadValues[7]);
                // 翻译后是否朗读译文
                isSpeak = Convert.ToBoolean(FrmSetting.ReadValues[8]);
                // 翻译源
                sourceOfTran = FrmSetting.ReadValues[9];
                // 固定截图翻译坐标
                screenRect.X = Convert.ToInt32(FrmSetting.ReadValues[10]);
                screenRect.Y = Convert.ToInt32(FrmSetting.ReadValues[11]);
                screenRect.Width = Convert.ToInt32(FrmSetting.ReadValues[12]);
                screenRect.Height = Convert.ToInt32(FrmSetting.ReadValues[13]);
            }
            catch
            {
                MessageBox.Show("加载配置文件错误，请重新设置！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // 获取功能键键值
        private uint GetKeyVal(string key)
        {
            switch (key.Trim().ToLower())
            {
                case "alt":
                    return 0x0001;
                case "control":
                    return 0x0002;
                case "shift":
                    return 0x0004;
                case "win":
                    return 0x0008;
            }
            return 0;
        }


        private void RegHotKey(uint f1, uint f2, Keys k, int num)
        {
            if (!RegisterHotKey(this.Handle, num, f1 | f2, k)) // 注册热键
            {   // 如果注册失败
                throw new Exception("注册热键失败！");
            }
        }


        // 通过监视系统消息，判断是否按下热键
        protected override void WndProc(ref Message m)
        {
            if (m.Msg != 0x0312)                    // 如果m.Msg的值为0x0312那么表示用户按下了热键
            {
                base.WndProc(ref m);
                return;
            }

            base.WndProc(ref m);

            switch (m.WParam.ToString())
            {
                case "1000": // 截图翻译
                    {
                        isFixedScreen = false;
                        tranMode = TranMode.TranAndShowText;
                        StartThread(null);
                        this.WindowState = FormWindowState.Minimized;
                        break;
                    }
                case "1001": // 切换英译中模式
                    {
                        if (!isEnToZh) // 如果当前翻译模式为 俄 译 中
                        {
                            showCont = "当前翻译模式：英译中";
                            isEnToZh = true;
                            tranMode = TranMode.ShowText; // 显示“当前模式：英译中”这句话
                            StartThread(showCont);
                        }
                        break;
                    }
                case "1002": // 翻译
                    {
                        ShowTranForm();
                        break;
                    }
                case "1003": // 切换俄译中模式
                    {
                        if (isEnToZh) // 如果当前翻译模式为 英 译 中
                        {
                            showCont = "当前翻译模式：俄译中";
                            isEnToZh = false;
                            tranMode = TranMode.ShowText;  // 显示“当前模式：x译中”这句话
                            StartThread(showCont);
                        }
                        break;
                    }
                case "1004": // 固定区域截图翻译
                    {
                        isFixedScreen = true;
                        tranMode = TranMode.TranAndShowText;
                        StartThread(null);
                        this.WindowState = FormWindowState.Minimized;
                        break;
                    }
            }

            // base.WndProc(ref m);
        }


        //切换显示的窗口
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!showWindow[tabControl1.SelectedIndex])//判断是否打开窗口
                CreateForm(((TabControl)sender).SelectedTab.Text.ToString(), sender);
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Exit(null, null);
        }

        

        // 截图翻译
        private void ScreenTran()
        {
            string savePath = DateTime.Now.ToString("yyyy-dd-MM_HH_mm_ss") + ".bmp";
            string from = "en", src, dst = null;

            FrmScreenShot shot = new FrmScreenShot(savePath, true);

            try
            {   // 截图翻译并显示
                if (tranMode == TranMode.TranAndShowText)
                {
                    Thread.Sleep(200);

                    // 如果是固定区域翻译（isFixedScreen = true则视为固定区域翻译）
                    if (isFixedScreen == true)
                    {
                        if (screenRect.Width <= 0 || screenRect.Height <= 0)
                            throw new Exception("请设置固定截图翻译坐标！");

                        IntPtr hwnd = FindWindow("grcWindow", null);
                        if (IntPtr.Zero == hwnd)
                            throw new Exception("找不到GTA窗口句柄");

                        POINT p = new POINT();
                        p.X = screenRect.X;
                        p.Y = screenRect.Y;
                        ClientToScreen(hwnd, ref p);
                        Screenshot(savePath, p.X, p.Y, screenRect.Width, screenRect.Height);

                        // 如果文件不存在，则视为截图失败
                        if (!File.Exists(savePath))
                            throw new Exception("固定区域截图失败！");
                    }
                    else
                    {
                        // 显示截图窗口
                        DialogResult result = shot.ShowDialog();

                        // 如果文件不存在，则视为用户取消截图
                        if (!File.Exists(savePath) || result == DialogResult.Cancel)
                            return;
                    }

                    // 翻译模式isEnToZh=true为英译中，false为俄译中
                    if (isEnToZh == false)
                        from = "ru";

                    // sourceOfTran有“有道”两字使用有道翻译，否则使用百度翻译
                    if (sourceOfTran.IndexOf("有道") != -1)
                        Youdao.YoudaoTran(savePath, from, "zh-CHS", out src, out dst);
                    else
                        Baidu.BaiduTran(savePath, from, "zh", out src, out dst);

                    if (copySourceTextToClip)
                        Clipboard.SetText(src);// 复制原文到剪切板
                    if (copyDestTextToClip)
                        Clipboard.SetText(dst);// 复制译文到剪切板
                    if (isSpeak)
                    {
                        SpeechSynthesizer speech = new SpeechSynthesizer();
                        speech.Rate = 3;   // 语速
                        speech.SpeakAsync(dst);
                    }
                }
                else
                {
                    dst = showCont;
                }

                // 不为空
                if (!string.IsNullOrEmpty(dst))
                {
                    using (FrmShowCont sc = new FrmShowCont(showTime))
                    {
                        sc.ContText(dst);
                        sc.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.GetType().FullName == "System.Threading.ThreadAbortException")
                    return;

                dst = "错误：" + ex.Message;
                // 显示错误
                using (FrmShowCont sc = new FrmShowCont(showTime))
                {
                    sc.ContText(dst);
                    sc.ShowDialog();
                }
            }
            finally
            {
                if (File.Exists(savePath))
                    File.Delete(savePath);

                if (shot != null && !shot.IsDisposed)
                    shot.Dispose();
            }
        }


        private void StartThread(string cont)
        {
            // 如果此次按热键的时间距离上次不足300毫秒则忽略掉
            if ((DateTime.Now - lastTime).TotalMilliseconds < 500)
            {
                lastTime = DateTime.Now;
                return;
            }
            lastTime = DateTime.Now;

            // 显示提示内容
            if (cont != null)
            {   // 如果当前线程未关闭，并且将要关闭的这个线程不为 显示模式（tranMode=TranMode.TranAndShowText）
                if (CloseThread(true) && tranMode != TranMode.ShowText)
                    return;
            }

            // 如果线程正在运行则结束
            if (CloseThread(false))
                Thread.Sleep(80);

            // 启动线程
            newThread = new Thread(ScreenTran);
            newThread.SetApartmentState(ApartmentState.STA);
            newThread.Start();
        }


        /// <summary>
        /// 关闭线程
        /// </summary>
        /// <param name="checkState">此项为true则只返回线程的运行状态</param>
        /// <returns></returns>
        private bool CloseThread(bool checkState)
        {
            if (newThread != null)  // 如果线程还在运行
            {
                if ((newThread.ThreadState & (ThreadState.Stopped | ThreadState.Unstarted)) == 0)
                {
                    if (checkState == false)
                        newThread.Abort(); // 关闭线程
                    return true;
                }
            }
            return false;
        }


        // TranslateForm
        public static int AutoPressKey { get; set; }
        public static int TranDestLang { get; set; }
        public static bool AutoSend { get; set; }

        // 显示翻译窗口
        private void ShowTranForm()
        {
            try
            {
                FrmTranslate ts = new FrmTranslate(sourceOfTran);
                ts.Show();
            }
            catch
            {
                ;
            }
        }


        /// <summary>
        /// 从指定坐标截取指定大小区域
        /// </summary>
        /// <param name="x">左上角横坐标</param>
        /// <param name="y">左上角纵坐标</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public static void Screenshot(string savePath, int x, int y, int width, int height)
        {
            Bitmap bit = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bit);

            try
            {
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.CopyFromScreen(x, y, 0, 0, new Size(width, height));
                bit.Save(savePath, ImageFormat.Bmp);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                g.Dispose();
                bit.Dispose();
            }
        }
    }
}
