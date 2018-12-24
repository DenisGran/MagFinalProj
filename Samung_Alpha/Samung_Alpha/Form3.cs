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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            textBox1.Text = Form1.getId();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Can't login without password");
            }
            else
            {
                if (!Form1.SignIn(textBox2.Text.ToString())) //If it didn't login
                {
                    MessageBox.Show("Couldn't login. Please try again.");
                }
                else
                { //If we logged in just close the form and go back to the main screen
                    this.Close();
                }
            }
        }
    }
}
