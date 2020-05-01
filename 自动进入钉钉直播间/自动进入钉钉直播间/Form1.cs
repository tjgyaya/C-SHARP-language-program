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

            CheckBoxEnable(false);//将所有CheckBox复选框设置为未启用
            ComboBoxEnable(false);//将所有ComboBox列表设置为未启用
            LabelEnable(false);

            //显示窗口
            MenuItem show = new MenuItem("显示");
            show.Click += new EventHandler(Show);
            //退出菜单项  
            MenuItem exit = new MenuItem("退出");
            exit.Click += new EventHandler(Exit);

            //关联托盘控件  
            MenuItem[] childen = new MenuItem[] { show, exit };
            notifyIcon1.ContextMenu = new ContextMenu(childen);

            notifyIcon1.Text = "自动进入钉钉直播间\n点击此处显示窗口";

            textBox1_log.ReadOnly = true;
        }
        //配置文件路径
        private string iniDirectory = Environment.GetEnvironmentVariable("APPDATA") + @"\自动进入钉钉直播间";
        private string iniPath = Environment.GetEnvironmentVariable("APPDATA") + @"\自动进入钉钉直播间\自动进入钉钉直播间.ini";
        private string screenIniDir = Environment.GetEnvironmentVariable("APPDATA") + @"\自动进入钉钉直播间";
        private string screenIniPath = Environment.GetEnvironmentVariable("APPDATA") + @"\自动进入钉钉直播间\截图.ini";
        private int DingDingX = 0, DingDingY = 0;//钉钉左上角默认坐标
        private int DingDingW = 930, DingDingH = 640;//钉钉窗口默认宽度和高度
        private int ScreenshotX = 132, ScreenshotY = 102;//默认截图坐标
        private int ScreenshotW = 165, ScreenshotH = 30;//截图宽度和高度
        private int MouseClickX = 214, MouseClickY = 109;//默认鼠标点击坐标
        private string DingDingPath;//钉钉安装路径
        private int Element = 0;
        private Thread newThread;
        private bool start = false, saveDesk = false, delConfigFile = false;


        //钉钉窗口始终显示在最顶层
        private void checkBox11_ShowTop_Click(object sender, EventArgs e)
        {
            //查找钉钉窗口句柄
            hwnd = FindWindow(null, "钉钉");
            if (hwnd == IntPtr.Zero)
            {
                RefLog("获取钉钉窗口句柄失败");
                return;
            }

            if (!checkBox11_ShowTop.Checked)
            {
                checkBox11_ShowTop.Checked = true;
                SetWindowPos(hwnd, -1, 0, 0, 0, 0, 1 | 2);
            }
            else
            {
                checkBox11_ShowTop.Checked = false;
                SetWindowPos(hwnd, -2, 0, 0, 0, 0, 1 | 2);
            }
        }


        //添加自启动
        private void button2_AddStart_Click(object sender, EventArgs e)
        {
            string err = Reg.AddStart("\"" + Process.GetCurrentProcess().MainModule.FileName + "\"", "自动进入钉钉直播间");
            if (err != null)
                RefLog(err);
            else
                RefLog("添加自启动成功");
        }


        //删除自启动
        private void button3_DelStart_Click(object sender, EventArgs e)
        {
            string err = Reg.DelStart("自动进入钉钉直播间");
            if (err != null)
                RefLog(err);
            else
                RefLog("删除自启动成功");
        }


        //删除自定义截图文件
        private void button4_DelCustomScreenshot_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(screenIniPath))
                {
                    RefLog("未找到自定义截图文件");
                    return;
                }
                File.Delete(screenIniPath);
                RefLog("删除自定义截图文件成功，重启软件后生效");
            }
            catch (Exception ex)
            {
                RefLog(ex.Message);
            }
        }


        private CustomScreenshot cs;
        //自定义区域截屏
        private void button1_CustomScreenshot_Click(object sender, EventArgs e)
        {
            //判断截图窗口是否打开
            if (cs == null)
            {
                cs = new CustomScreenshot(checkBox12_SaveDesk.Checked);
                cs.Show();
            }
            else
                cs.Activate();//打开则激活窗体赋予焦点
        }


        //启用或取消启动下拉列表
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

        //启用或取消启动下复选框
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

        //取消所有复选框打勾
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


        //直播断开时自动进入
        private void checkBox1_AutoOpenLive_Click(object sender, EventArgs e)
        {
            if (!checkBox1_AutoOpenLive.Checked)
            {
                checkBox1_AutoOpenLive.Checked = true;
                if (start)
                {
                    RefLog("已开启检测...");
                    timer2.Enabled = false;
                    timer1.Enabled = true;
                }
            }
            else
            {
                checkBox1_AutoOpenLive.Checked = false;
                if (start)
                {
                    RefLog("已停止检测...");
                    timer1.Enabled = false;
                    timer2.Enabled = false;
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

        //自动开启下一次直播
        private void checkBox2_AutoOPenNextLive_Click(object sender, EventArgs e)
        {
            if (start)
            {
                RefLog("启动后不能设置自定义时间，请停止后再设置");
                return;
            }
            if (!checkBox2_AutoOPenNextLive.Checked)
            {
                checkBox2_AutoOPenNextLive.Checked = true;
                //if (start == true)
                //    MessageBox.Show("设定好时间后请先点击窗体中间的停止按钮，\n再点击开始按钮", "自动进入钉钉直播间", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                ComboBoxEnable(false);
                CheckBoxCheck(false);//打勾的复选框取消打勾
                LabelEnable(false);
            }
        }
        private void checkBox2_AutoOPenNextLive_CheckedChanged(object sender, EventArgs e)
        {
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
            //if (!checkBox3_Time1.Checked)
            //{
            //    MessageBox.Show("请启用并设定前一个自定义时间！");
            //    return;
            //}
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
            //if (!checkBox4_Time2.Checked)
            //{
            //    MessageBox.Show("请启用并设定前一个自定义时间！");
            //    return;
            //}

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


        private void checkBox12_SaveDesk_Click(object sender, EventArgs e)
        {
            if (checkBox12_SaveDesk.Checked)
                checkBox12_SaveDesk.Checked = true;
            else
                checkBox12_SaveDesk.Checked = false;
        }
        private void checkBox12_SaveDesk_CheckedChanged(object sender, EventArgs e)
        {
            saveDesk = checkBox12_SaveDesk.Checked;
        }



        //将指定的日志显示到textbox
        private void RefLog(string log)
        {
            textBox1_log.AppendText(DateTime.Now.ToString() + "  " + log + Environment.NewLine);
        }


        private bool success = true;
        private string logPath = Application.StartupPath + "\\自动进入钉钉直播间.log";
        private StreamWriter sw;
        //将日志写入文本
        private void textBox1_log_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!success)
                    return;

                sw = new StreamWriter(logPath, false, Encoding.UTF8);
                sw.Write(textBox1_log.Text);
                sw.Close();
            }
            catch
            {
                RefLog("将日志写入文件失败");
                success = false;
            }
        }


        //退出
        private void Exit(object sender, EventArgs e)
        {
            Exit_WriteConfigFile();//写入配置文件

            notifyIcon1.Dispose();//释放notifyIcon1的所有资源，保证托盘图标在程序关闭时立即消失
            if (newThread != null)
                newThread.Abort();

            Process.GetCurrentProcess().Kill();
            //Environment.Exit(0);//终止所有线程
        }
        //关闭窗口时写入配置文件
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Exit_WriteConfigFile();
            notifyIcon1.Dispose();//释放notifyIcon1的所有资源，保证托盘图标在程序关闭时立即消失
            if (newThread != null)
                newThread.Abort();
            Process.GetCurrentProcess().Kill();
        }

        private void Exit_WriteConfigFile()
        {
            if (delConfigFile != true)
            {
                if (!Directory.Exists(iniDirectory))
                    Directory.CreateDirectory(iniDirectory);

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
                      BoolToNum(checkBox11_ShowTop.Checked), this.Location.X, this.Location.Y, this.Width, this.Height, iniPath);
                if (err != null)
                    MessageBox.Show("写入配置文件错误\n原因：" + err, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        //布尔值转数字 true为1，false为0
        private int BoolToNum(bool val)
        {
            if (val == true)
                return 1;
            else
                return 0;
        }

        //数字转布尔值
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
                if (!File.Exists("NO") && !File.Exists("no"))
                {//如果当前目录存在NO这个文件
                    if (DateTime.Compare(DateTime.Now, DateTime.Parse("19:00:00")) > 1 || DateTime.Compare(DateTime.Now, DateTime.Parse("19:00:00")) == 1)
                    {//则在19点及19点后启动本软件不会启用深色模式
                        this.BackColor = SystemColors.ControlDark;
                        button5_start.BackColor = SystemColors.ActiveBorder;
                        label19_Explain.BackColor = SystemColors.WindowFrame;
                        label23_DistanceTime.BackColor = Color.Silver;
                    }
                }

                //判断主窗体配置文件是否存在
                if (Directory.Exists(iniDirectory) && File.Exists(iniPath))
                {
                    int al = 0;//中断直播时自动进入
                    int cl = 0;//每隔xx秒检测是否中断直播
                    int scl = 0;//xx分钟后还未检测到直播开启则中断检测
                    int aonl = 0;//自动打开下一次直播
                    int olt = 0;//距离下一次直播还有xx分钟时自动进入
                    int t1s = 0;//时间一
                    string t1t = null;//时间一内容
                    int t2s = 0;
                    string t2t = null;//时间二容
                    int t3s = 0;
                    string t3t = null;//时间三内容
                    int t4s = 0;
                    string t4t = null;//时间四内容
                    int t5s = 0;
                    string t5t = null;//时间五内容
                    int t6s = 0;
                    string t6t = null;//时间六内容
                    int t7s = 0;
                    string t7t = null;//时间七内容
                    int t8s = 0;
                    string t8t = null;//时间八内容
                    int st = 0;
                    //主窗体坐标 宽高
                    int px = 0;
                    int py = 0;
                    int pw = 0;
                    int ph = 0;
                    string err = ConfigFile.ReadFile(ref al, ref cl, ref scl, ref aonl, ref olt, ref t1s, out t1t, ref t2s, out t2t, ref t3s, out t3t, ref t4s, out t4t, ref t5s, out t5t, ref t6s, out t6t,
                        ref t7s, out t7t, ref t8s, out t8t, ref st, ref px, ref py, ref pw, ref ph, iniPath);

                    if (err != null)
                    {
                        RefLog(err);
                        //恢复默认数据
                        st = t8s = t7s = t6s = t5s = t4s = t3s = t2s = t1s = olt = aonl = scl = cl = al = 0;
                        t8t = t7t = t6t = t5t = t4t = t3t = t2t = t1t = "0,0";
                    }
                    else
                        RefLog("加载主窗口配置文件成功");

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


                    if (pw != 0 && ph != 0)
                    {
                        this.Width = pw;
                        this.Height = ph;
                    }
                    this.Location = new System.Drawing.Point(px, py);
                }
                else
                    RefLog("未找到主窗口配置文件");

                //读取截图配置文件
                if (Directory.Exists(screenIniDir) && File.Exists(screenIniPath))
                {
                    string error = ConfigFile.ScreenReadFile(ref DingDingX, ref DingDingY, ref DingDingW, ref DingDingH, ref ScreenshotX, ref ScreenshotY, ref ScreenshotW, ref ScreenshotH, screenIniPath);
                    if (error != null)
                    {
                        //恢复默认数据
                        DingDingX = DingDingY = 0;
                        DingDingW = 930;
                        DingDingH = 640;
                        ScreenshotX = ScreenshotY = 118;
                        ScreenshotW = 165;
                        ScreenshotH = 30;
                        MouseClickX = 214;
                        MouseClickY = 109;
                        RefLog(error);
                    }
                    else
                        RefLog("加载截图配置文件成功");
                }
                else
                    RefLog("未找到截图配置文件");

                if (!checkBox2_AutoOPenNextLive.Checked)
                {
                    checkBox2_AutoOPenNextLive.Checked = true;
                    checkBox2_AutoOPenNextLive_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                RefLog(ex.Message);
            }


        }

        private void SplitStr(string str, out int index1, out int index2)
        {
            try
            {
                string[] Array = str.Split(',');
                index1 = Convert.ToInt32(Array[0]);
                index2 = Convert.ToInt32(Array[1]);
            }
            catch
            {
                index1 = 0;
                index2 = 0;
            }
        }


        //窗口加载完成
        private void Form1_Shown(object sender, EventArgs e)
        {
            button5_Start_Click(null, null);
        }

        //显示窗口
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal; //窗体恢复正常大小
            this.ShowInTaskbar = true;
        }

        private void Show(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal; //窗体恢复正常大小
            this.ShowInTaskbar = true;
        }




        //启动
        private void button5_Start_Click(object sender, EventArgs e)
        {
           // return;

            //判断当前状态（启动|停止）
            if (start == false)
            {//启动
                start = true;
                newThread = new Thread(OpenDingDing);
                newThread.Start();//启动新线程
                button5_start.Text = "停止";

                SaveCheckboxEnable(1);
                CheckBoxEnable(false);//将所有CheckBox复选框设置为未启用
                ComboBoxEnable(false);//将所有ComboBox列表设置为未启用
                DateTimeArray();
            }
            else
            {//停止
                start = false;
                if (newThread != null)
                    newThread.Abort();//关闭线程
                button5_start.Text = "启动";

                //关闭所有计时器
                Update_Contro_Mode = 1;
                Update_Control();

                CheckBoxEnable(true);//将所有CheckBox复选框设置为启用
                ComboBoxEnable(true);//将所有ComboBox列表设置为启用
                SaveCheckboxEnable(2);
            }
        }

        private bool[] arr = new bool[16];
        private void SaveCheckboxEnable(int mode)
        {
            if (mode == 1)//保存
            {
                arr[0] = comboBox1.Enabled;
                arr[1] = comboBox2.Enabled;
                arr[2] = comboBox3.Enabled;
                arr[3] = comboBox4.Enabled;
                arr[4] = comboBox5.Enabled;
                arr[5] = comboBox6.Enabled;
                arr[6] = comboBox7.Enabled;
                arr[7] = comboBox8.Enabled;
                arr[8] = comboBox9.Enabled;
                arr[9] = comboBox10.Enabled;
                arr[10] = comboBox11.Enabled;
                arr[11] = comboBox12.Enabled;
                arr[12] = comboBox13.Enabled;
                arr[13] = comboBox14.Enabled;
                arr[14] = comboBox15.Enabled;
                arr[15] = comboBox16.Enabled;
            }
            else if (mode == 2)//恢复
            {
                comboBox1.Enabled = arr[0];
                comboBox2.Enabled = arr[1];
                comboBox3.Enabled = arr[2];
                comboBox4.Enabled = arr[3];
                comboBox5.Enabled = arr[4];
                comboBox6.Enabled = arr[5];
                comboBox7.Enabled = arr[6];
                comboBox8.Enabled = arr[7];
                comboBox9.Enabled = arr[8];
                comboBox10.Enabled = arr[9];
                comboBox11.Enabled = arr[10];
                comboBox12.Enabled = arr[11];
                comboBox13.Enabled = arr[12];
                comboBox14.Enabled = arr[13];
                comboBox15.Enabled = arr[14];
                comboBox16.Enabled = arr[15];
            }
        }



        //timer1检测直播是否中断
        //timer2检测直播是否中断后直播是否开启
        //timer3检测当前时间是否到下一场直播开启时间
        //timer4计时当前直播已开启xx分钟
        private int timer1_Num = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = decimal.ToInt32(numericUpDown1_CheckLiveTime.Value) * 1000;//将秒化为毫秒
            RefLog("第" + timer1_Num.ToString() + "次检测直播是否中断...");
            timer1_Num++;

            //判断图片中的rgb是否与钉钉正在直播时的rgb一致
            if (!JudgePixel())
            {
                RefLog("检测到直播中断");
                LiveBSTime = DateTime.Now;//保存直播断开时间
                timer2.Enabled = true;//检测直播是否断开后直播是否开启
                timer1.Enabled = false;//关闭检测直播是否中断
                start = false;
            }
        }

        //直播断开时间
        private DateTime LiveBSTime;
        private int timer2_Num = 1;
        private void timer2_Tick(object sender, EventArgs e)
        {
            RefLog("第" + timer2_Num.ToString() + "次检测直播重新开启...");
            timer2_Num++;

            //如果当前时间 大于 （直播断开时间 + xx分钟后还未检测到直播开启则停止检测时间）
            if (DateTime.Now > LiveBSTime.AddMinutes(decimal.ToDouble(numericUpDown2_StopCheckLiveTime.Value)))
            {
                RefLog("检测直播是否重新开启超时，即将停止检测");
                timer2.Enabled = false;
            }

            if (JudgePixel())//截取指定区域图片，判断直播是否恢复
            {
                timer2.Enabled = false;
                RefLog("已检测到直播重新开启");
                OpenDingDing();
            }
        }


        private void timer3_Tick(object sender, EventArgs e)
        {
            //如果是最后一个自定义时间
            if (Element + 1 >= Dates.Length)
            {
                RefLog("已到达最后一个自定义时间，自动开启下一次直播将不会生效");

                if (!checkBox1_AutoOpenLive.Checked)
                {
                    //timer1.Enabled = false;
                    //timer2.Enabled = false;
                    timer3.Enabled = false;
                    timer4.Enabled = false;

                    start = false;
                    button5_start.Text = "启动";
                    CheckBoxEnable(true);//将所有CheckBox复选框设置为启用
                    ComboBoxEnable(true);//将所有ComboBox列表设置为启用
                    SaveCheckboxEnable(2);

                    label23_DistanceTime.Text =
                   "距   00\n"
                 + "离   时\n"
                 + "开   00\n"
                 + "启   分\n"
                 + "还   00\n"
                 + "有   秒";
                }

                timer3.Enabled = false;
                return;
            }
            if (DateTime.Now >= Dates[Element + 1].AddMinutes(-(double)numericUpDown3.Value))//如果当前时间 大于或等于 直播开启时间 =（直播时间-距离直播还有xx分钟自动开启）
            {
                if (JudgePixel())//如果直播未关闭
                    return;
                timer3.Enabled = false;
                Element += 1;
                OpenDingDing();
            }
        }

        private DateTime timer4_Time;
        private TimeSpan diff;
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

        /// <summary>
        /// 在多线程中刷新控件
        /// </summary>
        private void Update_Log()
        {
            RefLog(threadErr);
        }


        //杂七杂八
        private TimeSpan timeDiffer;
        private int Update_Contro_Mode;
        private void Update_Control()
        {
            if (Update_Contro_Mode == 1)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
            }
            if (Update_Contro_Mode == 2)
            {
                timer1.Enabled = checkBox1_AutoOpenLive.Checked;//启动定时器，检测直播是否中断
            }
            else if (Update_Contro_Mode == 3)
            {
                timer3.Enabled = checkBox2_AutoOPenNextLive.Checked;//检测是否到达下一次直播时间
            }
            else if (Update_Contro_Mode == 4)
            {
                if (checkBox1_AutoOpenLive.Checked || checkBox2_AutoOPenNextLive.Checked)
                {
                    timer4.Enabled = true;//直播开启后计时
                    timer4_Time = DateTime.Now;
                }
                else
                {
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    timer3.Enabled = false;
                    timer4.Enabled = false;

                    start = false;
                    button5_start.Text = "启动";
                    CheckBoxEnable(true);//将所有CheckBox复选框设置为启用
                    ComboBoxEnable(true);//将所有ComboBox列表设置为启用
                    SaveCheckboxEnable(2);
                }
            }
            else if (Update_Contro_Mode == 5)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;

                start = false;
                button5_start.Text = "启动";
                CheckBoxEnable(true);//将所有CheckBox复选框设置为启用
                ComboBoxEnable(true);//将所有ComboBox列表设置为启用
                SaveCheckboxEnable(2);
            }
            else if (Update_Contro_Mode == 999)
            {
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


        private DateTime[] Dates;
        private void DateTimeArray()
        {
            Dates = new DateTime[8];

            if (checkBox3_Time1.Checked)
                Dates[0] = DateTime.Parse(comboBox1.SelectedItem.ToString() + ":" + comboBox2.SelectedItem.ToString());
            if (checkBox4_Time2.Checked)
                Dates[1] = DateTime.Parse(comboBox3.SelectedItem.ToString() + ":" + comboBox4.SelectedItem.ToString());
            if (checkBox5_Time3.Checked)
                Dates[2] = DateTime.Parse(comboBox5.SelectedItem.ToString() + ":" + comboBox6.SelectedItem.ToString());
            if (checkBox6_Time4.Checked)
                Dates[3] = DateTime.Parse(comboBox7.SelectedItem.ToString() + ":" + comboBox8.SelectedItem.ToString());
            if (checkBox6_Time4.Checked)
                Dates[4] = DateTime.Parse(comboBox9.SelectedItem.ToString() + ":" + comboBox10.SelectedItem.ToString());
            if (checkBox6_Time4.Checked)
                Dates[5] = DateTime.Parse(comboBox11.SelectedItem.ToString() + ":" + comboBox12.SelectedItem.ToString());
            if (checkBox7_Time5.Checked)
                Dates[6] = DateTime.Parse(comboBox13.SelectedItem.ToString() + ":" + comboBox14.SelectedItem.ToString());
            if (checkBox8_Time6.Checked)
                Dates[7] = DateTime.Parse(comboBox15.SelectedItem.ToString() + ":" + comboBox16.SelectedItem.ToString());
            BubbleSorting(ref Dates);
        }
        //将时间数组进行冒泡排序
        private void BubbleSorting(ref DateTime[] dates)
        {
            DateTime tmp = DateTime.Parse("0001/1/1 00:00:00");
            List<DateTime> list = dates.ToList();

            for (int k = 0; k < list.Count; k++)
            {
                if (DateTime.Compare(list[k], tmp) == 0)
                {
                    list.RemoveAt(k);//移除未赋值的元素（0001/1/1 00:00:00）
                    k--;
                }
            }

            dates = list.ToArray();

            //冒泡排序，把最小的排到前面
            for (int i = 0; i < dates.Length; i++)
            {
                for (int j = 0; j < dates.Length; j++)
                {
                    if (DateTime.Compare(dates[i], dates[j]) < 0)//进行比较
                    {
                        tmp = dates[i];
                        dates[i] = dates[j];
                        dates[j] = tmp;
                    }
                }
            }

        }




        [DllImport("user32.dll", EntryPoint = "FindWindow")]//查找窗口句柄
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);//始终保持窗口在最前端

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);//移动窗口

        [DllImport("User32")]
        public extern static void SetCursorPos(int x, int y);//设置鼠标光标位置

        [DllImport("User32")]
        public extern static bool GetCursorPos(out POINT p);//获取鼠标光标位置

        [DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);//模拟鼠标左键按下


        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }

        [DllImport("user32.dll")]
        private static extern int GetWindowRect(IntPtr hwnd, out Rect lpRect);//获取钉钉窗口位置
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        const int MOUSEEVENTF_LEFTDOWN = 0x0002;   //模拟鼠标左键按下      

        private void label20_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.52pojie.cn/thread-1168398-3-1.html");
        }

        private void button6_delConfigFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists(iniPath))
                {
                    RefLog("未找到主窗口配置文件");
                    return;
                }
                File.Delete(iniPath);
                RefLog("删除主窗口配置文件成功，重启软件后生效");
                delConfigFile = true;
            }
            catch (Exception ex)
            {
                RefLog(ex.Message);
            }
            //ScreenCapture.Screenshot(ScreenshotX, ScreenshotY, 165, 30).Save(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\自动进入钉钉直播间" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://shimo.im/docs/b8467ba8b9db4e29/");
        }


        //在button按钮显示提示
        private void button1_CustomScreenshot_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.button1_CustomScreenshot, "多次检测直播失败时请使用此功能\n有几率 提高 识别钉钉直播是否开启的准确性");
        }

        private void button2_AddStart_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.button2_AddStart, "添加自启动后本软件将 会 在系统启动时自动启动");
        }

        private void button3_DelStart_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.button3_DelStart, "删除自启动后本软件将 不会 在系统启动时自动启动");
        }

        private void button4_DelCustomScreenshot_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.button4_DelCustomScreenshot, "删除截图数据后，截图数据会恢复到默认，\n有可能 降低 识别钉钉直播是否开启的准确性");
        }

        private void button6_delConfigFile_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.button6_delConfigFile, "此功能会删除 您设定的自定义时间数据，\n但不会删除自定义截图数据");
        }

        private void checkBox2_AutoOPenNextLive_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.checkBox2_AutoOPenNextLive, "启用此功能后会在当前直播完后\n按照设定并启用的自定义时间自动打开下一场直播");
        }

        private void label19_Explain_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.label19_Explain, "学生党请以学习为重");
        }

        const int MOUSEEVENTF_LEFTUP = 0x0004;     //模拟鼠标左键抬起 

        protected delegate void UpdateLog();//刷新控件
        protected delegate void UpdateLabel();//刷新控件
        private string threadErr;
        private IntPtr hwnd;//窗口句柄

        /// <summary>
        /// 打开钉钉并检测是否正在直播
        /// </summary>
        private void OpenDingDing()
        {
            ////如果钉钉进程存在，则杀掉
            //foreach (Process pro in Process.GetProcessesByName("DingTalk"))
            //{
            //    pro.Kill();
            //}

            UpdateLog update = new UpdateLog(Update_Log);//刷新日志
            UpdateLabel ul = new UpdateLabel(Update_Control);//杂七杂八
            int i = 1;
            Update_Contro_Mode = 1;
            this.Invoke(ul);

            string err = Reg.GetDingDingPath(out DingDingPath);//获取钉钉路径
            if (err != null)
            {
                this.Invoke(update);
                newThread.Abort();//终止线程
            }

            threadErr = "获取钉钉路径成功";
            this.Invoke(update);//调用窗体Invoke方法

            try
            {
                Process.Start(DingDingPath);//打开钉钉

                threadErr = "正在打开钉钉...";
                this.Invoke(update);

                for (i = 1; i <= 5; i++)
                {
                    threadErr = "\t" + i.ToString() + "...";
                    this.Invoke(update);
                    Thread.Sleep(1000);//休眠5秒等待打开钉钉
                }


                for (i = 1; i <= 20; i++)//寻找钉钉进程
                {
                    foreach (Process pro in Process.GetProcesses())
                    {
                        if (pro.ProcessName.ToLower() == "DingTalk".ToLower())
                        {
                            i = 999;
                            break;
                        }
                    }

                    if (i > 20)
                        break;
                    else if (i == 20)
                    {
                        threadErr = "未找到钉钉进程";
                        this.Invoke(update);
                        newThread.Abort();//如果1分钟还未找到则终止线程
                    }
                    Thread.Sleep(5000);//如未找到则等待5秒再查找
                }


                threadErr = "已找到钉钉进程";
                this.Invoke(update);

                threadErr = "请不要移动钉钉窗口，否则会造成识别失败";
                this.Invoke(update);

                //查找钉钉窗口句柄
                hwnd = FindWindow(null, "钉钉");
                if (hwnd == IntPtr.Zero)
                {
                    threadErr = "获取钉钉窗口句柄失败";
                    this.Invoke(update);
                    newThread.Abort();
                }


                threadErr = "已找到钉钉窗口句柄";
                this.Invoke(update);


                ////移动钉钉窗口
                //if (checkBox11_ShowTop.Checked)
                //    SetWindowPos(hwnd, -1, DingDingX, DingDingY, DingDingW, DingDingH, 0x0040);
                //else
                MoveWindow(hwnd, DingDingX, DingDingY, DingDingW, DingDingH, true);


                //判断直播时间
                if (checkBox2_AutoOPenNextLive.Checked)
                {
                    threadErr = "正在检测是否到达直播开启时间...";
                    this.Invoke(update);

                    for (i = Element; i < Dates.Length; i++)
                    {
                        if (DateTime.Now >= Dates[i])
                        {
                            continue;
                        }
                        else
                        {
                            //如果当前时间大于上一次直播开启时间，小于下一次直播开启时间
                            if (JudgePixel())//判断直播是否开启
                                break;
                        }

                        //判断当前时间是否小于下一次直播开启时间
                        while (DateTime.Now < Dates[i])//如果当前时间 小于 自定义直播时间
                        {
                            timeDiffer = Dates[i].AddMinutes(-(double)numericUpDown3.Value) - DateTime.Now;//获取时间差，并显示到label23
                            Update_Contro_Mode = 999;//刷新距离直播开启还有xx时xx分xx秒
                            this.Invoke(ul);
                            Thread.Sleep(1000);//休眠一秒判断
                            if (DateTime.Now >= Dates[i].AddMinutes(-(double)numericUpDown3.Value))//如果当前时间 小于 直播开启时间 =（直播时间-距离直播还有xx分钟自动开启）
                                goto loop;
                        }
                    }
                }

            loop:
                Element = i;//保存当前直播开启时间的数组元素下标
                threadErr = "正在检测当前是否正在直播...";
                this.Invoke(update);
                //判断是否正在直播

                for (i = 1; i <= 1800; i++)//60分钟都还未直播就退出
                {
                    threadErr = "第" + i.ToString() + "次检测当前是否正在直播...";
                    this.Invoke(update);

                    if (JudgePixel())//判断是否在直播
                    {
                        threadErr = "检测到当前正在直播";
                        this.Invoke(update);
                        break;
                    }
                    Thread.Sleep(5000);//如未找到则等待5秒再查找
                }


                threadErr = "打开直播中...";
                this.Invoke(update);

                POINT p = new POINT();
                GetCursorPos(out p);//获取鼠标光标位置
                SetCursorPos(MouseClickX, MouseClickY);//设置鼠标光标位置
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);  //模拟鼠标左键按下

                threadErr = "已打开直播";
                this.Invoke(update);

                SetCursorPos(p.X, p.Y);//恢复鼠标原来的位置


                //已在Update_Control判断复选框是否打开
                //启动timer1，检测直播是否中断
                Update_Contro_Mode = 2;
                this.Invoke(ul);

                //启动timer3，检测是否到达下一场直播时间
                Update_Contro_Mode = 3;
                this.Invoke(ul);

                Update_Contro_Mode = 4;
                this.Invoke(ul);

            }
            catch (Exception ex)
            {
                threadErr = ex.Message;
                this.Invoke(update);

                //退出
                Update_Contro_Mode = 5;
                this.Invoke(ul);
                newThread.Abort();//退出线程
            }
        }


        //判断图片中的rgb是否与钉钉正在直播时的rgb一致
        private bool JudgePixel()
        {
            Bitmap bit;
            bit = ScreenCapture.Screenshot(ScreenshotX, ScreenshotY, ScreenshotW, ScreenshotH);//截取指定坐标图片，通过rgb判断钉钉是否在直播

            if (saveDesk)
                bit.Save(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\自动进入钉钉直播间" + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss") + ".jpg");

            if (ScreenCapture.GetPixel(bit, out MouseClickX, out MouseClickY) == true)//判断图片中的rgb是否与钉钉正在直播时的rgb一致
            {
                MouseClickX += ScreenshotX;
                MouseClickY += ScreenshotY;
                return true;
            }
            else
            {
                MouseClickX = 214;
                MouseClickY = 109;
                return false;
            }
        }
    }
}
