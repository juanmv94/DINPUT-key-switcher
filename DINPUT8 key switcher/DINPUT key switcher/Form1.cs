using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

using System.IO;

//
//  DINPUT_key_switcher by Juanmv94   //
//  May,2017                          //

//  If you want to use this source code please leave me a comment at
//  https://tragicomedy-hellin.blogspot.com.es/2017/05/dinput-key-switcher-personaliza-el.html
//


namespace DINPUT_key_switcher
{
    public partial class Form1 : Form
    {
        //Estos son nuestros fragmentos de codigo assembly que inyectaremos en el DLL
        private byte[] code1= new byte[] {0x50,0x83,0xE8};
        private byte[] code2 = new byte[] {0x58,0x0F,0x85,0x0A,0x00,0x00,0x00,0xB8};
        private byte[] code3 = new byte[] {0x00,0x00,0x00,0xE9};
        private byte[] codef = new byte[] {0x50,0x0F,0xB6,0xC3,0x50,0xE9};

        private struct entrada
        {
            public int initial_key;
            public int final_key;
            public String initial_k_name;
            public String final_k_name;
        };

        const int codeAdress = 0x1f47c;   //Offset del DLL casi al final de este, y a partir del cual inyectamos nuestro assembly
        public ArrayList entradas;
        FileStream archivo;

        public Form1()
        {
            try {
                archivo = new FileStream("dinput8.dll", FileMode.Open, FileAccess.ReadWrite);
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("customized dinput8.dll not found. You have to extract the exe and the dll in the same folder.");
                System.Environment.Exit(1);
            }
            entradas = new ArrayList(24);

            //Leemos entradas ya definidas en el dll una por una
            byte[] leido = new byte[4];     //para leer numeros enteros
            entrada e;

            archivo.Seek(codeAdress + 12, SeekOrigin.Begin);
            archivo.Read(leido, 0, 4);
            e.final_key = BitConverter.ToInt32(leido, 0);
            while (e.final_key > 0)     //si en la tecla final leemos 0 es porque no hay mas entradas,
            {
                archivo.Seek(-13, SeekOrigin.Current);
                archivo.Read(leido, 0, 4);
                e.initial_key = BitConverter.ToInt32(leido, 0) & 0x000000FF;

                e.initial_k_name = nombre(e.initial_key);
                e.final_k_name = nombre(e.final_key);
                entradas.Add(e);
                
                archivo.Seek(26, SeekOrigin.Current);
                archivo.Read(leido, 0, 4);
                e.final_key = BitConverter.ToInt32(leido, 0);
            }

            InitializeComponent();
            updatelista();
        }


        private void updatelista()  //muestra en el listbox el contenido de nuestro array de entradas
        {
            listBox1.Items.Clear();
            for (int i = 0; i < entradas.Count; i++)
            {
                listBox1.Items.Add(((entrada)entradas[i]).initial_k_name + " acting as game's " + ((entrada)entradas[i]).final_k_name);
            }
        }
        public void addentrada(int initial_key, int final_key, String initial_k_name, String final_k_name)
        {
            entrada ent;
            ent.initial_key = initial_key;
            ent.final_key = final_key;
            ent.initial_k_name = initial_k_name;
            ent.final_k_name = final_k_name;
            entradas.Add(ent);
            updatelista();
        }

