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
            this.button4_DelCustomScreenshot = new System.Windows.Forms.Button();
            this.button5_start = new System.Windows.Forms.Button();
            this.checkBox12_SaveDesk = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label23 = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
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
            this.button1_CustomScreenshot.TabIndex = 0;
            this.button1_CustomScreenshot.Text = "自定义截图";
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
            this.checkBox1_AutoOpenLive.TabIndex = 1;
            this.checkBox1_AutoOpenLive.Text = "中断直播时自动进入";
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
            300,
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
            this.numericUpDown1_CheckLiveTime.TabIndex = 2;
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
            this.label1.Text = "秒钟检测一次直播是否中断\r\n";
            // 
            // checkBox2_AutoOPenNextLive
            // 
            this.checkBox2_AutoOPenNextLive.AutoCheck = false;
            this.checkBox2_AutoOPenNextLive.AutoSize = true;
            this.checkBox2_AutoOPenNextLive.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox2_AutoOPenNextLive.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkBox2_AutoOPenNextLive.Location = new System.Drawing.Point(313, 12);
            this.checkBox2_AutoOPenNextLive.Name = "checkBox2_AutoOPenNextLive";
            this.checkBox2_AutoOPenNextLive.Size = new System.Drawing.Size(160, 25);
            this.checkBox2_AutoOPenNextLive.TabIndex = 5;
            this.checkBox2_AutoOPenNextLive.Text = "自动开启下一次直播";
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
            this.comboBox1.Location = new System.Drawing.Point(432, 60);
            this.comboBox1.MaxDropDownItems = 10;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(48, 25);
            this.comboBox1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(485, 68);
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
            this.comboBox2.Location = new System.Drawing.Point(512, 60);
            this.comboBox2.MaxDropDownItems = 10;
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(48, 25);
            this.comboBox2.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(565, 68);
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
            this.label7.Location = new System.Drawing.Point(565, 103);
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
            this.comboBox4.Location = new System.Drawing.Point(512, 95);
            this.comboBox4.MaxDropDownItems = 10;
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(48, 25);
            this.comboBox4.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(485, 103);
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
            this.comboBox3.Location = new System.Drawing.Point(432, 98);
            this.comboBox3.MaxDropDownItems = 10;
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(48, 25);
            this.comboBox3.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(565, 137);
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
            this.comboBox6.Location = new System.Drawing.Point(514, 129);
            this.comboBox6.MaxDropDownItems = 10;
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(48, 25);
            this.comboBox6.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(485, 137);
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
            this.comboBox5.Location = new System.Drawing.Point(432, 129);
            this.comboBox5.MaxDropDownItems = 10;
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(48, 25);
            this.comboBox5.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(565, 171);
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
            this.comboBox8.Location = new System.Drawing.Point(514, 163);
            this.comboBox8.MaxDropDownItems = 10;
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(48, 25);
            this.comboBox8.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(485, 171);
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
            this.comboBox7.Location = new System.Drawing.Point(432, 163);
            this.comboBox7.MaxDropDownItems = 10;
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(48, 25);
            this.comboBox7.TabIndex = 21;
            // 
            // checkBox3_Time1
            // 
            this.checkBox3_Time1.AutoCheck = false;
            this.checkBox3_Time1.AutoSize = true;
            this.checkBox3_Time1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox3_Time1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox3_Time1.Location = new System.Drawing.Point(313, 63);
            this.checkBox3_Time1.Name = "checkBox3_Time1";
            this.checkBox3_Time1.Size = new System.Drawing.Size(117, 22);
            this.checkBox3_Time1.TabIndex = 25;
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
            this.checkBox4_Time2.Location = new System.Drawing.Point(313, 101);
            this.checkBox4_Time2.Name = "checkBox4_Time2";
            this.checkBox4_Time2.Size = new System.Drawing.Size(117, 22);
            this.checkBox4_Time2.TabIndex = 26;
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
            this.checkBox5_Time3.Location = new System.Drawing.Point(313, 133);
            this.checkBox5_Time3.Name = "checkBox5_Time3";
            this.checkBox5_Time3.Size = new System.Drawing.Size(117, 22);
            this.checkBox5_Time3.TabIndex = 27;
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
            this.checkBox6_Time4.Location = new System.Drawing.Point(313, 166);
            this.checkBox6_Time4.Name = "checkBox6_Time4";
            this.checkBox6_Time4.Size = new System.Drawing.Size(117, 22);
            this.checkBox6_Time4.TabIndex = 28;
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
            this.checkBox10_Time8.Location = new System.Drawing.Point(313, 307);
            this.checkBox10_Time8.Name = "checkBox10_Time8";
            this.checkBox10_Time8.Size = new System.Drawing.Size(117, 22);
            this.checkBox10_Time8.TabIndex = 48;
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
            this.checkBox9_Time7.Location = new System.Drawing.Point(313, 273);
            this.checkBox9_Time7.Name = "checkBox9_Time7";
            this.checkBox9_Time7.Size = new System.Drawing.Size(117, 22);
            this.checkBox9_Time7.TabIndex = 47;
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
            this.checkBox8_Time6.Location = new System.Drawing.Point(313, 239);
            this.checkBox8_Time6.Name = "checkBox8_Time6";
            this.checkBox8_Time6.Size = new System.Drawing.Size(117, 22);
            this.checkBox8_Time6.TabIndex = 46;
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
            this.checkBox7_Time5.Location = new System.Drawing.Point(313, 206);
            this.checkBox7_Time5.Name = "checkBox7_Time5";
            this.checkBox7_Time5.Size = new System.Drawing.Size(117, 22);
            this.checkBox7_Time5.TabIndex = 45;
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
            this.label5.Location = new System.Drawing.Point(565, 309);
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
            this.comboBox16.Location = new System.Drawing.Point(512, 305);
            this.comboBox16.MaxDropDownItems = 10;
            this.comboBox16.Name = "comboBox16";
            this.comboBox16.Size = new System.Drawing.Size(48, 25);
            this.comboBox16.TabIndex = 43;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(485, 309);
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
            this.comboBox15.Location = new System.Drawing.Point(431, 303);
            this.comboBox15.MaxDropDownItems = 10;
            this.comboBox15.Name = "comboBox15";
            this.comboBox15.Size = new System.Drawing.Size(48, 25);
            this.comboBox15.TabIndex = 41;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(565, 277);
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
            this.comboBox14.Location = new System.Drawing.Point(512, 274);
            this.comboBox14.MaxDropDownItems = 10;
            this.comboBox14.Name = "comboBox14";
            this.comboBox14.Size = new System.Drawing.Size(48, 25);
            this.comboBox14.TabIndex = 39;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(485, 277);
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
            this.comboBox13.Location = new System.Drawing.Point(431, 269);
            this.comboBox13.MaxDropDownItems = 10;
            this.comboBox13.Name = "comboBox13";
            this.comboBox13.Size = new System.Drawing.Size(48, 25);
            this.comboBox13.TabIndex = 37;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(565, 243);
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
            this.comboBox12.Location = new System.Drawing.Point(512, 238);
            this.comboBox12.MaxDropDownItems = 10;
            this.comboBox12.Name = "comboBox12";
            this.comboBox12.Size = new System.Drawing.Size(48, 25);
            this.comboBox12.TabIndex = 35;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(485, 243);
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
            this.comboBox11.Location = new System.Drawing.Point(431, 235);
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
            this.label17.Location = new System.Drawing.Point(565, 208);
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
            this.comboBox10.Location = new System.Drawing.Point(514, 200);
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
            this.label18.Location = new System.Drawing.Point(485, 208);
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
            this.comboBox9.Location = new System.Drawing.Point(432, 200);
            this.comboBox9.MaxDropDownItems = 10;
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(48, 25);
            this.comboBox9.TabIndex = 29;
            // 
            // label19_Explain
            // 
            this.label19_Explain.AutoSize = true;
            this.label19_Explain.BackColor = System.Drawing.Color.White;
            this.label19_Explain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19_Explain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19_Explain.Font = new System.Drawing.Font("微软雅黑", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label19_Explain.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label19_Explain.Location = new System.Drawing.Point(2, 2);
            this.label19_Explain.Name = "label19_Explain";
            this.label19_Explain.Size = new System.Drawing.Size(179, 74);
            this.label19_Explain.TabIndex = 49;
            this.label19_Explain.Text = "你若不努力，\r\n谁也救不了你";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label19.Location = new System.Drawing.Point(215, 348);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(125, 19);
            this.label19.TabIndex = 50;
            this.label19.Text = "Copyright (C) 2020";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label20.ForeColor = System.Drawing.Color.Coral;
            this.label20.Location = new System.Drawing.Point(2, 348);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(82, 19);
            this.label20.TabIndex = 51;
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
            30,
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
            this.numericUpDown2_StopCheckLiveTime.TabIndex = 52;
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
            this.textBox1_log.Size = new System.Drawing.Size(302, 92);
            this.textBox1_log.TabIndex = 54;
            this.textBox1_log.TabStop = false;
            this.textBox1_log.Text = "日志...\r\n";
            this.textBox1_log.TextChanged += new System.EventHandler(this.textBox1_log_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label2.Location = new System.Drawing.Point(485, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 57;
            this.label2.Text = "分钟时自动进入";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.numericUpDown3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.numericUpDown3.Location = new System.Drawing.Point(432, 34);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(47, 23);
            this.numericUpDown3.TabIndex = 56;
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
            this.label22.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label22.Location = new System.Drawing.Point(346, 40);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 17);
            this.label22.TabIndex = 58;
            this.label22.Text = "距离直播还有\r\n";
            // 
            // label23_DistanceTime
            // 
            this.label23_DistanceTime.BackColor = System.Drawing.Color.SkyBlue;
            this.label23_DistanceTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label23_DistanceTime.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.label23_DistanceTime.ForeColor = System.Drawing.Color.Tomato;
            this.label23_DistanceTime.Location = new System.Drawing.Point(233, 2);
            this.label23_DistanceTime.Name = "label23_DistanceTime";
            this.label23_DistanceTime.Size = new System.Drawing.Size(63, 135);
            this.label23_DistanceTime.TabIndex = 59;
            this.label23_DistanceTime.Text = "距   00\r\n离   时\r\n开   00\r\n启   分\r\n还   00\r\n有   秒\r\n";
            this.label23_DistanceTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox11_ShowTop
            // 
            this.checkBox11_ShowTop.AutoCheck = false;
            this.checkBox11_ShowTop.AutoSize = true;
            this.checkBox11_ShowTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox11_ShowTop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox11_ShowTop.Location = new System.Drawing.Point(2, 156);
            this.checkBox11_ShowTop.Name = "checkBox11_ShowTop";
            this.checkBox11_ShowTop.Size = new System.Drawing.Size(165, 22);
            this.checkBox11_ShowTop.TabIndex = 60;
            this.checkBox11_ShowTop.Text = "将钉钉窗口显示在最前方";
            this.checkBox11_ShowTop.UseVisualStyleBackColor = true;
            this.checkBox11_ShowTop.Click += new System.EventHandler(this.checkBox11_ShowTop_Click);
            // 
            // button2_AddStart
            // 
            this.button2_AddStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2_AddStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2_AddStart.Location = new System.Drawing.Point(2, 79);
            this.button2_AddStart.Name = "button2_AddStart";
            this.button2_AddStart.Size = new System.Drawing.Size(75, 25);
            this.button2_AddStart.TabIndex = 61;
            this.button2_AddStart.Text = "添加自启";
            this.button2_AddStart.UseVisualStyleBackColor = true;
            this.button2_AddStart.Click += new System.EventHandler(this.button2_AddStart_Click);
            // 
            // button3_DelStart
            // 
            this.button3_DelStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3_DelStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3_DelStart.Location = new System.Drawing.Point(80, 79);
            this.button3_DelStart.Name = "button3_DelStart";
            this.button3_DelStart.Size = new System.Drawing.Size(75, 25);
            this.button3_DelStart.TabIndex = 62;
            this.button3_DelStart.Text = "删除自启";
            this.button3_DelStart.UseVisualStyleBackColor = true;
            this.button3_DelStart.Click += new System.EventHandler(this.button3_DelStart_Click);
            // 
            // button4_DelCustomScreenshot
            // 
            this.button4_DelCustomScreenshot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4_DelCustomScreenshot.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button4_DelCustomScreenshot.Location = new System.Drawing.Point(80, 105);
            this.button4_DelCustomScreenshot.Name = "button4_DelCustomScreenshot";
            this.button4_DelCustomScreenshot.Size = new System.Drawing.Size(116, 25);
            this.button4_DelCustomScreenshot.TabIndex = 63;
            this.button4_DelCustomScreenshot.Text = "删除自定义截图文件";
            this.button4_DelCustomScreenshot.UseVisualStyleBackColor = true;
            this.button4_DelCustomScreenshot.Click += new System.EventHandler(this.button4_DelCustomScreenshot_Click);
            // 
            // button5_start
            // 
            this.button5_start.BackColor = System.Drawing.Color.LawnGreen;
            this.button5_start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.button5_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5_start.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Bold);
            this.button5_start.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button5_start.Location = new System.Drawing.Point(166, 153);
            this.button5_start.Name = "button5_start";
            this.button5_start.Size = new System.Drawing.Size(139, 40);
            this.button5_start.TabIndex = 64;
            this.button5_start.Text = "开启";
            this.button5_start.UseVisualStyleBackColor = false;
            this.button5_start.Click += new System.EventHandler(this.button5_Start_Click);
            // 
            // checkBox12_SaveDesk
            // 
            this.checkBox12_SaveDesk.AutoSize = true;
            this.checkBox12_SaveDesk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox12_SaveDesk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox12_SaveDesk.Location = new System.Drawing.Point(2, 134);
            this.checkBox12_SaveDesk.Name = "checkBox12_SaveDesk";
            this.checkBox12_SaveDesk.Size = new System.Drawing.Size(164, 22);
            this.checkBox12_SaveDesk.TabIndex = 65;
            this.checkBox12_SaveDesk.Text = "截图保存到桌面(Debug)";
            this.checkBox12_SaveDesk.UseVisualStyleBackColor = true;
            this.checkBox12_SaveDesk.CheckedChanged += new System.EventHandler(this.checkBox12_SaveDesk_CheckedChanged);
            this.checkBox12_SaveDesk.Click += new System.EventHandler(this.checkBox12_SaveDesk_Click);
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
            this.label23.Text = "中断";
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
            this.linkLabel1.Location = new System.Drawing.Point(468, 346);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(109, 21);
            this.linkLabel1.TabIndex = 67;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "戳我看使用教程";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(184, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 60);
            this.button1.TabIndex = 68;
            this.button1.Text = "删除配置文件";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(582, 374);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.checkBox12_SaveDesk);
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
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动进入钉钉直播间V2.0";
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
        private System.Windows.Forms.TextBox textBox1_log;
        private System.Windows.Forms.Button button2_AddStart;
        private System.Windows.Forms.Button button3_DelStart;
        private System.Windows.Forms.Button button4_DelCustomScreenshot;
        private System.Windows.Forms.Button button5_start;
        private System.Windows.Forms.CheckBox checkBox12_SaveDesk;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button1;
    }
}