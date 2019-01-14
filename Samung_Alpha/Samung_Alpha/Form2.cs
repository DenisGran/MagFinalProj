using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samung_Alpha
{
    public partial class Form2 : Form
    {
        public const string idExample = "XX123456XXXX";

        public Form2()
        {
            InitializeComponent();
        }

        public static void connectionListener()
        {
            Form5 connectionForm = null;
            string readFromSocket = "";
            const string conRequest = "req";

            while (Form1.loggedIn) //While the user is logged in
            {
                /*readFromSocket = Form1.readSocket();

                if (readFromSocket.Contains(conRequest))
                {
                    connectionForm = new Form5(readFromSocket);
                    connectionForm.ShowDialog();
                    //TODO: do stuff after user decides to connect
                }*/
            }
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
                if (textBox1.Text.Length == 12)
                {
                    if (Form1.ConToUser(textBox1.Text.ToString()))
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Client refused connection");
                    }
                }
                else
                {
                    MessageBox.Show("ERROR #001: user ID must be 12 characters long");
                }
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        { //Removing the placeholder
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
            button1.Enabled = true;
        }
    }
}