        private String nombre(int t)    //Obtiene el nombre de tecla de un codigo de tecla DirectInput.
        {

            switch (t)
            {
                case 0x01:
	                return "ESCAPE";
                case 0x02:
	                return "1";
                case 0x03:
	                return "2";
                case 0x04:
	                return "3";
                case 0x05:
	                return "4";
                case 0x06:
	                return "5";
                case 0x07:
	                return "6";
                case 0x08:
	                return "7";
                case 0x09:
	                return "8";
                case 0x0A:
	                return "9";
                case 0x0B:
	                return "0";
                case 0x0C:
	                return "MINUS";
                case 0x0D:
	                return "EQUALS";
                case 0x0E:
	                return "BACK";
                case 0x0F:
	                return "TAB";
                case 0x10:
	                return "Q";
                case 0x11:
	                return "W";
                case 0x12:
	                return "E";
                case 0x13:
	                return "R";
                case 0x14:
	                return "T";
                case 0x15:
	                return "Y";
                case 0x16:
	                return "U";
                case 0x17:
	                return "I";
                case 0x18:
	                return "O";
                case 0x19:
	                return "P";
                case 0x1A:
	                return "LBRACKET";
                case 0x1B:
	                return "RBRACKET";
                case 0x1C:
	                return "RETURN";
                case 0x1D:
	                return "LCONTROL";
                case 0x1E:
	                return "A";
                case 0x1F:
	                return "S";
                case 0x20:
	                return "D";
                case 0x21:
	                return "F";
                case 0x22:
	                return "G";
                case 0x23:
	                return "H";
                case 0x24:
	                return "J";
                case 0x25:
	                return "K";
                case 0x26:
	                return "L";
                case 0x27:
	                return "SEMICOLON";
                case 0x28:
	                return "APOSTROPHE";
                case 0x29:
	                return "GRAVE";
                case 0x2A:
	                return "LSHIFT";
                case 0x2B:
	                return "BACKSLASH";
                case 0x2C:
	                return "Z";
                case 0x2D:
	                return "X";
                case 0x2E:
	                return "C";
                case 0x2F:
	                return "V";
                case 0x30:
	                return "B";
                case 0x31:
	                return "N";
                case 0x32:
	                return "M";
                case 0x33:
	                return "COMMA";
                case 0x34:
	                return "PERIOD";
                case 0x35:
	                return "SLASH";
                case 0x36:
	                return "RSHIFT";
                case 0x37:
	                return "MULTIPLY";
                case 0x38:
	                return "ALT";
                case 0x39:
	                return "SPACE";
                case 0x3A:
	                return "CAPITAL";
                case 0x3B:
	                return "F1";
                case 0x3C:
	                return "F2";
                case 0x3D:
	                return "F3";
                case 0x3E:
	                return "F4";
                case 0x3F:
	                return "F5";
                case 0x40:
	                return "F6";
                case 0x41:
	                return "F7";
                case 0x42:
	                return "F8";
                case 0x43:
	                return "F9";
                case 0x44:
	                return "F10";
                case 0x45:
	                return "NUMLOCK";
                case 0x46:
	                return "SCROLL";
                case 0x47:
	                return "NUMPAD7";
                case 0x48:
	                return "NUMPAD8";
                case 0x49:
	                return "NUMPAD9";
                case 0x4A:
	                return "SUBTRACT";
                case 0x4B:
	                return "NUMPAD4";
                case 0x4C:
	                return "NUMPAD5";
                case 0x4D:
	                return "NUMPAD6";
                case 0x4E:
	                return "ADD";
                case 0x4F:
	                return "NUMPAD1";
                case 0x50:
	                return "NUMPAD2";
                case 0x51:
	                return "NUMPAD3";
                case 0x52:
	                return "NUMPAD0";
                case 0x53:
	                return "DECIMAL";
                case 0x57:
	                return "F11";
                case 0x58:
	                return "F12";
                case 0x64:
	                return "F13";
                case 0x65:
	                return "F14";
                case 0x66:
	                return "F15";
                case 0x70:
	                return "KANA";
                case 0x73:
	                return "ABNT_C1";
                case 0x79:
	                return "CONVERT";
                case 0x7B:
	                return "NOCONVERT";
                case 0x7D:
	                return "YEN";
                case 0x7E:
	                return "ABNT_C2";
                case 0x8D:
	                return "NUMPADEQUALS";
                case 0x90:
	                return "PREVTRACK";
                case 0x91:
	                return "AT";
                case 0x92:
	                return "COLON";
                case 0x93:
	                return "UNDERLINE";
                case 0x94:
	                return "KANJI";
                case 0x95:
	                return "STOP";
                case 0x96:
	                return "AX";
                case 0x97:
	                return "UNLABELED";
                case 0x99:
	                return "NEXTTRACK";
                case 0x9C:
	                return "NUMPADENTER";
                case 0x9D:
	                return "RCONTROL";
                case 0xA0:
	                return "MUTE";
                case 0xA1:
	                return "CALCULATOR";
                case 0xA2:
	                return "PLAYPAUSE";
                case 0xA4:
	                return "MEDIASTOP";
                case 0xAE:
	                return "VOLUMEDOWN";
                case 0xB0:
	                return "VOLUMEUP";
                case 0xB2:
	                return "WEBHOME";
                case 0xB3:
	                return "NUMPADCOMMA";
                case 0xB5:
	                return "DIVIDE";
                case 0xB7:
	                return "SYSRQ";
                case 0xB8:
	                return "ALT_GR";
                case 0xC5:
	                return "PAUSE";
                case 0xC7:
	                return "HOME";
                case 0xC8:
	                return "UP";
                case 0xC9:
	                return "PRIOR";
                case 0xCB:
	                return "LEFT";
                case 0xCD:
	                return "RIGHT";
                case 0xCF:
	                return "END";
                case 0xD0:
	                return "DOWN";
                case 0xD1:
	                return "NEXT";
                case 0xD2:
	                return "INSERT";
                case 0xD3:
	                return "DELETE";
                case 0xDB:
	                return "LWIN";
                case 0xDC:
	                return "RWIN";
                case 0xDD:
	                return "APPS";
                case 0xDE:
	                return "POWER";
                case 0xDF:
	                return "SLEEP";
                case 0xE3:
	                return "WAKE";
                case 0xE5:
	                return "WEBSEARCH";
                case 0xE6:
	                return "WEBFAVORITES";
                case 0xE7:
	                return "WEBREFRESH";
                case 0xE8:
	                return "WEBSTOP";
                case 0xE9:
	                return "WEBFORWARD";
                case 0xEA:
	                return "WEBBACK";
                case 0xEB:
	                return "MYCOMPUTER";
                case 0xEC:
	                return "MAIL";
                case 0xED:
	                return "MEDIASELECT";
                default:
                    return "NOT_IMPLEMENTED";
            }
        }

