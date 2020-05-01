#include <stdio.h>
#include "标头.h"
#include <errno.h>
#include <string.h>
#include <wtypes.h>
//#include <Windows.h>
#define MAXSIZE 50
#define MAXPATH 512

extern  _declspec(dllexport) char* Write_File(const int* AutoOpenLive, const int* CheckLive, const int* StopCheckLive, const int* AutoOPenNextLive, const int* OpenLiveTime,
	const int* Time1Start, const char* Time1Time, const int* Time2Start, const char* Time2Time, const  int* Time3Start, const char* Time3Time, const int* Time4Start, const char* Time4Time,
	const int* Time5Start, const char* Time5Time, const int* Time6Start, const char* Time6Time, const int* Time7Start, const char* Time7Time, const int* Time8Start, const char* Time8Time,
	const int* ShowTop, const int* PositionX, const int* PositionY, const int* PositionW, const int* PositionH, const char* config_file_path)
{
	char buff[MAXPATH];
	static char err[MAXSIZE];

	sprintf_s(buff, 512, "中断直播时自动进入 = %d;\n"
		"xx分钟检测一次直播是否中断 = %d;\n"
		"xx分钟后还未检测到直播开启则中断检测 = %d;\n"
		"自动开启下一次直播 = %d;\n"
		"距离直播还有xx分钟自动开启 = %d;\n"
		"时间一开启 = %d;\n"
		"时间一 = %s;\n"
		"时间二开启 = %d;\n"
		"时间二 = %s;\n"
		"时间三开启 = %d;\n"
		"时间三 = %s;\n"
		"时间四开启 = %d;\n"
		"时间四 = %s;\n"
		"时间五开启 = %d;\n"
		"时间五 = %s;\n"
		"时间六开启 = %d;\n"
		"时间六 = %s;\n"
		"时间七开启 = %d;\n"
		"时间七 = %s;\n"
		"时间八开启 = %d;\n"
		"时间八 = %s;\n"
		"钉钉始终显示在最顶层 = %d;\n"
		"主窗体X坐标 = %d;\n"
		"主窗体Y坐标 = %d;\n"
		"主窗体宽度 = %d;\n"
		"主窗体高度 = %d;\n",
		*AutoOpenLive, *CheckLive, *StopCheckLive, *AutoOPenNextLive, *OpenLiveTime,
		*Time1Start, Time1Time, *Time2Start, Time2Time, *Time3Start, Time3Time, *Time4Start, Time4Time,
		*Time5Start, Time5Time, *Time6Start, Time6Time, *Time7Start, Time7Time, *Time8Start, Time8Time, *ShowTop,
		*PositionX, *PositionY, *PositionW, *PositionH);

	FILE* fp;
	if (fopen_s(&fp, config_file_path, "w") != 0)
	{
		strerror_s(err, MAXSIZE, errno);
		return err;
	}

	if (fwrite(buff, sizeof(char), strlen(buff), fp) == 0)
	{
		strerror_s(err, MAXSIZE, errno);
		return err;
	}
	fclose(fp);

	return NULL;
}


