using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToICO
{
    public partial class Form1 : Form
    {
        private string sourceName;

        public Form1()
        {
            InitializeComponent();

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.Multiselect = false;
            openFileDialog1.DereferenceLinks = true;
            openFileDialog1.Filter = "图片 (*.jpg;*.jpeg;*.png;*.webp;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.webp;*.bmp;*.gif";
            openFileDialog1.Title = "请选择图片文件...";

            folderBrowserDialog1.Description = "请选择保存文件夹...";
            folderBrowserDialog1.ShowNewFolderButton = true;

            checkedListBox1.CheckOnClick = true;

            // 拖动文件
            pictureBox1.AllowDrop = true;
            label4_tip.AllowDrop = true;
        }


        private void button_open_Click(object sender, EventArgs e)
        {
            try
            {
                toolStripStatusLabel1.Text = "状态：";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    sourceName = openFileDialog1.FileName;
                    ShowPicture(sourceName);
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(sourceName))
                    throw new Exception("失败：请先打开文件。");

                if (!checkBox_noChangeSize.Checked)
                {
                    // 如果未选中 复选框列表中的复选框 或 自定义宽高有一项小于或等于0
                    if (checkedListBox1.CheckedItems.Count < 1 && (numericUpDown1_height.Value <= 0 || numericUpDown2_width.Value <= 0))
                        throw new Exception("失败：请选中复选框 或 设置自定义宽高。");
                }

                string savePath = Path.GetDirectoryName(sourceName);
                // 是否保存到源文件夹
                if (!checkBox_SaveToSourceFolder.Checked)
                {
                    if (folderBrowserDialog1.ShowDialog() != DialogResult.OK)
                    {
                        toolStripStatusLabel1.Text = "保存失败。";
                        return;
                    }
                    else
                        savePath = folderBrowserDialog1.SelectedPath;
                }

                // 不改变大小
                if (checkBox_noChangeSize.Checked)
                {
                    ConvertToIcon(0, 0, savePath);
                    toolStripStatusLabel1.Text = "保存成功。";
                    return;
                }

                // 遍历打勾的复选框
                foreach (var ckItem in checkedListBox1.CheckedItems)
                {
                    Size size = SplitSize(ckItem.ToString(), 'x');
                    ConvertToIcon(size.Width, size.Height, savePath);
                }

                // 自定义大小
                if (numericUpDown1_height.Value > 0 && numericUpDown2_width.Value > 0)
                {
                    ConvertToIcon((int)numericUpDown2_width.Value, (int)numericUpDown1_height.Value, savePath);
                }
                toolStripStatusLabel1.Text = "保存成功。";

            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }


        private void ConvertToIcon(int width, int height, string savePath)
        {
            string destName;
            if (!checkBox_noChangeSize.Checked)
                destName = Path.Combine(savePath + "\\", Path.GetFileNameWithoutExtension(sourceName) + "_" + width + "x" + height + ".ico");
            else
                destName = Path.Combine(savePath + "\\", Path.GetFileNameWithoutExtension(sourceName) + ".ico");
            ImageConvertToIcon.ConvertToIcon(sourceName, destName, new Size(width, height));
        }


        private void button_clean_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                toolStripStatusLabel1.Text = "清除成功。";
            }
            else
            {
                toolStripStatusLabel1.Text = "清除失败。";
            }
            label4_tip.Visible = true;
            sourceName = null;
        }


        private Size SplitSize(string size, char ch)
        {
            string[] arr = size.Split(ch);
            int width = Convert.ToInt32(arr[0]);
            int height = Convert.ToInt32(arr[1]);
            return new Size(width, height);
        }


        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))// 只接受文件拖动
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }


        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            // 获得路径
            sourceName = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            ShowPicture(sourceName);
        }


        private void ShowPicture(string fileName)
        {
            try
            {
                pictureBox1.Image = new Bitmap(fileName);
                label4_tip.Visible = false;
            }
            catch (Exception ex)
            {
                sourceName = null;
                toolStripStatusLabel1.Text = ex.Message;
            }
        }


        private void checkBox_topMost_Click(object sender, EventArgs e)
        {
            if (checkBox_topMost.Checked)
                checkBox_topMost.Checked = false;
            else
                checkBox_topMost.Checked = true;

            this.TopMost = checkBox_topMost.Checked;
        }


        private void checkBox_noChangeSize_Click(object sender, EventArgs e)
        {
            if (checkBox_noChangeSize.Checked)
                checkBox_noChangeSize.Checked = false;
            else
                checkBox_noChangeSize.Checked = true;

            checkedListBox1.Enabled = !checkBox_noChangeSize.Checked;
            groupBox1.Enabled = !checkBox_noChangeSize.Checked;
        }


        private void checkBox_SaveToSourceFolder_Click(object sender, EventArgs e)
        {
            if (checkBox_SaveToSourceFolder.Checked)
                checkBox_SaveToSourceFolder.Checked = false;
            else
                checkBox_SaveToSourceFolder.Checked = true;
        }
    }


    class ImageConvertToIcon
    {
        /// <summary>
        /// 调整图像大小，会释放原图资源
        /// </summary>
        /// <param name="oldBmp">要调整大小的图像</param>
        /// <param name="newSize">目标大小</param>
        /// <returns>改变大小后的图像</returns>
        private static Bitmap ResizeImage(Bitmap oldBmp, Size newSize)
        {
            if (oldBmp == null)
                throw new Exception("函数名：ResizeImage\n原因：参数oldBmp为空！");

            Bitmap newBmp = new Bitmap(newSize.Width, newSize.Height);
            using (Graphics g = Graphics.FromImage(newBmp))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;// 高质量
                g.DrawImage(oldBmp, new Rectangle(0, 0, newSize.Width, newSize.Height), new Rectangle(0, 0, oldBmp.Width, oldBmp.Height), GraphicsUnit.Pixel);
                oldBmp.Dispose();
                return newBmp;
            }
        }


        /// <summary>
        /// 将图片转为ico
        /// </summary>
        /// <param name="source">源图片路径</param>
        /// <param name="dest">目标图片路径</param>
        /// <param name="size">转换成ico后的大小</param>
        public static void ConvertToIcon(string source, string dest, Size icoSize)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(dest))
                return;

            Bitmap bit;
            if (icoSize.Width <= 0 && icoSize.Height <= 0)     // 是否改变原图大小 
                bit = new Bitmap(source);
            else
                bit = ResizeImage(new Bitmap(source), icoSize);// 改变原图大小

            // 将图片转换为图标（转换为含有一张png图片的icon文件）
            using (MemoryStream msImg = new MemoryStream(), msIco = new MemoryStream())
            {
                // 将原图以png格式保存到流中
                bit.Save(msImg, ImageFormat.Png);
                using (BinaryWriter bin = new BinaryWriter(msIco))
                {
                    // 将ico图标的头部写到流中
                    // 写文件头（6字节）
                    bin.Write((short)0);           // 0-1保留字节
                    bin.Write((short)1);           // 2-3文件类型。1=图标, 2=光标
                    bin.Write((short)1);           // 4-5图像数量（图标可以包含多个图像）
                    // 写图像信息块（16字节）
                    bin.Write((byte)bit.Width);    // 6图标宽度
                    bin.Write((byte)bit.Height);   // 7图标高度
                    bin.Write((byte)0);            // 8颜色数（2＝单色，0>=256色。若像素位深>=8，填0。）
                    bin.Write((byte)0);            // 9保留。必须为0
                    bin.Write((short)0);           // 10-11调色板
                    bin.Write((short)32);          // 12-13位深
                    bin.Write((int)msImg.Length);  // 14-17位图数据大小
                    bin.Write(22);                 // 18-21位图数据起始字节

                    // 将png图像的数据写到流中
                    bin.Write(msImg.ToArray());
                    bin.Flush();
                    bin.Seek(0, SeekOrigin.Begin);

                    // 将流写到图标文件
                    using (FileStream fs = new FileStream(dest, FileMode.Create))
                    {
                        fs.Write(msIco.ToArray(), 0, msIco.ToArray().Length);
                    }
                }
            }
        }
    }
}
