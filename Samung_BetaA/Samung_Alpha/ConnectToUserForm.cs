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

namespace Desktop_Viewer
{
    public partial class ConnectToUserForm : Form
    {
        public const string idExample = "XX123456XXXX";

        public ConnectToUserForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void handleConnection()
        { //This function is useful so we can run it in a different thread

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("No user entered");
            }
            else
            {
                if(textBox1.Text.CompareTo(MainMenuForm.getUid()) == 0)
                {
                    MessageBox.Show("Can't connect to yourself...");
                }
                else if (textBox1.Text.Length == 12 && !textBox1.Text.Equals(idExample))
                {

                    if (MainMenuForm.ConToUser(textBox1.Text.ToString()))
                    { //If user accepted our request we just close this form
                        MainMenuForm.user2 = textBox1.Text.ToString(); //Setting the user that we want to connect

                        this.Invoke((MethodInvoker)delegate
                        {
                            this.Close();
                        });
                    }
                    else
                    {
                        MessageBox.Show("Client refused connection");
                    }
                }
                else
                {
                    MessageBox.Show("ERROR #001: user UID must be 12 characters long");
                }
            }

            BeginInvoke((MethodInvoker)delegate ()
            { //Resetting everything
                waitingForAnswerGif.Visible = false;
                waitingLabel.Visible = false;
                button1.Enabled = true;
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread connectionRequest = new Thread(handleConnection); //Doing this in a new thread so the program wont crash.
            connectionRequest.Start(); //Why dont we run other functions threaded? -because other functions interact with server and the server-
                                       //answers in miliseconds, while this request is for the user who can answer in minutes, and it will make the program crash.
            button1.Enabled = false;
            waitingForAnswerGif.Visible = true;
            waitingLabel.Visible = true;
        }

        private void textBox1_Click(object sender, EventArgs e)
        { //Removing the placeholder
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
            button1.Enabled = true;
        }
    }
}
