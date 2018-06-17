using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//
//  DINPUT_key_switcher by Juanmv94   //
//  May,2017                          //

//  If you want to use this source code please leave me a comment at
//  https://tragicomedy-hellin.blogspot.com.es/2017/05/dinput-key-switcher-personaliza-el.html
//

namespace DINPUT_key_switcher
{
    public partial class ObtieneTeclas : Form
    {
        bool primero;       //es la primera tecla leida?
        public int tecla1;
        public int tecla2;
        public ObtieneTeclas()
        {
            primero = true;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }


        private void teclaleida(int id)     //a leer una tecla, se le debe pasar su codigo DirectInput a esta funcion
        {
            if (primero)
            {
                primero = false;
                this.label1.Text = "Press the new key you want to assign";
                tecla1 = id;
            }
            else
            {
                tecla2 = id;
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)    //Algunas teclas interfieren con la interfaz. Las tratamos aqui
        {
            switch (keyData)
            {
                case Keys.Up:
                    teclaleida(0xC8);
                    return true;
                case Keys.Left:
                    teclaleida(0xCB);
                    return true;
                case Keys.Right:
                    teclaleida(0xCD);
                    return true;
                case Keys.Down:
                    teclaleida(0xD0);
                    return true;
                case Keys.Space:
                    teclaleida(0x39);
                    return true;
                case Keys.Tab:
                    teclaleida(0x0F);
                    return true;
                default:
                    return false;
            }
            

        }

        private int convierte(int i)    //traduce codigos de tecla de c# en codigos de tecla DINPUT
        {
            if (i <= 57 && i >= 49)     //1-9
                return i - 47;
            if (i <= 121 && i >= 112)   //f1-f10
                return i - 53;

            switch (i)
            {
                case 48:    //0
                    return 0x0B;
                case 122:   //f11
                    return 0x57;
                case 123:   //f12
                    return 0x58;
                case 27:
                    return 0x01;	//escape
                case 8:
                    return 0x0E;    /* backspace */
                case 13:
                    return 0x1C;    /* Enter on main keyboard */
                case 20:
                    return 0x3A;    /* capslock */
                case 19:
                    return 0xC5;	//pause
                case 36:			//home
                    return 0xC7;
                case 35:			//END
                    return 0xCF;
                case 33:			//PAGE UP
                    return 0xC9;
                case 34:			//PAGE DOWN
                    return 0xD1;
                case 45:			//insert
                    return 0xD2;
                case 46:			//delete
                    return 0xD3;
                case 192:
                    return 0x29;	//Grave
                case 188:			//comma
                    return 0x33;
                case 190:			//period
                    return 0x34;
                case 226:
                    return 0x2B;    // <
                //LETRAS
                case 65:
                    return 0x1E;
                case 66:
                    return 0x30;
                case 67:
                    return 0x2E;
                case 68:
                    return 0x20;
                case 69:
                    return 0x12;
                case 70:
                    return 0x21;
                case 71:
                    return 0x22;
                case 72:
                    return 0x23;
                case 73:
                    return 0x17;
                case 74:
                    return 0x24;
                case 75:
                    return 0x25;
                case 76:
                    return 0x26;
                case 77:
                    return 0x32;
                case 78:
                    return 0x31;
                case 79:
                    return 0x18;
                case 80:
                    return 0x19;
                case 81:
                    return 0x10;
                case 82:
                    return 0x13;
                case 83:
                    return 0x1F;
                case 84:
                    return 0x14;
                case 85:
                    return 0x16;
                case 86:
                    return 0x2F;
                case 87:
                    return 0x11;
                case 88:
                    return 0x2D;
                case 89:
                    return 0x15;
                case 90:
                    return 0x2C;
                //NUM PAD
                case 96:
                    return 0x52;
                case 97:
                    return 0x4F;
                case 98:
                    return 0x50;
                case 99:
                    return 0x51;
                case 100:
                    return 0x4B;
                case 101:
                    return 0x4C;
                case 102:
                    return 0x4D;
                case 103:
                    return 0x47;
                case 104:
                    return 0x48;
                case 105:
                    return 0x49;
                case 107:
                    return 0x4E;
                case 109:
                    return 0x4A;
                default:
                    return 0;
            }
        }
        private void ObtieneTeclas_KeyDown(object sender, KeyEventArgs e)   //Captura el evento KeyDown
        {
            switch (e.KeyCode)      //Las diferentes teclas de CTRL, SHIFT y ALT se distinguen en DINPUT pero no aqui!!
            {
                case Keys.ShiftKey:
                    RightOrLeft rls = new RightOrLeft(e.KeyCode.ToString());
                    rls.ShowDialog();
                    if (rls.DialogResult == DialogResult.Yes) teclaleida(0x2A);
                    else teclaleida(0x36);
                    break;
                case Keys.ControlKey:
                    RightOrLeft rlc = new RightOrLeft(e.KeyCode.ToString());
                    rlc.ShowDialog();
                    if (rlc.DialogResult == DialogResult.Yes) teclaleida(0x1D);
                    else teclaleida(0x9D);
                    break;
                case Keys.RButton | Keys.ShiftKey:  //alt
                    RightOrLeft rla = new RightOrLeft("ALT");
                    rla.ShowDialog();
                    if (rla.DialogResult == DialogResult.Yes) teclaleida(0x38);
                    else teclaleida(0xB8);
                    break;
                default:
                    teclaleida(convierte(e.KeyValue));
                    break;
            }
        }
    }
}
