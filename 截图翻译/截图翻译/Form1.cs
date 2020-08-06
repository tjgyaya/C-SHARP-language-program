using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);// 注册热键

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);// 释放注册的的热键

        public Form1()
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

        private bool EnToZh = true;                  // 翻译模式 英译中、俄译中
        private bool CopySourceTextToClip, CopyDestTextToClip;     // 翻译后是否复制到剪切板（源语言、目标语言）
        private bool Speak;                          // 翻译后是否朗读译文
        private int ShowTime = 5;                    // 翻译后延迟显示翻译后内容的时间
        private string SourceOfTran = "百度翻译";    // 翻译源
        private DateTime Time = DateTime.Now;
        private Thread newThread;                  // 新线程              
        private string Show_cont;                  // 要在ShowCont窗口显示的内容
        private TranMode tranMode;
        private bool[] ShowWindow = { false, false };
        FrmHomePage hp = new FrmHomePage();
        FrmSetting setting = new FrmSetting();


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
            for (int i = 0; i < 4; i++)
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
                hp.TopLevel = false;//取消顶级窗口
                // 设置要显示窗口的父容器为当前的选项卡页
                hp.Parent = ((TabControl)sender).SelectedTab;
                hp.Dock = DockStyle.Fill;
                hp.Show();//显示窗口
            }
            else
            {
                setting.TopLevel = false;//取消顶级窗口
                // 设置要显示窗口的父容器为当前的选项卡页
                setting.Parent = ((TabControl)sender).SelectedTab;
                setting.Dock = DockStyle.Fill;
                setting.Show();//显示窗口
            }
            ShowWindow[((TabControl)sender).SelectedIndex] = true;
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
                for (int i = 0; i < 4; i++)
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
                ShowTime = Convert.ToInt32(FrmSetting.ReadValues[4]);
                // 翻译后是否复制到剪切板
                CopySourceTextToClip = Convert.ToBoolean(FrmSetting.ReadValues[5]);
                CopyDestTextToClip = Convert.ToBoolean(FrmSetting.ReadValues[6]);
                // 翻译后是否朗读译文
                Speak = Convert.ToBoolean(FrmSetting.ReadValues[7]);
                // 翻译源
                SourceOfTran = FrmSetting.ReadValues[8];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


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
            if (!RegisterHotKey(this.Handle, num, (f1 | f2), k)) // 注册热键
            {   // 如果注册失败
                UnregisterHotKey(this.Handle, num); // 卸载已注册的热键
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

            if (m.WParam.ToString() == "1000")      // 截图翻译
            {
                tranMode = TranMode.TranAndShowText;
                StartThread(null);
            }
            else if (m.WParam.ToString() == "1001") // 切换英译中模式
            {
                if (!EnToZh) // 如果当前翻译模式为 俄 译 中
                {
                    Show_cont = "当前翻译模式：英译中";
                    EnToZh = true;
                    tranMode = TranMode.ShowText; // 显示“当前模式：英译中”这句话
                    StartThread(Show_cont);
                }
            }
            else if (m.WParam.ToString() == "1002") // 翻译
            {
                ShowTranForm();
            }
            else if (m.WParam.ToString() == "1003") // 切换俄译中模式
            {
                if (EnToZh) // 如果当前翻译模式为 英 译 中
                {
                    Show_cont = "当前翻译模式：俄译中";
                    EnToZh = false;
                    tranMode = TranMode.ShowText;  // 显示“当前模式：x译中”这句话
                    StartThread(Show_cont);
                }
            }

            // base.WndProc(ref m);
        }


        //切换显示的窗口
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ShowWindow[tabControl1.SelectedIndex])//判断是否打开窗口
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
                    // 显示截图窗口
                    DialogResult result = shot.ShowDialog();
                    // 如果文件不存在，则视为用户取消截图
                    if (!File.Exists(savePath) || result == DialogResult.Cancel)
                        return;

                    // 翻译模式EnToZh=true为英译中，false为俄译中
                    if (EnToZh == false)
                        from = "ru";

                    // SourceOfTran有“有道”两字使用有道翻译，否则使用百度翻译
                    if (SourceOfTran.IndexOf("有道") != -1)
                        Youdao.YoudaoTran(savePath, from, "zh-CHS", out src, out dst);
                    else
                        Baidu.BaiduTran(savePath, from, "zh", out src, out dst);

                    if (CopySourceTextToClip)
                        Clipboard.SetText(src);// 复制原文到剪切板
                    if (CopyDestTextToClip)
                        Clipboard.SetText(dst);// 复制译文到剪切板
                    if (Speak)
                    {
                        SpeechSynthesizer speech = new SpeechSynthesizer();
                        speech.Rate = 3;   // 语速
                        speech.SpeakAsync(dst);
                    }
                }
                else
                {
                    dst = Show_cont;
                }

                // 不为空
                if (!string.IsNullOrEmpty(dst))
                {
                    using (FrmShowCont sc = new FrmShowCont(ShowTime))
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

                using (FrmShowCont sc = new FrmShowCont(ShowTime))
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
            if ((DateTime.Now - Time).TotalMilliseconds < 500)
            {
                Time = DateTime.Now;
                return;
            }
            Time = DateTime.Now;

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
        /// 关闭新线程
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
                FrmTranslate ts = new FrmTranslate(SourceOfTran);
                ts.Show();
            }
            catch
            {
                ;
            }
        }
    }
}
