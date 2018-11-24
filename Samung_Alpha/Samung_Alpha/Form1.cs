using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samung_Alpha
{
    public partial class Form1 : Form
    {
        public static TcpClient client = new TcpClient();
        public static IPEndPoint serverEndPoint = new
            IPEndPoint(IPAddress.Parse("127.0.0.1"), 1450);
        public static NetworkStream clientStream;
        public static string password;
        public static string id;
        public static string user2;

        public static void playsound(int code)
        {
                SoundPlayer simpleSound = new SoundPlayer(@"C:\\Users\\magshimim\\Downloads\\0.olololo ah sheli.wav");
                simpleSound.Play();
        }

        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            playsound(1);
        }

        public static void startCon()
        {
            client.Connect(serverEndPoint);
            clientStream = client.GetStream();

        }

        public static void ConToUser()
        {
            byte[] buffer = new ASCIIEncoding().GetBytes("con,"+user2);
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();

        }
        /*
            byte[] buffer = new ASCIIEncoding().GetBytes("Hello Server!");
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
            buffer = new byte[4096];
            int bytesRead = clientStream.Read(buffer, 0, 4096);
         */


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
            if (user2 != null)
            {
                label3.Text = "Connected to:" + user2.ToUpper();
                button1.Enabled = false;
                ConToUser();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();
            label2.Text = "Logged in as:" + id;
            if(password != null)
            {
                button2.Enabled = false;
                button1.Enabled = true;
                startCon();
            }
        }

        private static void EnableForm()
        {
        }
    }
}
