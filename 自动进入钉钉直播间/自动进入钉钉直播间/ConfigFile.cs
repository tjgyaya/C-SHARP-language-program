using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 自动进入钉钉直播间
{
    class ConfigFile
    {
        //#define MAXSIZE 50
        const int MAXSIZE = 50;


        //主窗体配置文件，储存自定义时间，是否自动开启下一次直播等
        [DllImport("ReadOrWriteFile.dll", EntryPoint = "Write_File", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Write_File(ref int AutoOpenLive, ref int CheckLive, ref int StopCheckLive, ref int AutoOPenNextLive, ref int OpenLiveTime,
        ref int Time1Start, string Time1Time, ref int Time2Start, string Time2Time, ref int Time3Start, string Time3Time, ref int Time4Start, string Time4Time,
        ref int Time5Start, string Time5Time, ref int Time6Start, string Time6Time, ref int Time7Start, string Time7Time, ref int Time8Start, string Time8Time,
        ref int ShowTop, ref int PositionX, ref int PositionY, ref int PositionW, ref int PositionH, string config_file_path);


        public static string WriteFile(int AutoOpenLive, int CheckLive, int StopCheckLive, int AutoOPenNextLive, int OpenLiveTime,
        int Time1Start, string Time1Time, int Time2Start, string Time2Time, int Time3Start, string Time3Time, int Time4Start, string Time4Time,
        int Time5Start, string Time5Time, int Time6Start, string Time6Time, int Time7Start, string Time7Time, int Time8Start, string Time8Time,
        int ShowTop, int PositionX, int PositionY, int PositionW, int PositionH, string config_file_path)
        {

            IntPtr p = Write_File(ref AutoOpenLive, ref CheckLive, ref StopCheckLive, ref AutoOPenNextLive, ref OpenLiveTime,
            ref Time1Start, Time1Time, ref Time2Start, Time2Time, ref Time3Start, Time3Time, ref Time4Start, Time4Time,
            ref Time5Start, Time5Time, ref Time6Start, Time6Time, ref Time7Start, Time7Time, ref Time8Start, Time8Time,
            ref ShowTop, ref PositionX, ref PositionY, ref PositionW, ref PositionH, config_file_path);

            if (p != IntPtr.Zero)
                return Marshal.PtrToStringAnsi(p);
            else
                return null;
        }




        [DllImport("ReadOrWriteFile.dll", EntryPoint = "Read_File", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Read_File(ref int AutoOpenLive, ref int CheckLive, ref int StopCheckLive, ref int AutoOPenNextLive, ref int OpenLiveTime,
        ref int Time1Start, StringBuilder Time1Time, ref int Time2Start, StringBuilder Time2Time, ref int Time3Start, StringBuilder Time3Time, ref int Time4Start, StringBuilder Time4Time,
        ref int Time5Start, StringBuilder Time5Time, ref int Time6Start, StringBuilder Time6Time, ref int Time7Start, StringBuilder Time7Time, ref int Time8Start, StringBuilder Time8Time,
        ref int ShowTop, ref int PositionX, ref int PositionY, ref int PositionW, ref int PositionH, string config_file_path);


        public static string ReadFile(ref int AutoOpenLive, ref int CheckLive, ref int StopCheckLive, ref int AutoOPenNextLive, ref int OpenLiveTime,
        ref int Time1Start, out string Time1Time, ref int Time2Start, out string Time2Time, ref int Time3Start, out string Time3Time, ref int Time4Start, out string Time4Time,
        ref int Time5Start, out string Time5Time, ref int Time6Start, out string Time6Time, ref int Time7Start, out string Time7Time, ref int Time8Start, out string Time8Time,
        ref int ShowTop, ref int PositionX, ref int PositionY, ref int PositionW, ref int PositionH, string config_file_path)
        {
            StringBuilder SB_Time1Time = new StringBuilder(MAXSIZE);
            StringBuilder SB_Time2Time = new StringBuilder(MAXSIZE);
            StringBuilder SB_Time3Time = new StringBuilder(MAXSIZE);
            StringBuilder SB_Time4Time = new StringBuilder(MAXSIZE);
            StringBuilder SB_Time5Time = new StringBuilder(MAXSIZE);
            StringBuilder SB_Time6Time = new StringBuilder(MAXSIZE);
            StringBuilder SB_Time7Time = new StringBuilder(MAXSIZE);
            StringBuilder SB_Time8Time = new StringBuilder(MAXSIZE);

            IntPtr p = Read_File(ref AutoOpenLive, ref CheckLive, ref StopCheckLive, ref AutoOPenNextLive, ref OpenLiveTime,
            ref Time1Start, SB_Time1Time, ref Time2Start, SB_Time2Time, ref Time3Start, SB_Time3Time, ref Time4Start, SB_Time4Time,
            ref Time5Start, SB_Time5Time, ref Time6Start, SB_Time6Time, ref Time7Start, SB_Time7Time, ref Time8Start, SB_Time8Time,
            ref ShowTop, ref PositionX, ref PositionY, ref PositionW, ref PositionH, config_file_path);

            if (p != IntPtr.Zero)
            {
                Time1Time = null;
                Time2Time = null;
                Time3Time = null;
                Time4Time = null;
                Time5Time = null;
                Time6Time = null;
                Time7Time = null;
                Time8Time = null;
                return Marshal.PtrToStringAnsi(p);
            }
            else
            {
                Time1Time = SB_Time1Time.ToString();
                Time2Time = SB_Time2Time.ToString();
                Time3Time = SB_Time3Time.ToString();
                Time4Time = SB_Time4Time.ToString();
                Time5Time = SB_Time5Time.ToString();
                Time6Time = SB_Time6Time.ToString();
                Time7Time = SB_Time7Time.ToString();
                Time8Time = SB_Time8Time.ToString();
                return null;
            }
        }






        //截图配置文件，储存截图的坐标高宽和钉钉窗口的坐标高宽
        [DllImport("ReadOrWriteFile.dll", EntryPoint = "Screen_Write_File", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Screen_Write_File(ref int DingDingX, ref int DingDingY, ref int DingDingWidth, ref int DingDingHeigth,
           ref int ScreenShotX, ref int ScreenShotY, ref int ScreenShotWidth, ref int ScreenShotHeight, string config_file_path);


        public static string ScreenWriteFile(int DingDingX, int DingDingY, int DingDingWidth, int DingDingHeigth,
           int ScreenShotX, int ScreenShotY, int ScreenShotWidth, int ScreenShotHeight, string config_file_path)
        {
            //写入截图配置文件
            IntPtr p = Screen_Write_File(ref DingDingX, ref DingDingY, ref DingDingWidth, ref DingDingHeigth,
                ref ScreenShotX, ref ScreenShotY, ref ScreenShotWidth, ref ScreenShotHeight, config_file_path);

            if (p != IntPtr.Zero)
                return Marshal.PtrToStringAnsi(p);
            else
                return null;
        }



        [DllImport("ReadOrWriteFile.dll", EntryPoint = "Screen_Read_File", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr Screen_Read_File(ref int DingDingX, ref int DingDingY, ref int DingDingWidth, ref int DingDingHeigth,
           ref int ScreenShotX, ref int ScreenShotY, ref int ScreenShotWidth, ref int ScreenShotHeight, string config_file_path);


        public static string ScreenReadFile(ref int DingDingX, ref int DingDingY, ref int DingDingWidth, ref int DingDingHeigth,
           ref int ScreenShotX, ref int ScreenShotY, ref int ScreenShotWidth, ref int ScreenShotHeight, string config_file_path)
        {
            IntPtr p = Screen_Read_File(ref DingDingX, ref DingDingY, ref DingDingWidth, ref DingDingHeigth,
                ref ScreenShotX, ref ScreenShotY, ref ScreenShotWidth, ref ScreenShotHeight, config_file_path);

            if (p != IntPtr.Zero)
                return Marshal.PtrToStringAnsi(p);
            else
                return null;
        }
    }
}
