# DINPUT key switcher
Who has never played _Rayman2_ on PC and has didn't wanted to change the keyboard controls? Some videogames (especially old ones) did not allow remap the keymap in any way, and it's not always easy to hack them to change controls. The aforementioned video game never saw a way to change the keyboard controls... before...

With this application you can generate a "hacked" Dinput.dll  that you only have to copy to the directory where you have your game EXE, and it will change your keyboard controls.

![screenshot](https://4.bp.blogspot.com/-5tnrcWsauvM/WQdcV7eAm8I/AAAAAAAAAkE/xhDeDt9AjpkAJ-6M-FmGdL37Z8oI-ctYACLcB/s1600/1.png)

## How does it works?
This program injects customized assembly code into a special DINPUT.DLL/DINPUT8.DLL file.

Copying this file into the EXE directory makes the executable use this DLL instead of the default C:\Windows\... DLL.

## Requirements
This tool works with the 64bit version of DINPUT.DLL and DINPUT8.DLL and doesn't work on 32bit machines.

## License
DINPUT.DLL and DINPUT8.DLL are property of Microsoft.

You can freely use the source and tool, but must contact me if you want to edit and/or distribute.

    //
    //  DINPUT_key_switcher by Juanmv94   //
    //  May,2017                          //

    //  If you want to use this source code please leave me a comment at
    //  https://tragicomedy-hellin.blogspot.com.es/2017/05/dinput-key-switcher-personaliza-el.html
    //

## Links

Full blog article:
<http://tragicomedy-hellin.blogspot.com/2017/05/dinput-key-switcher-personaliza-el.html>