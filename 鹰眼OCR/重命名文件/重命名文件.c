#include <stdio.h>
#include <io.h>
#include <stdlib.h>
#include <windows.h>

void set_title(char* const title);  // 设置窗口标题
char* get_errmsg(DWORD dwErrCode);  // 打印错误
void print_error();                 // 获取本地语言的错误消息

#define DRAKRED  FOREGROUND_RED | FOREGROUND_INTENSITY
#define RED  FOREGROUND_RED
#define WHITE   FOREGROUND_GREEN | FOREGROUND_RED | FOREGROUND_BLUE

int main(int argc, char** argv)
{
    if (argc < 3)
    {
        puts("参数错误！");
        puts("使用方法：重命名文件.exe <窗口标题> <源文件路径> <目标文件路径>");
        system("pause");
        return -1;
    }

    char* const title = argv[1];// 要设置的窗口标题
    const char* source = argv[2]; // 源文件路径
    const char* dest = argv[3];   // 目标文件路径
    char drive[MAX_PATH], dir[MAX_PATH], tmp[MAX_PATH];
    STARTUPINFO si;
    PROCESS_INFORMATION pi;
    ZeroMemory(&si, sizeof(si));
    ZeroMemory(&pi, sizeof(pi));
    _splitpath_s(dest, drive, sizeof(drive), dir, sizeof(dir), NULL, 0, NULL, 0);
    snprintf(tmp, sizeof(tmp), "%s%s", drive, dir);

    Sleep(1000);// 延时等待软件退出
    set_title(title);
    // 检测路径是否正确
    if (_access(source, 0))
    {
        puts("源文件路径不存在！");
        puts(source);
        puts("使用方法：替换文件.exe <窗口标题> <源文件路径> <目标文件路径>");
        system("pause");
        return -1;
    }
    // 判断目标路径文件是否存在
    if (!_access(dest, 0))
    {
        // 删除已存在的目标文件
        if (remove(dest))
        {
            print_error();
            system("pause");
            return -1;
        }
    }
    // 重命名文件
    if (rename(source, dest))
    {
        print_error();
        system("pause");
        return -1;
    }

    // 启动重命名后的程序
    CreateProcessA(dest, NULL, NULL, NULL, FALSE, 0, NULL, tmp, &si, &pi);
    return 0;
}

// 设置窗口标题
void set_title(char* const title)
{
    char cmd[MAX_PATH];
    snprintf(cmd, sizeof(cmd), "title %s", title);
    system(cmd);
}

// 打印错误
void print_error()
{
    char* msg = get_errmsg(GetLastError());
    // 设置字体颜色
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), RED);
    puts(msg);// 打印错误内容
    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), WHITE);
    LocalFree(msg);// 释放错误内容所占的内存
}

// 获取本地语言的错误消息
char* get_errmsg(DWORD dwErrCode)
{
    char* szBuf;
    FormatMessageA(FORMAT_MESSAGE_ALLOCATE_BUFFER
        | FORMAT_MESSAGE_FROM_SYSTEM
        | FORMAT_MESSAGE_IGNORE_INSERTS,
        NULL, dwErrCode, LANG_USER_DEFAULT, (LPSTR)&szBuf, 0, NULL);
    return szBuf;
}