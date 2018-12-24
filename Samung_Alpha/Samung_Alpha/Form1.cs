using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;

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


        public static void GetID()
        {
            string x = "";
            ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Processor");
            ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_VideoController");
            foreach (ManagementObject obj in myProcessorObject.Get())
            {
                if (obj["Name"].ToString().Contains("Intel"))
                    x = "I";
                else
                    x = "A";
            }

            foreach(ManagementObject obj in objvide.Get())
            {
                if (obj["Name"].ToString().Contains("Intel"))
                    x = x + "I";
                else if (obj["Name"].ToString().Contains("Nvidia"))
                    x = x + "N";
                else if (obj["Name"].ToString().Contains("AMD"))
                    x = x + "A";

            }

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == "C:\\")
                {
                    x = x + (drive.TotalFreeSpace / 100000).ToString();
                }
            }

            Random rnd = new Random();
            int rand = rnd.Next(1000, 10000); // creates a number between 1 and 12
            x = x + rand.ToString();

            id = x;


        }

        public Form1()
        {
            InitializeComponent();
            ConnectButton.Enabled = false;
            GetID();
        }

        public static void startCon()
        {
            client.Connect(serverEndPoint);
            clientStream = client.GetStream();

        }

        public static void SignIn()
        {
            byte[] buffer = new ASCIIEncoding().GetBytes("sgin," + id + "," + password);
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }

        public static void ConToUser()
        {
            byte[] buffer = new ASCIIEncoding().GetBytes("con,"+user2);
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();

        }

        public static void ChangePass()
        {
            byte[] buffer = new ASCIIEncoding().GetBytes("nps," + id + "," + password);
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
                ConnectButton.Enabled = false;
                ConToUser();
            }
        }


        private static void EnableForm()
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (id != null)
            {
                Form4 f = new Form4();
                f.Show();
            }
            else
            {
                MessageBox.Show("to change the password, please login");
            }

        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();
            label2.Text = "Logged in as:" + id;
            if (password != null)
            {
                SignInButton.Enabled = false;
                ConnectButton.Enabled = true;
                startCon();
                SignIn();
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
            if (user2 != null)
            {
                label3.Text = "Connected to:" + user2.ToUpper();
                ConnectButton.Enabled = false;
                ConToUser();
            }
        }
    }
}
