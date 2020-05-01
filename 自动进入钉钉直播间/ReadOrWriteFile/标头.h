#pragma once
extern  _declspec(dllexport) char* Write_File(const int* AutoOpenLive, const int* CheckLive, const int* StopCheckLive, const int* AutoOPenNextLive, const int* OpenLiveTime,
	const int* Time1Start, const char* Time1Time, const int* Time2Start, const char* Time2Time, const  int* Time3Start, const char* Time3Time, const int* Time4Start, const char* Time4Time,
	const int* Time5Start, const char* Time5Time, const int* Time6Start, const char* Time6Time, const int* Time7Start, const char* Time7Time, const int* Time8Start, const char* Time8Time,
	const int* ShowTop, const int* PositionX, const int* PositionY, const int* PositionW, const int* PositionH, const char* config_file_path);

extern  _declspec(dllexport) char* Read_File(int* AutoOpenLive, int* CheckLive, int* StopCheckLive, int* AutoOPenNextLive, int* OpenLiveTime,
	int* Time1Start, char* Time1Time, int* Time2Start, char* Time2Time, int* Time3Start, char* Time3Time, int* Time4Start, char* Time4Time,
	int* Time5Start, char* Time5Time, int* Time6Start, char* Time6Time, int* Time7Start, char* Time7Time, int* Time8Start, char* Time8Time,
	int* ShowTop, int* PositionX, int* PositionY, int* PositionW, int* PositionH, const char* config_file_path);

extern  _declspec(dllexport) char* Screen_Write_File(const int* DingDingX, const int* DingDingY, const int* DingDingWidth, const int* DingDingHeigth,
	const int* ScreenShotX, const int* ScreenShotY, const int* ScreenShotWidth, const int* ScreenShotHeight, const char* config_file_path);


extern  _declspec(dllexport) char* Screen_Read_File(int* DingDingX, int* DingDingY, int* DingDingWidth, int* DingDingHeigth,
	int* ScreenShotX, int* ScreenShotY, int* ScreenShotWidth, int* ScreenShotHeight, const char* config_file_path);

extern _declspec(dllexport) char* Add(const char* Path, const char* KeyName);

extern _declspec(dllexport) char* Del(const char* KeyName);