namespace 自动进入钉钉直播间
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button1_CustomScreenshot = new System.Windows.Forms.Button();
            this.checkBox1_AutoOpenLive = new System.Windows.Forms.CheckBox();
            this.numericUpDown1_CheckLiveTime = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox2_AutoOPenNextLive = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.checkBox3_Time1 = new System.Windows.Forms.CheckBox();
            this.checkBox4_Time2 = new System.Windows.Forms.CheckBox();
            this.checkBox5_Time3 = new System.Windows.Forms.CheckBox();
            this.checkBox6_Time4 = new System.Windows.Forms.CheckBox();
            this.checkBox10_Time8 = new System.Windows.Forms.CheckBox();
            this.checkBox9_Time7 = new System.Windows.Forms.CheckBox();
            this.checkBox8_Time6 = new System.Windows.Forms.CheckBox();
            this.checkBox7_Time5 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox16 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox15 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox14 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox13 = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox12 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.comboBox11 = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBox10 = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.label19_Explain = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.numericUpDown2_StopCheckLiveTime = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox1_log = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.label23_DistanceTime = new System.Windows.Forms.Label();
            this.checkBox11_ShowTop = new System.Windows.Forms.CheckBox();
            this.button2_AddStart = new System.Windows.Forms.Button();
            this.button3_DelStart = new System.Windows.Forms.Button();
            this.button5_start = new System.Windows.Forms.Button();
            this.checkBox12_SaveToDesk = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label23 = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button6_delConfigFile = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox13_preventSleep = new System.Windows.Forms.CheckBox();
            this.button7_SaveConfigFile = new System.Windows.Forms.Button();
            this.button4_DelCustomScreenshot = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.label25 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1_CheckLiveTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2_StopCheckLiveTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // button1_CustomScreenshot
            // 
            this.button1_CustomScreenshot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1_CustomScreenshot.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button1_CustomScreenshot.Location = new System.Drawing.Point(2, 105);
            this.button1_CustomScreenshot.Name = "button1_CustomScreenshot";
            this.button1_CustomScreenshot.Size = new System.Drawing.Size(75, 25);
            this.button1_CustomScreenshot.TabIndex = 3;
            this.button1_CustomScreenshot.Text = "自定义截图区域";
            this.toolTip1.SetToolTip(this.button1_CustomScreenshot, "自定义截图区域\\n多次检测直播失败时请使用此功能\\n有几率 提高 识别钉钉直播是否开启的准确性");
            this.button1_CustomScreenshot.UseVisualStyleBackColor = true;
            this.button1_CustomScreenshot.Click += new System.EventHandler(this.button1_CustomScreenshot_Click);
            // 
            // checkBox1_AutoOpenLive
            // 
            this.checkBox1_AutoOpenLive.AutoCheck = false;
            this.checkBox1_AutoOpenLive.AutoSize = true;
            this.checkBox1_AutoOpenLive.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox1_AutoOpenLive.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.checkBox1_AutoOpenLive.Location = new System.Drawing.Point(2, 183);
            this.checkBox1_AutoOpenLive.Name = "checkBox1_AutoOpenLive";
            this.checkBox1_AutoOpenLive.Size = new System.Drawing.Size(141, 22);
            this.checkBox1_AutoOpenLive.TabIndex = 8;
            this.checkBox1_AutoOpenLive.Text = "直播断开时自动打开";
            this.checkBox1_AutoOpenLive.UseVisualStyleBackColor = true;
            this.checkBox1_AutoOpenLive.CheckedChanged += new System.EventHandler(this.checkBox1_AutoOpenLive_CheckedChanged);
            this.checkBox1_AutoOpenLive.Click += new System.EventHandler(this.checkBox1_AutoOpenLive_Click);
            // 
            // numericUpDown1_CheckLiveTime
            // 
            this.numericUpDown1_CheckLiveTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown1_CheckLiveTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numericUpDown1_CheckLiveTime.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.numericUpDown1_CheckLiveTime.Location = new System.Drawing.Point(37, 203);
            this.numericUpDown1_CheckLiveTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown1_CheckLiveTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1_CheckLiveTime.Name = "numericUpDown1_CheckLiveTime";
            this.numericUpDown1_CheckLiveTime.Size = new System.Drawing.Size(41, 23);
            this.numericUpDown1_CheckLiveTime.TabIndex = 9;
            this.toolTip1.SetToolTip(this.numericUpDown1_CheckLiveTime, "推荐30以下，数值过大将会不准确");
            this.numericUpDown1_CheckLiveTime.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label1.Location = new System.Drawing.Point(82, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "秒钟检测一次直播是否断开";
            // 
            // checkBox2_AutoOPenNextLive
            // 
            this.checkBox2_AutoOPenNextLive.AutoCheck = false;
            this.checkBox2_AutoOPenNextLive.AutoSize = true;
            this.checkBox2_AutoOPenNextLive.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox2_AutoOPenNextLive.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.checkBox2_AutoOPenNextLive.Location = new System.Drawing.Point(313, 2);
            this.checkBox2_AutoOPenNextLive.Name = "checkBox2_AutoOPenNextLive";
            this.checkBox2_AutoOPenNextLive.Size = new System.Drawing.Size(169, 25);
            this.checkBox2_AutoOPenNextLive.TabIndex = 15;
            this.checkBox2_AutoOPenNextLive.Text = "自动开启下一次直播";
            this.toolTip1.SetToolTip(this.checkBox2_AutoOPenNextLive, "自动开启下一次直播\\n启用此功能，将在当前直播完后\\n自动按照设定并启用的自定义时间打开下一场直播");
            this.checkBox2_AutoOPenNextLive.UseVisualStyleBackColor = true;
            this.checkBox2_AutoOPenNextLive.CheckedChanged += new System.EventHandler(this.checkBox2_AutoOPenNextLive_CheckedChanged);
            this.checkBox2_AutoOPenNextLive.Click += new System.EventHandler(this.checkBox2_AutoOPenNextLive_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.IntegralHeight = false;
            this.comboBox1.Location = new System.Drawing.Point(431, 56);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.comboBox1.MaxDropDownItems = 10;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(48, 25);
            this.comboBox1.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(484, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "时";
            // 
            // comboBox2
            // 
            this.comboBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.IntegralHeight = false;
            this.comboBox2.Location = new System.Drawing.Point(511, 56);
            this.comboBox2.MaxDropDownItems = 10;
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(48, 25);
            this.comboBox2.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(564, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "分";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(564, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "分";
            // 
            // comboBox4
            // 
            this.comboBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.IntegralHeight = false;
            this.comboBox4.Location = new System.Drawing.Point(511, 86);
            this.comboBox4.MaxDropDownItems = 10;
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(48, 25);
            this.comboBox4.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(484, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "时";
            // 
            // comboBox3
            // 
            this.comboBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.IntegralHeight = false;
            this.comboBox3.Location = new System.Drawing.Point(431, 89);
            this.comboBox3.MaxDropDownItems = 10;
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(48, 25);
            this.comboBox3.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(564, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "分";
            // 
            // comboBox6
            // 
            this.comboBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.IntegralHeight = false;
            this.comboBox6.Location = new System.Drawing.Point(511, 120);
            this.comboBox6.MaxDropDownItems = 10;
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(48, 25);
            this.comboBox6.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(484, 128);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 17);
            this.label11.TabIndex = 17;
            this.label11.Text = "时";
            // 
            // comboBox5
            // 
            this.comboBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.IntegralHeight = false;
            this.comboBox5.Location = new System.Drawing.Point(431, 120);
            this.comboBox5.MaxDropDownItems = 10;
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(48, 25);
            this.comboBox5.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(564, 162);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 17);
            this.label13.TabIndex = 24;
            this.label13.Text = "分";
            // 
            // comboBox8
            // 
            this.comboBox8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.IntegralHeight = false;
            this.comboBox8.Location = new System.Drawing.Point(511, 151);
            this.comboBox8.MaxDropDownItems = 10;
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(48, 25);
            this.comboBox8.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(484, 162);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 17);
            this.label14.TabIndex = 22;
            this.label14.Text = "时";
            // 
            // comboBox7
            // 
            this.comboBox7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.IntegralHeight = false;
            this.comboBox7.Location = new System.Drawing.Point(431, 151);
            this.comboBox7.MaxDropDownItems = 10;
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(48, 25);
            this.comboBox7.TabIndex = 27;
            // 
            // checkBox3_Time1
            // 
            this.checkBox3_Time1.AutoCheck = false;
            this.checkBox3_Time1.AutoSize = true;
            this.checkBox3_Time1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox3_Time1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox3_Time1.Location = new System.Drawing.Point(312, 57);
            this.checkBox3_Time1.Name = "checkBox3_Time1";
            this.checkBox3_Time1.Size = new System.Drawing.Size(117, 22);
            this.checkBox3_Time1.TabIndex = 17;
            this.checkBox3_Time1.Text = "自定义时间一：";
            this.checkBox3_Time1.UseVisualStyleBackColor = true;
            this.checkBox3_Time1.CheckedChanged += new System.EventHandler(this.checkBox3_Time1_CheckedChanged);
            this.checkBox3_Time1.Click += new System.EventHandler(this.checkBox3_Time1_ClickChanged);
            // 
            // checkBox4_Time2
            // 
            this.checkBox4_Time2.AutoCheck = false;
            this.checkBox4_Time2.AutoSize = true;
            this.checkBox4_Time2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox4_Time2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox4_Time2.Location = new System.Drawing.Point(312, 89);
            this.checkBox4_Time2.Name = "checkBox4_Time2";
            this.checkBox4_Time2.Size = new System.Drawing.Size(117, 22);
            this.checkBox4_Time2.TabIndex = 20;
            this.checkBox4_Time2.Text = "自定义时间二：";
            this.checkBox4_Time2.UseVisualStyleBackColor = true;
            this.checkBox4_Time2.CheckedChanged += new System.EventHandler(this.checkBox4_Time2_CheckedChanged);
            this.checkBox4_Time2.Click += new System.EventHandler(this.checkBox4_Time2_ClickChanged);
            // 
            // checkBox5_Time3
            // 
            this.checkBox5_Time3.AutoCheck = false;
            this.checkBox5_Time3.AutoSize = true;
            this.checkBox5_Time3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox5_Time3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox5_Time3.Location = new System.Drawing.Point(312, 123);
            this.checkBox5_Time3.Name = "checkBox5_Time3";
            this.checkBox5_Time3.Size = new System.Drawing.Size(117, 22);
            this.checkBox5_Time3.TabIndex = 23;
            this.checkBox5_Time3.Text = "自定义时间三：";
            this.checkBox5_Time3.UseVisualStyleBackColor = true;
            this.checkBox5_Time3.CheckedChanged += new System.EventHandler(this.checkBox5_Time3_CheckedChanged);
            this.checkBox5_Time3.Click += new System.EventHandler(this.checkBox5_Time3_ClickChanged);
            // 
            // checkBox6_Time4
            // 
            this.checkBox6_Time4.AutoCheck = false;
            this.checkBox6_Time4.AutoSize = true;
            this.checkBox6_Time4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox6_Time4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox6_Time4.Location = new System.Drawing.Point(312, 154);
            this.checkBox6_Time4.Name = "checkBox6_Time4";
            this.checkBox6_Time4.Size = new System.Drawing.Size(117, 22);
            this.checkBox6_Time4.TabIndex = 26;
            this.checkBox6_Time4.Text = "自定义时间四：";
            this.checkBox6_Time4.UseVisualStyleBackColor = true;
            this.checkBox6_Time4.CheckedChanged += new System.EventHandler(this.checkBox6_Time4_CheckedChanged);
            this.checkBox6_Time4.Click += new System.EventHandler(this.checkBox6_Time4_ClickChanged);
            // 
            // checkBox10_Time8
            // 
            this.checkBox10_Time8.AutoCheck = false;
            this.checkBox10_Time8.AutoSize = true;
            this.checkBox10_Time8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox10_Time8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox10_Time8.Location = new System.Drawing.Point(312, 279);
            this.checkBox10_Time8.Name = "checkBox10_Time8";
            this.checkBox10_Time8.Size = new System.Drawing.Size(117, 22);
            this.checkBox10_Time8.TabIndex = 38;
            this.checkBox10_Time8.Text = "自定义时间八：";
            this.checkBox10_Time8.UseVisualStyleBackColor = true;
            this.checkBox10_Time8.CheckedChanged += new System.EventHandler(this.checkBox10_Time8_CheckedChanged);
            this.checkBox10_Time8.Click += new System.EventHandler(this.checkBox10_Time8_ClickChanged);
            // 
            // checkBox9_Time7
            // 
            this.checkBox9_Time7.AutoCheck = false;
            this.checkBox9_Time7.AutoSize = true;
            this.checkBox9_Time7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox9_Time7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox9_Time7.Location = new System.Drawing.Point(312, 248);
            this.checkBox9_Time7.Name = "checkBox9_Time7";
            this.checkBox9_Time7.Size = new System.Drawing.Size(117, 22);
            this.checkBox9_Time7.TabIndex = 35;
            this.checkBox9_Time7.Text = "自定义时间七：";
            this.checkBox9_Time7.UseVisualStyleBackColor = true;
            this.checkBox9_Time7.CheckedChanged += new System.EventHandler(this.checkBox9_Time7_CheckedChanged);
            this.checkBox9_Time7.Click += new System.EventHandler(this.checkBox9_Time7_ClickChanged);
            // 
            // checkBox8_Time6
            // 
            this.checkBox8_Time6.AutoCheck = false;
            this.checkBox8_Time6.AutoSize = true;
            this.checkBox8_Time6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox8_Time6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox8_Time6.Location = new System.Drawing.Point(312, 216);
            this.checkBox8_Time6.Name = "checkBox8_Time6";
            this.checkBox8_Time6.Size = new System.Drawing.Size(117, 22);
            this.checkBox8_Time6.TabIndex = 32;
            this.checkBox8_Time6.Text = "自定义时间六：";
            this.checkBox8_Time6.UseVisualStyleBackColor = true;
            this.checkBox8_Time6.CheckedChanged += new System.EventHandler(this.checkBox8_Time6_CheckedChanged);
            this.checkBox8_Time6.Click += new System.EventHandler(this.checkBox8_Time6_ClickChanged);
            // 
            // checkBox7_Time5
            // 
            this.checkBox7_Time5.AutoCheck = false;
            this.checkBox7_Time5.AutoSize = true;
            this.checkBox7_Time5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox7_Time5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox7_Time5.Location = new System.Drawing.Point(312, 185);
            this.checkBox7_Time5.Name = "checkBox7_Time5";
            this.checkBox7_Time5.Size = new System.Drawing.Size(117, 22);
            this.checkBox7_Time5.TabIndex = 29;
            this.checkBox7_Time5.Text = "自定义时间五：";
            this.checkBox7_Time5.UseVisualStyleBackColor = true;
            this.checkBox7_Time5.CheckedChanged += new System.EventHandler(this.checkBox7_Time5_CheckedChanged);
            this.checkBox7_Time5.Click += new System.EventHandler(this.checkBox7_Time5_ClickChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(564, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 17);
            this.label5.TabIndex = 44;
            this.label5.Text = "分";
            // 
            // comboBox16
            // 
            this.comboBox16.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox16.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox16.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox16.FormattingEnabled = true;
            this.comboBox16.IntegralHeight = false;
            this.comboBox16.Location = new System.Drawing.Point(511, 278);
            this.comboBox16.MaxDropDownItems = 10;
            this.comboBox16.Name = "comboBox16";
            this.comboBox16.Size = new System.Drawing.Size(48, 25);
            this.comboBox16.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(484, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 17);
            this.label6.TabIndex = 42;
            this.label6.Text = "时";
            // 
            // comboBox15
            // 
            this.comboBox15.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox15.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox15.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox15.FormattingEnabled = true;
            this.comboBox15.IntegralHeight = false;
            this.comboBox15.Location = new System.Drawing.Point(431, 276);
            this.comboBox15.MaxDropDownItems = 10;
            this.comboBox15.Name = "comboBox15";
            this.comboBox15.Size = new System.Drawing.Size(48, 25);
            this.comboBox15.TabIndex = 39;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(564, 253);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 17);
            this.label9.TabIndex = 40;
            this.label9.Text = "分";
            // 
            // comboBox14
            // 
            this.comboBox14.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox14.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox14.FormattingEnabled = true;
            this.comboBox14.IntegralHeight = false;
            this.comboBox14.Location = new System.Drawing.Point(511, 245);
            this.comboBox14.MaxDropDownItems = 10;
            this.comboBox14.Name = "comboBox14";
            this.comboBox14.Size = new System.Drawing.Size(48, 25);
            this.comboBox14.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(484, 253);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 17);
            this.label12.TabIndex = 38;
            this.label12.Text = "时";
            // 
            // comboBox13
            // 
            this.comboBox13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox13.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox13.FormattingEnabled = true;
            this.comboBox13.IntegralHeight = false;
            this.comboBox13.Location = new System.Drawing.Point(431, 245);
            this.comboBox13.MaxDropDownItems = 10;
            this.comboBox13.Name = "comboBox13";
            this.comboBox13.Size = new System.Drawing.Size(48, 25);
            this.comboBox13.TabIndex = 36;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(564, 223);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(20, 17);
            this.label15.TabIndex = 36;
            this.label15.Text = "分";
            // 
            // comboBox12
            // 
            this.comboBox12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox12.FormattingEnabled = true;
            this.comboBox12.IntegralHeight = false;
            this.comboBox12.Location = new System.Drawing.Point(511, 213);
            this.comboBox12.MaxDropDownItems = 10;
            this.comboBox12.Name = "comboBox12";
            this.comboBox12.Size = new System.Drawing.Size(48, 25);
            this.comboBox12.TabIndex = 34;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(484, 223);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 17);
            this.label16.TabIndex = 34;
            this.label16.Text = "时";
            // 
            // comboBox11
            // 
            this.comboBox11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox11.FormattingEnabled = true;
            this.comboBox11.IntegralHeight = false;
            this.comboBox11.Location = new System.Drawing.Point(431, 213);
            this.comboBox11.MaxDropDownItems = 10;
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new System.Drawing.Size(48, 25);
            this.comboBox11.TabIndex = 33;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(564, 190);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 17);
            this.label17.TabIndex = 32;
            this.label17.Text = "分";
            // 
            // comboBox10
            // 
            this.comboBox10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox10.FormattingEnabled = true;
            this.comboBox10.IntegralHeight = false;
            this.comboBox10.Location = new System.Drawing.Point(511, 182);
            this.comboBox10.MaxDropDownItems = 10;
            this.comboBox10.Name = "comboBox10";
            this.comboBox10.Size = new System.Drawing.Size(48, 25);
            this.comboBox10.TabIndex = 31;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(484, 193);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 17);
            this.label18.TabIndex = 30;
            this.label18.Text = "时";
            // 
            // comboBox9
            // 
            this.comboBox9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.IntegralHeight = false;
            this.comboBox9.Location = new System.Drawing.Point(431, 182);
            this.comboBox9.MaxDropDownItems = 10;
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(48, 25);
            this.comboBox9.TabIndex = 30;
            // 
            // label19_Explain
            // 
            this.label19_Explain.BackColor = System.Drawing.Color.White;
            this.label19_Explain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19_Explain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19_Explain.Font = new System.Drawing.Font("微软雅黑", 21F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label19_Explain.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label19_Explain.Location = new System.Drawing.Point(2, 2);
            this.label19_Explain.Name = "label19_Explain";
            this.label19_Explain.Size = new System.Drawing.Size(232, 74);
            this.label19_Explain.TabIndex = 14;
            this.label19_Explain.Text = "你若不努力，\r\n谁也救不了你";
            this.label19_Explain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.label19_Explain, "学生党以学习为重");
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label19.Location = new System.Drawing.Point(218, 358);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(125, 19);
            this.label19.TabIndex = 42;
            this.label19.Text = "Copyright (C) 2020";
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label20.ForeColor = System.Drawing.Color.LightSalmon;
            this.label20.Location = new System.Drawing.Point(2, 355);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(95, 22);
            this.label20.TabIndex = 41;
            this.label20.Text = "吾爱破解首发";
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // numericUpDown2_StopCheckLiveTime
            // 
            this.numericUpDown2_StopCheckLiveTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown2_StopCheckLiveTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numericUpDown2_StopCheckLiveTime.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.numericUpDown2_StopCheckLiveTime.Location = new System.Drawing.Point(37, 230);
            this.numericUpDown2_StopCheckLiveTime.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown2_StopCheckLiveTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2_StopCheckLiveTime.Name = "numericUpDown2_StopCheckLiveTime";
            this.numericUpDown2_StopCheckLiveTime.Size = new System.Drawing.Size(41, 23);
            this.numericUpDown2_StopCheckLiveTime.TabIndex = 10;
            this.numericUpDown2_StopCheckLiveTime.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label21.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label21.Location = new System.Drawing.Point(82, 236);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(212, 17);
            this.label21.TabIndex = 53;
            this.label21.Text = "分钟后还未检测到直播开启则停止检测";
            // 
            // textBox1_log
            // 
            this.textBox1_log.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1_log.HideSelection = false;
            this.textBox1_log.Location = new System.Drawing.Point(2, 254);
            this.textBox1_log.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1_log.MaxLength = 3276700;
            this.textBox1_log.Multiline = true;
            this.textBox1_log.Name = "textBox1_log";
            this.textBox1_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1_log.Size = new System.Drawing.Size(301, 100);
            this.textBox1_log.TabIndex = 11;
            this.textBox1_log.TabStop = false;
            this.textBox1_log.Text = "\r\n";
            this.textBox1_log.TextChanged += new System.EventHandler(this.textBox1_log_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label2.Location = new System.Drawing.Point(481, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.label2.TabIndex = 57;
            this.label2.Text = "分钟时自动打开";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numericUpDown3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.numericUpDown3.Location = new System.Drawing.Point(431, 28);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(47, 25);
            this.numericUpDown3.TabIndex = 16;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label22.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.label22.Location = new System.Drawing.Point(336, 30);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(93, 20);
            this.label22.TabIndex = 58;
            this.label22.Text = "距离直播还有\r\n";
            // 
            // label23_DistanceTime
            // 
            this.label23_DistanceTime.BackColor = System.Drawing.Color.SkyBlue;
            this.label23_DistanceTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label23_DistanceTime.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label23_DistanceTime.ForeColor = System.Drawing.Color.Tomato;
            this.label23_DistanceTime.Location = new System.Drawing.Point(240, 2);
            this.label23_DistanceTime.Name = "label23_DistanceTime";
            this.label23_DistanceTime.Size = new System.Drawing.Size(63, 128);
            this.label23_DistanceTime.TabIndex = 13;
            this.label23_DistanceTime.Text = "距   00\r\n离   时\r\n开   00\r\n启   分\r\n还   00\r\n有   秒\r\n";
            this.label23_DistanceTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox11_ShowTop
            // 
            this.checkBox11_ShowTop.AutoCheck = false;
            this.checkBox11_ShowTop.AutoSize = true;
            this.checkBox11_ShowTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox11_ShowTop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox11_ShowTop.Location = new System.Drawing.Point(2, 165);
            this.checkBox11_ShowTop.Name = "checkBox11_ShowTop";
            this.checkBox11_ShowTop.Size = new System.Drawing.Size(165, 22);
            this.checkBox11_ShowTop.TabIndex = 7;
            this.checkBox11_ShowTop.Text = "钉钉窗口始终显示最前方";
            this.toolTip1.SetToolTip(this.checkBox11_ShowTop, "钉钉窗口始终显示最前方，\r\n避免被其它窗口遮挡导致卡在“第xx次识别直播是否开启”");
            this.checkBox11_ShowTop.UseVisualStyleBackColor = true;
            this.checkBox11_ShowTop.CheckedChanged += new System.EventHandler(this.checkBox11_ShowTop_CheckedChanged);
            this.checkBox11_ShowTop.Click += new System.EventHandler(this.checkBox11_ShowTop_Click);
            // 
            // button2_AddStart
            // 
            this.button2_AddStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2_AddStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2_AddStart.Location = new System.Drawing.Point(2, 79);
            this.button2_AddStart.Name = "button2_AddStart";
            this.button2_AddStart.Size = new System.Drawing.Size(75, 25);
            this.button2_AddStart.TabIndex = 1;
            this.button2_AddStart.Text = "添加自启";
            this.toolTip1.SetToolTip(this.button2_AddStart, "添加自启\\n添加自启动后本软件将 会 在系统启动时自动启动");
            this.button2_AddStart.UseVisualStyleBackColor = true;
            this.button2_AddStart.Click += new System.EventHandler(this.button2_AddStart_Click);
            // 
            // button3_DelStart
            // 
            this.button3_DelStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3_DelStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3_DelStart.Location = new System.Drawing.Point(81, 79);
            this.button3_DelStart.Name = "button3_DelStart";
            this.button3_DelStart.Size = new System.Drawing.Size(75, 25);
            this.button3_DelStart.TabIndex = 2;
            this.button3_DelStart.Text = "删除自启";
            this.toolTip1.SetToolTip(this.button3_DelStart, "删除自启动\\n删除自启动后本软件将 不会 在系统启动时自动启动");
            this.button3_DelStart.UseVisualStyleBackColor = true;
            this.button3_DelStart.Click += new System.EventHandler(this.button3_DelStart_Click);
            // 
            // button5_start
            // 
            this.button5_start.BackColor = System.Drawing.Color.LawnGreen;
            this.button5_start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.button5_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5_start.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold);
            this.button5_start.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button5_start.Location = new System.Drawing.Point(159, 141);
            this.button5_start.Name = "button5_start";
            this.button5_start.Size = new System.Drawing.Size(144, 46);
            this.button5_start.TabIndex = 12;
            this.button5_start.Text = "开启";
            this.button5_start.UseVisualStyleBackColor = false;
            this.button5_start.Click += new System.EventHandler(this.button5_Start_Click);
            // 
            // checkBox12_SaveToDesk
            // 
            this.checkBox12_SaveToDesk.AutoSize = true;
            this.checkBox12_SaveToDesk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox12_SaveToDesk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox12_SaveToDesk.Location = new System.Drawing.Point(2, 130);
            this.checkBox12_SaveToDesk.Name = "checkBox12_SaveToDesk";
            this.checkBox12_SaveToDesk.Size = new System.Drawing.Size(157, 22);
            this.checkBox12_SaveToDesk.TabIndex = 6;
            this.checkBox12_SaveToDesk.Text = "截图保存到桌面  (调试)";
            this.checkBox12_SaveToDesk.UseVisualStyleBackColor = true;
            this.checkBox12_SaveToDesk.CheckedChanged += new System.EventHandler(this.checkBox12_SaveToDesk_CheckedChanged);
            this.checkBox12_SaveToDesk.Click += new System.EventHandler(this.checkBox12_SaveToDesk_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 10000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label23.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label23.Location = new System.Drawing.Point(2, 236);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(32, 17);
            this.label23.TabIndex = 66;
            this.label23.Text = "断开";
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 1000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Lime;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkLabel1.Font = new System.Drawing.Font("微软雅黑", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.linkLabel1.LinkColor = System.Drawing.Color.SlateBlue;
            this.linkLabel1.Location = new System.Drawing.Point(472, 355);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(109, 21);
            this.linkLabel1.TabIndex = 43;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "戳我看使用教程";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button6_delConfigFile
            // 
            this.button6_delConfigFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6_delConfigFile.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button6_delConfigFile.Location = new System.Drawing.Point(159, 105);
            this.button6_delConfigFile.Name = "button6_delConfigFile";
            this.button6_delConfigFile.Size = new System.Drawing.Size(75, 25);
            this.button6_delConfigFile.TabIndex = 5;
            this.button6_delConfigFile.Text = "删除配置文件";
            this.toolTip1.SetToolTip(this.button6_delConfigFile, "删除配置文件\\n删除配置文件会删除 您设定的自定义截图数据 和 自定义时间数据等");
            this.button6_delConfigFile.UseVisualStyleBackColor = true;
            this.button6_delConfigFile.Click += new System.EventHandler(this.button6_delConfigFile_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.BackColor = System.Drawing.Color.White;
            this.toolTip1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // checkBox13_preventSleep
            // 
            this.checkBox13_preventSleep.AutoCheck = false;
            this.checkBox13_preventSleep.AutoSize = true;
            this.checkBox13_preventSleep.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox13_preventSleep.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox13_preventSleep.Location = new System.Drawing.Point(2, 147);
            this.checkBox13_preventSleep.Name = "checkBox13_preventSleep";
            this.checkBox13_preventSleep.Size = new System.Drawing.Size(105, 22);
            this.checkBox13_preventSleep.TabIndex = 67;
            this.checkBox13_preventSleep.Text = "阻止系统休眠";
            this.toolTip1.SetToolTip(this.checkBox13_preventSleep, "阻止系统休眠\\n启用此功能，将在运行本软件时阻止系统休眠");
            this.checkBox13_preventSleep.UseVisualStyleBackColor = true;
            this.checkBox13_preventSleep.CheckedChanged += new System.EventHandler(this.checkBox13_preventSleep_CheckedChanged);
            this.checkBox13_preventSleep.Click += new System.EventHandler(this.checkBox13_preventSleep_Click);
            // 
            // button7_SaveConfigFile
            // 
            this.button7_SaveConfigFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7_SaveConfigFile.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button7_SaveConfigFile.Location = new System.Drawing.Point(159, 79);
            this.button7_SaveConfigFile.Name = "button7_SaveConfigFile";
            this.button7_SaveConfigFile.Size = new System.Drawing.Size(75, 25);
            this.button7_SaveConfigFile.TabIndex = 68;
            this.button7_SaveConfigFile.Text = "保存配置文件";
            this.toolTip1.SetToolTip(this.button7_SaveConfigFile, "保存配置文件\\n手动保存配置文件，避免软件意外退出不能自动保存");
            this.button7_SaveConfigFile.UseVisualStyleBackColor = true;
            this.button7_SaveConfigFile.Click += new System.EventHandler(this.button7_SaveConfigFile_Click);
            // 
            // button4_DelCustomScreenshot
            // 
            this.button4_DelCustomScreenshot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4_DelCustomScreenshot.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button4_DelCustomScreenshot.Location = new System.Drawing.Point(81, 105);
            this.button4_DelCustomScreenshot.Name = "button4_DelCustomScreenshot";
            this.button4_DelCustomScreenshot.Size = new System.Drawing.Size(75, 25);
            this.button4_DelCustomScreenshot.TabIndex = 4;
            this.button4_DelCustomScreenshot.Text = "删除截图区域";
            this.toolTip1.SetToolTip(this.button4_DelCustomScreenshot, "删除自定义截图区域\\n删除后截图数据会恢复到默认，\\n有可能 降低 识别钉钉直播是否开启的准确性");
            this.button4_DelCustomScreenshot.UseVisualStyleBackColor = true;
            this.button4_DelCustomScreenshot.Click += new System.EventHandler(this.button4_DelCustomScreenshot_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.ForeColor = System.Drawing.Color.DarkOrange;
            this.label24.Location = new System.Drawing.Point(308, 306);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(249, 38);
            this.label24.TabIndex = 69;
            this.label24.Text = "注  1.请不要移动或遮挡钉钉窗口\r\n意  2.打开直播前3秒内不要使用鼠标";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer5
            // 
            this.timer5.Interval = 1000;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.SystemColors.Control;
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label25.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label25.Font = new System.Drawing.Font("微软雅黑", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label25.Location = new System.Drawing.Point(379, 355);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(66, 21);
            this.label25.TabIndex = 70;
            this.label25.Text = "BUG提交";
            this.label25.Click += new System.EventHandler(this.label25_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(582, 378);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.button7_SaveConfigFile);
            this.Controls.Add(this.checkBox13_preventSleep);
            this.Controls.Add(this.button6_delConfigFile);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.checkBox12_SaveToDesk);
            this.Controls.Add(this.button5_start);
            this.Controls.Add(this.button4_DelCustomScreenshot);
            this.Controls.Add(this.button3_DelStart);
            this.Controls.Add(this.button2_AddStart);
            this.Controls.Add(this.checkBox11_ShowTop);
            this.Controls.Add(this.label23_DistanceTime);
            this.Controls.Add(this.textBox1_log);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.numericUpDown2_StopCheckLiveTime);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label19_Explain);
            this.Controls.Add(this.checkBox10_Time8);
            this.Controls.Add(this.checkBox9_Time7);
            this.Controls.Add(this.checkBox8_Time6);
            this.Controls.Add(this.checkBox7_Time5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox16);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox15);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBox13);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.comboBox12);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.comboBox11);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.comboBox10);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.comboBox9);
            this.Controls.Add(this.checkBox6_Time4);
            this.Controls.Add(this.checkBox5_Time3);
            this.Controls.Add(this.checkBox4_Time2);
            this.Controls.Add(this.checkBox3_Time1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.comboBox8);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboBox7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.checkBox2_AutoOPenNextLive);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1_CheckLiveTime);
            this.Controls.Add(this.checkBox1_AutoOpenLive);
            this.Controls.Add(this.button1_CustomScreenshot);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动进入钉钉直播间V2.2.0 Beta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1_CheckLiveTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2_StopCheckLiveTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button1_CustomScreenshot;
        private System.Windows.Forms.CheckBox checkBox1_AutoOpenLive;
        private System.Windows.Forms.NumericUpDown numericUpDown1_CheckLiveTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox2_AutoOPenNextLive;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.CheckBox checkBox3_Time1;
        private System.Windows.Forms.CheckBox checkBox4_Time2;
        private System.Windows.Forms.CheckBox checkBox5_Time3;
        private System.Windows.Forms.CheckBox checkBox6_Time4;
        private System.Windows.Forms.CheckBox checkBox10_Time8;
        private System.Windows.Forms.CheckBox checkBox9_Time7;
        private System.Windows.Forms.CheckBox checkBox8_Time6;
        private System.Windows.Forms.CheckBox checkBox7_Time5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox16;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBox14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBox12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBox11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBox10;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox comboBox9;
        private System.Windows.Forms.Label label19_Explain;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown numericUpDown2_StopCheckLiveTime;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23_DistanceTime;
        private System.Windows.Forms.CheckBox checkBox11_ShowTop;
        private System.Windows.Forms.Button button2_AddStart;
        private System.Windows.Forms.Button button3_DelStart;
        private System.Windows.Forms.Button button5_start;
        private System.Windows.Forms.CheckBox checkBox12_SaveToDesk;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button6_delConfigFile;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBox13_preventSleep;
        private System.Windows.Forms.Button button7_SaveConfigFile;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button button4_DelCustomScreenshot;
        public System.Windows.Forms.TextBox textBox1_log;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Label label25;
    }
}