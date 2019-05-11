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

namespace Samung_Alpha
{
    public partial class Form8 : Form
    {
        private static bool isClicked = false;
        private static Socket _clientSocket =
    new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        public Form8()
        {
            InitializeComponent();
            LoopConnect();
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
                byte[] buffer = Encoding.ASCII.GetBytes(msg);
                byte[] receiveBuf = new byte[1024];
                _clientSocket.Send(buffer);
                int rec = _clientSocket.Receive(receiveBuf);
                byte[] data = new byte[rec];
                Array.Copy(receiveBuf, data, rec);
                chatBox.AppendText("User: "+Encoding.ASCII.GetString(data) + "\n");
        }




        private void LoopConnect()
        {
            int attempts = 0;
            chatBox.AppendText("Trying to Connect...\n");
            while (!_clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    _clientSocket.Connect(IPAddress.Loopback, 2350);
                }
                catch (SocketException)
                {

                }
            }
            chatBox.AppendText("Connected. \n");
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            SendL(writeBox.Text);
            chatBox.AppendText("You: " + writeBox.Text + "\n");
            writeBox.Clear();
        }
    }
}
