using Microsoft.JScript;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using 鹰眼OCR.Audio;

namespace 鹰眼OCR
{
    // 语音识别委托
    public delegate void SpeechRecognitionHandler();

    public partial class FrmAsr : Form
    {
        public SpeechRecognitionHandler SpeechRecognition { get; set; }

        /// <summary>
        /// 窗体显示的坐标
        /// </summary>
        public Point Position { get; set; }

        //保存到本地的音频文件名称 
        public string FileName { get; private set; }

        public string SaveDir { get; set; }

        /// <summary>
        /// 录制的语言类型（普通话或英文）
        /// </summary>
        public string RecordLang { get; set; }

        /// <summary>
        /// wav文件采样率（16000或8000）
        /// </summary>
        public int SamplingRate { get; set; }

        private string[] _SpeechLang;
        public string[] SpeechLang
        {
            get { return _SpeechLang; }
            set
            {
                _SpeechLang = value;
                RefreshLanguage(_SpeechLang);
            }
        }

        public int MaxSec { get; set; }

        private Recorder recorder = new Recorder();
        private PlayAudio playAudio = new PlayAudio();
        private int MaxTime;
        public FrmAsr()
        {
            InitializeComponent();
            SamplingRate = 16000;
        }

        // 开始录音
        private void button1_Start_Click(object sender, EventArgs e)
        {
            FileName = SaveDir + DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") + ".wav";
            if (!Directory.Exists(Path.GetDirectoryName(FileName)))
                Directory.CreateDirectory(Path.GetDirectoryName(FileName));

            try
            {
                if (recorder.Starting)
                    throw new Exception("正在录音！");

                if (File.Exists(FileName))
                    File.Delete(FileName);
                recorder.Start(FileName, SamplingRate);
                MaxTime = MaxSec;
                timer1_RecordingTime.Enabled = true;
                label2.Text = MaxSec.ToString() + "秒";
                label3.ForeColor = Color.DeepSkyBlue;
                label3.Text = "当前状态：正在录音";
            }
            catch (Exception ex)
            {
                if (!Setting_Other.SaveRecord)
                {
                    if (Directory.Exists(Path.GetDirectoryName(FileName)))
                        Directory.Delete(Path.GetDirectoryName(FileName));
                }
                label3.Text = ex.Message;
            }
        }

        // 结束录音
        private void button2_Stop_Click(object sender, EventArgs e)
        {
            try
            {
                if (!recorder.Starting)
                    return;
                recorder.Stop();
                timer1_RecordingTime.Enabled = false;
                label3.ForeColor = Color.Black;
                label3.Text = "当前状态：已停止录音";
            }
            catch (Exception ex)
            {
                label3.Text = ex.Message;
            }
        }

        // 播放录音
        private void button3_Play_Click(object sender, EventArgs e)
        {
            try
            {
                if (recorder.Starting)
                    throw new Exception("请先结束录音");

                // 如果当前未播放，则播放
                if (!playAudio.IsPlaying())
                {
                    if (!File.Exists(FileName))
                        throw new Exception("文件不存在");
                    playAudio.Play(FileName);
                }
                else
                    playAudio.ClosePlay();
            }
            catch (Exception ex)
            {
                label3.Text = ex.Message;
            }
        }

        // 识别录音
        private void button_Recognition_Click(object sender, EventArgs e)
        {
            //if (recorder.RecordedTime == -1)
            //    return;
            if (recorder.Starting)
                button2_Stop_Click(null, null);
            SpeechRecognition?.Invoke();// 调用委托，识别录制的语音
        }

        private void FrmSoundRecording_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.N && !recorder.Starting)    // 按下的是N键 并且 已停止录音
                button1_Start_Click(null, null);
            else if (e.KeyCode == Keys.N && recorder.Starting)// 按下的是N键 并且 正在录音
                button_Recognition_Click(null, null);
        }

        private void FrmSoundRecording_FormClosing(object sender, FormClosingEventArgs e)
        {
            button2_Stop_Click(null, null);

        }

        private void FrmSoundRecording_Shown(object sender, EventArgs e)
        {
            // 显示窗口后录音
            button1_Start_Click(null, null);
        }

        private void FrmSoundRecording_Load(object sender, EventArgs e)
        {
            this.Location = Position;
        }

        private void timer1_RecordingTime_Tick(object sender, EventArgs e)
        {   // 显示录制时间
            // label2.Text = string.Format($"{((int)recorder.RecordedTime / 60).ToString().PadLeft(2, '0')}分{((int)recorder.RecordedTime % 60).ToString().PadLeft(2, '0')}秒");
            try
            {
                MaxTime--;
                label2.Text = MaxTime.ToString() + "秒";
                if (MaxTime <= 0)
                {
                    button_Recognition_Click(null, null);
                    throw new Exception("已到达最大录制时间。");
                }
            }
            catch (Exception ex)
            {
                label3.Text = ex.Message;
            }
        }

        private void comboBox_Lang_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecordLang = comboBox_Lang.SelectedItem.ToString();
        }

        public void RefreshLanguage(string[] lang)
        {
            if (lang == null)
                return;
            try
            {
                comboBox_Lang.Items.Clear();
                comboBox_Lang.Items.AddRange(lang);
                comboBox_Lang.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                label3.Text = ex.Message;
            }
        }
    }
}
