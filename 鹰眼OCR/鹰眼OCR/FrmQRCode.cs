using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 鹰眼OCR.OCR;

namespace 鹰眼OCR
{
    public partial class FrmQRCode : Form
    {
        private string _Content;
        public string Content
        {
            set { _Content = value; }
        }

        public Point Position { get; set; }

        public FrmQRCode()
        {
            InitializeComponent();
            label_ShowErr.Visible = false;
        }

        private void QrCode(int size, string text)
        {
            try
            {
                ShowError(false, null);
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                //if (IsOnline) // 在线生成二维码
                //    pictureBox1.Image = LocalQRCode.OnlineGenerateQRCode(size, _Content);
                //else          // 本地生成二维码
                    pictureBox1.Image = LocalQRCode.LocalGenerateQRCode(size, text);
            }
            catch (Exception ex)
            {
                ShowError(true, ex.Message);
            }
        }

        private void FrmQRCode_Load(object sender, EventArgs e)
        {
            this.Location = Position;
            QrCode(trackBar1.Value, _Content);
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                QrCode(trackBar1.Value, _Content);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            SaveFileDialog fileDialog = new SaveFileDialog();
            try
            {
                fileDialog.Filter = "图片（*.png、*.bmp、*.jpg、*.gif）|*.png;*.bmp;*.jpg;*.gif";
                fileDialog.FileName = "*.png";
                fileDialog.AddExtension = true;
                fileDialog.DefaultExt = "png";
                DialogResult result = fileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ImageFormat format = ImageFormat.Png;
                    string ext = Path.GetExtension(fileDialog.FileName);
                    if (ext == ".bmp")
                        format = ImageFormat.Bmp;
                    else if (ext == ".jpg")
                        format = ImageFormat.Jpeg;
                    else if (ext == ".gif")
                        format = ImageFormat.Gif;

                    pictureBox1.Image.Save(fileDialog.FileName, format);
                }
            }
            catch (Exception ex)
            {
                ShowError(true, ex.Message);
                if (fileDialog != null)
                    fileDialog.Dispose();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label_ShowSize.Text = trackBar1.Value.ToString() + "PX";
            QrCode(trackBar1.Value, _Content);
        }

        private void ShowError(bool show, string err)
        {
            if (show)
            {
                pictureBox1.Visible = false;
                label_ShowErr.Dock = DockStyle.Fill;
                label_ShowErr.Visible = true;
                label_ShowErr.Text = err;
            }
            else
            {
                label_ShowErr.Dock = DockStyle.None;
                label_ShowErr.Visible = false;
                pictureBox1.Visible = true;
            }
        }
    }
}
