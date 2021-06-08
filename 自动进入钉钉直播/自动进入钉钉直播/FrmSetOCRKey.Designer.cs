namespace 自动进入钉钉直播
{
    partial class FrmSetOCRKey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetOCRKey));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1_APIKey = new System.Windows.Forms.TextBox();
            this.textBox2_SecretKey = new System.Windows.Forms.TextBox();
            this.button1_ApplicationKey = new System.Windows.Forms.Button();
            this.button2_TestKey = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label1.Location = new System.Drawing.Point(36, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Secret Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label2.Location = new System.Drawing.Point(54, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "API Key:";
            // 
            // textBox1_APIKey
            // 
            this.textBox1_APIKey.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox1_APIKey.Location = new System.Drawing.Point(123, 7);
            this.textBox1_APIKey.Name = "textBox1_APIKey";
            this.textBox1_APIKey.Size = new System.Drawing.Size(280, 23);
            this.textBox1_APIKey.TabIndex = 2;
            // 
            // textBox2_SecretKey
            // 
            this.textBox2_SecretKey.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.textBox2_SecretKey.Location = new System.Drawing.Point(123, 36);
            this.textBox2_SecretKey.Name = "textBox2_SecretKey";
            this.textBox2_SecretKey.Size = new System.Drawing.Size(280, 23);
            this.textBox2_SecretKey.TabIndex = 3;
            // 
            // button1_ApplicationKey
            // 
            this.button1_ApplicationKey.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.button1_ApplicationKey.Location = new System.Drawing.Point(39, 65);
            this.button1_ApplicationKey.Name = "button1_ApplicationKey";
            this.button1_ApplicationKey.Size = new System.Drawing.Size(102, 30);
            this.button1_ApplicationKey.TabIndex = 4;
            this.button1_ApplicationKey.Text = "申请ApiKey";
            this.button1_ApplicationKey.UseVisualStyleBackColor = true;
            this.button1_ApplicationKey.Click += new System.EventHandler(this.button1_ApplicationKey_Click);
            // 
            // button2_TestKey
            // 
            this.button2_TestKey.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.button2_TestKey.Location = new System.Drawing.Point(301, 65);
            this.button2_TestKey.Name = "button2_TestKey";
            this.button2_TestKey.Size = new System.Drawing.Size(102, 30);
            this.button2_TestKey.TabIndex = 5;
            this.button2_TestKey.Text = "测试并保存";
            this.button2_TestKey.UseVisualStyleBackColor = true;
            this.button2_TestKey.Click += new System.EventHandler(this.button2_TestKey_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowser1.Location = new System.Drawing.Point(0, 101);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(460, 235);
            this.webBrowser1.TabIndex = 7;
            // 
            // FrmSetOCRKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(460, 336);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.button2_TestKey);
            this.Controls.Add(this.button1_ApplicationKey);
            this.Controls.Add(this.textBox2_SecretKey);
            this.Controls.Add(this.textBox1_APIKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(476, 406);
            this.Name = "FrmSetOCRKey";
            this.Text = "自定义文字识别Key";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmSetOCRKey_FormClosed);
            this.Load += new System.EventHandler(this.FrmSetOCRKey_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1_APIKey;
        private System.Windows.Forms.TextBox textBox2_SecretKey;
        private System.Windows.Forms.Button button1_ApplicationKey;
        private System.Windows.Forms.Button button2_TestKey;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}