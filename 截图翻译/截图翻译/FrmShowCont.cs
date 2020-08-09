using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 截图翻译
{
    public partial class FrmShowCont : Form
    {
        // **************************************显示翻译结果窗口**************************************
        private int showTime;
        public FrmShowCont(int show_time)
        {
            InitializeComponent();

            this.ShowInTaskbar = false;
            this.TopMost = true;

            showTime = show_time * 1000;
        }

        public void ContText(string cont)
        {
            if (cont == null)
                return;
            label1.Text = cont;  // 将要显示的内容显示到label

            SizeF Size;
            using (Graphics g = this.CreateGraphics())
            {
                // 求出单个中文字体的宽度（像素）
                Size = g.MeasureString("微", this.Font);
            }

            // 求出每一行显示的最大字符数并取整
            int max = RoundUp(Screen.PrimaryScreen.Bounds.Width / (int)Size.Width);
            cont = InsertChar(cont, max);
            if (cont.Length < 5)
            {
                // 如果宽度太小就增加字号
                for (int i = 0; i < 10 && label1.Width <= 100; i++)
                    label1.Font = new Font("微软雅黑", 12 + i);
            }
        }

        private void ShowCont_Load(object sender, EventArgs e)
        {
            // 设置宽高与label一致
            this.Width = label1.Width;
            this.Height = label1.Height;

            // 在顶部中间显示（屏幕宽 - 窗口宽）/2
            int x = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2 - 40;
            int y = 0;
            this.Location = new Point(x, y);
        }


        // 整数个位数向上取整（5或0）
        private int RoundUp(int num)
        {
            // 是否是负数
            bool negative = false;
            int temp;

            if (num == 0)
                return num;

            // 如果为负数
            if (num < 0)
            {
                negative = true;
                num = -num; // 把负数变为整数 
            }

            string str = num.ToString();
            // 取这个数个位上的数
            temp = str[str.Length - 1] - '0';

            if (temp > 5)// 个位上的数大于5
                temp = num + (10 - temp);
            else if (temp == 5)
                temp = num;
            else if (temp < 5)
                temp = num - temp;

            // 如果取整后的数不等于0并且原数为负数
            if (temp != 0 && negative)
                temp = -temp;

            return temp;
        }


        // 每隔max个字符，在max+1出插入一个换行符
        private string InsertChar(string str, int max)
        {
            int i;
            i = max < 1 ? 1 : 2;
            for (; i < str.Length; i++)
            {
                if (i % max == 0)
                    str = str.Insert(i + 1, "\r\n");
            }

            return str;
        }


        private void ShowCont_Shown(object sender, EventArgs e)
        {
            SleepAsync();
        }


        private delegate void MyInvoke();
        // 休眠showTime秒后关闭窗口
        private async void SleepAsync()
        {
            MyInvoke mi = new MyInvoke(CloseWindow);

            await Task.Run(() =>
            {
                Thread.Sleep(showTime);
                if (this.IsHandleCreated) //判断窗口句柄是否存在
                    this.BeginInvoke(mi);
            });
        }


        private void CloseWindow()
        {
            this.Close();
        }
    }
}
