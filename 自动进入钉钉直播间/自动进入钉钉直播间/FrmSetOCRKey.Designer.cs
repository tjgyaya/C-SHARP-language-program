namespace 自动进入钉钉直播间
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1_APIKey = new System.Windows.Forms.TextBox();
            this.textBox2_SecretKey = new System.Windows.Forms.TextBox();
            this.button1_ApplicationKey = new System.Windows.Forms.Button();
            this.button2_TestKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Secret Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.Location = new System.Drawing.Point(30, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "API Key:";
            // 
            // textBox1_APIKey
            // 
            this.textBox1_APIKey.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1_APIKey.Location = new System.Drawing.Point(99, 16);
            this.textBox1_APIKey.Name = "textBox1_APIKey";
            this.textBox1_APIKey.Size = new System.Drawing.Size(266, 23);
            this.textBox1_APIKey.TabIndex = 2;
            // 
            // textBox2_SecretKey
            // 
            this.textBox2_SecretKey.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2_SecretKey.Location = new System.Drawing.Point(99, 53);
            this.textBox2_SecretKey.Name = "textBox2_SecretKey";
            this.textBox2_SecretKey.Size = new System.Drawing.Size(266, 23);
            this.textBox2_SecretKey.TabIndex = 3;
            // 
            // button1_ApplicationKey
            // 
            this.button1_ApplicationKey.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1_ApplicationKey.Location = new System.Drawing.Point(16, 95);
            this.button1_ApplicationKey.Name = "button1_ApplicationKey";
            this.button1_ApplicationKey.Size = new System.Drawing.Size(90, 30);
            this.button1_ApplicationKey.TabIndex = 4;
            this.button1_ApplicationKey.Text = "申请ApiKey";
            this.button1_ApplicationKey.UseVisualStyleBackColor = true;
            this.button1_ApplicationKey.Click += new System.EventHandler(this.button1_ApplicationKey_Click);
            // 
            // button2_TestKey
            // 
            this.button2_TestKey.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2_TestKey.Location = new System.Drawing.Point(275, 95);
            this.button2_TestKey.Name = "button2_TestKey";
            this.button2_TestKey.Size = new System.Drawing.Size(90, 30);
            this.button2_TestKey.TabIndex = 5;
            this.button2_TestKey.Text = "测试并保存";
            this.button2_TestKey.UseVisualStyleBackColor = true;
            this.button2_TestKey.Click += new System.EventHandler(this.button2_TestKey_Click);
            // 
            // FrmSetOCRKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(387, 135);
            this.Controls.Add(this.button2_TestKey);
            this.Controls.Add(this.button1_ApplicationKey);
            this.Controls.Add(this.textBox2_SecretKey);
            this.Controls.Add(this.textBox1_APIKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(403, 174);
            this.Name = "FrmSetOCRKey";
            this.Text = "自定义文字识别Key";
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
    }
}