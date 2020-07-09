using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 截图翻译
{
    public partial class Setting : Form
    {
        // 要写入配置文件的键名称
        public static string[] Names = { "截图热键", "切换英中", "翻译热键", "切换俄中", "延迟", "复制翻译原文", "复制翻译译文", "翻译后朗读译文", "翻译来源" };
        // 从文件中读取的键值
        public static string[] ReadValues = new string[Names.Length];

        public Setting()
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
                numericUpDown1.Value = Convert.ToDecimal(ReadValues[4]);
                checkBox1.Checked = Convert.ToBoolean(ReadValues[5]);
                checkBox2.Checked = Convert.ToBoolean(ReadValues[6]);
                checkBox3.Checked = Convert.ToBoolean(ReadValues[7]);
                comboBox1.SelectedItem = ReadValues[8];
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
                if (!(ctl is TextBox))
                    continue;

                if (ctl.Text == "")
                {
                    MessageBox.Show("热键为空！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (list.Contains(ctl.Text))
                {
                    MessageBox.Show("热键存在重复！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                    list.Add(ctl.Text);

            }

            // 创建一个数组，保存要写入配置文件的内容
            string[] writeValues = {
                textBox1.Text ,textBox2.Text ,textBox3.Text,
                textBox4.Text,((int)numericUpDown1.Value).ToString() ,
                checkBox1.Checked.ToString() ,checkBox2.Checked.ToString(),
                checkBox3.Checked.ToString(),comboBox1.SelectedItem.ToString() };

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


    }
}
