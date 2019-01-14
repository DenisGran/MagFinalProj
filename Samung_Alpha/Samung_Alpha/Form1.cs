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
using System.Runtime.InteropServices;
using System.Threading;

namespace Samung_Alpha
{
    public partial class Form1 : Form
    {
        // These are for moving the application from the bar
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //Networking stuff
        public static TcpClient client = new TcpClient();
        public static IPEndPoint serverEndPoint = new
            IPEndPoint(IPAddress.Parse("127.0.0.1"), 1450);
        private static NetworkStream clientStream;

        //User information
        private static string password = null;
        private static string id = null;
        private static string user2 = null;
        public static bool loggedIn = false;
        public static bool isConnectedToUser = false;
        public static bool isConnectedToServer = false;
        public static bool allowConnections = true;

        //Protocol codes
        private const string successCode = "01";
        private const string failureCode = "02";
        private const string incommingRequest = "req";

        //Recieved messages from server
        private static Queue<string> recievedFromServer = new Queue<string>();


        private static void createID()
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
            connectBtn.Enabled = false;
            connectBtn.Visible = false;
            changePasswordLabel.Visible = false;
            allowConnectionBtn.Visible = false;
        }

        private static void messagesToQueue()
        {
            Form incomingConnectionForm = null;
            string responseFromServer = "";

            while(isConnectedToServer)
            {
                responseFromServer = readSocket(); //Reading message

                if (allowConnections && responseFromServer.Contains(incommingRequest))
                { //We have to make sure this is not incoming request
                    incomingConnectionForm = new Form5(responseFromServer);
                    incomingConnectionForm.Show(); //Connecting to the server
                }
                else
                {
                    recievedFromServer.Enqueue(responseFromServer); //Into the queue
                }
            }
        }

        private static void startCon()
        { //This function connects to the server (creates socket)
            try
            {
                client.Connect(serverEndPoint);
                clientStream = client.GetStream();
                clientStream.ReadTimeout = 60000; //Creating timeout of 1 minute
                isConnectedToServer = true;
                messagesToQueue(); //Turning on the reading function
            }
            catch
            {
                MessageBox.Show("Couldn't connect to the server. Please try again later!");
                Environment.Exit(1); //Exit code 1 because it didn't succeed
            }
        }

        private static string getLastFromQueue()
        { //Using this function so we will wait for the queue to contain information
            while(recievedFromServer.Count() == 0)
            {
            }
            return recievedFromServer.Dequeue();
        }

        private static void sendToServer(string messageToServer)
        { //This function sends a message to the server
            byte[] buffer = new ASCIIEncoding().GetBytes(messageToServer);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush(); //Send message
        }

        private static string readSocket()
        {
            // Buffer to store the response bytes.
            Byte[] data = new Byte[256];

            // String to store the response ASCII representation.
            string responseData = "";

            // Read the first batch of the TcpServer response bytes.
            try
            {
                Int32 bytes = clientStream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            }
            catch
            {
                //In case we couldn't read from stream dont raise an exception thank you
            }

            return responseData;
        }

        private static bool checkIfSuccess()
        { //Function checks if last command was successfull or not and returns value
            string x = getLastFromQueue(); //Reading the latest message from server

            if (successCode.Equals(x)) // Checking if we have a success
            {
                return true;
            }
            MessageBox.Show(x);
            return false;
        }

        public static bool SignIn(string thePassword)
        {
            bool res = true;

            sendToServer("sgin," + id + "," + thePassword);

            if (checkIfSuccess()) // Checking if we succeeded
            {
                password = thePassword;
                res = true;
                loggedIn = true;
            }

            return res;
        }

        public static bool ConToUser(string targetUser)
        {
            bool res = false;

            sendToServer("con," + targetUser);

            if(checkIfSuccess()) // Checking if we have a success
            {
                res = true;
                isConnectedToUser = true;
                 
            }
            return res;
        }

        public static bool ChangePass(string currPassword, string newPassword)
        {
            bool res = false;

            if (currPassword.Equals(password)) //Checking if the current password user provided is correct
            {
                sendToServer("nps," + id + "," + newPassword);

                if (checkIfSuccess()) // Checking if we have a success
                {
                    res = true;
                    password = newPassword;
                }
            }

            return res;
        }


        /*
            byte[] buffer = new ASCIIEncoding().GetBytes("Hello Server!");
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
            buffer = new byte[4096];
            int bytesRead = clientStream.Read(buffer, 0, 4096);
         */

        public static string getId()
        {
            return id;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread connectionThread = new Thread(Form1.startCon);
            Thread idCreationThread = new Thread(Form1.createID);

            connectionThread.Start(); //Connecting to the server
            idCreationThread.Start(); //Creating an id
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();

            if (isConnectedToUser)
            {
                sessionStatusBtn.Text = "Connected to: " + user2.ToUpper();
                connectBtn.Enabled = false;
                connectBtn.Visible = false;
                //TODO: Add disconnect button that appears after the user is connected
            }
            else
            {
                MessageBox.Show("Could not connect to user");
            }
        }

        private void signinBtn_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();

            f.ShowDialog();

            if (loggedIn)
            {
                loginStatusBtn.Text = "Logged in as: " + id;
                sginBtn.Enabled = false;
                sginBtn.Visible = false;
                connectBtn.Enabled = true;
                connectBtn.Visible = true;
                changePasswordLabel.Enabled = true;
                changePasswordLabel.Visible = true;
                allowConnectionBtn.Visible = true;
            }
        }

        private void newPasswordLabel_Click(object sender, EventArgs e)
        {
            if (loggedIn && !isConnectedToUser) //We won't allow a user to change the password if he is in a session
            {
                Form4 f = new Form4();
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("To change the password, please disconnect from the session.");
            }

        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void mnmzBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void barPctr_MouseDown(object sender, MouseEventArgs e)
        { //This is for moving the bar
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            loadingGifBox.Dock = DockStyle.Fill;

            //Adding loading screen
            loadingLabel.Font = new Font("Arial", ClientRectangle.Width / 80);
            loadingLabel.TextAlign = ContentAlignment.MiddleCenter;
            loadingLabel.Dock = DockStyle.Bottom;

            topBar.BringToFront();
            mnmzBtn.BringToFront();
            exitBtn.BringToFront();
            loadingLabel.BringToFront();

            new Thread(() =>
            {
                while (!isConnectedToServer || id == null)
                {
                    Thread.Sleep(10); // Waiting for the id and the connection
                }
                BeginInvoke((MethodInvoker)delegate () { //Removing the loading screen
                    loadingLabel.Visible = false;
                    loadingLabel.Enabled = false;
                    loadingGifBox.Visible = false;
                    loadingGifBox.Enabled = false;
                });
            }).Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Close();
            if (clientStream != null)
            {
                clientStream.Close();
            }
        }

        private void allowConnectionBtn_Click(object sender, EventArgs e)
        {
            if(allowConnections)
            {
                allowConnectionBtn.Text = "Denying connections";
                allowConnections = false;
            }
            else
            {
                allowConnectionBtn.Text = "Allowing connections";
                allowConnections = true;
            }
        }
    }
}
