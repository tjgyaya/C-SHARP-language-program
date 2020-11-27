using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 鹰眼OCR.Audio
{
    class PlayAudio
    {
        private Thread newThread = null;

        public PlayStoppedHandler PlayStopped { get; set; }

        WaveOut waveOut = null;
        private string fileName;
        private string mode;

        public PlayAudio()
        {
            
        }

        /// <summary>
        /// 播放mp3
        /// </summary>
        /// <param name="fileName"></param>
        public void Play(string fileName, string mode = null)
        {
            if (waveOut == null)
                waveOut = new WaveOut();
            waveOut.PlaybackStopped += WaveOut_PlaybackStopped;
            this.fileName = fileName;
            this.mode = mode;
            if (IsPlaying())
                ClosePlay();
            newThread = new Thread(StartThread);// 创建新线程播放，避免卡死当前线程
            newThread.Start();
        }

        /// <summary>
        /// 停止播放
        /// </summary>
        public void ClosePlay()
        {
            CloseThread();
            WaveOutDispose();
            PlayStopped?.Invoke(fileName, mode);
        }

        /// <summary>
        /// 播放状态
        /// 正在播放返回true
        /// </summary>
        /// <returns></returns>
        public bool IsPlaying()
        {
            if (waveOut == null)
                return false;
            else
                return waveOut.PlaybackState == PlaybackState.Playing;
        }

        /// <summary>
        /// 开始播放
        /// </summary>
        private void StartThread()
        {
            if (!File.Exists(fileName))
                throw new Exception("文件不存在！");
            try
            {
                using (AudioFileReader audioFileReader = new AudioFileReader(fileName))
                {
                    waveOut.Init(audioFileReader);
                    waveOut.Play();
                    // 如果没有下面这个循环，则播放1s后自动停止
                    while (waveOut.PlaybackState == PlaybackState.Playing)
                    {
                        Thread.Sleep(200);
                    }
                }
            }
            finally
            {
            }
        }

        private void WaveOutDispose()
        {
            if (waveOut != null)
            {
                waveOut.Dispose();
                waveOut = null;
            }
        }

        private void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            ClosePlay();
        }

        /// <summary>
        /// 关闭线程，当“getStatus”为true时返回线程的状态，不关闭线程
        /// </summary>
        /// <param name="getStatus">当为true时返回线程的状态，不关闭线程</param>
        /// <returns>线程的状态</returns>
        private bool CloseThread(bool getStatus = false)
        {
            if (newThread != null)
            {
                if ((newThread.ThreadState & (ThreadState.Stopped | ThreadState.Unstarted | ThreadState.Aborted)) == 0)
                {
                    if (getStatus)
                        return true;
                    newThread.Abort();
                    newThread = null;
                }
            }
            return false;
        }
    }
}
