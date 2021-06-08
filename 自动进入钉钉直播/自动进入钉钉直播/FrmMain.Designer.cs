namespace 自动进入钉钉直播
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox1_log = new System.Windows.Forms.TextBox();
            this.checkBox11_ShowTop = new System.Windows.Forms.CheckBox();
            this.button5_start = new System.Windows.Forms.Button();
            this.checkBox12_SaveToDesk = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox13_preventSleep = new System.Windows.Forms.CheckBox();
            this.button2_AddStart = new System.Windows.Forms.Button();
            this.button3_DelStart = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.button1_SetOCRKey = new System.Windows.Forms.Button();
            this.button2_SetOCRKeyWord = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_DelConfig = new System.Windows.Forms.Button();
            this.button_SaveConfig = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "自动进入钉钉直播\r\n点击此处显示窗口";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.显示ToolStripMenuItem.Text = "显示";
            this.显示ToolStripMenuItem.Click += new System.EventHandler(this.显示ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label19.Location = new System.Drawing.Point(284, 232);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 21);
            this.label19.TabIndex = 42;
            this.label19.Text = "下载源码";
            this.toolTip1.SetToolTip(this.label19, "点此处下载软件源代码");
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.Color.LightSalmon;
            this.label20.Location = new System.Drawing.Point(215, 232);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 21);
            this.label20.TabIndex = 41;
            this.label20.Text = "吾爱破解";
            this.toolTip1.SetToolTip(this.label20, "点此处进入论坛发布页面");
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // textBox1_log
            // 
            this.textBox1_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1_log.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1_log.HideSelection = false;
            this.textBox1_log.Location = new System.Drawing.Point(3, 19);
            this.textBox1_log.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1_log.MaxLength = 3276700;
            this.textBox1_log.Multiline = true;
            this.textBox1_log.Name = "textBox1_log";
            this.textBox1_log.ReadOnly = true;
            this.textBox1_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1_log.Size = new System.Drawing.Size(257, 129);
            this.textBox1_log.TabIndex = 11;
            this.textBox1_log.TabStop = false;
            this.textBox1_log.Text = "\r\n";
            this.textBox1_log.TextChanged += new System.EventHandler(this.textBox1_log_TextChanged);
            // 
            // checkBox11_ShowTop
            // 
            this.checkBox11_ShowTop.AutoSize = true;
            this.checkBox11_ShowTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox11_ShowTop.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox11_ShowTop.Location = new System.Drawing.Point(6, 76);
            this.checkBox11_ShowTop.Name = "checkBox11_ShowTop";
            this.checkBox11_ShowTop.Size = new System.Drawing.Size(165, 22);
            this.checkBox11_ShowTop.TabIndex = 7;
            this.checkBox11_ShowTop.Text = "钉钉窗口始终显示最前方";
            this.toolTip1.SetToolTip(this.checkBox11_ShowTop, "钉钉窗口始终显示最前方，\r\n避免被其它窗口遮挡导致卡在“第xx次识别直播是否开启”");
            this.checkBox11_ShowTop.UseVisualStyleBackColor = true;
            this.checkBox11_ShowTop.CheckedChanged += new System.EventHandler(this.checkBox11_ShowTop_CheckedChanged);
            // 
            // button5_start
            // 
            this.button5_start.BackColor = System.Drawing.Color.LawnGreen;
            this.button5_start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.button5_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5_start.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.button5_start.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button5_start.Location = new System.Drawing.Point(227, 164);
            this.button5_start.Name = "button5_start";
            this.button5_start.Size = new System.Drawing.Size(263, 48);
            this.button5_start.TabIndex = 12;
            this.button5_start.Text = "开启";
            this.toolTip1.SetToolTip(this.button5_start, "启动");
            this.button5_start.UseVisualStyleBackColor = false;
            this.button5_start.Click += new System.EventHandler(this.button5_Start_Click);
            // 
            // checkBox12_SaveToDesk
            // 
            this.checkBox12_SaveToDesk.AutoSize = true;
            this.checkBox12_SaveToDesk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox12_SaveToDesk.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox12_SaveToDesk.Location = new System.Drawing.Point(6, 20);
            this.checkBox12_SaveToDesk.Name = "checkBox12_SaveToDesk";
            this.checkBox12_SaveToDesk.Size = new System.Drawing.Size(157, 22);
            this.checkBox12_SaveToDesk.TabIndex = 6;
            this.checkBox12_SaveToDesk.Text = "截图保存到桌面  (调试)";
            this.toolTip1.SetToolTip(this.checkBox12_SaveToDesk, "卡在“第xx次检测当前是否正在直播”时请启用此功能，\r\n并在反馈BUG时附带保存到桌面的截图。");
            this.checkBox12_SaveToDesk.UseVisualStyleBackColor = true;
            this.checkBox12_SaveToDesk.CheckedChanged += new System.EventHandler(this.checkBox12_SaveToDesk_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Lime;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.linkLabel1.Font = new System.Drawing.Font("微软雅黑", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.linkLabel1.LinkColor = System.Drawing.Color.SlateBlue;
            this.linkLabel1.Location = new System.Drawing.Point(423, 232);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(67, 21);
            this.linkLabel1.TabIndex = 43;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "使用教程";
            this.toolTip1.SetToolTip(this.linkLabel1, "点此处查看使用教程");
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
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
            this.checkBox13_preventSleep.AutoSize = true;
            this.checkBox13_preventSleep.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox13_preventSleep.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox13_preventSleep.Location = new System.Drawing.Point(6, 48);
            this.checkBox13_preventSleep.Name = "checkBox13_preventSleep";
            this.checkBox13_preventSleep.Size = new System.Drawing.Size(105, 22);
            this.checkBox13_preventSleep.TabIndex = 67;
            this.checkBox13_preventSleep.Text = "阻止系统休眠";
            this.toolTip1.SetToolTip(this.checkBox13_preventSleep, "启用此功能，将在运行本软件时阻止系统休眠");
            this.checkBox13_preventSleep.UseVisualStyleBackColor = true;
            this.checkBox13_preventSleep.CheckedChanged += new System.EventHandler(this.checkBox13_preventSleep_CheckedChanged);
            // 
            // button2_AddStart
            // 
            this.button2_AddStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2_AddStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2_AddStart.Location = new System.Drawing.Point(9, 19);
            this.button2_AddStart.Name = "button2_AddStart";
            this.button2_AddStart.Size = new System.Drawing.Size(66, 25);
            this.button2_AddStart.TabIndex = 69;
            this.button2_AddStart.Text = "添加自启";
            this.toolTip1.SetToolTip(this.button2_AddStart, "添加自启动后本软件将 会 在系统启动时自动启动");
            this.button2_AddStart.UseVisualStyleBackColor = true;
            this.button2_AddStart.Click += new System.EventHandler(this.button2_AddStart_Click);
            // 
            // button3_DelStart
            // 
            this.button3_DelStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3_DelStart.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3_DelStart.Location = new System.Drawing.Point(9, 62);
            this.button3_DelStart.Name = "button3_DelStart";
            this.button3_DelStart.Size = new System.Drawing.Size(66, 25);
            this.button3_DelStart.TabIndex = 70;
            this.button3_DelStart.Text = "删除自启";
            this.toolTip1.SetToolTip(this.button3_DelStart, "删除自启动后本软件将 不会 在系统启动时自动启动");
            this.button3_DelStart.UseVisualStyleBackColor = true;
            this.button3_DelStart.Click += new System.EventHandler(this.button3_DelStart_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label24.Font = new System.Drawing.Font("微软雅黑", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.ForeColor = System.Drawing.Color.Magenta;
            this.label24.Location = new System.Drawing.Point(16, 232);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(191, 21);
            this.label24.TabIndex = 69;
            this.label24.Text = "注意：请不要遮挡钉钉窗口";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label24, "注意事项\r\n如发现BUG请将鼠标放在“BUG提交”处查看提交说明后再提交");
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label25.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label25.Font = new System.Drawing.Font("微软雅黑", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label25.Location = new System.Drawing.Point(353, 232);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(66, 21);
            this.label25.TabIndex = 75;
            this.label25.Text = "BUG提交";
            this.toolTip1.SetToolTip(this.label25, "提交BUG时请提交：\r\n1、windows版本\r\n2、在何时出现\r\n感谢您的反馈");
            this.label25.Click += new System.EventHandler(this.label25_Click);
            // 
            // button1_SetOCRKey
            // 
            this.button1_SetOCRKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1_SetOCRKey.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button1_SetOCRKey.Location = new System.Drawing.Point(141, 19);
            this.button1_SetOCRKey.Name = "button1_SetOCRKey";
            this.button1_SetOCRKey.Size = new System.Drawing.Size(51, 25);
            this.button1_SetOCRKey.TabIndex = 73;
            this.button1_SetOCRKey.Text = "KEY";
            this.toolTip1.SetToolTip(this.button1_SetOCRKey, "设置文字识别Key，防止多人使用同一Key\r\n造成识别钉钉直播是否开启失效");
            this.button1_SetOCRKey.UseVisualStyleBackColor = true;
            this.button1_SetOCRKey.Click += new System.EventHandler(this.button1_SetOCRKey_Click);
            // 
            // button2_SetOCRKeyWord
            // 
            this.button2_SetOCRKeyWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2_SetOCRKeyWord.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button2_SetOCRKeyWord.Location = new System.Drawing.Point(141, 62);
            this.button2_SetOCRKeyWord.Name = "button2_SetOCRKeyWord";
            this.button2_SetOCRKeyWord.Size = new System.Drawing.Size(51, 25);
            this.button2_SetOCRKeyWord.TabIndex = 74;
            this.button2_SetOCRKeyWord.Text = "关键字";
            this.toolTip1.SetToolTip(this.button2_SetOCRKeyWord, "设置RGB识别数据和OCR识别关键字，\r\n提高识别钉钉直播是否开启的准确性。");
            this.button2_SetOCRKeyWord.UseVisualStyleBackColor = true;
            this.button2_SetOCRKeyWord.Click += new System.EventHandler(this.button2_SetOCRKeyWord_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Tomato;
            this.pictureBox1.Location = new System.Drawing.Point(41, 114);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(171, 30);
            this.pictureBox1.TabIndex = 75;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "pictureBox控件存在的意义就是为了获取不同缩放比下的截图区域大小");
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.groupBox1.Controls.Add(this.button_SaveConfig);
            this.groupBox1.Controls.Add(this.button_DelConfig);
            this.groupBox1.Controls.Add(this.button2_SetOCRKeyWord);
            this.groupBox1.Controls.Add(this.button1_SetOCRKey);
            this.groupBox1.Controls.Add(this.button3_DelStart);
            this.groupBox1.Controls.Add(this.button2_AddStart);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(15, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 100);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "其它设置";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gold;
            this.groupBox2.Controls.Add(this.checkBox12_SaveToDesk);
            this.groupBox2.Controls.Add(this.checkBox13_preventSleep);
            this.groupBox2.Controls.Add(this.checkBox11_ShowTop);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(15, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(206, 100);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "使用设置";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Controls.Add(this.textBox1_log);
            this.groupBox4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox4.Location = new System.Drawing.Point(227, -2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(263, 151);
            this.groupBox4.TabIndex = 74;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "日志";
            // 
            // button_DelConfig
            // 
            this.button_DelConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_DelConfig.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_DelConfig.Location = new System.Drawing.Point(81, 19);
            this.button_DelConfig.Name = "button_DelConfig";
            this.button_DelConfig.Size = new System.Drawing.Size(53, 25);
            this.button_DelConfig.TabIndex = 75;
            this.button_DelConfig.Text = "删除";
            this.toolTip1.SetToolTip(this.button_DelConfig, "删除配置文件");
            this.button_DelConfig.UseVisualStyleBackColor = true;
            this.button_DelConfig.Click += new System.EventHandler(this.button_DelConfig_Click);
            // 
            // button_SaveConfig
            // 
            this.button_SaveConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SaveConfig.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.button_SaveConfig.Location = new System.Drawing.Point(81, 62);
            this.button_SaveConfig.Name = "button_SaveConfig";
            this.button_SaveConfig.Size = new System.Drawing.Size(53, 25);
            this.button_SaveConfig.TabIndex = 76;
            this.button_SaveConfig.Text = "保存";
            this.toolTip1.SetToolTip(this.button_SaveConfig, "保存到配置文件");
            this.button_SaveConfig.UseVisualStyleBackColor = true;
            this.button_SaveConfig.Click += new System.EventHandler(this.button_SaveConfig_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(505, 266);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button5_start);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动进入钉钉直播";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox checkBox11_ShowTop;
        private System.Windows.Forms.Button button5_start;
        private System.Windows.Forms.CheckBox checkBox12_SaveToDesk;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBox13_preventSleep;
        private System.Windows.Forms.Label label24;
        public System.Windows.Forms.TextBox textBox1_log;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3_DelStart;
        private System.Windows.Forms.Button button2_AddStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button button2_SetOCRKeyWord;
        private System.Windows.Forms.Button button1_SetOCRKey;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Button button_SaveConfig;
        private System.Windows.Forms.Button button_DelConfig;
    }
}