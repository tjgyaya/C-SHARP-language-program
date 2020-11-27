using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 鹰眼OCR.Audio
{
    class Recorder
    {
        private WaveIn waveIn = null;
        private WaveFileWriter waveFile = null;

        /// <summary>
        /// 获取录制状态（是否启动）
        /// </summary>
        public bool Starting { get; private set; }

        ///// <summary>
        /////  获取录音时长
        ///// </summary>
        //public double RecordedTime
        //{
        //    get
        //    {
        //        if (waveFile == null)
        //            return -1;
        //        return (double)waveFile.Length / waveFile.WaveFormat.AverageBytesPerSecond;
        //    }
        //}

        /// <summary>
        /// 开始录音
        /// </summary>
        public void Start(string fileName, int rate)
        {
            try
            {
                waveIn = new WaveIn();
                // 设置录音格式
                waveIn.WaveFormat = new WaveFormat(rate, 16, 1);
                // 录音中接收到数据事件
                waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
                // 录音结束事件
                waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(waveIn_RecordingStopped);

                waveFile = new WaveFileWriter(fileName, waveIn.WaveFormat);
                // 开始录音
                waveIn.StartRecording();
                Starting = true;
            }
            catch 
            {
                Stop();
                if (File.Exists(fileName))
                    File.Delete(fileName);
                throw new Exception("请插入麦克风！");
            }
        }

        /// <summary>
        /// 停止录音
        /// </summary>
        public void Stop()
        {
            Starting = false;
            waveIn.StopRecording();
            waveIn_RecordingStopped(null, null);
        }

        /// <summary>
        /// 开始录音回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
            }
        }

        /// <summary>
        /// 录音结束回调函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void waveIn_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveIn != null)
            {
                waveIn.Dispose();
                waveIn = null;
            }

            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }
        }
    }
}
