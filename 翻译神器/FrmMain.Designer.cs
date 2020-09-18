namespace 翻译神器
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.textBox_FixedTranHotkey = new System.Windows.Forms.TextBox();
            this.label_FixedTranHotkey = new System.Windows.Forms.Label();
            this.textBox_SwitchRuToCn = new System.Windows.Forms.TextBox();
            this.label_SwitchRuToCn = new System.Windows.Forms.Label();
            this.textBox_SwitchEnToCn = new System.Windows.Forms.TextBox();
            this.label_SwitchEnToCn = new System.Windows.Forms.Label();
            this.groupBox_HotKey = new System.Windows.Forms.GroupBox();
            this.textBox_TranHotkey = new System.Windows.Forms.TextBox();
            this.label_TranHotkey = new System.Windows.Forms.Label();
            this.textBox_ScreenHotkey = new System.Windows.Forms.TextBox();
            this.label_ScreenHotkey = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label_WindowName = new System.Windows.Forms.Label();
            this.label_WindowClass = new System.Windows.Forms.Label();
            this.textBox_WindowName = new System.Windows.Forms.TextBox();
            this.textBox_WindowClass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_Reload = new System.Windows.Forms.Button();
            this.groupBox_FixedTran = new System.Windows.Forms.GroupBox();
            this.button_SetPosition = new System.Windows.Forms.Button();
            this.button_Save = new System.Windows.Forms.Button();
            this.groupBox_Other = new System.Windows.Forms.GroupBox();
            this.checkBox_ReadAloud = new System.Windows.Forms.CheckBox();
            this.comboBox_TranSource = new System.Windows.Forms.ComboBox();
            this.label_TranSource = new System.Windows.Forms.Label();
            this.checkBox_CopyTranText = new System.Windows.Forms.CheckBox();
            this.checkBox_CopyOriginalText = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown_Delay = new System.Windows.Forms.NumericUpDown();
            this.label_Delay = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_YoudaoKeyTest = new System.Windows.Forms.Button();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.textBox_YoudaoAppSecret = new System.Windows.Forms.TextBox();
            this.textBox_YoudaoAppKey = new System.Windows.Forms.TextBox();
            this.label_YoudaoAppSecret = new System.Windows.Forms.Label();
            this.label_YoudaoAppKey = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_BaiduKeyTest = new System.Windows.Forms.Button();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label_BaiduPassword = new System.Windows.Forms.Label();
            this.label_BaiduAppId = new System.Windows.Forms.Label();
            this.textBox_BaiduPassword = new System.Windows.Forms.TextBox();
            this.textBox_BaiduAppId = new System.Windows.Forms.TextBox();
            this.textBox_BaiduSecretKey = new System.Windows.Forms.TextBox();
            this.textBox_BaiduApiKey = new System.Windows.Forms.TextBox();
            this.label_BaiduSecretKey = new System.Windows.Forms.Label();
            this.label_BaiduApiKey = new System.Windows.Forms.Label();
            this.groupBox_HotKey.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox_FixedTran.SuspendLayout();
            this.groupBox_Other.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Delay)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_FixedTranHotkey
            // 
            this.textBox_FixedTranHotkey.BackColor = System.Drawing.Color.White;
            this.textBox_FixedTranHotkey.Location = new System.Drawing.Point(87, 80);
            this.textBox_FixedTranHotkey.Name = "textBox_FixedTranHotkey";
            this.textBox_FixedTranHotkey.ReadOnly = true;
            this.textBox_FixedTranHotkey.Size = new System.Drawing.Size(111, 23);
            this.textBox_FixedTranHotkey.TabIndex = 9;
            this.toolTip1.SetToolTip(this.textBox_FixedTranHotkey, "在固定区域截图并翻译");
            this.textBox_FixedTranHotkey.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_PreviewKeyDown);
            // 
            // label_FixedTranHotkey
            // 
            this.label_FixedTranHotkey.AutoSize = true;
            this.label_FixedTranHotkey.Location = new System.Drawing.Point(24, 83);
            this.label_FixedTranHotkey.Name = "label_FixedTranHotkey";
            this.label_FixedTranHotkey.Size = new System.Drawing.Size(68, 17);
            this.label_FixedTranHotkey.TabIndex = 8;
            this.label_FixedTranHotkey.Text = "固定翻译：";
            this.toolTip1.SetToolTip(this.label_FixedTranHotkey, "在固定区域截图并翻译");
            // 
            // textBox_SwitchRuToCn
            // 
            this.textBox_SwitchRuToCn.BackColor = System.Drawing.Color.White;
            this.textBox_SwitchRuToCn.Location = new System.Drawing.Point(279, 50);
            this.textBox_SwitchRuToCn.Name = "textBox_SwitchRuToCn";
            this.textBox_SwitchRuToCn.ReadOnly = true;
            this.textBox_SwitchRuToCn.Size = new System.Drawing.Size(112, 23);
            this.textBox_SwitchRuToCn.TabIndex = 7;
            this.toolTip1.SetToolTip(this.textBox_SwitchRuToCn, "切换翻译源和目标语言为俄语翻译中文");
            this.textBox_SwitchRuToCn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_PreviewKeyDown);
            // 
            // label_SwitchRuToCn
            // 
            this.label_SwitchRuToCn.AutoSize = true;
            this.label_SwitchRuToCn.Location = new System.Drawing.Point(217, 53);
            this.label_SwitchRuToCn.Name = "label_SwitchRuToCn";
            this.label_SwitchRuToCn.Size = new System.Drawing.Size(68, 17);
            this.label_SwitchRuToCn.TabIndex = 6;
            this.label_SwitchRuToCn.Text = "切换俄中：";
            this.toolTip1.SetToolTip(this.label_SwitchRuToCn, "切换翻译源和目标语言为俄语翻译中文");
            // 
            // textBox_SwitchEnToCn
            // 
            this.textBox_SwitchEnToCn.BackColor = System.Drawing.Color.White;
            this.textBox_SwitchEnToCn.Location = new System.Drawing.Point(279, 19);
            this.textBox_SwitchEnToCn.Name = "textBox_SwitchEnToCn";
            this.textBox_SwitchEnToCn.ReadOnly = true;
            this.textBox_SwitchEnToCn.Size = new System.Drawing.Size(112, 23);
            this.textBox_SwitchEnToCn.TabIndex = 5;
            this.toolTip1.SetToolTip(this.textBox_SwitchEnToCn, "切换翻译源和目标语言为英语翻译中文");
            this.textBox_SwitchEnToCn.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_PreviewKeyDown);
            // 
            // label_SwitchEnToCn
            // 
            this.label_SwitchEnToCn.AutoSize = true;
            this.label_SwitchEnToCn.Location = new System.Drawing.Point(217, 22);
            this.label_SwitchEnToCn.Name = "label_SwitchEnToCn";
            this.label_SwitchEnToCn.Size = new System.Drawing.Size(68, 17);
            this.label_SwitchEnToCn.TabIndex = 4;
            this.label_SwitchEnToCn.Text = "切换英中：";
            this.toolTip1.SetToolTip(this.label_SwitchEnToCn, "切换翻译源和目标语言为英语翻译中文");
            // 
            // groupBox_HotKey
            // 
            this.groupBox_HotKey.BackColor = System.Drawing.Color.White;
            this.groupBox_HotKey.Controls.Add(this.textBox_FixedTranHotkey);
            this.groupBox_HotKey.Controls.Add(this.label_FixedTranHotkey);
            this.groupBox_HotKey.Controls.Add(this.textBox_SwitchRuToCn);
            this.groupBox_HotKey.Controls.Add(this.label_SwitchRuToCn);
            this.groupBox_HotKey.Controls.Add(this.textBox_SwitchEnToCn);
            this.groupBox_HotKey.Controls.Add(this.label_SwitchEnToCn);
            this.groupBox_HotKey.Controls.Add(this.textBox_TranHotkey);
            this.groupBox_HotKey.Controls.Add(this.label_TranHotkey);
            this.groupBox_HotKey.Controls.Add(this.textBox_ScreenHotkey);
            this.groupBox_HotKey.Controls.Add(this.label_ScreenHotkey);
            this.groupBox_HotKey.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox_HotKey.Location = new System.Drawing.Point(3, 3);
            this.groupBox_HotKey.Name = "groupBox_HotKey";
            this.groupBox_HotKey.Size = new System.Drawing.Size(444, 111);
            this.groupBox_HotKey.TabIndex = 3;
            this.groupBox_HotKey.TabStop = false;
            this.groupBox_HotKey.Text = "热键";
            // 
            // textBox_TranHotkey
            // 
            this.textBox_TranHotkey.BackColor = System.Drawing.Color.White;
            this.textBox_TranHotkey.Location = new System.Drawing.Point(87, 50);
            this.textBox_TranHotkey.Name = "textBox_TranHotkey";
            this.textBox_TranHotkey.ReadOnly = true;
            this.textBox_TranHotkey.Size = new System.Drawing.Size(111, 23);
            this.textBox_TranHotkey.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textBox_TranHotkey, "显示翻译窗口");
            this.textBox_TranHotkey.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_PreviewKeyDown);
            // 
            // label_TranHotkey
            // 
            this.label_TranHotkey.AutoSize = true;
            this.label_TranHotkey.Location = new System.Drawing.Point(24, 53);
            this.label_TranHotkey.Name = "label_TranHotkey";
            this.label_TranHotkey.Size = new System.Drawing.Size(68, 17);
            this.label_TranHotkey.TabIndex = 2;
            this.label_TranHotkey.Text = "翻译热键：";
            this.toolTip1.SetToolTip(this.label_TranHotkey, "显示翻译窗口");
            // 
            // textBox_ScreenHotkey
            // 
            this.textBox_ScreenHotkey.BackColor = System.Drawing.Color.White;
            this.textBox_ScreenHotkey.Location = new System.Drawing.Point(87, 19);
            this.textBox_ScreenHotkey.Name = "textBox_ScreenHotkey";
            this.textBox_ScreenHotkey.ReadOnly = true;
            this.textBox_ScreenHotkey.Size = new System.Drawing.Size(111, 23);
            this.textBox_ScreenHotkey.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBox_ScreenHotkey, "鼠标拖动截图并显示翻译结果");
            this.textBox_ScreenHotkey.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_PreviewKeyDown);
            // 
            // label_ScreenHotkey
            // 
            this.label_ScreenHotkey.AutoSize = true;
            this.label_ScreenHotkey.Location = new System.Drawing.Point(24, 22);
            this.label_ScreenHotkey.Name = "label_ScreenHotkey";
            this.label_ScreenHotkey.Size = new System.Drawing.Size(68, 17);
            this.label_ScreenHotkey.TabIndex = 0;
            this.label_ScreenHotkey.Text = "截图热键：";
            this.toolTip1.SetToolTip(this.label_ScreenHotkey, "鼠标拖动截图并显示翻译结果");
            // 
            // label_WindowName
            // 
            this.label_WindowName.AutoSize = true;
            this.label_WindowName.Location = new System.Drawing.Point(24, 25);
            this.label_WindowName.Name = "label_WindowName";
            this.label_WindowName.Size = new System.Drawing.Size(68, 17);
            this.label_WindowName.TabIndex = 10;
            this.label_WindowName.Text = "窗口标题：";
            this.toolTip1.SetToolTip(this.label_WindowName, "在固定区域截图并翻译");
            // 
            // label_WindowClass
            // 
            this.label_WindowClass.AutoSize = true;
            this.label_WindowClass.Location = new System.Drawing.Point(217, 25);
            this.label_WindowClass.Name = "label_WindowClass";
            this.label_WindowClass.Size = new System.Drawing.Size(68, 17);
            this.label_WindowClass.TabIndex = 12;
            this.label_WindowClass.Text = "窗口类名：";
            this.toolTip1.SetToolTip(this.label_WindowClass, "在固定区域截图并翻译");
            // 
            // textBox_WindowName
            // 
            this.textBox_WindowName.BackColor = System.Drawing.Color.White;
            this.textBox_WindowName.Location = new System.Drawing.Point(87, 22);
            this.textBox_WindowName.Name = "textBox_WindowName";
            this.textBox_WindowName.Size = new System.Drawing.Size(111, 23);
            this.textBox_WindowName.TabIndex = 11;
            // 
            // textBox_WindowClass
            // 
            this.textBox_WindowClass.BackColor = System.Drawing.Color.White;
            this.textBox_WindowClass.Location = new System.Drawing.Point(279, 22);
            this.textBox_WindowClass.Name = "textBox_WindowClass";
            this.textBox_WindowClass.Size = new System.Drawing.Size(111, 23);
            this.textBox_WindowClass.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(3, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 30);
            this.label2.TabIndex = 11;
            this.label2.Text = "使用方法：\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 16F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(8, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 180);
            this.label1.TabIndex = 10;
            this.label1.Text = "             \r\n             1、按下截图热键\r\n\r\n             2、用鼠标选取需要翻译的区域\r\n\r\n          " +
    "   3、查看翻译结果\r\n";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox1.Size = new System.Drawing.Size(450, 359);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(450, 359);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "首页";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button_Reload);
            this.tabPage2.Controls.Add(this.groupBox_FixedTran);
            this.tabPage2.Controls.Add(this.button_Save);
            this.tabPage2.Controls.Add(this.groupBox_Other);
            this.tabPage2.Controls.Add(this.groupBox_HotKey);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(450, 359);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button_Reload
            // 
            this.button_Reload.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Reload.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.button_Reload.FlatAppearance.BorderSize = 2;
            this.button_Reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Reload.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.button_Reload.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.button_Reload.Location = new System.Drawing.Point(101, 314);
            this.button_Reload.Name = "button_Reload";
            this.button_Reload.Size = new System.Drawing.Size(100, 37);
            this.button_Reload.TabIndex = 7;
            this.button_Reload.Text = "重新加载";
            this.button_Reload.UseVisualStyleBackColor = true;
            this.button_Reload.Click += new System.EventHandler(this.button_Reload_Click);
            // 
            // groupBox_FixedTran
            // 
            this.groupBox_FixedTran.Controls.Add(this.button_SetPosition);
            this.groupBox_FixedTran.Controls.Add(this.textBox_WindowClass);
            this.groupBox_FixedTran.Controls.Add(this.label_WindowClass);
            this.groupBox_FixedTran.Controls.Add(this.textBox_WindowName);
            this.groupBox_FixedTran.Controls.Add(this.label_WindowName);
            this.groupBox_FixedTran.Location = new System.Drawing.Point(3, 219);
            this.groupBox_FixedTran.Name = "groupBox_FixedTran";
            this.groupBox_FixedTran.Size = new System.Drawing.Size(444, 90);
            this.groupBox_FixedTran.TabIndex = 6;
            this.groupBox_FixedTran.TabStop = false;
            this.groupBox_FixedTran.Text = "固定翻译";
            // 
            // button_SetPosition
            // 
            this.button_SetPosition.BackColor = System.Drawing.Color.White;
            this.button_SetPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SetPosition.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.button_SetPosition.ForeColor = System.Drawing.Color.DarkOrange;
            this.button_SetPosition.Location = new System.Drawing.Point(27, 51);
            this.button_SetPosition.Name = "button_SetPosition";
            this.button_SetPosition.Size = new System.Drawing.Size(171, 33);
            this.button_SetPosition.TabIndex = 16;
            this.button_SetPosition.Text = "设置固定翻译坐标";
            this.button_SetPosition.UseVisualStyleBackColor = true;
            this.button_SetPosition.Click += new System.EventHandler(this.button_SetPosition_Click);
            // 
            // button_Save
            // 
            this.button_Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_Save.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.button_Save.FlatAppearance.BorderSize = 2;
            this.button_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Save.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.button_Save.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button_Save.Location = new System.Drawing.Point(238, 314);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(100, 37);
            this.button_Save.TabIndex = 5;
            this.button_Save.Text = "保存配置";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // groupBox_Other
            // 
            this.groupBox_Other.BackColor = System.Drawing.Color.White;
            this.groupBox_Other.Controls.Add(this.checkBox_ReadAloud);
            this.groupBox_Other.Controls.Add(this.comboBox_TranSource);
            this.groupBox_Other.Controls.Add(this.label_TranSource);
            this.groupBox_Other.Controls.Add(this.checkBox_CopyTranText);
            this.groupBox_Other.Controls.Add(this.checkBox_CopyOriginalText);
            this.groupBox_Other.Controls.Add(this.label7);
            this.groupBox_Other.Controls.Add(this.numericUpDown_Delay);
            this.groupBox_Other.Controls.Add(this.label_Delay);
            this.groupBox_Other.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox_Other.Location = new System.Drawing.Point(3, 119);
            this.groupBox_Other.Name = "groupBox_Other";
            this.groupBox_Other.Size = new System.Drawing.Size(444, 94);
            this.groupBox_Other.TabIndex = 4;
            this.groupBox_Other.TabStop = false;
            this.groupBox_Other.Text = "其它";
            // 
            // checkBox_ReadAloud
            // 
            this.checkBox_ReadAloud.AutoCheck = false;
            this.checkBox_ReadAloud.AutoSize = true;
            this.checkBox_ReadAloud.Location = new System.Drawing.Point(235, 66);
            this.checkBox_ReadAloud.Name = "checkBox_ReadAloud";
            this.checkBox_ReadAloud.Size = new System.Drawing.Size(111, 21);
            this.checkBox_ReadAloud.TabIndex = 7;
            this.checkBox_ReadAloud.Text = "翻译后朗读译文";
            this.checkBox_ReadAloud.UseVisualStyleBackColor = true;
            this.checkBox_ReadAloud.Click += new System.EventHandler(this.checkBox_Click);
            // 
            // comboBox_TranSource
            // 
            this.comboBox_TranSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TranSource.FormattingEnabled = true;
            this.comboBox_TranSource.Items.AddRange(new object[] {
            "百度翻译（推荐）",
            "有道翻译"});
            this.comboBox_TranSource.Location = new System.Drawing.Point(87, 58);
            this.comboBox_TranSource.Name = "comboBox_TranSource";
            this.comboBox_TranSource.Size = new System.Drawing.Size(111, 25);
            this.comboBox_TranSource.TabIndex = 6;
            // 
            // label_TranSource
            // 
            this.label_TranSource.AutoSize = true;
            this.label_TranSource.Location = new System.Drawing.Point(24, 61);
            this.label_TranSource.Name = "label_TranSource";
            this.label_TranSource.Size = new System.Drawing.Size(68, 17);
            this.label_TranSource.TabIndex = 5;
            this.label_TranSource.Text = "翻译来源：";
            // 
            // checkBox_CopyTranText
            // 
            this.checkBox_CopyTranText.AutoCheck = false;
            this.checkBox_CopyTranText.AutoSize = true;
            this.checkBox_CopyTranText.Location = new System.Drawing.Point(235, 39);
            this.checkBox_CopyTranText.Name = "checkBox_CopyTranText";
            this.checkBox_CopyTranText.Size = new System.Drawing.Size(99, 21);
            this.checkBox_CopyTranText.TabIndex = 4;
            this.checkBox_CopyTranText.Text = "复制翻译译文";
            this.checkBox_CopyTranText.UseVisualStyleBackColor = true;
            this.checkBox_CopyTranText.Click += new System.EventHandler(this.checkBox_Click);
            // 
            // checkBox_CopyOriginalText
            // 
            this.checkBox_CopyOriginalText.AutoCheck = false;
            this.checkBox_CopyOriginalText.AutoSize = true;
            this.checkBox_CopyOriginalText.Location = new System.Drawing.Point(235, 13);
            this.checkBox_CopyOriginalText.Name = "checkBox_CopyOriginalText";
            this.checkBox_CopyOriginalText.Size = new System.Drawing.Size(99, 21);
            this.checkBox_CopyOriginalText.TabIndex = 3;
            this.checkBox_CopyOriginalText.Text = "复制翻译原文";
            this.checkBox_CopyOriginalText.UseVisualStyleBackColor = true;
            this.checkBox_CopyOriginalText.Click += new System.EventHandler(this.checkBox_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(106, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "秒关闭译文窗口";
            // 
            // numericUpDown_Delay
            // 
            this.numericUpDown_Delay.Location = new System.Drawing.Point(62, 16);
            this.numericUpDown_Delay.Name = "numericUpDown_Delay";
            this.numericUpDown_Delay.Size = new System.Drawing.Size(40, 23);
            this.numericUpDown_Delay.TabIndex = 1;
            this.numericUpDown_Delay.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label_Delay
            // 
            this.label_Delay.AutoSize = true;
            this.label_Delay.Location = new System.Drawing.Point(24, 17);
            this.label_Delay.Name = "label_Delay";
            this.label_Delay.Size = new System.Drawing.Size(44, 17);
            this.label_Delay.TabIndex = 0;
            this.label_Delay.Text = "延迟：";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(458, 389);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(450, 359);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "翻译Key";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button_YoudaoKeyTest);
            this.groupBox2.Controls.Add(this.linkLabel3);
            this.groupBox2.Controls.Add(this.textBox_YoudaoAppSecret);
            this.groupBox2.Controls.Add(this.textBox_YoudaoAppKey);
            this.groupBox2.Controls.Add(this.label_YoudaoAppSecret);
            this.groupBox2.Controls.Add(this.label_YoudaoAppKey);
            this.groupBox2.Location = new System.Drawing.Point(3, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 157);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "有道";
            // 
            // button_YoudaoKeyTest
            // 
            this.button_YoudaoKeyTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_YoudaoKeyTest.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button_YoudaoKeyTest.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button_YoudaoKeyTest.Location = new System.Drawing.Point(372, 109);
            this.button_YoudaoKeyTest.Name = "button_YoudaoKeyTest";
            this.button_YoudaoKeyTest.Size = new System.Drawing.Size(66, 29);
            this.button_YoudaoKeyTest.TabIndex = 23;
            this.button_YoudaoKeyTest.Text = "验证";
            this.button_YoudaoKeyTest.UseVisualStyleBackColor = true;
            this.button_YoudaoKeyTest.Click += new System.EventHandler(this.button_YoudaoKeyTest_Click);
            // 
            // linkLabel3
            // 
            this.linkLabel3.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.LinkColor = System.Drawing.Color.DodgerBlue;
            this.linkLabel3.Location = new System.Drawing.Point(382, 28);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(56, 17);
            this.linkLabel3.TabIndex = 22;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "点此申请";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // textBox_YoudaoAppSecret
            // 
            this.textBox_YoudaoAppSecret.Location = new System.Drawing.Point(151, 53);
            this.textBox_YoudaoAppSecret.Name = "textBox_YoudaoAppSecret";
            this.textBox_YoudaoAppSecret.Size = new System.Drawing.Size(225, 23);
            this.textBox_YoudaoAppSecret.TabIndex = 21;
            // 
            // textBox_YoudaoAppKey
            // 
            this.textBox_YoudaoAppKey.Location = new System.Drawing.Point(151, 22);
            this.textBox_YoudaoAppKey.Name = "textBox_YoudaoAppKey";
            this.textBox_YoudaoAppKey.Size = new System.Drawing.Size(225, 23);
            this.textBox_YoudaoAppKey.TabIndex = 20;
            // 
            // label_YoudaoAppSecret
            // 
            this.label_YoudaoAppSecret.AutoSize = true;
            this.label_YoudaoAppSecret.Location = new System.Drawing.Point(6, 53);
            this.label_YoudaoAppSecret.Name = "label_YoudaoAppSecret";
            this.label_YoudaoAppSecret.Size = new System.Drawing.Size(144, 17);
            this.label_YoudaoAppSecret.TabIndex = 19;
            this.label_YoudaoAppSecret.Text = "有道图片翻译 应用密钥：";
            // 
            // label_YoudaoAppKey
            // 
            this.label_YoudaoAppKey.AutoSize = true;
            this.label_YoudaoAppKey.Location = new System.Drawing.Point(6, 22);
            this.label_YoudaoAppKey.Name = "label_YoudaoAppKey";
            this.label_YoudaoAppKey.Size = new System.Drawing.Size(133, 17);
            this.label_YoudaoAppKey.TabIndex = 18;
            this.label_YoudaoAppKey.Text = "有道图片翻译 应用ID：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_BaiduKeyTest);
            this.groupBox1.Controls.Add(this.linkLabel2);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.label_BaiduPassword);
            this.groupBox1.Controls.Add(this.label_BaiduAppId);
            this.groupBox1.Controls.Add(this.textBox_BaiduPassword);
            this.groupBox1.Controls.Add(this.textBox_BaiduAppId);
            this.groupBox1.Controls.Add(this.textBox_BaiduSecretKey);
            this.groupBox1.Controls.Add(this.textBox_BaiduApiKey);
            this.groupBox1.Controls.Add(this.label_BaiduSecretKey);
            this.groupBox1.Controls.Add(this.label_BaiduApiKey);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 190);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "百度：";
            // 
            // button_BaiduKeyTest
            // 
            this.button_BaiduKeyTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_BaiduKeyTest.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button_BaiduKeyTest.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button_BaiduKeyTest.Location = new System.Drawing.Point(372, 155);
            this.button_BaiduKeyTest.Name = "button_BaiduKeyTest";
            this.button_BaiduKeyTest.Size = new System.Drawing.Size(66, 29);
            this.button_BaiduKeyTest.TabIndex = 17;
            this.button_BaiduKeyTest.Text = "验证";
            this.button_BaiduKeyTest.UseVisualStyleBackColor = true;
            this.button_BaiduKeyTest.Click += new System.EventHandler(this.button_BaiduKeyTest_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.LinkColor = System.Drawing.Color.DodgerBlue;
            this.linkLabel2.Location = new System.Drawing.Point(385, 80);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(56, 17);
            this.linkLabel2.TabIndex = 14;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "点此申请";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.OrangeRed;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.LinkColor = System.Drawing.Color.DodgerBlue;
            this.linkLabel1.Location = new System.Drawing.Point(382, 25);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(56, 17);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "点此申请";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label_BaiduPassword
            // 
            this.label_BaiduPassword.AutoSize = true;
            this.label_BaiduPassword.Location = new System.Drawing.Point(6, 112);
            this.label_BaiduPassword.Name = "label_BaiduPassword";
            this.label_BaiduPassword.Size = new System.Drawing.Size(96, 17);
            this.label_BaiduPassword.TabIndex = 12;
            this.label_BaiduPassword.Text = "百度翻译 密钥：";
            // 
            // label_BaiduAppId
            // 
            this.label_BaiduAppId.AutoSize = true;
            this.label_BaiduAppId.Location = new System.Drawing.Point(6, 83);
            this.label_BaiduAppId.Name = "label_BaiduAppId";
            this.label_BaiduAppId.Size = new System.Drawing.Size(111, 17);
            this.label_BaiduAppId.TabIndex = 11;
            this.label_BaiduAppId.Text = "百度翻译 APP ID：";
            // 
            // textBox_BaiduPassword
            // 
            this.textBox_BaiduPassword.Location = new System.Drawing.Point(151, 112);
            this.textBox_BaiduPassword.Name = "textBox_BaiduPassword";
            this.textBox_BaiduPassword.Size = new System.Drawing.Size(225, 23);
            this.textBox_BaiduPassword.TabIndex = 10;
            // 
            // textBox_BaiduAppId
            // 
            this.textBox_BaiduAppId.Location = new System.Drawing.Point(151, 80);
            this.textBox_BaiduAppId.Name = "textBox_BaiduAppId";
            this.textBox_BaiduAppId.Size = new System.Drawing.Size(225, 23);
            this.textBox_BaiduAppId.TabIndex = 9;
            // 
            // textBox_BaiduSecretKey
            // 
            this.textBox_BaiduSecretKey.Location = new System.Drawing.Point(151, 50);
            this.textBox_BaiduSecretKey.Name = "textBox_BaiduSecretKey";
            this.textBox_BaiduSecretKey.Size = new System.Drawing.Size(225, 23);
            this.textBox_BaiduSecretKey.TabIndex = 8;
            // 
            // textBox_BaiduApiKey
            // 
            this.textBox_BaiduApiKey.Location = new System.Drawing.Point(151, 19);
            this.textBox_BaiduApiKey.Name = "textBox_BaiduApiKey";
            this.textBox_BaiduApiKey.Size = new System.Drawing.Size(225, 23);
            this.textBox_BaiduApiKey.TabIndex = 7;
            // 
            // label_BaiduSecretKey
            // 
            this.label_BaiduSecretKey.AutoSize = true;
            this.label_BaiduSecretKey.Location = new System.Drawing.Point(6, 50);
            this.label_BaiduSecretKey.Name = "label_BaiduSecretKey";
            this.label_BaiduSecretKey.Size = new System.Drawing.Size(153, 17);
            this.label_BaiduSecretKey.TabIndex = 1;
            this.label_BaiduSecretKey.Text = "百度文字识别Secret Key：";
            // 
            // label_BaiduApiKey
            // 
            this.label_BaiduApiKey.AutoSize = true;
            this.label_BaiduApiKey.Location = new System.Drawing.Point(6, 19);
            this.label_BaiduApiKey.Name = "label_BaiduApiKey";
            this.label_BaiduApiKey.Size = new System.Drawing.Size(136, 17);
            this.label_BaiduApiKey.TabIndex = 0;
            this.label_BaiduApiKey.Text = "百度文字识别API Key：";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 389);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(474, 428);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "翻译神器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox_HotKey.ResumeLayout(false);
            this.groupBox_HotKey.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox_FixedTran.ResumeLayout(false);
            this.groupBox_FixedTran.PerformLayout();
            this.groupBox_Other.ResumeLayout(false);
            this.groupBox_Other.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Delay)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_FixedTranHotkey;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label_FixedTranHotkey;
        private System.Windows.Forms.TextBox textBox_SwitchRuToCn;
        private System.Windows.Forms.Label label_SwitchRuToCn;
        private System.Windows.Forms.TextBox textBox_SwitchEnToCn;
        private System.Windows.Forms.Label label_SwitchEnToCn;
        private System.Windows.Forms.GroupBox groupBox_HotKey;
        private System.Windows.Forms.TextBox textBox_TranHotkey;
        private System.Windows.Forms.Label label_TranHotkey;
        private System.Windows.Forms.TextBox textBox_ScreenHotkey;
        private System.Windows.Forms.Label label_ScreenHotkey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox_FixedTran;
        private System.Windows.Forms.Button button_SetPosition;
        private System.Windows.Forms.TextBox textBox_WindowClass;
        private System.Windows.Forms.Label label_WindowClass;
        private System.Windows.Forms.TextBox textBox_WindowName;
        private System.Windows.Forms.Label label_WindowName;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.GroupBox groupBox_Other;
        private System.Windows.Forms.CheckBox checkBox_ReadAloud;
        private System.Windows.Forms.ComboBox comboBox_TranSource;
        private System.Windows.Forms.Label label_TranSource;
        private System.Windows.Forms.CheckBox checkBox_CopyTranText;
        private System.Windows.Forms.CheckBox checkBox_CopyOriginalText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown_Delay;
        private System.Windows.Forms.Label label_Delay;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_BaiduApiKey;
        private System.Windows.Forms.Label label_BaiduSecretKey;
        private System.Windows.Forms.Label label_BaiduPassword;
        private System.Windows.Forms.Label label_BaiduAppId;
        private System.Windows.Forms.TextBox textBox_BaiduPassword;
        private System.Windows.Forms.TextBox textBox_BaiduAppId;
        private System.Windows.Forms.TextBox textBox_BaiduSecretKey;
        private System.Windows.Forms.TextBox textBox_BaiduApiKey;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_BaiduKeyTest;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button_YoudaoKeyTest;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.TextBox textBox_YoudaoAppSecret;
        private System.Windows.Forms.TextBox textBox_YoudaoAppKey;
        private System.Windows.Forms.Label label_YoudaoAppSecret;
        private System.Windows.Forms.Label label_YoudaoAppKey;
        private System.Windows.Forms.Button button_Reload;
    }
}

