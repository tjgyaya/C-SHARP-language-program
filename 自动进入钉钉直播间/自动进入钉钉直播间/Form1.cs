using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;


///////////////////////////////////////////////////////////////////////////////////////////////
//                   非1920x1080分辨率的屏幕可能会卡在“第xx次 检测钉钉是否正在直播”
///////////////////////////////////////////////////////////////////////////////////////////////


namespace 自动进入钉钉直播间
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDown1_CheckLiveTime.Enabled = false;
            numericUpDown2_StopCheckLiveTime.Enabled = false;
            numericUpDown3.Enabled = false;
            label1.Enabled = false;
            label21.Enabled = false;
            label23.Enabled = false;
            toolTip1.ShowAlways = true;

            for (int i = 0; i < 24; i++)
            {
                comboBox1.Items.Add(i.ToString().PadLeft(2, '0'));
                comboBox3.Items.Add(i.ToString().PadLeft(2, '0'));
                comboBox5.Items.Add(i.ToString().PadLeft(2, '0'));
                comboBox7.Items.Add(i.ToString().PadLeft(2, '0'));
                comboBox9.Items.Add(i.ToString().PadLeft(2, '0'));
                comboBox11.Items.Add(i.ToString().PadLeft(2, '0'));
                comboBox13.Items.Add(i.ToString().PadLeft(2, '0'));
                comboBox15.Items.Add(i.ToString().PadLeft(2, '0'));
            }

            for (int i = 0; i < 60; i++)
            {
                comboBox2.Items.Add(i.ToString().PadLeft(2, '0'));
                comboBox4.Items.Add(i.ToString().PadLeft(2, '0'));
                comboBox6.Items.Add(i.ToString().PadLeft(2, '0'));
                comboBox8.Items.Add(i.ToString().PadLeft(2, '0'));
                comboBox10.Items.Add(i.ToString().PadLeft(2, '0'));
                comboBox12.Items.Add(i.ToString().PadLeft(2, '0'));
                comboBox14.Items.Add(i.ToString().PadLeft(2, '0'));
                comboBox16.Items.Add(i.ToString().PadLeft(2, '0'));
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            comboBox9.SelectedIndex = 0;
            comboBox10.SelectedIndex = 0;
            comboBox11.SelectedIndex = 0;
            comboBox12.SelectedIndex = 0;
            comboBox13.SelectedIndex = 0;
            comboBox14.SelectedIndex = 0;
            comboBox15.SelectedIndex = 0;
            comboBox16.SelectedIndex = 0;

            CheckBoxEnable(false);// 将所有CheckBox复选框设置为未启用
            ComboBoxEnable(false);// 将所有ComboBox列表设置为未启用
            LabelEnable(false);   // 将所有label设置为未启用

            // 显示窗口
            MenuItem show = new MenuItem("显示");
            show.Click += new EventHandler(Show);
            // 退出菜单项  
            MenuItem exit = new MenuItem("退出");
            exit.Click += new EventHandler(Exit);
            // 关联托盘控件  
            MenuItem[] childen = new MenuItem[] { show, exit };
            notifyIcon1.ContextMenu = new ContextMenu(childen);
            notifyIcon1.Text = "自动进入钉钉直播间\r\n点击此处显示窗口";

            // 日志框只读属性
            textBox1_log.ReadOnly = true;
            textBox1_log.Text = "日志...    " + DateTime.Now.ToString("yyyy-MM-dd") + Environment.NewLine;

            ScreenshotX = 132;
            ScreenshotY = 102;
            ScreenshotW = 165;
            ScreenshotH = 30;
        }

        // 配置文件路径
        private string iniDir = Environment.GetEnvironmentVariable("APPDATA") + @"\自动进入钉钉直播间";
        private string iniPath = Environment.GetEnvironmentVariable("APPDATA") + @"\自动进入钉钉直播间\自动进入钉钉直播间.ini";
        private string logPath = Application.StartupPath + "\\自动进入钉钉直播间.log"; // 日志文件路径
        // 桌面路径（截图保存到桌面）
        private string DeskPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\自动进入钉钉直播间截图文件";
        // 钉钉窗口类名
        private string DingDingWindowClass = "StandardFrame_DingTalk";
        // 钉钉直播窗口类名
        private string DingDingLiveWindowClass = "StandardFrame";

        // 截图相对坐标
        public int RelPosX { get; set; }
        public int RelPosY { get; set; }

        // 默认截图坐标
        public int ScreenshotX { get; set; }
        public int ScreenshotY { get; set; }

        // 截图宽度和高度
        public int ScreenshotW { get; set; }
        public int ScreenshotH { get; set; }

        // 当前缩放比
        public float DpiY { get; set; }
        public float DpiX { get; set; }

        // 配置文件版本
        public string CurrentVersion { get; set; }

        // 自定义截图是否成功
        public bool CustScreenSuccess { get; set; }


        private int MouseClickX = 214, MouseClickY = 109;// 默认鼠标点击坐标
        private string DingDingPath;                     // 钉钉安装路径
        private string identifyType;                     // 图片识别类型
        private int element = 0, first = 0;              // 当前使用的自定义时间数组 元素下标
        private Thread newThread;                        // 新线程
        private bool start = false;                      // 运行状态（是否启动）
        private bool saveToDesk = false;                 // 是否将截图保存到桌面
        private bool delScreenFile = false, delConfigFile = false; // 是否点击了“删除自定义截图配置文件”或“删除配置文件”按钮
        private bool FirstUse = false;                   // 是否是第一次使用（配置文件不存在则为第一次）
        private bool noCloseTimer5 = false;              // 不关闭timer5控件

        // 钉钉窗口始终显示在最顶层
        private void checkBox11_ShowTop_Click(object sender, EventArgs e)
        {
            IntPtr hwnd = FindWindow(DingDingWindowClass, null);
            // 查找钉钉窗口句柄
            if (hwnd == IntPtr.Zero)
            {
                RefLog("获取钉钉窗口句柄失败");
                return;
            }

            if (!checkBox11_ShowTop.Checked)
            {
                checkBox11_ShowTop.Checked = true;
                // SetWindowPos(hwnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
                // RefLog("设置成功，可能需要退出钉钉并重启本软件后才会生效");
            }
            else
            {
                checkBox11_ShowTop.Checked = false;
                timer5.Enabled = false;
                SetWindowPos(hwnd, -2, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE);
            }
        }
        private void checkBox11_ShowTop_CheckedChanged(object sender, EventArgs e)
        {
            if (start && checkBox11_ShowTop.Checked)
            {
                timer5.Enabled = checkBox11_ShowTop.Checked;
                RefLog("钉钉显示在最前方设置成功，立即生效");
            }
            else if (!start && checkBox11_ShowTop.Checked)
                RefLog("钉钉显示在最前方设置成功，点击开启按钮后生效");
            else if (!checkBox11_ShowTop.Checked)
                RefLog("已取消将钉钉窗口显示在最前方");
        }

        // 添加自启动
        private void button2_AddStart_Click(object sender, EventArgs e)
        {
            // 获取当前exe路径
            string err = Reg.AddStart("\"" + Process.GetCurrentProcess().MainModule.FileName + "\"", "自动进入钉钉直播间");
            if (err != null)
                RefLog(err);
            else
                RefLog("添加自启动成功");
        }

        // 删除自启动
        private void button3_DelStart_Click(object sender, EventArgs e)
        {
            string err = Reg.DelStart("自动进入钉钉直播间");
            if (err != null)
                RefLog(err);
            else
                RefLog("删除自启动成功");
        }

        // 删除自定义截图数据
        private void button4_DelCustomScreenshot_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(iniPath))
                {
                    RefLog("未找到自定义截图区域信息");
                    return;
                }

                Exit_WriteConfigFile();

                RefLog("删除自定义截图区域信息成功，重启软件后生效");
            }
            catch (Exception ex)
            {
                RefLog(ex.Message);
            }
        }

        // 删除主窗口配置文件
        private void button6_delConfigFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(iniPath))
                {
                    RefLog("未找到配置文件");
                    return;
                }
                File.Delete(iniPath);
                RefLog("删除配置文件成功，重启软件后生效");
                delConfigFile = true;
            }
            catch (Exception ex)
            {
                RefLog(ex.Message);
            }
        }

        // 保存配置文件
        private void button7_SaveConfigFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(iniPath) || FirstUse)
                {
                    MessageBox.Show("请点击“自定义截图区域”按钮设置截图区域后，\n退出并重新打开本软件！", "自动进入钉钉直播间", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                delConfigFile = true;
                Exit_WriteConfigFile();
                RefLog("保存主窗口配置文件成功");
            }
            catch (Exception ex)
            {
                RefLog(ex.Message);
            }
        }

        // 自定义截图区域
        private void button1_CustomScreenshot_Click(object sender, EventArgs e)
        {
            // 停止
            start = false;
            CloseThread();
            button5_start.Text = "开启";
            // 关闭所有计时器
            Update_Contro_Mode = 0;
            Update_Control();
            CheckBoxEnable(true); // 将所有CheckBox复选框设置为启用
            ComboBoxEnable(true); // 将所有ComboBox列表设置为启用
            SaveCheckboxEnable(2);// 恢复checkBox中Enabled属性的值

            CustScreenSuccess = false;

            if (!File.Exists(DingDingPath))
                DingDingPath = Reg.GetDingDingPath();// 获取钉钉路径
            if (DingDingPath == null)
            {
                //MessageBox.Show("钉钉路径无效！", "自动进入钉钉直播间",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            CustomScreenshot cs = new CustomScreenshot(checkBox12_SaveToDesk.Checked, DeskPath, DingDingWindowClass, DingDingPath);
            cs.ShowDialog(this);

            // 如果设置截图区域成功，将截图坐标高宽保存到配置文件
            if (CustScreenSuccess == true)
            {
                delConfigFile = false;
                Exit_WriteConfigFile();
            }
        }

        // 下拉列表 启用或取消启用
        private void ComboBoxEnable(bool val)
        {
            comboBox1.Enabled = val;
            comboBox2.Enabled = val;
            comboBox3.Enabled = val;
            comboBox4.Enabled = val;
            comboBox5.Enabled = val;
            comboBox6.Enabled = val;
            comboBox7.Enabled = val;
            comboBox8.Enabled = val;
            comboBox9.Enabled = val;
            comboBox10.Enabled = val;
            comboBox11.Enabled = val;
            comboBox12.Enabled = val;
            comboBox13.Enabled = val;
            comboBox14.Enabled = val;
            comboBox15.Enabled = val;
            comboBox16.Enabled = val;
        }

        // 所有复选框 启用或取消启用
        private void CheckBoxEnable(bool val)
        {
            checkBox3_Time1.Enabled = val;
            checkBox4_Time2.Enabled = val;
            checkBox5_Time3.Enabled = val;
            checkBox5_Time3.Enabled = val;
            checkBox6_Time4.Enabled = val;
            checkBox7_Time5.Enabled = val;
            checkBox8_Time6.Enabled = val;
            checkBox9_Time7.Enabled = val;
            checkBox10_Time8.Enabled = val;
        }

        // 所有复选框 打勾或取消打勾
        private void CheckBoxCheck(bool val)
        {
            checkBox3_Time1.Checked = val;
            checkBox4_Time2.Checked = val;
            checkBox5_Time3.Checked = val;
            checkBox5_Time3.Checked = val;
            checkBox6_Time4.Checked = val;
            checkBox7_Time5.Checked = val;
            checkBox8_Time6.Checked = val;
            checkBox9_Time7.Checked = val;
            checkBox10_Time8.Checked = val;
        }

        //所有label控件 启用或取消启用
        private void LabelEnable(bool val)
        {
            label2.Enabled = val;
            label3.Enabled = val;
            label4.Enabled = val;
            label5.Enabled = val;
            label6.Enabled = val;
            label7.Enabled = val;
            label8.Enabled = val;
            label9.Enabled = val;
            label10.Enabled = val;
            label11.Enabled = val;
            label12.Enabled = val;
            label13.Enabled = val;
            label14.Enabled = val;
            label15.Enabled = val;
            label16.Enabled = val;
            label17.Enabled = val;
            label18.Enabled = val;
            label22.Enabled = val;
        }

        // 直播断开时自动检测直播是否重新开启，如果直播在检测时间内开启，则自动打开
        private void checkBox1_AutoOpenLive_Click(object sender, EventArgs e)
        {
            if (!checkBox1_AutoOpenLive.Checked)
            {   // 开启直播断开时自动打开功能
                checkBox1_AutoOpenLive.Checked = true;
                if (start)
                {
                    // 如果打开此功能时，正好在开启状态
                    RefLog("已开启检测...");
                    timer1_Num = timer2_Num = 1;
                    timer2.Enabled = false;
                    timer1.Enabled = true;
                    timer1_Num = 1;
                }
            }
            else
            {   // 关闭直播断开时自动打开功能
                // 如果开启了“自动开启下一次直播”功能
                if (checkBox2_AutoOPenNextLive.Checked)
                {
                    DialogResult res = MessageBox.Show("关闭此功能后将会导致“自动开启下一次直播”功能不准确，\n确定关闭吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                        checkBox1_AutoOpenLive.Checked = false;
                }
                else
                    checkBox1_AutoOpenLive.Checked = false;

                if (start)
                {
                    // 如果关闭此功能时，正好在开启状态
                    RefLog("已停止检测...");
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    // 如果打开了 自动开启下一场直播 并且当前时间是最后一个自定义时间
                    if (!checkBox2_AutoOPenNextLive.Checked || (checkBox2_AutoOPenNextLive.Checked && element + 1 >= Dates.Count))
                    {
                        start = true; // start = true是为了下面调用button5_Start_Click函数时让软件处于停止状态
                        button5_Start_Click(null, null);
                        return;
                    }
                }
            }
        }
        private void checkBox1_AutoOpenLive_CheckedChanged(object sender, EventArgs e)
        {
            label1.Enabled = checkBox1_AutoOpenLive.Checked;
            label21.Enabled = checkBox1_AutoOpenLive.Checked;
            label23.Enabled = checkBox1_AutoOpenLive.Checked;
            numericUpDown1_CheckLiveTime.Enabled = checkBox1_AutoOpenLive.Checked;
            numericUpDown2_StopCheckLiveTime.Enabled = checkBox1_AutoOpenLive.Checked;
        }

        // 自动开启下一次直播
        private void checkBox2_AutoOPenNextLive_Click(object sender, EventArgs e)
        {
            if (start) // 如果打开或关闭“自动开启下一次直播”功能时，软件正好在开启状态（start = true）
            {
                RefLog("启动后不能设置自定义时间，请停止后再设置");
                return;
            }

            if (!checkBox2_AutoOPenNextLive.Checked)
            {
                checkBox2_AutoOPenNextLive.Checked = true;
            }
            else
            {
                checkBox2_AutoOPenNextLive.Checked = false;
                label23_DistanceTime.Text = "距   00\n"
                                          + "离   时\n"
                                          + "开   00\n"
                                          + "启   分\n"
                                          + "还   00\n"
                                          + "有   秒";
                ComboBoxEnable(false);// 所有列表取消启用
                CheckBoxCheck(false); // 所有复选框取消打勾
                LabelEnable(false);   // 所有label控件取消启用
            }
        }
        private void checkBox2_AutoOPenNextLive_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2_AutoOPenNextLive.Checked)
                checkBox1_AutoOpenLive.Checked = true;

            label22.Enabled = checkBox2_AutoOPenNextLive.Checked;
            label2.Enabled = checkBox2_AutoOPenNextLive.Checked;
            checkBox2_AutoOPenNextLive.Checked = checkBox2_AutoOPenNextLive.Checked;
            numericUpDown3.Enabled = checkBox2_AutoOPenNextLive.Checked;
            CheckBoxEnable(checkBox2_AutoOPenNextLive.Checked);
        }

        //自定义时间一
        private void checkBox3_Time1_ClickChanged(object sender, EventArgs e)
        {
            if (!checkBox3_Time1.Checked)
                checkBox3_Time1.Checked = true;
            else
                checkBox3_Time1.Checked = false;
        }
        private void checkBox3_Time1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = checkBox3_Time1.Checked;
            comboBox2.Enabled = checkBox3_Time1.Checked;
            label3.Enabled = checkBox3_Time1.Checked;
            label4.Enabled = checkBox3_Time1.Checked;
        }

        //自定义时间二
        private void checkBox4_Time2_ClickChanged(object sender, EventArgs e)
        {
            if (!checkBox4_Time2.Checked)
                checkBox4_Time2.Checked = true;
            else
                checkBox4_Time2.Checked = false;
        }
        private void checkBox4_Time2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox3.Enabled = checkBox4_Time2.Checked;
            comboBox4.Enabled = checkBox4_Time2.Checked;
            label8.Enabled = checkBox4_Time2.Checked;
            label7.Enabled = checkBox4_Time2.Checked;
        }

        //自定义时间三
        private void checkBox5_Time3_ClickChanged(object sender, EventArgs e)
        {
            if (!checkBox5_Time3.Checked)
                checkBox5_Time3.Checked = true;
            else
                checkBox5_Time3.Checked = false;
        }
        private void checkBox5_Time3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox5.Enabled = checkBox5_Time3.Checked;
            comboBox6.Enabled = checkBox5_Time3.Checked;
            label11.Enabled = checkBox5_Time3.Checked;
            label10.Enabled = checkBox5_Time3.Checked;
        }

        //自定义时间四
        private void checkBox6_Time4_ClickChanged(object sender, EventArgs e)
        {
            if (!checkBox6_Time4.Checked)
                checkBox6_Time4.Checked = true;
            else
                checkBox6_Time4.Checked = false;
        }
        private void checkBox6_Time4_CheckedChanged(object sender, EventArgs e)
        {
            comboBox7.Enabled = checkBox6_Time4.Checked;
            comboBox8.Enabled = checkBox6_Time4.Checked;
            label14.Enabled = checkBox6_Time4.Checked;
            label13.Enabled = checkBox6_Time4.Checked;
        }

        //自定义时间五
        private void checkBox7_Time5_ClickChanged(object sender, EventArgs e)
        {
            if (!checkBox7_Time5.Checked)
                checkBox7_Time5.Checked = true;
            else
                checkBox7_Time5.Checked = false;
        }
        private void checkBox7_Time5_CheckedChanged(object sender, EventArgs e)
        {
            comboBox9.Enabled = checkBox7_Time5.Checked;
            comboBox10.Enabled = checkBox7_Time5.Checked;
            label18.Enabled = checkBox7_Time5.Checked;
            label17.Enabled = checkBox7_Time5.Checked;
        }

        //自定义时间六
        private void checkBox8_Time6_ClickChanged(object sender, EventArgs e)
        {
            if (!checkBox8_Time6.Checked)
                checkBox8_Time6.Checked = true;
            else
                checkBox8_Time6.Checked = false;
        }
        private void checkBox8_Time6_CheckedChanged(object sender, EventArgs e)
        {
            comboBox11.Enabled = checkBox8_Time6.Checked;
            comboBox12.Enabled = checkBox8_Time6.Checked;
            label16.Enabled = checkBox8_Time6.Checked;
            label15.Enabled = checkBox8_Time6.Checked;
        }

        //自定义时间七
        private void checkBox9_Time7_ClickChanged(object sender, EventArgs e)
        {
            if (!checkBox9_Time7.Checked)
                checkBox9_Time7.Checked = true;
            else
                checkBox9_Time7.Checked = false;
        }
        private void checkBox9_Time7_CheckedChanged(object sender, EventArgs e)
        {
            comboBox13.Enabled = checkBox9_Time7.Checked;
            comboBox14.Enabled = checkBox9_Time7.Checked;
            label12.Enabled = checkBox9_Time7.Checked;
            label9.Enabled = checkBox9_Time7.Checked;
        }

        //自定义时间八
        private void checkBox10_Time8_ClickChanged(object sender, EventArgs e)
        {
            if (!checkBox10_Time8.Checked)
                checkBox10_Time8.Checked = true;
            else
                checkBox10_Time8.Checked = false;
        }
        private void checkBox10_Time8_CheckedChanged(object sender, EventArgs e)
        {
            comboBox15.Enabled = checkBox10_Time8.Checked;
            comboBox16.Enabled = checkBox10_Time8.Checked;
            label6.Enabled = checkBox10_Time8.Checked;
            label5.Enabled = checkBox10_Time8.Checked;
        }

        // 将截图保存到桌面
        private void checkBox12_SaveToDesk_Click(object sender, EventArgs e)
        {
            if (checkBox12_SaveToDesk.Checked)
                checkBox12_SaveToDesk.Checked = true;
            else
                checkBox12_SaveToDesk.Checked = false;
        }
        private void checkBox12_SaveToDesk_CheckedChanged(object sender, EventArgs e)
        {
            saveToDesk = checkBox12_SaveToDesk.Checked;
        }


        [DllImport("kernel32.dll")]
        static extern uint SetThreadExecutionState(uint esFlags);
        const uint ES_SYSTEM_REQUIRED = 0x00000001;
        const uint ES_DISPLAY_REQUIRED = 0x00000002;
        const uint ES_CONTINUOUS = 0x80000000;
        // 阻止系统休眠
        private void checkBox13_preventSleep_Click(object sender, EventArgs e)
        {
            if (!checkBox13_preventSleep.Checked)
                checkBox13_preventSleep.Checked = true;
            else
                checkBox13_preventSleep.Checked = false;
        }
        private void checkBox13_preventSleep_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13_preventSleep.Checked) // 调用api函数阻止系统休眠
                SetThreadExecutionState(ES_CONTINUOUS | ES_SYSTEM_REQUIRED | ES_DISPLAY_REQUIRED);
            else
                SetThreadExecutionState(ES_CONTINUOUS);
        }


        // 将日志显示到textbox控件
        private void RefLog(string log)
        {
            if (log == null)
                return;

            // 将要显示的内容添到textBox末尾
            textBox1_log.AppendText(DateTime.Now.ToString("HH:mm:ss") + "  " + log + Environment.NewLine);
        }

        private bool writeLogSuccess = true;
        // 将日志写入文件
        private void textBox1_log_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!writeLogSuccess) // 如果有一次写入文件失败则取消把日志写入文件
                    return;
                File.WriteAllText(logPath, textBox1_log.Text, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                RefLog("将日志写入文件失败\r\n原因：" + ex.Message);
                writeLogSuccess = false;
            }
        }


        // 通过右上角“X”退出软件时
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exit(null, null);
        }
        // 通过任务栏托盘退出软件时
        private void Exit(object sender, EventArgs e)
        {
            Exit_WriteConfigFile(); // 写入配置文件
            notifyIcon1.Dispose();  // 释放notifyIcon1的所有资源，保证托盘图标在程序关闭时立即消失
            CloseThread();

            // 如果设置了阻止系统休眠
            if (checkBox13_preventSleep.Checked)
                // 清除执行状态标志以禁用离开模式并允许系统空闲以正常睡眠
                SetThreadExecutionState(ES_CONTINUOUS);

            Environment.Exit(0);    // 退出
        }

        /// <summary>
        /// 退出软件时将信息保存到配置文件
        /// </summary>
        private void Exit_WriteConfigFile()
        {
            // 如果点击了“删除配置文件”按钮，则不将数据写入到文件
            if (delConfigFile == true)
                return;

            // 如果是第一次使用，并且未设置自定义坐标，也不写入文件
            if (FirstUse == true && CustScreenSuccess == false)
                return;

            // 如果点击了“删除截图区域”按钮
            if (delScreenFile == true)
            {   // 重置相对坐标为0
                RelPosX = 0;
                RelPosY = 0;
            }

            try
            {
                if (!Directory.Exists(iniDir))
                    Directory.CreateDirectory(iniDir);

                string err = ConfigFile.WriteFile(
                      BoolToNum(checkBox1_AutoOpenLive.Checked), (int)numericUpDown1_CheckLiveTime.Value,
                      (int)numericUpDown2_StopCheckLiveTime.Value, BoolToNum(checkBox2_AutoOPenNextLive.Checked), (int)numericUpDown3.Value,
                      BoolToNum(checkBox3_Time1.Checked), comboBox1.SelectedIndex + "," + comboBox2.SelectedIndex,
                      BoolToNum(checkBox4_Time2.Checked), comboBox3.SelectedIndex + "," + comboBox4.SelectedIndex,
                      BoolToNum(checkBox5_Time3.Checked), comboBox5.SelectedIndex + "," + comboBox6.SelectedIndex,
                      BoolToNum(checkBox6_Time4.Checked), comboBox7.SelectedIndex + "," + comboBox8.SelectedIndex,
                      BoolToNum(checkBox7_Time5.Checked), comboBox9.SelectedIndex + "," + comboBox10.SelectedIndex,
                      BoolToNum(checkBox8_Time6.Checked), comboBox11.SelectedIndex + "," + comboBox12.SelectedIndex,
                      BoolToNum(checkBox9_Time7.Checked), comboBox13.SelectedIndex + "," + comboBox14.SelectedIndex,
                      BoolToNum(checkBox10_Time8.Checked), comboBox15.SelectedIndex + "," + comboBox16.SelectedIndex,
                      BoolToNum(checkBox11_ShowTop.Checked), this.Location.X, this.Location.Y, RelPosX, RelPosY,
                      ScreenshotH, ScreenshotW, DpiX, DpiY, BoolToNum(checkBox13_preventSleep.Checked), CurrentVersion,
                      DingDingPath, iniPath);
                if (err != null)
                    throw new Exception(err);
            }
            catch (Exception ex)
            {
                MessageBox.Show("写入配置文件错误\n原因：" + ex, "写入配置文件错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //布尔值转数字 true转为1，false转为0
        private int BoolToNum(bool val)
        {
            if (val == true)
                return 1;
            else
                return 0;
        }

        //数字转布尔值  1转为true，0转为false
        private bool NumToBool(int val)
        {
            if (val == 1)
                return true;
            else
                return false;
        }


        //加载窗口时读取配置文件
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // 获取屏幕分辨率
                if (Screen.PrimaryScreen.Bounds.Height > 1080 || Screen.PrimaryScreen.Bounds.Width > 1920)
                    MessageBox.Show("本软件仅对1920x1080分辨率的屏幕进行适配\n其它分辨率可能会卡在“正在检测钉钉是否在直播...”", "自动进入钉钉直播间", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                try
                {
                    // 自动更新
                    AutoUpdateForm autoUpdate = new AutoUpdateForm(logPath);
                    if (autoUpdate.GetUpdate() == true)
                        autoUpdate.ShowDialog(this);
                    else
                        throw new Exception("当前版本已为最新版本");
                }
                catch (Exception ex)
                {
                    RefLog(ex.Message);
                }

                // 如果当前目录存在NO这个文件，则在19点及19点后启动本软件不会启用深色模式
                if (!File.Exists(Application.StartupPath + "\\NO") && !File.Exists(Application.StartupPath + "\\no"))
                {
                    if (DateTime.Compare(DateTime.Now, DateTime.Parse("19:00:00")) >= 0)
                    {
                        this.BackColor = SystemColors.ControlDark;
                        button5_start.BackColor = SystemColors.ActiveBorder;
                        label19_Explain.BackColor = SystemColors.WindowFrame;
                        label23_DistanceTime.BackColor = Color.Silver;
                        label25.BackColor = SystemColors.WindowFrame;
                    }
                }

                // 判断配置文件是否存在
                if (File.Exists(iniPath))
                {
                    int al = 0;   // 中断直播时自动进入
                    int cl = 0;   // 每隔xx秒检测是否中断直播
                    int scl = 0;  // xx分钟后还未检测到直播开启则中断检测
                    int aonl = 0; // 自动打开下一次直播
                    int olt = 0;  // 距离下一次直播还有xx分钟时自动进入
                    int t1s = 0;  // 时间一
                    string t1t = null;// 时间一内容
                    int t2s = 0;
                    string t2t = null;// 时间二容
                    int t3s = 0;
                    string t3t = null;// 时间三内容
                    int t4s = 0;
                    string t4t = null;// 时间四内容
                    int t5s = 0;
                    string t5t = null;// 时间五内容
                    int t6s = 0;
                    string t6t = null;// 时间六内容
                    int t7s = 0;
                    string t7t = null;// 时间七内容
                    int t8s = 0;
                    string t8t = null;// 时间八内容
                    int st = 0;
                    // 主窗体坐标
                    int px = 0;
                    int py = 0;
                    // 相对截图坐标
                    int sx = 0;
                    int sy = 0;
                    // 截图高度和宽度
                    int sh = 0;
                    int sw = 0;

                    // 是否阻止系统休眠
                    int ps = 0;

                    // 屏幕缩放比
                    float dx = 0;
                    float dy = 0;

                    // 当前版本号
                    string cv = null;

                    // 钉钉路径
                    string dP = null;

                    // 读配置文件
                    string err = ConfigFile.ReadFile(ref al, ref cl, ref scl, ref aonl, ref olt, ref t1s, ref t1t, ref t2s, ref t2t, ref t3s, ref t3t, ref t4s, ref t4t, ref t5s, ref t5t, ref t6s, ref t6t,
                        ref t7s, ref t7t, ref t8s, ref t8t, ref st, ref px, ref py, ref sx, ref sy, ref sh, ref sw, ref dx, ref dy, ref ps, ref cv, ref dP, iniPath);
                    // 如果读配置文件出现错误
                    if (err != null)
                    {
                        // 恢复默认数据
                        st = t8s = t7s = t6s = t5s = t4s = t3s = t2s = t1s = olt = aonl = scl = cl = al = 0;
                        t8t = t7t = t6t = t5t = t4t = t3t = t2t = t1t = "0,0";
                        dx = dy = 0f;
                        MessageBox.Show("数据文件加载错误，\n请以管理员权限运行本软件重试！", "自动进入钉钉直播间", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                        // throw new Exception(err);
                    }
                    else
                    {
                        RefLog("加载配置文件成功");
                        // 截图高度和宽度
                        ScreenshotH = sh;
                        ScreenshotW = sw;
                    }

                    // 将配置文件中的数据恢复到主窗口
                    checkBox1_AutoOpenLive.Checked = NumToBool(al);
                    numericUpDown1_CheckLiveTime.Value = cl;
                    numericUpDown2_StopCheckLiveTime.Value = scl;
                    checkBox2_AutoOPenNextLive.Checked = NumToBool(aonl);
                    numericUpDown3.Value = olt;
                    checkBox3_Time1.Checked = NumToBool(t1s);
                    checkBox4_Time2.Checked = NumToBool(t2s);
                    checkBox5_Time3.Checked = NumToBool(t3s);
                    checkBox6_Time4.Checked = NumToBool(t4s);
                    checkBox7_Time5.Checked = NumToBool(t5s);
                    checkBox8_Time6.Checked = NumToBool(t6s);
                    checkBox9_Time7.Checked = NumToBool(t7s);
                    checkBox10_Time8.Checked = NumToBool(t8s);
                    checkBox11_ShowTop.Checked = NumToBool(st);
                    checkBox13_preventSleep.Checked = NumToBool(ps);

                    int c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16;
                    SplitStr(t1t, out c1, out c2);
                    SplitStr(t2t, out c3, out c4);
                    SplitStr(t3t, out c5, out c6);
                    SplitStr(t4t, out c7, out c8);
                    SplitStr(t5t, out c9, out c10);
                    SplitStr(t6t, out c11, out c12);
                    SplitStr(t7t, out c13, out c14);
                    SplitStr(t8t, out c15, out c16);
                    comboBox1.SelectedIndex = c1;
                    comboBox2.SelectedIndex = c2;
                    comboBox3.SelectedIndex = c3;
                    comboBox4.SelectedIndex = c4;
                    comboBox5.SelectedIndex = c5;
                    comboBox6.SelectedIndex = c6;
                    comboBox7.SelectedIndex = c7;
                    comboBox8.SelectedIndex = c8;
                    comboBox9.SelectedIndex = c9;
                    comboBox10.SelectedIndex = c10;
                    comboBox11.SelectedIndex = c11;
                    comboBox12.SelectedIndex = c12;
                    comboBox13.SelectedIndex = c13;
                    comboBox14.SelectedIndex = c14;
                    comboBox15.SelectedIndex = c15;
                    comboBox16.SelectedIndex = c16;

                    // 截图相对与钉钉窗口的坐标
                    if (sx == 0 && sy == 0)
                    {
                        RelPosX = 0;
                        RelPosY = 0;
                        FirstUse = true;
                    }
                    else
                    {
                        RelPosX = sx;
                        RelPosY = sy;
                    }

                    // 屏幕缩放比
                    DpiX = dx;
                    DpiY = dy;

                    // 判断读出来的窗体坐标是否有误
                    if (px >= 0 && py >= 0)
                    {
                        this.Location = new System.Drawing.Point(px, py);
                    }
                    // 软件版本号
                    CurrentVersion = cv;

                    // 钉钉路径
                    DingDingPath = dP;
                }
                else
                {
                    FirstUse = true; // 未找到配置文件则视为用户第一次使用
                    RefLog("未找到配置文件");
                }

                // 如果未启用 “自动开启下一次直播”功能
                if (!checkBox2_AutoOPenNextLive.Checked)
                {
                    // 关闭所有列表和复选框
                    ComboBoxEnable(false);// 所有列表取消启用
                    CheckBoxCheck(false); // 所有复选框取消打勾
                    LabelEnable(false);   // 所有label控件取消启用
                }
            }
            catch (Exception ex)
            {
                RefLog(ex.Message);
            }
        }

        // 分割字符串（将“1,2”分割为“1”和“2”）
        private void SplitStr(string str, out int str1, out int str2)
        {
            try
            {
                string[] Array = str.Split(',');
                str1 = Convert.ToInt32(Array[0]);
                str2 = Convert.ToInt32(Array[1]);
            }
            catch
            {
                str1 = 0;
                str2 = 0;
            }
        }

        // 窗口加载完成并第一次显示时
        private void Form1_Shown(object sender, EventArgs e)
        {
            try
            {
                // 判断屏幕缩放比是否改变
                if (DpiX != 0 && DpiY != 0)
                {
                    Graphics g = this.CreateGraphics();
                    if (g.DpiX != DpiX || g.DpiY != DpiY)
                        throw new Exception("检测到屏幕缩放比改变，\n请点击“自定义截图”按钮重新设置截图区域");
                }
                if (!FirstUse)
                {
                    // 判断配置文件版本号和当前软件版本号是否相同
                    if (CurrentVersion == null || CurrentVersion == "" || new Version(CurrentVersion) != new Version(Application.ProductVersion))
                        throw new Exception("检测到软件版本改变，\n请点击“点击自定义截图”按钮设置截图区域！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "自动进入钉钉直播间", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RefLog(ex.Message);
                return;
            }

            //开启
            button5_Start_Click(null, null);
        }

        // 点击任务栏托盘图标时显示窗口
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            Show(null, null);
        }

        // 显示窗口
        private void Show(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal; // 窗体恢复正常大小
            this.ShowInTaskbar = true;
        }


        // 启动
        private void button5_Start_Click(object sender, EventArgs e)
        {
            // return;
            if (!File.Exists(iniPath) || FirstUse)
            {
                MessageBox.Show("请点击“自定义截图区域”按钮设置截图区域后，\n退出并重新打开本软件！", "自动进入钉钉直播间", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 判断当前状态（启动|停止）
            if (start == false)
            {// 启动
                first = 0;
                start = true;
                StartThread();
                button5_start.Text = "停止";

                SaveCheckboxEnable(1);// 保存checkBox中Enabled属性的值
                CheckBoxEnable(false);// 将所有CheckBox复选框设置为未启用
                ComboBoxEnable(false);// 将所有ComboBox列表设置为未启用
                DateTimeArray();      // 将所有启用的comboBox列表的值保存到时间数组
            }
            else
            {// 停止
                start = false;

                CloseThread();
                button5_start.Text = "开启";

                if (noCloseTimer5)
                    Update_Contro_Mode = 1;// 关闭除了timer5之外的所有计时器
                else
                    Update_Contro_Mode = 0;// 关闭所有计时器
                Update_Control();

                CheckBoxEnable(true); // 将所有CheckBox复选框设置为启用
                ComboBoxEnable(true); // 将所有ComboBox列表设置为启用
                SaveCheckboxEnable(2);// 恢复checkBox中Enabled属性的值
            }
        }

        // 保存或恢复checkBox中Enabled属性的值
        private bool[] bArr = new bool[16];
        private void SaveCheckboxEnable(int mode)
        {
            if (mode == 1)//保存
            {
                bArr[0] = comboBox1.Enabled;
                bArr[1] = comboBox2.Enabled;
                bArr[2] = comboBox3.Enabled;
                bArr[3] = comboBox4.Enabled;
                bArr[4] = comboBox5.Enabled;
                bArr[5] = comboBox6.Enabled;
                bArr[6] = comboBox7.Enabled;
                bArr[7] = comboBox8.Enabled;
                bArr[8] = comboBox9.Enabled;
                bArr[9] = comboBox10.Enabled;
                bArr[10] = comboBox11.Enabled;
                bArr[11] = comboBox12.Enabled;
                bArr[12] = comboBox13.Enabled;
                bArr[13] = comboBox14.Enabled;
                bArr[14] = comboBox15.Enabled;
                bArr[15] = comboBox16.Enabled;
            }
            else if (mode == 2)//恢复
            {
                comboBox1.Enabled = bArr[0];
                comboBox2.Enabled = bArr[1];
                comboBox3.Enabled = bArr[2];
                comboBox4.Enabled = bArr[3];
                comboBox5.Enabled = bArr[4];
                comboBox6.Enabled = bArr[5];
                comboBox7.Enabled = bArr[6];
                comboBox8.Enabled = bArr[7];
                comboBox9.Enabled = bArr[8];
                comboBox10.Enabled = bArr[9];
                comboBox11.Enabled = bArr[10];
                comboBox12.Enabled = bArr[11];
                comboBox13.Enabled = bArr[12];
                comboBox14.Enabled = bArr[13];
                comboBox15.Enabled = bArr[14];
                comboBox16.Enabled = bArr[15];
            }
        }

        // 将所有启用的comboBox列表的值保存到时间数组
        private List<DateTime> Dates;
        private void DateTimeArray()
        {
            Dates = new List<DateTime>();

            if (checkBox3_Time1.Checked)
                Dates.Add(DateTime.Parse(comboBox1.SelectedItem.ToString() + ":" + comboBox2.SelectedItem.ToString()));
            if (checkBox4_Time2.Checked)
                Dates.Add(DateTime.Parse(comboBox3.SelectedItem.ToString() + ":" + comboBox4.SelectedItem.ToString()));
            if (checkBox5_Time3.Checked)
                Dates.Add(DateTime.Parse(comboBox5.SelectedItem.ToString() + ":" + comboBox6.SelectedItem.ToString()));
            if (checkBox6_Time4.Checked)
                Dates.Add(DateTime.Parse(comboBox7.SelectedItem.ToString() + ":" + comboBox8.SelectedItem.ToString()));
            if (checkBox7_Time5.Checked)
                Dates.Add(DateTime.Parse(comboBox9.SelectedItem.ToString() + ":" + comboBox10.SelectedItem.ToString()));
            if (checkBox8_Time6.Checked)
                Dates.Add(DateTime.Parse(comboBox11.SelectedItem.ToString() + ":" + comboBox12.SelectedItem.ToString()));
            if (checkBox9_Time7.Checked)
                Dates.Add(DateTime.Parse(comboBox13.SelectedItem.ToString() + ":" + comboBox14.SelectedItem.ToString()));
            if (checkBox10_Time8.Checked)
                Dates.Add(DateTime.Parse(comboBox15.SelectedItem.ToString() + ":" + comboBox16.SelectedItem.ToString()));

            Dates.Sort();
        }


        // timer1检测直播是否断开
        // timer2检测直播是否断开后直播是否重新开启
        // timer3检测当前时间是否到下一场直播开启时间
        // timer4计时当前直播已开启xx分钟

        // timer1检测直播是否断开
        private int timer1_Num = 1;// 检测直播是否中断次数
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = decimal.ToInt32(numericUpDown1_CheckLiveTime.Value) * 1000;// 将秒化为毫秒

            RefLog("第" + timer1_Num++.ToString() + "次检测直播是否断开...");

            // 判断直播窗口句柄是否存在（直播窗口句柄存在则说明当前直播未断开，就不需要通过截图来判断直播是否断开） 
            if (FindWindow(DingDingLiveWindowClass, null) != IntPtr.Zero)
                return;

            // 如果 钉钉直播窗口 不存在，则截图并判断图片中的（rgb或文字）是否含有钉钉正在直播时的（rgb或关键字）
            if (!JudgeLive())
            {
                if (judgeLiveErr)
                {
                    RefLog("检测直播是否断开错误！");
                    return;
                }
                RefLog("(" + identifyType + ")检测到直播断开");
                LiveBSTime = DateTime.Now;// 保存直播断开时间
                timer2.Enabled = true;    // 检测直播断开后直播是否重新开启
                timer2_Num = 1;
                timer1.Enabled = false;   // 关闭检测直播是否中断
            }
        }

        // timer2检测直播断开后 在检测时间内检测 直播是否重新开启
        private DateTime LiveBSTime;// 直播断开时间
        private int timer2_Num = 1; // 检测直播重新开启次数
        private void timer2_Tick(object sender, EventArgs e)
        {
            RefLog("第" + timer2_Num++.ToString() + "次检测直播是否重新开启...");

            // 如果当前时间 大于 （直播断开时间 + xx分钟后还未检测到直播开启则停止检测时间）
            if (DateTime.Now > LiveBSTime.AddMinutes(decimal.ToDouble(numericUpDown2_StopCheckLiveTime.Value)))
            {
                RefLog("(" + identifyType + ")检测直播是否重新开启超时，即将停止检测");
                timer2.Enabled = false;
                timer4.Enabled = false;

                // 如果打开了 自动开启下一场直播 并且当前时间未到达自定义时间
                if (checkBox2_AutoOPenNextLive.Checked && element + 1 < Dates.Count)
                {
                    RefLog("等待下一场直播开启...");
                }
                // 如果打开了 自动开启下一场直播 并且当前时间是最后一个自定义时间
                else if (!checkBox2_AutoOPenNextLive.Checked || (checkBox2_AutoOPenNextLive.Checked && element + 1 >= Dates.Count))
                {// 停止
                    start = true;
                    button5_Start_Click(null, null);
                    return;
                }
            }


            // 截取指定区域图片，判断直播是否恢复
            if (JudgeLive())
            {
                if (judgeLiveErr)
                {
                    RefLog("检测直播是否恢复错误！");
                    return;
                }

                timer2.Enabled = false;
                RefLog("(" + identifyType + ")已检测到直播重新开启");

                CloseThread();
                StartThread();
            }
        }

        // timer3检测当前时间是否到下一场直播开启时间（只在checkBox2_AutoOPenNextLive打开时有效）
        private void timer3_Tick(object sender, EventArgs e)
        {
            //到达最后一个自定义时间
            if (element + 1 >= Dates.Count)
            {
                RefLog("已到达最后一个自定义时间，自动开启下一次直播将不会生效");

                // 如果未勾选 直播中断时自动打开
                if (!checkBox1_AutoOpenLive.Checked)
                {
                    timer3.Enabled = false;
                    timer4.Enabled = false;

                    start = false;
                    button5_start.Text = "开启";
                    CheckBoxEnable(true); // 将所有CheckBox复选框设置为启用
                    ComboBoxEnable(true); // 将所有ComboBox列表设置为启用
                    SaveCheckboxEnable(2);// 恢复checkBox中Enabled属性的值

                    label23_DistanceTime.Text =
                   "距   00\n"
                 + "离   时\n"
                 + "开   00\n"
                 + "启   分\n"
                 + "还   00\n"
                 + "有   秒";

                    CloseThread();
                }

                // 关闭定时器
                timer3.Enabled = false;
                return;
            }

            // 如果当前时间 大于或等于 直播开启时间 =（直播时间-距离直播还有xx分钟自动开启）
            if (DateTime.Now >= Dates[element + 1].AddMinutes(-(double)numericUpDown3.Value))
            {
                // 下面这段注释的代码有BUG
                //if (JudgeLive())//如果直播未关闭
                //	return;

                timer3.Enabled = false;
                element += 1;// 数组元素+1，使用下一个自定义时间

                CloseThread();
                StartThread();
            }
        }

        // timer4计时当前直播已开启xx分钟
        private DateTime timer4_Time;
        private TimeSpan diff; // 时间差
        private void timer4_Tick(object sender, EventArgs e)
        {
            diff = DateTime.Now - timer4_Time;
            int h, m, s;

            h = diff.Hours < 0 ? 0 : diff.Hours;
            m = diff.Minutes < 0 ? 0 : diff.Minutes;
            s = diff.Seconds < 0 ? 0 : diff.Seconds;

            label23_DistanceTime.Text =
                    "当   " + h.ToString().PadLeft(2, '0') + "\n"
                  + "前   时\n"
                  + "直   " + m.ToString().PadLeft(2, '0') + "\n"
                  + "播   分\n"
                  + "开   " + s.ToString().PadLeft(2, '0') + "\n"
                  + "启   秒";
        }


        // timer5将钉钉窗口显示到最前方
        private void timer5_Tick(object sender, EventArgs e)
        {
            // 查找钉钉窗口句柄
            IntPtr hwnd = FindWindow(DingDingWindowClass, null);
            if (hwnd == IntPtr.Zero)
            {
                RefLog("获取钉钉窗口句柄失败");
                timer5.Enabled = false;
                return;
            }
            // 将钉钉窗口显示到最前方
            if (SetWindowPos(hwnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE) == 0)
            {
                RefLog("将钉钉窗口显示在最前方失败");
                timer5.Enabled = false;
            }
        }


        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]// 查找窗口句柄
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos", CharSet = CharSet.Auto)]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, uint flags);// 始终保持窗口在最前端
        const int HWND_TOPMOST = -1;
        const int SWP_SHOWWINDOW = 0x0040;
        const int SWP_NOMOVE = 0x0002;
        const int SWP_NOSIZE = 0x0001;

        [DllImport("user32.dll", EntryPoint = "MoveWindow", CharSet = CharSet.Auto)]
        public static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);// 移动窗口

        [DllImport("user32.dll", EntryPoint = "SetCursorPos", CharSet = CharSet.Auto)]
        public extern static void SetCursorPos(int x, int y);// 设置鼠标光标位置

        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out Rect lpRect);// 获取窗口坐标
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll", EntryPoint = "GetCursorPos", CharSet = CharSet.Auto)]
        public extern static bool GetCursorPos(out POINT p);// 获取鼠标光标位置

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        [DllImport("user32", EntryPoint = "mouse_event", CharSet = CharSet.Auto)]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);// 模拟鼠标左键按下 


        //打开网址
        private void label20_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.52pojie.cn/thread-1168398-3-1.html");
        }
        private void label19_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/cdmxz/C-SHARP-language-language-program/tree/master/%E8%87%AA%E5%8A%A8%E8%BF%9B%E5%85%A5%E9%92%89%E9%92%89%E7%9B%B4%E6%92%AD%E9%97%B4");
        }
        private void label25_Click(object sender, EventArgs e)
        {
            Process.Start("http://mail.qq.com/cgi-bin/qm_share?t=qm_mailme&email=XW5pb2VvbG9sZWgdLCxzPjIw");
        }
        //打开使用说明网址
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://shimo.im/docs/b8467ba8b9db4e29/");
        }


        const int MOUSEEVENTF_LEFTDOWN = 0x0002; // 模拟鼠标左键按下      
        const int MOUSEEVENTF_LEFTUP = 0x0004;   // 模拟鼠标左键抬起 
        protected delegate void UpdateLog();     // 刷新控件
        protected delegate void UpdateLabel();   // 刷新控件
        private string threadErr;                // 错误提示


        private void CloseThread()
        {
            if (newThread != null)
            {             // 如果线程还在运行，就关闭
                if ((newThread.ThreadState & (System.Threading.ThreadState.Stopped | System.Threading.ThreadState.Unstarted)) == 0)
                    newThread.Abort();
            }
        }


        private void StartThread()
        {
            newThread = new Thread(OpenDingDing);
            newThread.SetApartmentState(ApartmentState.STA);
            newThread.Start(); // 启动新线程
        }

        /// <summary>
        /// 打开钉钉并检测是否正在直播
        /// </summary>
        private void OpenDingDing()
        {
            UpdateLog update = new UpdateLog(Update_Log);    // 刷新日志
            UpdateLabel ul = new UpdateLabel(Update_Control);// 杂七杂八（刷新控件）
            Rect r = new Rect();
            int i = 1;
            // 关闭所有timer控件
            Update_Contro_Mode = 0;
            this.Invoke(ul);

            try
            {
                if (!File.Exists(DingDingPath))
                    DingDingPath = Reg.GetDingDingPath();// 获取钉钉路径

                if (DingDingPath == null)
                    return;
                //throw new Exception("钉钉路径无效！");

                threadErr = "获取钉钉路径成功";
                this.Invoke(update);// 调用窗体Invoke方法

                Process.Start(DingDingPath);// 打开钉钉

                threadErr = "正在打开钉钉...";
                this.Invoke(update);

                for (i = 1; i <= 5; i++)
                {
                    // 关闭除了timer5之外的所有timer控件，避免在打开钉钉时 勾选断开直播时自动进入
                    Update_Contro_Mode = 1;
                    this.Invoke(ul);

                    threadErr = "            " + i.ToString() + "...";
                    this.Invoke(update);
                    Thread.Sleep(1000);// 休眠3秒等待打开钉钉
                }

                // 寻找钉钉进程
                for (i = 0; i <= 120; i++)
                {
                    // 关闭除了timer5之外的所有timer控件，避免在打开钉钉时 勾选断开直播时自动进入
                    Update_Contro_Mode = 1;
                    this.Invoke(ul);

                    foreach (Process pro in Process.GetProcesses())
                    {
                        if (pro.ProcessName.ToLower() == "DingTalk".ToLower())
                        {
                            i = 999; // 跳出外层for循环
                            break;   // 跳出foreach循环
                        }
                    }

                    if (i > 120)       // 跳出for循环
                    {
                        break;
                    }
                    else if (i == 120) // 如果循环20次都未找到
                    {
                        throw new Exception("未找到钉钉进程"); // 抛出异常
                    }
                    Thread.Sleep(1000);    // 如未找到则等待5秒再查找
                }

                threadErr = "已找到钉钉进程";
                this.Invoke(update);

                // 查找钉钉窗口句柄
                IntPtr hwnd = FindWindow(DingDingWindowClass, null);
                if (hwnd == IntPtr.Zero)
                    throw new Exception("获取钉钉窗口句柄失败"); // 抛出异常

                threadErr = "已找到钉钉窗口句柄";
                this.Invoke(update);

                // 如果启用将钉钉窗口显示到最顶层
                if (checkBox11_ShowTop.Checked)
                {
                    // 启动timer5，将钉钉窗口显示在最前方
                    Update_Contro_Mode = 5;
                    this.Invoke(ul);
                }

                Thread.Sleep(1000);

                // 如果打开自动开启下一场直播
                if (checkBox2_AutoOPenNextLive.Checked)
                {
                    // 判断当前时间是否到达直播时间
                    threadErr = "等待到达直播开启时间...";
                    this.Invoke(update);

                    for (i = element; i < Dates.Count; i++)
                    {
                        // 关闭除了timer5之外的所有timer控件，避免在打开钉钉时 勾选中断直播时自动进入
                        Update_Contro_Mode = 1;
                        this.Invoke(ul);

                        // 如果当前时间 大于 数组当前元素中的时间 则跳过，直到当前时间 小于 数组下一个元素中的时间为止
                        if (DateTime.Compare(DateTime.Now, Dates[i]) > 0)
                        {
                            if (i == Dates.Count - 1) // 如果数组里的 自定义时间全部小于 当前时间
                                break;
                            else
                                continue;
                        }
                        // 如果当前时间大于上一次直播开启时间，小于下一次直播开启时间
                        else if (JudgeLive())// 判断直播是否开启
                        {
                            if (first++ == 0)
                                i -= 1;           // 直播开启则使用前一个元素（上一次直播开启时间）
                            break;
                        }

                        // 判断当前时间是否小于下一次直播开启时间
                        while (DateTime.Now < Dates[i])// 如果当前时间 小于 自定义直播时间，则等待到达直播开启时间
                        {
                            // 关闭除了timer5之外的所有timer控件，避免在打开钉钉时 勾选中断直播时自动进入
                            Update_Contro_Mode = 1;
                            this.Invoke(ul);

                            // 获取时间差，并显示到label23（直播开启还有xx时xx分xx秒）
                            timeDiffer = Dates[i].AddMinutes(-(double)numericUpDown3.Value) - DateTime.Now;
                            Update_Contro_Mode = 999;  // 刷新距离直播开启还有xx时xx分xx秒
                            this.Invoke(ul);
                            Thread.Sleep(1000);        // 休眠一秒判断

                            // 如果当前时间 小于 直播开启时间 =（直播时间-距离直播还有xx分钟自动开启的时间）
                            if (DateTime.Now >= Dates[i].AddMinutes(-(double)numericUpDown3.Value))
                            {
                                i = Dates.Count + 1; // 跳出外层for循环 
                                break;                // 跳出内层while循环
                            }
                        }
                    }
                }

                element = i;  // 保存当前直播开启时间的数组元素下标
                // 刷新日志
                threadErr = "正在检测当前是否正在直播...";
                this.Invoke(update);
                threadErr = "请不要移动或遮挡钉钉窗口，否则会造成检测失败";
                this.Invoke(update);


                bool find = false;
                // 再寻找一次钉钉进程，避免等待到达直播开启时间过程中钉钉意外关闭
                foreach (Process pro in Process.GetProcesses())
                {
                    if (pro.ProcessName.ToLower() == "DingTalk".ToLower())
                    {
                        find = true;
                        break;
                    }
                }
                // 如果未找到钉钉进程
                if (!find)
                {
                    OpenDingDing();
                    return;
                }

                // 判断当前是否在直播
                for (i = 1; i <= 1800; i++)
                {
                    // 关闭所有timer控件，避免在打开钉钉时 勾选中断直播时自动进入
                    Update_Contro_Mode = 1;
                    this.Invoke(ul);

                    threadErr = "第" + i.ToString() + "次检测当前是否正在直播...";
                    this.Invoke(update);

                    if (JudgeLive())// 判断是否在直播
                    {
                        threadErr = "(" + identifyType + ")检测到当前正在直播";
                        this.Invoke(update);
                        break;
                    }
                    Thread.Sleep(3000);// 如检测到 则等待3秒后 再检测

                    // 如果循环1800次（60分钟）都还未直播就退出
                    if (i == 1800)
                        throw new Exception("检测当前正在直播超时，将停止检测..."); // 抛出异常
                }

                threadErr = "打开直播中...";
                this.Invoke(update);

                // 获取鼠标光标位置
                POINT p = new POINT();
                GetCursorPos(out p);

                // 模拟鼠标左键按下  
                for (i = 0; i < 30; i++)
                {
                    // 第N次点击  在钉钉窗口坐标的基础上 加：X坐标 + i * 4，Y坐标 + i
                    if (GetWindowRect(hwnd, out r) == 0)
                        throw new Exception("获取钉钉窗口坐标失败");

                    // 鼠标点击坐标
                    MouseClickX = r.Left + RelPosX + i * 2;
                    MouseClickY = r.Top + RelPosY + i;

                    // 设置鼠标光标位置
                    SetCursorPos(MouseClickX, MouseClickY);
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

                    // 查找钉钉直播窗口类名，如果找到，则已打开直播
                    if (FindWindow("StandardFrame", null) != IntPtr.Zero)
                    {
                        threadErr = "已打开直播";
                        break;
                    }

                    Thread.Sleep(300);
                    if (i == 30)
                        threadErr = "可能 已打开直播";
                }

                this.Invoke(update);

                Thread.Sleep(1000);
                // 恢复鼠标原来的位置
                SetCursorPos(p.X, p.Y);

                // 启动timer1，检测直播是否断开
                Update_Contro_Mode = 2;
                this.Invoke(ul);

                // 启动timer3，检测是否到达下一场直播时间
                Update_Contro_Mode = 3;
                this.Invoke(ul);

                // 启动timer4，刷新 直播已开启 xx分... 控件
                Update_Contro_Mode = 4;
                this.Invoke(ul);

            }
            catch (Exception ex)
            {
                threadErr = ex.Message;
                this.Invoke(update);

                // 通过button按钮关闭时（会引发异常，造成线程退出），以下语句在button5_Start_Click()中已执行，并且start = false
                if (start)
                {
                    Update_Contro_Mode = 6;
                    this.Invoke(ul);
                }
                return;
            }
        }


        // 在多线程中刷新日志
        private void Update_Log()
        {
            RefLog(threadErr);
        }

        //在多线程中刷新控件
        private TimeSpan timeDiffer;
        private int Update_Contro_Mode;
        private void Update_Control()
        {
            if (Update_Contro_Mode == 0)
            { // 关闭所有定时器
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
                timer5.Enabled = false;
            }
            else if (Update_Contro_Mode == 1)
            {// 关闭除了timer5之外的所有定时器
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
            }
            else if (Update_Contro_Mode == 2)
            {// 启动定时器1，检测直播是否中断
                timer1.Enabled = checkBox1_AutoOpenLive.Checked;
                timer1_Num = 1;
            }
            else if (Update_Contro_Mode == 3)
            {// 启动定时器3，检测是否到达下一次直播时间
                timer3.Enabled = checkBox2_AutoOPenNextLive.Checked;
            }
            else if (Update_Contro_Mode == 4)
            {// 启动定时器4，直播开启后计时
                if (checkBox1_AutoOpenLive.Checked || checkBox2_AutoOPenNextLive.Checked)
                {
                    timer4.Enabled = true;
                    timer4_Time = DateTime.Now;
                }
                else
                {// 如果没有开启“直播中断时自动打开”和“自动开启下一次直播”功能
                    noCloseTimer5 = timer5.Enabled;
                    start = true; // 设置为停止状态
                    button5_Start_Click(null, null);
                }
            }
            else if (Update_Contro_Mode == 5)
            {// 启动定时器5，将钉钉窗口显示在最前方
                timer5.Enabled = true;
            }
            else if (Update_Contro_Mode == 6)
            {
                // 设置为停止状态
                start = true;
                button5_Start_Click(null, null);
            }
            else if (Update_Contro_Mode == 999)
            {    // 刷新距离直播开启还有xx时xx分xx秒
                int h, m, s;
                h = timeDiffer.Hours < 0 ? 0 : timeDiffer.Hours;
                m = timeDiffer.Minutes < 0 ? 0 : timeDiffer.Minutes;
                s = timeDiffer.Seconds < 0 ? 0 : timeDiffer.Seconds;

                label23_DistanceTime.Text =
                    "距   " + h.ToString().PadLeft(2, '0') + "\n"
                  + "离   时\n"
                  + "开   " + m.ToString().PadLeft(2, '0') + "\n"
                  + "启   分\n"
                  + "还   " + s.ToString().PadLeft(2, '0') + "\n"
                  + "有   秒";
            }
        }

        private string picturePath;
        private bool judgeLiveErr = false;
        private Bitmap bit;
        // 判断直播是否打开（也就是判断截图保存的图片中的rgb是否含有钉钉正在直播时的rgb）
        private bool JudgeLive()
        {
            UpdateLog update = new UpdateLog(Update_Log);// 刷新日志
            try
            {
                judgeLiveErr = false;

                IntPtr hwnd = FindWindow(DingDingWindowClass, null);
                // 查找钉钉窗口句柄
                if (hwnd == IntPtr.Zero)
                    throw new Exception("获取钉钉窗口句柄失败");

                Rect r = new Rect();
                if (GetWindowRect(hwnd, out r) == 0)
                    throw new Exception("获取钉钉窗口坐标失败");

                // 截图坐标 = 相对坐标 + 钉钉窗口坐标
                ScreenshotX = r.Left + RelPosX;
                ScreenshotY = r.Top + RelPosY;

                // 截取指定坐标图片，通过rgb判断钉钉是否在直播
                bit = ScreenCapture.Screenshot(ScreenshotX, ScreenshotY, ScreenshotW, ScreenshotH);

                // 如果打开截图保存到桌面
                if (saveToDesk)
                {
                    // 目录不存在则创建
                    if (!File.Exists(DeskPath))
                        Directory.CreateDirectory(DeskPath);

                    picturePath = DeskPath + "\\截图" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + ".bmp";
                    bit.Save(picturePath, System.Drawing.Imaging.ImageFormat.Bmp);
                }
                else
                {
                    picturePath = Environment.GetEnvironmentVariable("TEMP") + "\\自动进入钉钉直播间截图.bmp";
                    bit.Save(picturePath, System.Drawing.Imaging.ImageFormat.Bmp);
                }

                // 判断图片中的rgb是否含有钉钉正在直播时的rgb
                if (ScreenCapture.Is_LiveRgb(bit, out MouseClickX, out MouseClickY) == true)
                {
                    identifyType = "RGB";
                    return true;
                } // 如果RGB判断未成功则通过OCR文字识别判断关键字
                else if (OCR.Live(picturePath) == true)
                {
                    if (File.Exists(picturePath))
                        File.Delete(picturePath);

                    identifyType = "OCR";
                    return true;
                }
                else
                {
                    MouseClickX = 0;
                    MouseClickY = 0;
                    return false;
                }

            }
            catch (Exception ex)
            {
                judgeLiveErr = true;
                threadErr = ex.Message;
                this.Invoke(update);
                return false;
            }

        }
    }
}
