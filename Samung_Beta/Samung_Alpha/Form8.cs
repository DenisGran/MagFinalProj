using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samung_Alpha
{
    public partial class Form8 : Form
    {
        private static bool isClicked = false;

        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == (char)Keys.Enter)
            {
                //send it
                chatBox.AppendText(Form1.getUid() + ": " + writeBox.Text);
                writeBox.Clear();
            }
        }

        private void ManageRequests(string msg)
        {

        }
    }
}