extern  _declspec(dllexport) char* Read_File(int* AutoOpenLive, int* CheckLive, int* StopCheckLive, int* AutoOPenNextLive, int* OpenLiveTime,
	int* Time1Start, char* Time1Time, int* Time2Start, char* Time2Time, int* Time3Start, char* Time3Time, int* Time4Start, char* Time4Time,
	int* Time5Start, char* Time5Time, int* Time6Start, char* Time6Time, int* Time7Start, char* Time7Time, int* Time8Start, char* Time8Time,
	int* ShowTop, int* PositionX, int* PositionY, int* PositionW, int* PositionH, const char* config_file_path)
{
	int ch, i = 0, j = 0;
	int al = 0;//中断直播时自动进入
	int cl = 5;//每隔xx秒检测是否中断直播
	int scl = 5;//xx分钟后还未检测到直播开启则中断检测
	int aonl = 0;//自动打开下一次直播
	int olt = 5;//距离下一次直播还有xx分钟时自动进入
	int t1s = 0;//时间一
	char t1t[MAXSIZE] = { "0,0" };//时间一内容
	int t2s = 0;
	char t2t[MAXSIZE] = { "0,0" };//时间二容
	int t3s = 0;
	char t3t[MAXSIZE] = { "0,0" };//时间三内容
	int t4s = 0;
	char t4t[MAXSIZE] = { "0,0" };//时间四内容
	int t5s = 0;
	char t5t[MAXSIZE] = { "0,0" };//时间五内容
	int t6s = 0;
	char t6t[MAXSIZE] = { "0,0" };//时间六内容
	int t7s = 0;
	char t7t[MAXSIZE] = { "0,0" };//时间七内容
	int t8s = 0;
	char t8t[MAXSIZE] = { "0,0" };//时间八内容
	int st = 0;//钉钉始终显示在最顶层
	int px = 0;
	int py = 0;
	int pw = 0;
	int ph = 0;

	char config[MAXSIZE];     //储存从文件读取的参数
	static char err[MAXSIZE];//储存错误信息
	FILE* fp;

	//从配置文件读取内容
	if (fopen_s(&fp, config_file_path, "r") != 0)
	{
		strerror_s(err, MAXSIZE, errno);
		return err;
	}

	if ((ch = fgetc(fp)) == EOF)//判断文件是否为空
	{
		strcpy_s(err, MAXSIZE, "配置文件为空！");
		return err;
	}

	while ((ch = fgetc(fp)) != EOF)
	{
		if (ch == '=')   //判断ch是否为“=”
		{
			while ((ch = fgetc(fp)) != ';')//读取“=”到“;”内的参数
			{
				if (ch == ' ')//判断ch是否为空格
				{
					i = 0;
					continue;//跳过此次循环，丢弃读取的空格
				}
				config[i] = ch;
				i++;
			}
		}

		if (ch == '\n')       //判断是否读到下一行
		{
			if (j == 0)
				sscanf_s(config, "%d", &al);  //第一行的内容是中断直播时自动进入
			else if (j == 1)
				sscanf_s(config, "%d", &cl);  //第二行的内容是每隔xx秒检测是否中断直播
			else if (j == 2)
				sscanf_s(config, "%d", &scl); //第三行的内容是xx分钟后还未检测到直播开启则中断检测
			else if (j == 3)
				sscanf_s(config, "%d", &aonl);//第四行的内容是是否自动打开下一次直播
			else if (j == 4)
				sscanf_s(config, "%d", &olt); //第五行的内容是距离下一次直播还有xx分钟时自动进入
			else if (j == 5)
				sscanf_s(config, "%d", &t1s); //第六行的内容是时间一
			else if (j == 6)
				sscanf_s(config, "%s", &t1t, MAXSIZE); //第七行的内容是时间一内容
			else if (j == 7)
				sscanf_s(config, "%d", &t2s); //第八行的内容是时间二
			else if (j == 8)
				sscanf_s(config, "%s", &t2t, MAXSIZE); //第九行的内容是时间一内容
			else if (j == 9)
				sscanf_s(config, "%d", &t3s); //第十行的内容是时间三
			else if (j == 10)
				sscanf_s(config, "%s", &t3t, MAXSIZE); //第十一行的内容是时间时间三内容
			else if (j == 11)
				sscanf_s(config, "%d", &t4s); //第十二行的内容是时间四
			else if (j == 12)
				sscanf_s(config, "%s", &t4t, MAXSIZE); //第十三行的内容是时间时间四内容
			else if (j == 13)
				sscanf_s(config, "%d", &t5s); //第十四行的内容是时间五
			else if (j == 14)
				sscanf_s(config, "%s", &t5t, MAXSIZE); //第十五行的内容是时间五内容
			else if (j == 15)
				sscanf_s(config, "%d", &t6s); //第十六行的内容是时间六
			else if (j == 16)
				sscanf_s(config, "%s", &t6t, MAXSIZE); //第十七行的内容是时间六内容
			else if (j == 17)
				sscanf_s(config, "%d", &t7s); //第十八行的内容是时间七
			else if (j == 18)
				sscanf_s(config, "%s", &t7t, MAXSIZE); //第十九行的内容是时间七内容
			else if (j == 19)
				sscanf_s(config, "%d", &t8s); //第二十行的内容是时间八
			else if (j == 20)
				sscanf_s(config, "%s", &t8t, MAXSIZE); //第二一行的内容是时间八内容
			else if (j == 21)
				sscanf_s(config, "%d", &st); //第二一行的内容是钉钉始终显示在最顶层
			else if (j == 22)
				sscanf_s(config, "%d", &px); //第二二行的内容是主窗体x坐标
			else if (j == 23)
				sscanf_s(config, "%d", &py); //第二三行的内容是主窗体y坐标
			else if (j == 24)
				sscanf_s(config, "%d", &pw); //第二四行的内容是主窗体宽
			else if (j == 25)
				sscanf_s(config, "%d", &ph); //第二五行的内容是主窗体高
			else if (j == 26)
				break;

			j++;
			i = 0;
			memset(config, 0, MAXSIZE);//数组每次循环前清零
		}

	}

	*AutoOpenLive = al;
	*CheckLive = cl;
	*StopCheckLive = scl;
	*AutoOPenNextLive = aonl;
	*OpenLiveTime = olt;
	*Time1Start = t1s;
	strcpy_s(Time1Time, MAXSIZE, t1t);
	*Time2Start = t2s;
	strcpy_s(Time2Time, MAXSIZE, t2t);
	*Time3Start = t3s;
	strcpy_s(Time3Time, MAXSIZE, t3t);
	*Time4Start = t4s;
	strcpy_s(Time4Time, MAXSIZE, t4t);
	*Time5Start = t5s;
	strcpy_s(Time5Time, MAXSIZE, t5t);
	*Time6Start = t6s;
	strcpy_s(Time6Time, MAXSIZE, t6t);
	*Time7Start = t7s;
	strcpy_s(Time7Time, MAXSIZE, t7t);
	*Time8Start = t8s;
	strcpy_s(Time8Time, MAXSIZE, t8t);
	*ShowTop = st;
	*PositionX = px;
	*PositionY = py;
	*PositionW = pw;
	*PositionH = ph;

	fclose(fp);
	return NULL;
}


