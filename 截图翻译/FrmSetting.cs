using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace 截图翻译
{
    public partial class FrmSetting : Form
    {
        // **************************************设置窗口**************************************.

        // 要写入配置文件的键名称
        public static string[] Names = { "截图热键", "切换英中", "翻译热键", "切换俄中", "固定翻译",
            "延迟", "复制翻译原文", "复制翻译译文", "翻译后朗读译文", "翻译来源" ,
            "固定翻译截图横坐标","固定翻译截图竖坐标","固定翻译截图宽度","固定翻译截图高度"};

        // 从文件中读取的键值
        public static string[] ReadValues = new string[Names.Length];

        private Rectangle screenRect = new Rectangle();// 固定截图坐标大小

        public FrmSetting()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;
        }


        private void Setting_Load(object sender, EventArgs e)
        {
            try
            {
                if (Array.IndexOf(ReadValues, null) != -1)
                    return;
                textBox1.Text = ReadValues[0];
                textBox2.Text = ReadValues[1];
                textBox3.Text = ReadValues[2];
                textBox4.Text = ReadValues[3];
                textBox5.Text = ReadValues[4];
                numericUpDown1.Value = Convert.ToDecimal(ReadValues[5]);
                checkBox1.Checked = Convert.ToBoolean(ReadValues[6]);
                checkBox2.Checked = Convert.ToBoolean(ReadValues[7]);
                checkBox3.Checked = Convert.ToBoolean(ReadValues[8]);
                comboBox1.SelectedItem = ReadValues[9];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void checkBox_Click(object sender, EventArgs e)
        {
            if (!((CheckBox)sender).Checked)
                ((CheckBox)sender).Checked = true;
            else
                ((CheckBox)sender).Checked = false;
        }


        private void button1_SaveConfigFile_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked)
            {
                MessageBox.Show("“复制翻译原文”和“复制翻译译文”不可同时启用！");
                return;
            }

            List<string> list = new List<string>();
            // 判断文本框中的值是否为空或重复
            foreach (Control ctl in groupBox1.Controls)
            {
                // 如果控件类型不是TextBox
                if (!(ctl is TextBox) || string.IsNullOrEmpty(ctl.Text))
                    continue;

                if (list.Contains(ctl.Text))
                {
                    MessageBox.Show("热键存在重复！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                list.Add(ctl.Text);
            }

            // 创建一个数组，保存要写入配置文件的内容
            string[] writeValues = {
                textBox1.Text, textBox2.Text,  textBox3.Text,
                textBox4.Text, textBox5.Text,  ((int)numericUpDown1.Value).ToString(),
                checkBox1.Checked.ToString(),  checkBox2.Checked.ToString(),
                checkBox3.Checked.ToString(),  comboBox1.SelectedItem.ToString(),
                screenRect.X.ToString(),       screenRect.Y.ToString(),
                screenRect.Width.ToString(),   screenRect.Height.ToString()};

            try
            {
                ConfigFile.WriteFile(Names, writeValues);
                MessageBox.Show("保存成功，\n重启软件后生效！", "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("写入配置文件错误！\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void textBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            // 将按下的键显示到text
            ((TextBox)sender).Text = e.KeyData.ToString();
        }


        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]// 查找窗口句柄
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ScreenToClient(IntPtr hWnd, ref POINT pt);
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;
        }


        // 设置固定翻译坐标
        private void button2_SetPosition_Click(object sender, EventArgs e)
        {
            string savePath = DateTime.Now.ToString("yyyy-dd-MM_HH_mm_ss") + ".bmp";

            FrmScreenShot shot = new FrmScreenShot(savePath, true);
            try
            {
                // 显示截图窗口
                DialogResult result = shot.ShowDialog();
                if (result == DialogResult.Cancel)
                    throw new Exception("用户取消截图！");

                POINT p = new POINT();
                p.X = shot.MouseDownPoint.X;
                p.Y = shot.MouseDownPoint.Y;

                IntPtr hwnd=FindWindow("grcWindow", null);
                if (IntPtr.Zero == hwnd)
                    throw new Exception("找不到GTA窗口句柄");
                // 屏幕坐标转为客户端窗口坐标
                ScreenToClient(hwnd,ref p);

                // 保存截图坐标高宽
                screenRect = new Rectangle(p.X, p.Y, shot.ScreenWidth, shot.ScreenHeight);
                if (shot.ScreenWidth > 0 && shot.ScreenHeight > 0)
                    MessageBox.Show("设置成功，请点击“保存配置”按钮。", "截图翻译", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    throw new Exception("设置失败，请重试！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("设置固定翻译坐标失败！\n原因：" + ex.Message, "截图翻译", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (File.Exists(savePath))
                    File.Delete(savePath);

                if (shot != null && !shot.IsDisposed)
                    shot.Dispose();
            }
        }
    }
}
