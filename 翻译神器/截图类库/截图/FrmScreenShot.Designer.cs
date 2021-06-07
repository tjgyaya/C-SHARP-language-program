
namespace ScreenShot
{
    partial class FrmScreenShot
    {
        ///// <summary>
        ///// Required designer variable.
        ///// </summary>
        //private System.ComponentModel.IContainer components = null;

        ///// <summary>
        ///// Clean up any resources being used.
        ///// </summary>
        ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmScreenShot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(835, 524);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmScreenShot";
            this.ShowInTaskbar = false;
            this.Text = "截图";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmScreenShot_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmScreenShot_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmScreenShot_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FrmScreenShot_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FrmScreenShot_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmScreenShot_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmScreenShot_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmScreenShot_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}