extern _declspec(dllexport)  char* Screen_Write_File(const int* DingDingX, const int* DingDingY, const int* DingDingWidth, const int* DingDingHeigth,
	const int* ScreenShotX, const int* ScreenShotY, const int* ScreenShotWidth, const int* ScreenShotHeight, const char* config_file_path)
{
	char buff[MAXPATH];
	static char err[MAXSIZE];

	sprintf_s(buff, MAXPATH, "钉钉X坐标 = %d;\n钉钉Y坐标 = %d;\n钉钉宽度 = %d;\n钉钉高度 = %d;\n截图X坐标 = %d;\n截图Y坐标 = %d;\n截图宽度 = %d;\n截图高度 = %d;\n",
		*DingDingX, *DingDingY, *DingDingWidth, *DingDingHeigth, *ScreenShotX, *ScreenShotY, *ScreenShotWidth, *ScreenShotHeight);

	//MessageBoxA(NULL, buff, "aaa", MB_OK);
	FILE* fp;
	if (fopen_s(&fp, config_file_path, "w") != 0)
	{
		strerror_s(err, MAXSIZE, errno);
		return err;
	}

	if (fwrite(buff, sizeof(char), strlen(buff), fp) == 0)
	{
		strerror_s(err, MAXSIZE, errno);
		return err;
	}
	fclose(fp);

	return NULL;
}


