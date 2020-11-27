﻿using NAudio.MediaFoundation;
using NAudio.Wave;
using System;
using System.IO;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace 鹰眼OCR.OCR
{
    class LocalTTS
    {
        /// <summary>
        /// 调用本地微软TTS引擎，实现语音合成
        /// </summary>
        /// <param name="text">要合成的文本</param>
        /// <param name="spd">语速[-10,10]</param>
        /// <param name="vol">音量[0,100]</param>
        /// <param name="per">发音人</param>
        /// <param name="fileName">保存到本地的文件名</param>
        public static void MSSpeechSynthesis(string text, string spd, string vol, string per, string fileName)
        {
            using (SpeechSynthesizer speech = new SpeechSynthesizer())
            {
                speech.Rate = Convert.ToInt32(spd);   // 语速 [0,100] 
                speech.Volume = Convert.ToInt32(vol); // 音量 [0,100]
                speech.SelectVoice(per);              // 发音人
               // string temp = Application.StartupPath + "\\" + "temp.wav";
                speech.SetOutputToWaveFile(fileName);     // 先输出到wav文件
                speech.Speak(text);
                speech.SetOutputToNull();
                //WAVtoMP3(temp, fileName);             // 再将wav文件转换为到mp3文件
                //if (File.Exists(temp))
                //    File.Delete(temp);
            }
        }

        /// <summary>
        /// 将wav文件转换为mp3文件
        /// </summary>
        /// <param name="wavFile">wav文件路径</param>
        /// <param name="mp3File">mp3文件路径</param>
        public static void WAVtoMP3(string wavFile, string mp3File)
        {
            var mediaType = MediaFoundationEncoder.SelectMediaType(AudioSubtypes.MFAudioFormat_MP3,new WaveFormat(44100, 1),0);
            using (var reader = new MediaFoundationReader(wavFile))
            {
                using (var encoder = new MediaFoundationEncoder(mediaType))
                {
                    encoder.Encode(mp3File, reader);
                }
            }
        }
    }
}
