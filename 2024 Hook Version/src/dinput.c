#define WIN32_LEAN_AND_MEAN
#define _CRT_SECURE_NO_WARNINGS
#include <windows.h>
#include <stdio.h>
#include <dinput.h>

const char* const keynames[256] = {"NULL","ESCAPE","1","2","3","4","5","6","7","8","9","0","MINUS","EQUALS","BACK","TAB","Q","W","E","R","T","Y","U","I","O","P","LBRACKET","RBRACKET","RETURN","LCONTROL","A","S","D","F","G","H","J","K","L","SEMICOLON","APOSTROPHE","GRAVE","LSHIFT","BACKSLASH","Z","X","C","V","B","N","M","COMMA","PERIOD","SLASH","RSHIFT","MULTIPLY","ALT","SPACE","CAPITAL","F1","F2","F3","F4","F5","F6","F7","F8","F9","F10","NUMLOCK","SCROLL","NUMPAD7","NUMPAD8","NUMPAD9","SUBTRACT","NUMPAD4","NUMPAD5","NUMPAD6","ADD","NUMPAD1","NUMPAD2","NUMPAD3","NUMPAD0","DECIMAL",NULL,NULL,NULL,"F11","F12",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,"F13","F14","F15",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,"KANA",NULL,NULL,"ABNT_C1",NULL,NULL,NULL,NULL,NULL,"CONVERT",NULL,"NOCONVERT",NULL,"YEN","ABNT_C2",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,"NUMPADEQUALS",NULL,NULL,"PREVTRACK","AT","COLON","UNDERLINE","KANJI","STOP","AX","UNLABELED",NULL,"NEXTTRACK",NULL,NULL,"NUMPADENTER","RCONTROL",NULL,NULL,"MUTE","CALCULATOR","PLAYPAUSE",NULL,"MEDIASTOP",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,"VOLUMEDOWN",NULL,"VOLUMEUP",NULL,"WEBHOME","NUMPADCOMMA",NULL,"DIVIDE",NULL,"SYSRQ","ALT_GR",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,"PAUSE",NULL,"HOME","UP","PRIOR",NULL,"LEFT",NULL,"RIGHT",NULL,"END","DOWN","NEXT","INSERT","DELETE",NULL,NULL,NULL,NULL,NULL,NULL,NULL,"LWIN","RWIN","APPS","POWER","SLEEP",NULL,NULL,NULL,"WAKE",NULL,"WEBSEARCH","WEBFAVORITES","WEBREFRESH","WEBSTOP","WEBFORWARD","WEBBACK","MYCOMPUTER","MAIL","MEDIASELECT",NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL};
const GUID GUID_SysKeyboard = {0x6f1d2b61, 0xd5a0, 0x11cf, 0xbf, 0xc7, 0x44, 0x45, 0x53, 0x54, 0x00, 0x00};
unsigned char mapping[256] = {0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1a, 0x1b, 0x1c, 0x1d, 0x1e, 0x1f, 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2a, 0x2b, 0x2c, 0x2d, 0x2e, 0x2f, 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3a, 0x3b, 0x3c, 0x3d, 0x3e, 0x3f, 0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4a, 0x4b, 0x4c, 0x4d, 0x4e, 0x4f, 0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5a, 0x5b, 0x5c, 0x5d, 0x5e, 0x5f, 0x60, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6a, 0x6b, 0x6c, 0x6d, 0x6e, 0x6f, 0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78, 0x79, 0x7a, 0x7b, 0x7c, 0x7d, 0x7e, 0x7f, 0x80, 0x81, 0x82, 0x83, 0x84, 0x85, 0x86, 0x87, 0x88, 0x89, 0x8a, 0x8b, 0x8c, 0x8d, 0x8e, 0x8f, 0x90, 0x91, 0x92, 0x93, 0x94, 0x95, 0x96, 0x97, 0x98, 0x99, 0x9a, 0x9b, 0x9c, 0x9d, 0x9e, 0x9f, 0xa0, 0xa1, 0xa2, 0xa3, 0xa4, 0xa5, 0xa6, 0xa7, 0xa8, 0xa9, 0xaa, 0xab, 0xac, 0xad, 0xae, 0xaf, 0xb0, 0xb1, 0xb2, 0xb3, 0xb4, 0xb5, 0xb6, 0xb7, 0xb8, 0xb9, 0xba, 0xbb, 0xbc, 0xbd, 0xbe, 0xbf, 0xc0, 0xc1, 0xc2, 0xc3, 0xc4, 0xc5, 0xc6, 0xc7, 0xc8, 0xc9, 0xca, 0xcb, 0xcc, 0xcd, 0xce, 0xcf, 0xd0, 0xd1, 0xd2, 0xd3, 0xd4, 0xd5, 0xd6, 0xd7, 0xd8, 0xd9, 0xda, 0xdb, 0xdc, 0xdd, 0xde, 0xdf, 0xe0, 0xe1, 0xe2, 0xe3, 0xe4, 0xe5, 0xe6, 0xe7, 0xe8, 0xe9, 0xea, 0xeb, 0xec, 0xed, 0xee, 0xef, 0xf0, 0xf1, 0xf2, 0xf3, 0xf4, 0xf5, 0xf6, 0xf7, 0xf8, 0xf9, 0xfa, 0xfb, 0xfc, 0xfd, 0xfe, 0xff};
unsigned char buffer[256];

