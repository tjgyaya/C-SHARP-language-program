using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 自动进入钉钉直播
{
    class ConfigFile
    {
        // 写入 主窗体配置文件，储存自定义时间，是否自动开启下一次直播等
        public static void WriteFile(int AutoOpenLive, int CheckLive, int StopCheckLive, int AutoOPenNextLive, int OpenLiveTime,
int Time1Start, string Time1Time, int Time2Start, string Time2Time, int Time3Start, string Time3Time, int Time4Start, string Time4Time,
int Time5Start, string Time5Time, int Time6Start, string Time6Time, int Time7Start, string Time7Time, int Time8Start, string Time8Time,
int ShowTop, int PositionX, int PositionY, int PreventSleep, string DingDingPath, string config_file_path)
        {
            string buff = string.Format($"直播断开时自动打开 = {AutoOpenLive};\n" +
                    $"XX秒钟检测一次直播是否断开 = {CheckLive};\n" +
                    $"XX分钟后还未检测到直播开启则断开检测 = {StopCheckLive};\n" +
                    $"自动开启下一次直播 = {AutoOPenNextLive};\n" +
                    $"距离直播还有xx分钟自动开启 = {OpenLiveTime};\n" +
                    $"时间一开启 = {Time1Start};\n" +
                    $"自定义时间一 = {Time1Time};\n" +
                    $"时间二开启 = {Time2Start};\n" +
                    $"自定义时间二 = {Time2Time};\n" +
                    $"时间三开启 = {Time3Start};\n" +
                    $"自定义时间三 = {Time3Time};\n" +
                    $"时间四开启 = {Time4Start};\n" +
                    $"自定义时间四 = {Time4Time};\n" +
                    $"时间五开启 = {Time5Start};\n" +
                    $"自定义时间五 = {Time5Time};\n" +
                    $"时间六开启 = {Time6Start};\n" +
                    $"自定义时间六 = {Time6Time};\n" +
                    $"时间七开启 = {Time7Start};\n" +
                    $"自定义时间七 = {Time7Time};\n" +
                    $"时间八开启 = {Time8Start};\n" +
                    $"自定义时间八 = {Time8Time};\n" +
                    $"钉钉始终显示在最顶层 = {ShowTop};\n" +
                    $"主窗体X坐标 = {PositionX};\n" +
                    $"主窗体Y坐标 = {PositionY};\n" +
                    $"阻止系统休眠 = {PreventSleep};\n" +
                    $"钉钉路径 = {DingDingPath};\n");

            File.WriteAllText(config_file_path, buff);
        }


        // 读取 主窗体配置文件，储存自定义时间，是否自动开启下一次直播等
        public static string ReadFile(ref int AutoOpenLive, ref int CheckLive, ref int StopCheckLive, ref int AutoOPenNextLive,
            ref int OpenLiveTime, ref int Time1Start, ref string Time1Time, ref int Time2Start, ref string Time2Time,
            ref int Time3Start, ref string Time3Time, ref int Time4Start, ref string Time4Time, ref int Time5Start,
            ref string Time5Time, ref int Time6Start, ref string Time6Time, ref int Time7Start, ref string Time7Time,
            ref int Time8Start, ref string Time8Time, ref int ShowTop, ref int PositionX, ref int PositionY, ref int PreventSleep,
            ref string DingDingPath, string config_file_path)
        {
            const int MAXSIZE = 260;
            int ch, i = 0, j = 0;
            char[] config = new char[MAXSIZE]; // 储存从文件读取的参数
            FileStream fs = new FileStream(config_file_path, FileMode.Open, FileAccess.Read, FileShare.None);
            try
            {
                // 判断文件是否为空
                if (fs.Length == 0)
                    throw new Exception("文件为空！");

                while ((ch = fs.ReadByte()) != -1)
                {
                    if (ch == '=')   //判断ch是否为“=”
                    {
                        while ((ch = fs.ReadByte()) != ';')//读取“=”到“;”内的参数
                        {
                            if (ch == ' ' && NumberOfArrayElement(config) == 0)//判断ch是否为空格
                            {
                                i = 0;
                                continue;//跳过此次循环，丢弃读取的空格
                            }
                            config[i] = (char)ch;
                            i++;
                        }
                    }

                    if (ch == '\n')       //判断是否读到下一行
                    {
                        if (j == 0)
                            AutoOpenLive = Convert.ToInt32(new string(config)); //第一行的内容是中断直播时自动进入
                        else if (j == 1)
                            CheckLive = Convert.ToInt32(new string(config));//第二行的内容是每隔xx秒检测是否中断直播
                        else if (j == 2)
                            StopCheckLive = Convert.ToInt32(new string(config)); //第三行的内容是xx分钟后还未检测到直播开启则中断检测
                        else if (j == 3)
                            AutoOPenNextLive = Convert.ToInt32(new string(config));//第四行的内容是是否自动打开下一次直播
                        else if (j == 4)
                            OpenLiveTime = Convert.ToInt32(new string(config));//第五行的内容是距离下一次直播还有xx分钟时自动进入
                        else if (j == 5)
                            Time1Start = Convert.ToInt32(new string(config));//第六行的内容是时间一
                        else if (j == 6)
                            Time1Time = new string(config); //第七行的内容是时间一内容
                        else if (j == 7)
                            Time2Start = Convert.ToInt32(new string(config));//第八行的内容是时间二 
                        else if (j == 8)
                            Time2Time = new string(config);//第九行的内容是时间一内容
                        else if (j == 9)
                            Time3Start = Convert.ToInt32(new string(config)); //第十行的内容是时间三
                        else if (j == 10)
                            Time3Time = new string(config);//第十一行的内容是时间时间三内容
                        else if (j == 11)
                            Time4Start = Convert.ToInt32(new string(config));//第十二行的内容是时间四
                        else if (j == 12)
                            Time4Time = new string(config);//第十三行的内容是时间时间四内容
                        else if (j == 13)
                            Time5Start = Convert.ToInt32(new string(config));//第十四行的内容是时间五
                        else if (j == 14)
                            Time5Time = new string(config);//第十五行的内容是时间五内容
                        else if (j == 15)
                            Time6Start = Convert.ToInt32(new string(config));//第十六行的内容是时间六
                        else if (j == 16)
                            Time6Time = new string(config);//第十七行的内容是时间六内容
                        else if (j == 17)
                            Time7Start = Convert.ToInt32(new string(config));//第十八行的内容是时间七
                        else if (j == 18)
                            Time7Time = new string(config);//第十九行的内容是时间七内容
                        else if (j == 19)
                            Time8Start = Convert.ToInt32(new string(config));//第20行的内容是时间八
                        else if (j == 20)
                            Time8Time = new string(config);//第21行的内容是时间八内容
                        else if (j == 21)
                            ShowTop = Convert.ToInt32(new string(config));//第22行的内容是钉钉始终显示在最顶层
                        else if (j == 22)
                            PositionX = Convert.ToInt32(new string(config)); //第23行的内容是主窗体x坐标
                        else if (j == 23)
                            PositionY = Convert.ToInt32(new string(config));//第24行的内容是主窗体y坐标       
                        else if (j == 24)
                            PreventSleep = Convert.ToInt32(new string(config));//第25行的内容是 是否阻止系统休眠
                        else if (j == 25)
                            DingDingPath = new string(config);//第26行的内容是 钉钉路径
                        else if (j == 26)
                            break;

                        j++;
                        i = 0;
                        //数组每次循环前清零
                        Array.Clear(config, 0, config.Length);
                    }
                }

                SplitStr(ref Time1Time);
                SplitStr(ref Time2Time);
                SplitStr(ref Time3Time);
                SplitStr(ref Time4Time);
                SplitStr(ref Time5Time);
                SplitStr(ref Time6Time);
                SplitStr(ref Time7Time);
                SplitStr(ref Time8Time);
                SplitStr(ref DingDingPath);
                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                fs.Close();
            }
        }


        // 返回字符串“\0”字符之前的内容
        private static void SplitStr(ref string str)
        {
            int index = str.IndexOf('\0');
            if (index != -1)
                str = str.Substring(0, index);
        }


        // 获取数组元素个数
        private static int NumberOfArrayElement(char[] arr)
        {
            int i = 0;
            for (; i < arr.Length && arr[i] != '\0'; i++)
                ;

            return i;
        }
    }
}

