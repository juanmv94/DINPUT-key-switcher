# DINPUT key switcher (2024 Hook Version)

This version has some important diferences from the classic one:

* This version is made in pure C code, consisting on a single small inmutable .DLL file as result, no executables here
* We are not injecting assembly anymore into an adapted copy of Windows 7 **DINPUT.dll**. This small .DLL Hooks the Windows folder DINPUT.dll instead
* Key Config is made on a single **DINPUT.txt** file that should be created on the game folder. This .DLL loads the text file at game startup. An example **DINPUT.txt** file is provided
* There's no mapping limit

## How does it works?

Copying this .DLL file into the EXE directory makes the executable use this DLL instead of the default C:\Windows\... DirectInput DLL.

## DINPUT.txt syntax
* Only lines starting with *%s -> %s* will be parsed, and all text after that will be ignored
* Accepted key names are the following:
  * 0
  * 1
  * 2
  * 3
  * 4
  * 5
  * 6
  * 7
  * 8
  * 9
  * A
  * ABNT_C1
  * ABNT_C2
  * ADD
  * ALT
  * ALT_GR
  * APOSTROPHE
  * APPS
  * AT
  * AX
  * B
  * BACK
  * BACKSLASH
  * C
  * CALCULATOR
  * CAPITAL
  * COLON
  * COMMA
  * CONVERT
  * D
  * DECIMAL
  * DELETE
  * DIVIDE
  * DOWN
  * E
  * END
  * EQUALS
  * ESCAPE
  * F
  * F1
  * F10
  * F11
  * F12
  * F13
  * F14
  * F15
  * F2
  * F3
  * F4
  * F5
  * F6
  * F7
  * F8
  * F9
  * G
  * GRAVE
  * H
  * HOME
  * I
  * INSERT
  * J
  * K
  * KANA
  * KANJI
  * L
  * LBRACKET
  * LCONTROL
  * LEFT
  * LSHIFT
  * LWIN
  * M
  * MAIL
  * MEDIASELECT
  * MEDIASTOP
  * MINUS
  * MULTIPLY
  * MUTE
  * MYCOMPUTER
  * N
  * NEXT
  * NEXTTRACK
  * NOCONVERT
  * NUMLOCK
  * NUMPAD0
  * NUMPAD1
  * NUMPAD2
  * NUMPAD3
  * NUMPAD4
  * NUMPAD5
  * NUMPAD6
  * NUMPAD7
  * NUMPAD8
  * NUMPAD9
  * NUMPADCOMMA
  * NUMPADENTER
  * NUMPADEQUALS
  * O
  * P
  * PAUSE
  * PERIOD
  * PLAYPAUSE
  * POWER
  * PREVTRACK
  * PRIOR
  * Q
  * R
  * RBRACKET
  * RCONTROL
  * RETURN
  * RIGHT
  * RSHIFT
  * RWIN
  * S
  * SCROLL
  * SEMICOLON
  * SLASH
  * SLEEP
  * SPACE
  * STOP
  * SUBTRACT
  * SYSRQ
  * T
  * TAB
  * U
  * UNDERLINE
  * UNLABELED
  * UP
  * V
  * VOLUMEDOWN
  * VOLUMEUP
  * W
  * WAKE
  * WEBBACK
  * WEBFAVORITES
  * WEBFORWARD
  * WEBHOME
  * WEBREFRESH
  * WEBSEARCH
  * WEBSTOP
  * X
  * Y
  * YEN
  * Z
* You can assign a mapping for multiple diferent keys to the same key, but you can't make a key to act as multiple keys simultaneously pressed
* Mapping a key won't disable the original key from it's original function. There's an special "NULL" key name for disabling keys