static HMODULE loadLibrary(const char* dll) {
    char path[MAX_PATH];
    GetSystemDirectoryA(path, MAX_PATH);
    strcat_s(path, MAX_PATH, "\\");
    strcat_s(path, MAX_PATH, dll);
    return LoadLibraryA(path);
}

unsigned char findkey(const char* key) {
    for (int i = 0; i < 256; i++) {
        if (keynames[i] && !strcmp(keynames[i], key)) return i;
    }
    sprintf(buffer, "Unrecognized key %s", key);
    MessageBoxA(NULL, buffer, "DINPUT Key switcher", MB_OK);
    return 0;
}

static HRESULT(WINAPI* _DirectInputCreateA)(HINSTANCE hinst, DWORD dwVersion, LPDIRECTINPUTA* lplpDirectInput, LPUNKNOWN punkOuter);
static HRESULT(WINAPI* _DirectInputCreateEx)(HINSTANCE hinst, DWORD dwVersion, REFIID riidltf, LPDIRECTINPUT7* ppvOut, LPUNKNOWN punkOuter);
static HRESULT(WINAPI* _DirectInputCreateW)(HINSTANCE hinst, DWORD dwVersion, LPDIRECTINPUTW* lplpDirectInput, LPUNKNOWN punkOuter);

BOOL APIENTRY DllMain(HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved) {
    switch (ul_reason_for_call) {
        case DLL_PROCESS_ATTACH:
            {
                HMODULE dinput = loadLibrary("DINPUT.DLL");
                _DirectInputCreateA = GetProcAddress(dinput, "DirectInputCreateA");
                _DirectInputCreateEx = GetProcAddress(dinput, "DirectInputCreateEx");
                _DirectInputCreateW = GetProcAddress(dinput, "DirectInputCreateW");
                FILE* file = fopen("DINPUT.TXT", "r");
                if (!file) {
                    MessageBoxA(NULL, "DINPUT.TXT not found", "DINPUT Key switcher", MB_OK);
                    break;
                }
                while (fgets(buffer, sizeof(buffer), file) != NULL) {
                    char keyname[2][256];
                    if (sscanf(buffer, "%s -> %s", keyname[0], keyname[1]) == 2) {
                        unsigned char key1 = findkey(keyname[0]), key2 = findkey(keyname[1]);
                        mapping[key2] = key1;
                    }
                }
            }
            break;
        case DLL_THREAD_ATTACH:
        case DLL_THREAD_DETACH:
        case DLL_PROCESS_DETACH:
            break;
    }
    return TRUE;
}

static void remap(char* ptr) {
    memset(ptr, 0x00, 256);
    for (int i = 0; i < 256; i++) ptr[mapping[i]] |= buffer[i];
}

/////////////////  IDirectInputA  /////////////////

static HRESULT(WINAPI* _GetDeviceStateA)(IDirectInputDeviceA* this, DWORD size, LPVOID ptr);
static HRESULT WINAPI GetDeviceStateA(IDirectInputDeviceA* this, DWORD size, LPVOID ptr) {
    HRESULT result = (*_GetDeviceStateA)(this, 256, buffer);
    remap(ptr);
    return result;
}

static HRESULT(WINAPI *_CreateDeviceA)(IDirectInputA *this, const GUID* const guid, LPDIRECTINPUTDEVICEA* dev, LPUNKNOWN lp);
static HRESULT WINAPI CreateDeviceA(IDirectInputA *this, const GUID* const guid, LPDIRECTINPUTDEVICEA* dev, LPUNKNOWN lp) {
    HRESULT result = (*_CreateDeviceA)(this, guid, dev, lp);
    if (!memcmp(guid, &GUID_SysKeyboard, sizeof(GUID))                  //Device type == keyboard
            && (*dev)->lpVtbl->GetDeviceState != GetDeviceStateA) {     //Already hooked
        _GetDeviceStateA = (*dev)->lpVtbl->GetDeviceState;
        (*dev)->lpVtbl->GetDeviceState = GetDeviceStateA;
    }
    return result;
}

HRESULT WINAPI DirectInputCreateA(HINSTANCE hinst, DWORD dwVersion, LPDIRECTINPUTA * lplpDirectInput, LPUNKNOWN punkOuter) {
    HRESULT result = (*_DirectInputCreateA)(hinst, dwVersion, lplpDirectInput, punkOuter);
    if ((*lplpDirectInput)->lpVtbl->CreateDevice != CreateDeviceA) {    //Already hooked
        _CreateDeviceA = (*lplpDirectInput)->lpVtbl->CreateDevice;
        (*lplpDirectInput)->lpVtbl->CreateDevice = CreateDeviceA;
    }
    return result;
}

/////////////////  IDirectInputEx  /////////////////

HRESULT WINAPI DirectInputCreateEx(HINSTANCE hinst, DWORD dwVersion, REFIID riidltf, LPDIRECTINPUT7* ppvOut, LPUNKNOWN punkOuter) {
    MessageBoxA(NULL, "DirectInputCreateEx not implemented", "DINPUT Key switcher", MB_OK);
    return (*_DirectInputCreateEx)(hinst, dwVersion, riidltf, ppvOut, punkOuter);
}

/////////////////  IDirectInputW  /////////////////

HRESULT WINAPI DirectInputCreateW(HINSTANCE hinst, DWORD dwVersion, LPDIRECTINPUTW * lplpDirectInput, LPUNKNOWN punkOuter) {
    MessageBoxA(NULL, "DirectInputCreateW not implemented", "DINPUT Key switcher", MB_OK);
    return (*_DirectInputCreateW)(hinst, dwVersion, lplpDirectInput, punkOuter);
}