using System;
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
            if (Form1.ChangePass(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("Password Change Succesful");
                this.Close();
            }
            else
            {
                MessageBox.Show("Password Change Failed \nWrong Password");
            }
        }
    }
}
