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
    public partial class RightOrLeft : Form
    {
        public RightOrLeft(String nombretecla)
        {
            InitializeComponent();
            this.button1.Text = "Left " + nombretecla;
            this.button2.Text = "Right " + nombretecla;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
