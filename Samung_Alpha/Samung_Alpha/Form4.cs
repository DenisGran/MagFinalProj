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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == Form1.password)
            {
                Form1.password = textBox2.Text;
                MessageBox.Show("Password Change Succesful");
                Form1.ChangePass();
            }
            else
            {
                MessageBox.Show("Password Change Failed \nWrong Password");
            }
        }
    }
}
