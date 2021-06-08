using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;


///////////////////////////////////////////////////////////////////////////////////////////////
//                   非1920x1080分辨率的屏幕可能会卡在“第xx次 检测钉钉是否正在直播”
///////////////////////////////////////////////////////////////////////////////////////////////


namespace 自动进入钉钉直播
{

    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            toolTip1.ShowAlways = true;
            textBox1_log.Text = $"日志...    {DateTime.Now:yyyy-MM-dd}{Environment.NewLine}";
            pictureBox1.Enabled = false;
            pictureBox1.Visible = false;
            // 截图高度和宽度（pictureBox控件存在的意义就是为了获取不同缩放比下的截图区域大小）
            rectCapture.Width = pictureBox1.Width;
            rectCapture.Height = pictureBox1.Height;
        }


        // 日志文件路径
        private readonly string logPath = $"{Application.StartupPath}\\{Application.ProductName}.log";
        // 桌面路径（截图保存到桌面）
        private readonly string deskPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)} \\{Application.ProductName}截图文件";
        // 钉钉窗口类名
        private readonly string dingWindowClassName = "StandardFrame_DingTalk";
        // 钉钉直播窗口类名
        private readonly string dingLiveWindowClassName = "StandardFrame";
        // 钉钉子窗口类名（显示XX群正在直播的那个窗口）
        private readonly string dingChildWindowClassName = "DingChatWnd";
        // 钉钉进程名
        private readonly string dingProcessName = "DingTalk";
        private readonly string dingPathKey = "钉钉路径";

        private Rectangle rectCapture;                   // 截图坐标宽度和高度
        private string dingDingPath;                     // 钉钉安装路径                    
        private bool startFlag;                          // 运行状态（是否启动）
        private bool saveToDesk;                        // 是否将截图保存到桌面
        private OpenMode openMode;

        /// <summary>
        /// 当前运行模式 检测直播是否断开/打开直播
        /// </summary>
        enum OpenMode
        {
            Open,
            Check
        }

        // 钉钉窗口始终显示在最顶层
        private void checkBox11_ShowTop_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11_ShowTop.Checked)
                UpdateLog("顶置钉钉窗口");
            else
            {    // 取消将钉钉窗口显示到最前方
                IntPtr hwnd = Api.FindWindow(dingWindowClassName, null);
                Api.SetWindowPos(hwnd, Api.HWND_NOTOPMOST, 0, 0, 0, 0, Api.SWP_NOMOVE | Api.SWP_NOSIZE);
                UpdateLog("取消顶置钉钉窗口");
            }
        }

        // 添加自启动
        private void button2_AddStart_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取当前exe路径 10是指打开钉钉后等待的时间为10秒
                Reg.AddStart("\"" + Process.GetCurrentProcess().MainModule.FileName + "\" 10", Application.ProductName);
                UpdateLog("添加自启动成功");
            }
            catch (Exception ex)
            {
                UpdateLog(ex.Message);
            }
        }

        // 删除自启动
        private void button3_DelStart_Click(object sender, EventArgs e)
        {
            try
            {
                Reg.DelStart("自动进入钉钉直播");
                UpdateLog("删除自启动成功");
            }
            catch (Exception ex)
            {
                UpdateLog(ex.Message);
            }
        }

        // 将截图保存到桌面
        private void checkBox12_SaveToDesk_CheckedChanged(object sender, EventArgs e) => saveToDesk = checkBox12_SaveToDesk.Checked;

        // 阻止系统休眠
        private void checkBox13_preventSleep_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13_preventSleep.Checked) // 调用api函数阻止系统休眠
            {
                if (Api.SetThreadExecutionState(Api.ES_CONTINUOUS | Api.ES_SYSTEM_REQUIRED | Api.ES_DISPLAY_REQUIRED) == 0)
                    UpdateLog("阻止系统休眠 失败");
                else
                    UpdateLog("阻止系统休眠已生效");
            }
            else
            {
                if (Api.SetThreadExecutionState(Api.ES_CONTINUOUS) == 0)
                    UpdateLog("取消阻止系统休眠 失败");
                else
                    UpdateLog("已取消阻止系统休眠");
            }
        }

        // 将日志显示到textbox控件
        private void UpdateLog(string log)
        {
            // 将要显示的内容添到textBox末尾
            textBox1_log.AppendText($"{DateTime.Now:HH:mm:ss}    {log}{Environment.NewLine}");
        }

        // 将日志写入文件
        private void textBox1_log_TextChanged(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(logPath, textBox1_log.Text, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                UpdateLog($"将日志写入文件 失败{Environment.NewLine}原因：{ex.Message}");
            }
        }

        // 通过右上角“X”退出软件时
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) => Exit();

        // 退出软件
        private void Exit()
        {
            notifyIcon1.Dispose();  // 释放notifyIcon1的所有资源，保证托盘图标在程序关闭时立即消失
            if (checkBox13_preventSleep.Checked)// 如果设置了阻止系统休眠
                Api.SetThreadExecutionState(Api.ES_CONTINUOUS);// 清除执行状态标志以禁用离开模式并允许系统空闲以正常睡眠
        }

        // 设置黑暗模式
        private void SetDarkMode()
        {
            // 如果当前目录存在NO这个文件，则在19点及19点后启动本软件不会启用深色模式
            if (!File.Exists(Path.Combine(Application.StartupPath + "\\", "NO")) && !File.Exists(Path.Combine(Application.StartupPath + "\\", "no")))
            {
                if (DateTime.Compare(DateTime.Now, DateTime.Parse("19:00:00")) >= 0 || DateTime.Compare(DateTime.Now, DateTime.Parse("06:00:00")) < 0)
                {
                    groupBox1.BackColor = SystemColors.ControlDark;
                    groupBox2.BackColor = SystemColors.ControlDark;
                    this.BackColor = SystemColors.ControlDark;
                    button5_start.BackColor = SystemColors.ActiveBorder;
                }
            }
        }

        // 自动更新
        private void AutoUpdate()
        {
            using (var autoUpdate = new AutoUpdateForm())
            {
                if (autoUpdate.GetUpdate())
                {
                    if (autoUpdate.ShowDialog() == DialogResult.Cancel)
                        this.Text += "  有新版本*";
                }
            }
        }

        //加载窗口时读取配置文件
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += "V" + Application.ProductVersion.Remove(Application.ProductVersion.Length - 4);
            try
            {
                if (File.Exists(ConfigFile.ConfigPath))
                {
                    string tmp = ConfigFile.ReadFile(checkBox11_ShowTop.Text);
                    checkBox11_ShowTop.Checked = Convert.ToBoolean(tmp);
                    tmp = ConfigFile.ReadFile(checkBox13_preventSleep.Text);
                    checkBox13_preventSleep.Checked = Convert.ToBoolean(tmp);
                    dingDingPath = ConfigFile.ReadFile(dingPathKey);
                }
            }
            catch
            {
                UpdateLog("配置文件数据有误");
            }
            try
            {
                AutoUpdate();
            }
            catch (Exception ex)
            {
                UpdateLog(ex.Message);
            }
        }

        private void Form1_Shown(object sender, EventArgs e) => Start();

        // 点击任务栏托盘图标时显示窗口
        private void notifyIcon1_Click(object sender, EventArgs e) => Show();

        // 自定义文字识别Key
        private void button1_SetOCRKey_Click(object sender, EventArgs e)
        {
            FrmSetOCRKey setOCRKey = new FrmSetOCRKey(this.Location.X + this.Width / 2, this.Location.Y + this.Height / 2);
            try
            {
                setOCRKey.Show();
            }
            catch (Exception ex)
            {
                setOCRKey.Close();
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 自定义文字识别关键字
        private void button2_SetOCRKeyWord_Click(object sender, EventArgs e)
        {
            FrmSetKeyWord keyWord = new FrmSetKeyWord(this.Location.X + this.Width / 2, this.Location.Y + this.Height / 2);
            try
            {
                keyWord.Show();
            }
            catch (Exception ex)
            {
                keyWord.Close();
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 启动
        private void button5_Start_Click(object sender, EventArgs e) => Start();

        private void Start()
        {
            timer1.Interval = 100;
            openMode = OpenMode.Open;
            startFlag = !startFlag;
            timer1.Enabled = startFlag;
            button5_start.Text = startFlag ? "停止" : "开启";
        }

        // timer1检测直播是否断开
        private void timer1_Tick(object sender, EventArgs e)
        {
            string identifyType;
            try
            {
                if (openMode == OpenMode.Open)
                {
                    OpenDingDing();
                    if (!LiveIsOn(out identifyType))
                    {
                        UpdateLog("直播未开启...");
                        return;
                    }
                    OpenLive();
                    openMode = OpenMode.Check;
                    return;
                }
                // 如果启用将钉钉窗口显示到最顶层
                if (checkBox11_ShowTop.Checked)
                {
                    ShowWindow(dingWindowClassName);
                    Thread.Sleep(200);
                }
                UpdateLog("检测直播是否断开...");
                // 如果 钉钉直播窗口句柄 不存在，则截图并判断图片中的（rgb或文字）是否含有钉钉正在直播时的（rgb或关键字）
                if (!LiveIsOn(out identifyType))
                {
                    UpdateLog($"({identifyType})检测到直播断开");
                    openMode = OpenMode.Open;
                }
            }
            catch (Exception ex)
            {
                UpdateLog(ex.Message);
            }
        }

        // 将指定窗口显示到最前方
        private void ShowWindow(string className)
        {
            // 查找窗口句柄
            IntPtr hwnd = Api.FindWindow(className, null);
            // 将指定窗口显示到最前方
            if (Api.SetWindowPos(hwnd, Api.HWND_TOPMOST, 0, 0, 0, 0, Api.SWP_NOMOVE | Api.SWP_NOSIZE) == 0)
                UpdateLog("将钉钉窗口显示在最前方 失败");
        }

        #region 打开网址
        private void label20_Click(object sender, EventArgs e) => Process.Start("https://www.52pojie.cn/thread-1168398-3-1.html");
        private void label19_Click(object sender, EventArgs e) => Process.Start("https://fuhohua.gitee.io");
        private void label25_Click(object sender, EventArgs e) => Process.Start("http://mail.qq.com/cgi-bin/qm_share?t=qm_mailme&email=XW5pb2VvbG9sZWgdLCxzPjIw");
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("https://shimo.im/docs/b8467ba8b9db4e29/");
        #endregion

        // 打开钉钉
        private void OpenDingDing()
        {
            if (timer1.Interval != 10000)
                timer1.Interval = 10000;
            try
            {
                if (!File.Exists(dingDingPath))
                {
                    dingDingPath = Reg.GetdingDingPath();// 获取钉钉路径
                    UpdateLog("获取钉钉路径成功");
                    if (File.Exists(dingDingPath))
                        ConfigFile.WriteFile(dingPathKey, dingDingPath);
                }
                if (!File.Exists(dingDingPath))
                    throw new Exception("钉钉路径无效！");
                Process.Start(dingDingPath);// 打开钉钉
                UpdateLog("正在打开钉钉...");
                // 等待钉钉进程
                for (int i = 1; i <= 100; i++)
                {
                    if (DingDingIsRun())
                        break;
                    else if (i == 100)                     // 5分钟都未找到
                        throw new Exception("未找到钉钉进程"); // 抛出异常
                    Thread.Sleep(3000);                        // 如未找到则等待3秒再查找
                }
                UpdateLog("已找到钉钉进程");
            }
            catch (Exception ex)
            {
                UpdateLog(ex.Message);
            }
        }

        // 打开直播
        private void OpenLive()
        {
            // 获取鼠标光标位置
            Api.GetCursorPos(out Api.POINT p);
            // 模拟鼠标左键按下  
            for (int i = 0; i < 30; i++)
            {
                // 第N次点击
                // 鼠标点击坐标 = 钉钉子窗口坐标 + i（加i为了提高准确率）
                rectCapture.Location = GetScreenPos();
                // 设置鼠标光标位置
                Api.SetCursorPos(rectCapture.X + i, rectCapture.Y + i);
                Api.mouse_event(Api.MOUSEEVENTF_LEFTDOWN | Api.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                // 恢复鼠标原来的位置
                Api.SetCursorPos(p.X, p.Y);
                // 查找钉钉直播窗口类名，如果找到，则已打开直播
                if (Api.FindWindow("StandardFrame", null) != IntPtr.Zero)
                {
                    UpdateLog("已打开直播");
                    return;
                }
                Thread.Sleep(300);
            }
            UpdateLog("无法打开直播");
        }

        // 判断直播是否打开（也就是判断截图保存的图片中的rgb是否含有钉钉正在直播时的rgb）
        private bool LiveIsOn(out string identifyType)
        {
            identifyType = "other";
            Bitmap bit = null;
            Action<string> updateLog = new Action<string>(UpdateLog);
            // 判断直播窗口句柄是否存在（直播窗口句柄存在则说明当前直播未断开，就不需要通过截图来判断直播是否断开） 
            if (Api.FindWindow(dingLiveWindowClassName, null) != IntPtr.Zero)
                return true;
            try
            {
                rectCapture.Location = GetScreenPos(); // 获取截图坐标
                bit = ScreenCapture.Screenshot(rectCapture); // 截取指定坐标图片
                // 如果打开截图保存到桌面
                if (saveToDesk)
                {
                    string path = $"{deskPath}\\自动进入钉钉直播截图_{DateTime.Now:yyyy-MM-dd HH_mm_ss}.bmp";
                    bit.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
                }
                // 判断图片中的rgb是否含有钉钉正在直播时的rgb
                if (ScreenCapture.Is_LiveRgb(bit))
                {
                    identifyType = "RGB";
                    return true;
                } // 如果RGB判断未成功则通过OCR文字识别判断关键字
                else if (OCR.Is_Live(bit))
                {
                    identifyType = "OCR";
                    return true;
                }
            }
            catch (Exception ex)
            {
                this.Invoke(updateLog, ex.Message);
            }
            finally
            {
                bit?.Dispose();
            }
            return false;
        }

        // 获取钉钉子窗口坐标（钉钉子窗口坐标=鼠标点击坐标=截图坐标）
        private Point GetScreenPos()
        {
            IntPtr hwnd = Api.FindWindow(dingWindowClassName, null);
            // 查找钉钉窗口句柄
            if (hwnd == IntPtr.Zero)
                throw new Exception("获取钉钉窗口句柄失败");
            // 查找子窗口句柄（显示XX群正在直播的那个窗口）
            IntPtr childHandle = Api.FindWindowEx(hwnd, IntPtr.Zero, dingChildWindowClassName, string.Empty);
            if (childHandle == IntPtr.Zero)
                throw new Exception("获取截图区域句柄失败");
            // 查找子窗口坐标相对于屏幕的坐标
            if (!Api.ClientToScreen(childHandle, out Api.POINT p))
                throw new Exception("获取截图区域坐标失败");
            return new Point(p.X, p.Y);
        }

        // 判断钉钉是否在运行
        private bool DingDingIsRun()
        {
            bool find = false;
            // 寻找钉钉进程，判断钉钉是否在运行
            foreach (Process pro in Process.GetProcesses())
            {
                if (pro.ProcessName.ToLower() == dingProcessName.ToLower())
                {
                    find = true;
                    break;
                }
            }
            return find;
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal; // 窗体恢复正常大小
            this.ShowInTaskbar = true;                 // 在任务栏中显示
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e) => Exit();

        private void button_DelConfig_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(ConfigFile.ConfigPath);
                UpdateLog("删除成功");
            }
            catch (Exception ex)
            {
                UpdateLog(ex.Message);
            }
        }

        private void button_SaveConfig_Click(object sender, EventArgs e)
        {
            ConfigFile.WriteFile(checkBox11_ShowTop.Text, checkBox11_ShowTop.Checked.ToString());
            ConfigFile.WriteFile(checkBox13_preventSleep.Text, checkBox13_preventSleep.Checked.ToString());
            ConfigFile.WriteFile(dingPathKey, dingDingPath);
            UpdateLog("保存成功");
        }
    }
}