extern _declspec(dllexport) char* Screen_Read_File(int* DingDingX, int* DingDingY, int* DingDingWidth, int* DingDingHeigth, int* ScreenShotX,
	int* ScreenShotY, int* ScreenShotWidth, int* ScreenShotHeight, const char* config_file_path)
{

	int ch, i = 0, j = 0;
	int Dx = 0;	  //钉钉x坐标
	int Dy = 0;   //钉钉y坐标
	int Dw = 0;   //钉钉窗口宽度
	int Dh = 0;   //钉钉窗口高度
	int Sx = 0;   //截图x坐标
	int Sy = 0;   //截图y坐标
	int Sw = 0;   //截图宽度
	int Sh = 0;   //截图高度

	char config[MAXSIZE];     //储存从文件读取的参数
	static char err[MAXSIZE];//储存错误信息
	FILE* fp;

	//从配置文件读取内容
	if (fopen_s(&fp, config_file_path, "r") != 0)
	{
		strerror_s(err, MAXSIZE, errno);
		return err;
	}

	if ((ch = fgetc(fp)) == EOF)//判断文件是否为空
	{
		strcpy_s(err, MAXSIZE, "配置文件为空！");
		return err;
	}


	while ((ch = fgetc(fp)) != EOF)
	{
		if (ch == '=')        //判断ch是否为“=”
		{
			while ((ch = fgetc(fp)) != ';')//读取“=”到“;”内的参数
			{
				if (ch == ' ')//判断ch是否为空格
				{
					i = 0;
					continue;//跳过此次循环，丢弃读取的空格
				}
				config[i] = ch;
				i++;
			}
		}

		if (ch == '\n')       //判断是否读到下一行
		{
			if (j == 0)
				sscanf_s(config, "%d", &Dx);   //把第一行的内容保存到Dx，第一行的内容是钉钉x坐标
			else if (j == 1)
				sscanf_s(config, "%d", &Dy);   //把第二行的内容保存到Dy，第二行的内容是钉钉y坐标
			else if (j == 2)
				sscanf_s(config, "%d", &Dw);   //把第三行的内容保存到Dw，第三行的内容是钉钉窗口高度
			else if (j == 3)
				sscanf_s(config, "%d", &Dh);   //把第四行的内容保存到Dh，第三行的内容是钉钉窗口宽度
			else if (j == 4)
				sscanf_s(config, "%d", &Sx);//把第五行的内容保存到Sx，第三行的内容是截图x坐标
			else if (j == 5)
				sscanf_s(config, "%d", &Sy);//把第六行的内容保存到Sy，第三行的内容是截图y坐标
			else if (j == 6)
				sscanf_s(config, "%d", &Sw);//把第七行的内容保存到Sw，第三行的内容是截图宽度
			else if (j == 7)
				sscanf_s(config, "%d", &Sh); //把第八行的内容保存到Sh，第三行的内容是截图高度
			else if (j == 8)
				break;

			j++;
			i = 0;
			memset(config, 0, MAXSIZE);//数组每次循环前清零
		}
	}

	fclose(fp);

	*DingDingX = Dx;
	*DingDingY = Dy;
	*DingDingWidth = Dw;
	*DingDingHeigth = Dh;
	*ScreenShotX = Sx;
	*ScreenShotY = Sy;
	*ScreenShotWidth = Sw;
	*ScreenShotHeight = Sh;
	return NULL;
}


//添加自启动
extern _declspec(dllexport) char* Add(const char* Path, const char* KeyName)
{
	HKEY hkey;
	static char err[MAXSIZE];
	/*char path[MAXPATH];

	strcpy_s(path, MAXPATH, Path);*/

	//打开注册表启动项 
	if (RegOpenKeyExA(HKEY_LOCAL_MACHINE, "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", 0, KEY_ALL_ACCESS, &hkey) == ERROR_SUCCESS)
	{
		if (RegSetValueExA(hkey, "自动进入钉钉直播间", 0, REG_SZ, (BYTE*)Path, strlen(Path) + 1) == ERROR_SUCCESS)//写入注册表
		{
			RegCloseKey(hkey);//关闭注册表
			return NULL;
		}
		else
			strcpy_s(err, MAXSIZE, "向注册表写入键值失败，请以管理员权限运行");
	}
	else
		strcpy_s(err, MAXSIZE, "打开注册表失败，请以管理员权限运行");

	return err;
}

//删除注册表失败
extern _declspec(dllexport) char* Del(const char* KeyName)
{
	HKEY hkey;
	static char err[MAXSIZE];

	//打开注册表启动项 
	if (RegOpenKeyExA(HKEY_LOCAL_MACHINE, "Software\\Microsoft\\Windows\\CurrentVersion\\Run", 0, KEY_ALL_ACCESS, &hkey) == ERROR_SUCCESS)
	{
		if (RegQueryValueExA(hkey, "自动进入钉钉直播间", NULL, NULL, NULL, NULL) == ERROR_FILE_NOT_FOUND)//判断启动项是否存在
		{
			strcpy_s(err, MAXSIZE, "启动项不存在");
			return err;
		}
		else
			strcpy_s(err, MAXSIZE, "读注册表失败，请以管理员权限运行");

		if (RegDeleteValueA(hkey, "自动进入钉钉直播间") == ERROR_SUCCESS)//删除键值
		{
			RegCloseKey(hkey);//关闭注册表
			return NULL;
		}
		else
			strcpy_s(err, MAXSIZE, "读注册表失败，请以管理员权限运行");
	}
	else
		strcpy_s(err, MAXSIZE, "打开注册表失败，请以管理员权限运行");

	return err;
}