namespace 自动进入钉钉直播间
{
    partial class AutoUpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoUpdateForm));
            this.label1_CurrentVersion = new System.Windows.Forms.Label();
            this.label2_UpdateVersion = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1_UpdateCont = new System.Windows.Forms.TextBox();
            this.button1_Update = new System.Windows.Forms.Button();
            this.button2_CancelUpdate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1_CurrentVersion
            // 
            this.label1_CurrentVersion.AutoSize = true;
            this.label1_CurrentVersion.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label1_CurrentVersion.Location = new System.Drawing.Point(12, 9);
            this.label1_CurrentVersion.Name = "label1_CurrentVersion";
            this.label1_CurrentVersion.Size = new System.Drawing.Size(105, 17);
            this.label1_CurrentVersion.TabIndex = 6;
            this.label1_CurrentVersion.Text = "当前版本：2.2.0.0";
            // 
            // label2_UpdateVersion
            // 
            this.label2_UpdateVersion.AutoSize = true;
            this.label2_UpdateVersion.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label2_UpdateVersion.Location = new System.Drawing.Point(12, 34);
            this.label2_UpdateVersion.Name = "label2_UpdateVersion";
            this.label2_UpdateVersion.Size = new System.Drawing.Size(105, 17);
            this.label2_UpdateVersion.TabIndex = 1;
            this.label2_UpdateVersion.Text = "最新版本：2.3.0.0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1_UpdateCont);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.groupBox1.Location = new System.Drawing.Point(0, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 120);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " 更新说明：";
            // 
            // textBox1_UpdateCont
            // 
            this.textBox1_UpdateCont.BackColor = System.Drawing.Color.White;
            this.textBox1_UpdateCont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1_UpdateCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1_UpdateCont.Font = new System.Drawing.Font("Arial Narrow", 9F);
            this.textBox1_UpdateCont.HideSelection = false;
            this.textBox1_UpdateCont.Location = new System.Drawing.Point(3, 19);
            this.textBox1_UpdateCont.Multiline = true;
            this.textBox1_UpdateCont.Name = "textBox1_UpdateCont";
            this.textBox1_UpdateCont.ReadOnly = true;
            this.textBox1_UpdateCont.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1_UpdateCont.Size = new System.Drawing.Size(364, 98);
            this.textBox1_UpdateCont.TabIndex = 5;
            this.textBox1_UpdateCont.Text = "修复：更新后造成软件界面不能正常显示\r\n其它：打开直播后将会优先检查直播窗口是否关闭（方便全屏观看直播）\r\n\r\n注意：本次更新请重新设定自定义截图区域  ";
            // 
            // button1_Update
            // 
            this.button1_Update.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.button1_Update.Location = new System.Drawing.Point(292, 2);
            this.button1_Update.Name = "button1_Update";
            this.button1_Update.Size = new System.Drawing.Size(75, 29);
            this.button1_Update.TabIndex = 0;
            this.button1_Update.Text = "更新";
            this.button1_Update.UseVisualStyleBackColor = true;
            this.button1_Update.Click += new System.EventHandler(this.button1_Update_Click);
            // 
            // button2_CancelUpdate
            // 
            this.button2_CancelUpdate.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.button2_CancelUpdate.Location = new System.Drawing.Point(292, 37);
            this.button2_CancelUpdate.Name = "button2_CancelUpdate";
            this.button2_CancelUpdate.Size = new System.Drawing.Size(75, 29);
            this.button2_CancelUpdate.TabIndex = 4;
            this.button2_CancelUpdate.Text = "取消";
            this.button2_CancelUpdate.UseVisualStyleBackColor = true;
            this.button2_CancelUpdate.Click += new System.EventHandler(this.button2_CancelUpdate_Click);
            // 
            // AutoUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 175);
            this.Controls.Add(this.button2_CancelUpdate);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2_UpdateVersion);
            this.Controls.Add(this.label1_CurrentVersion);
            this.Controls.Add(this.button1_Update);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AutoUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动进入钉钉直播间-发现新版本";
            this.Load += new System.EventHandler(this.AutoUpdateForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1_CurrentVersion;
        private System.Windows.Forms.Label label2_UpdateVersion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1_UpdateCont;
        private System.Windows.Forms.Button button1_Update;
        private System.Windows.Forms.Button button2_CancelUpdate;
    }
}