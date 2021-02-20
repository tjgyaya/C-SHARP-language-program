using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 鹰眼OCR
{
    public partial class FrmPhotograph : Form
    {
        public FrmPhotograph()
        {
            InitializeComponent();
        }

        // 拍照识别委托
        public delegate void PhotographEventHandler(Image img);
        public event PhotographEventHandler PhotographEvent;

        /// <summary>
        /// 窗体显示的坐标
        /// </summary>
        public Point Position { get; set; }

        private FilterInfoCollection videoDevices;
        private string errMessage = null;   // 错误消息
        private int currentDeviceIndex = -1;// 当前选中的摄像头设备索引 (等于comboBox1_SwitchingDevice.SelectedIndex)
        private bool switchCameras = false; // 是否在切换摄像头


        // 扫描视频设备
        private void button1_ScanDevices_Click(object sender, EventArgs e)
        {
            try
            {
                comboBox1_SwitchingDevice.Items.Clear();

                // 查找视频输入设备并添加到comboBox1
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                    throw new Exception("没有视频设备");

                foreach (FilterInfo device in videoDevices)
                    comboBox1_SwitchingDevice.Items.Add(device.Name);
                groupBox1.Text = "发现新设备";
            }
            catch (Exception ex)
            {
                comboBox1_SwitchingDevice.Items.Add(ex.Message);
                errMessage = ex.Message;     // 保存错误消息
                groupBox1.Text = ex.Message; // 在groupBox1左上角显示
                videoDevices = null;
            }
            finally
            {
                comboBox1_SwitchingDevice.SelectedIndex = 0;
            }
        }


        // 连接视频设备
        private void button2_ConnectingDevice_Click(object sender, EventArgs e)
        {
            if (comboBox1_SwitchingDevice.SelectedItem.ToString() == errMessage)
            {   // 如果没有视频设备
                groupBox1.Text = errMessage;
                return;
            }
            if (!switchCameras)// 如果当前不是在切换分辨率，则判断当前选择的视频设备是否已连接
            {
                if (currentDeviceIndex == comboBox1_SwitchingDevice.SelectedIndex)
                {
                    groupBox1.Text = "当前设备已连接";
                    return;
                }
            }
            else
                switchCameras = false;

            // 如果正在运行，则停止
            if (videoPlayer1.IsRunning)
            {
                videoPlayer1.SignalToStop();
                videoPlayer1.WaitForStop();
            }

            currentDeviceIndex = comboBox1_SwitchingDevice.SelectedIndex; // 保留连接的视频设备索引
            VideoCaptureDevice videoCapture = new VideoCaptureDevice(videoDevices[comboBox1_SwitchingDevice.SelectedIndex].MonikerString);
            videoCapture.VideoResolution = videoCapture.VideoCapabilities[comboBox2_SwitchResolution.SelectedIndex];
            //videoCapture.DesiredFrameRate = 1;
            videoPlayer1.VideoSource = videoCapture;
            videoPlayer1.Start();
            groupBox1.Text = "正在拍照";
        }


        // 拍照
        private void button3_Photograph_Click(object sender, EventArgs e)
        {
            if (comboBox1_SwitchingDevice.SelectedItem.ToString() == errMessage)
            {   // 如果没有视频设备
                groupBox1.Text = errMessage;
                return;
            }

            if (!videoPlayer1.IsRunning)// 如果未运行
            {
                groupBox1.Text = "未运行";
                return;
            }

            // 将图片保存到本地
            groupBox1.Text = "已拍照";
            OnPhotograph(videoPlayer1.GetCurrentVideoFrame());
        }

        private void OnPhotograph(Image img)
        {
            PhotographEvent?.Invoke(img);
        }

        // 窗口加载时，自动连接摄像头
        private void FrmPhotograph_Load(object sender, EventArgs e)
        {
            this.Location = Position;
            button1_ScanDevices_Click(null, null);// 先扫描视频设备，再连接摄像头
            comboBox2_SwitchResolution.SelectedIndex = 0;// 在更改comboBox2的SelectedIndex属性时会触发comboBox2_SelectedIndexChanged事件，连接摄像头
        }


        // 关闭摄像头并清理资源
        private void FrmPhotograph_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoPlayer1 != null)
            {
                if (videoPlayer1.IsRunning)
                {
                    videoPlayer1.SignalToStop();
                    videoPlayer1.WaitForStop();
                }
                videoPlayer1.Dispose();
            }

            if (!this.IsDisposed)
                this.Dispose(true);
        }


        // 切换分辨率时关闭并重新打开摄像头
        private void comboBox2_SwitchResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            switchCameras = true;
            // 重新以选择的分辨率连接摄像头
            button2_ConnectingDevice_Click(null, null);
        }
    }
}