        private void AddKeys(object sender, EventArgs e)
        {
            if (entradas.Count>=18)     //Tenemos espacio limitado en el DLL
            {
                System.Windows.Forms.MessageBox.Show("Ups! There's no more empty space in the dll");
                return;
            }
            ObtieneTeclas ob = new ObtieneTeclas();
            ob.ShowDialog();
            if (ob.DialogResult==DialogResult.Yes)
            {
                addentrada(ob.tecla2, ob.tecla1, nombre(ob.tecla2), nombre(ob.tecla1));
            }
        }

        private void DeleteKeys(object sender, EventArgs e)     //Elimina entrada seleccionada de la lista
        {
            try
            {
                entradas.RemoveAt(listBox1.SelectedIndex);
                updatelista();
            }
            catch (Exception) {;}
        }

        private void exit(object sender, EventArgs e)   //Sale sin guardar los cambios
        {
            archivo.Close();
            System.Environment.Exit(0);
        }

        private void SaveAndExit(object sender, EventArgs e)    //Modifica el DLL
        {
            int i;
            archivo.Seek(codeAdress, SeekOrigin.Begin);
            for (i = 0; i < entradas.Count; i++)        //Debemos insertar nuestro codigo assembly personalizado para cada entrada
            {
                archivo.Write(code1, 0, 3);
                archivo.WriteByte((byte)((entrada)entradas[i]).initial_key);
                archivo.Write(code2, 0, 8);
                archivo.WriteByte((byte)((entrada)entradas[i]).final_key);
                archivo.Write(code3, 0, 4);
                archivo.Write(BitConverter.GetBytes((entradas.Count-i-1)*21), 0, 4);    //Instrucción "jmp" personalizada, siempre debe aputar al codigo final codef
            }
            archivo.Write(codef, 0, 6);     //codigo de finalización
            uint n = 0xFFFE24A8;
            n -= (uint)(21*i);
            archivo.Write(BitConverter.GetBytes(n), 0, 4);                  //Instrucción "jmp" personalizada, vuelve a donde estabamos al inicio
            while (archivo.Position<0x1f61A) archivo.WriteByte(0);   //Ponemos el resto de bytes a 0 hasta el final del archivo
            archivo.Close();
            System.Environment.Exit(0);
        }

        private void AboutButton(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Dinput key switcher (DInput8 version):\nSome games don't allows to change the keyboard map. This app generates a customized DINPUT8.DLL file that must be copied to the game's directory to change the keys you use in your game.\n\nHow it works?\nThis app automatically generates the assembly code needed to change the keydown and keyup events for the configured keys, inserting the code in a empty space inside the DLL.\n\nMade in 2017 by Juanmv94\nhttp://tragicomedy-hellin.blogspot.com");
                
        }
    }
}
