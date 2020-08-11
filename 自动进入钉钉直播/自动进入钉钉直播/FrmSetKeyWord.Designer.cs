namespace 自动进入钉钉直播
{
    partial class FrmSetKeyWord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetKeyWord));
            this.button3_SetOcrKey = new System.Windows.Forms.Button();
            this.button4_OCRExamples = new System.Windows.Forms.Button();
            this.button2_RGBExamples = new System.Windows.Forms.Button();
            this.button1_SetRgbKey = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // button3_SetOcrKey
            // 
            this.button3_SetOcrKey.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3_SetOcrKey.Location = new System.Drawing.Point(256, 12);
            this.button3_SetOcrKey.Name = "button3_SetOcrKey";
            this.button3_SetOcrKey.Size = new System.Drawing.Size(106, 31);
            this.button3_SetOcrKey.TabIndex = 1;
            this.button3_SetOcrKey.Text = "设置OCR关键字";
            this.button3_SetOcrKey.UseVisualStyleBackColor = true;
            this.button3_SetOcrKey.Click += new System.EventHandler(this.button3_SetOcrKey_Click);
            // 
            // button4_OCRExamples
            // 
            this.button4_OCRExamples.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4_OCRExamples.Location = new System.Drawing.Point(256, 49);
            this.button4_OCRExamples.MaximumSize = new System.Drawing.Size(256, 58);
            this.button4_OCRExamples.Name = "button4_OCRExamples";
            this.button4_OCRExamples.Size = new System.Drawing.Size(106, 31);
            this.button4_OCRExamples.TabIndex = 3;
            this.button4_OCRExamples.Text = "OCR关键字示例";
            this.button4_OCRExamples.UseVisualStyleBackColor = true;
            this.button4_OCRExamples.Click += new System.EventHandler(this.button4_OCRExamples_Click);
            // 
            // button2_RGBExamples
            // 
            this.button2_RGBExamples.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2_RGBExamples.Location = new System.Drawing.Point(15, 49);
            this.button2_RGBExamples.Name = "button2_RGBExamples";
            this.button2_RGBExamples.Size = new System.Drawing.Size(106, 31);
            this.button2_RGBExamples.TabIndex = 2;
            this.button2_RGBExamples.Text = "RGB关键字示例";
            this.button2_RGBExamples.UseVisualStyleBackColor = true;
            this.button2_RGBExamples.Click += new System.EventHandler(this.button2_RGBExamples_Click);
            // 
            // button1_SetRgbKey
            // 
            this.button1_SetRgbKey.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1_SetRgbKey.Location = new System.Drawing.Point(15, 12);
            this.button1_SetRgbKey.Name = "button1_SetRgbKey";
            this.button1_SetRgbKey.Size = new System.Drawing.Size(106, 31);
            this.button1_SetRgbKey.TabIndex = 0;
            this.button1_SetRgbKey.Text = "设置RGB关键字";
            this.button1_SetRgbKey.UseVisualStyleBackColor = true;
            this.button1_SetRgbKey.Click += new System.EventHandler(this.button1_SetRgbKey_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.webBrowser1.Location = new System.Drawing.Point(0, 86);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(386, 243);
            this.webBrowser1.TabIndex = 8;
            // 
            // FrmSetKeyWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(386, 329);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.button2_RGBExamples);
            this.Controls.Add(this.button1_SetRgbKey);
            this.Controls.Add(this.button4_OCRExamples);
            this.Controls.Add(this.button3_SetOcrKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(402, 368);
            this.Name = "FrmSetKeyWord";
            this.Text = "自定义关键字";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSetKeyWord_FormClosing);
            this.Load += new System.EventHandler(this.FrmSetKeyWord_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button3_SetOcrKey;
        private System.Windows.Forms.Button button4_OCRExamples;
        private System.Windows.Forms.Button button2_RGBExamples;
        private System.Windows.Forms.Button button1_SetRgbKey;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}