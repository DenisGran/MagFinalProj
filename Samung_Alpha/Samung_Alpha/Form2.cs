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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("No user entered");
            }
            else
            {
                if (textBox1.Text.ToString().Length == 12)
                {
                    Form1.user2 = textBox1.Text.ToString();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ERROR #001: user ID must be 12 characters long");
                }
            }
        }
    }
}
