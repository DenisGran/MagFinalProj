using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Viewer
{
    public partial class ChatForm : Form
    {

        public ChatForm()
        {
            InitializeComponent();
        }

        private void Form8_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue == (char)Keys.Enter)
            {
                SendL(writeBox.Text);
                chatBox.AppendText("You: " + writeBox.Text + "\n");
                writeBox.Clear();
            }
        }

        private void SendL(string msg)
        {

        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            SendL(writeBox.Text);
            chatBox.AppendText("You: " + writeBox.Text + "\n");
            writeBox.Clear();
        }
    }
}
