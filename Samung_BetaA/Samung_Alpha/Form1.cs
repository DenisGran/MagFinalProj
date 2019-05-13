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
using System.Diagnostics;

namespace Samung_Alpha
{
    public partial class Form1 : Form
    {
        //Threads
        Thread connectionThread = new Thread(startCon);
        Thread uidCreationThread = new Thread(createUID);


        //These are for moving the application from the bar
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
        private static string uid = null;
        public static string user2 = null; //User that this client is connected to
        public static bool loggedIn = false;
        public static bool isConnectedToUser = false;
        public static bool isConnectedToServer = false;
        public static bool allowConnections = true;

        //Protocol codes
        private const string successCode = "01";
        private const string failureCode = "02";
        private const string incommingRequest = "req";
        private const string acceptConnection = "acc";
        private const string informationMessage = "inf";

        //Default values
        string defaultStatusText = "";

        //Recieved messages from server
        private static Queue<string> recievedFromServer = new Queue<string>();

        //FUNCTIONS START HERE

        public Form1()
        {
            InitializeComponent();
            connectBtn.Enabled = false;
            connectBtn.Visible = false;
            changePasswordLabel.Visible = false;
            allowConnectionBtn.Visible = false;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            topBar.BringToFront();
            mnmzBtn.BringToFront();
            exitBtn.BringToFront();

            new Thread(() =>
            {
                while (!isConnectedToServer || uid == null)
                { // Waiting for the uid and the connection to the server
                }

                messagesToQueue(); //Turning on the reading function
            }).Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectionThread.Start(); //Connecting to the server
            uidCreationThread.Start(); //Creating a uid
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Close();
            if (clientStream != null)
            {
                clientStream.Close();
            }
            connectionThread.Abort(); //Closing the connection with the server
        }

        private static void createUID()
        {
            //This function creates a Unique ID for this user based on hardware and more...
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

            uid = x;
        }

        private void controlMenu(bool option = true)
        { //Enabling / disabling the menu according to the value of option
            connectBtn.Enabled = option;
            allowConnectionBtn.Enabled = option;
            changePasswordLabel.Enabled = option;
        }

        private void messagesToQueue()
        {
            //This function always reads messages from socket and puts them in the queue
            //It also manages the connection requests (req message)

            Form5 incomingConnectionForm = null;
            Form6 userInteractionForm = null;
            string responseFromServer = "";
            int requestingUserUidIndex = 1;
            int oneMinuteInMiliseconds = 60000;
            string requestingUid = "";
            Stopwatch stopwatch = new Stopwatch();

            while (isConnectedToServer)
            { //While we are connected to the server we read messages and put them in the queue
                responseFromServer = readSocket(); //Reading message

                if (!isConnectedToUser && responseFromServer != null)
                { //If the user is not in a session
                    if (allowConnections && responseFromServer.Contains(incommingRequest))
                    { //if we allow connections and If this is a request to connect
                        requestingUid = responseFromServer.Split(',')[requestingUserUidIndex]; //Splitting the message with ,
                        incomingConnectionForm = new Form5(requestingUid);
                        incomingConnectionForm.ShowDialog(); //Notifing the user that there is a connection request
                        //If user accepts connection in the form above then isConnectedToUser is going to be set true

                        if (isConnectedToUser)
                        {
                            //If our user pressed accept we notify server that we want a connection
                            sendToServer(acceptConnection + "," + requestingUid);

                            //Notifing the user that we are trying to connect
                            BeginInvoke((MethodInvoker)delegate ()
                            {
                                sessionStatusBtn.Text = "Waiting for a response from " + requestingUid;
                            });

                            responseFromServer = readSocket();

                            stopwatch.Start(); //Waiting for inf message for 60 seconds (timeout of 60 seconds)

                            while (!responseFromServer.Contains(informationMessage) && stopwatch.ElapsedMilliseconds < oneMinuteInMiliseconds)
                            { //Waiting for the inf message
                                recievedFromServer.Enqueue(responseFromServer); //If it's not the inf we put it in the queue
                                responseFromServer = readSocket(); //Waiting for inf message
                            }
                            stopwatch.Stop();

                            if (stopwatch.ElapsedMilliseconds >= oneMinuteInMiliseconds)
                            {
                                //Timeout
                                stopwatch.Reset();
                                isConnectedToUser = false;
                                BeginInvoke((MethodInvoker)delegate ()
                                {
                                    sessionStatusBtn.Text = defaultStatusText;
                                });
                            }
                            else
                            {
                                BeginInvoke((MethodInvoker)delegate ()
                                {
                                    sessionStatusBtn.Text = "Connected to: " + requestingUid;
                                    controlMenu(false); //Disabling the menu
                                });

                                if(((IPEndPoint)client.Client.LocalEndPoint).Port + 1 > 65530)
                                { //Making sure we still have available ports
                                    MessageBox.Show("You are out of available ports :(\nPlease free some ports and try again.");
                                    Application.Exit();
                                }

                                userInteractionForm = new Form6(responseFromServer, true, ((IPEndPoint)client.Client.LocalEndPoint).Port + 1, ((IPEndPoint)client.Client.LocalEndPoint).Address.ToString());
                                userInteractionForm.ShowDialog(); //Displaying the user interaction form
                                responseFromServer = "";
                            }
                        }
                    }
                    else
                    {
                        //If this is not a connection request
                        recievedFromServer.Enqueue(responseFromServer); //Into the queue
                    }
                }
                else
                { //If the user in a session we need to make sure that the messages come from the connected user
                    if(responseFromServer != null && responseFromServer.Contains(user2))
                    {
                        recievedFromServer.Enqueue(responseFromServer); //Into the queue
                    }
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
            }
            catch
            {
                if (!isConnectedToServer)
                {
                    MessageBox.Show("Couldn't connect to the server. Please try again later!");
                }
                Environment.Exit(1); //Exit code 1 because it didn't succeed
            }
        }

        private static string getLastFromQueue()
        { //Using this function so we will wait for the queue to contain information
            while(recievedFromServer.Count() == 0) //Waiting untill there will be a message in the queue
            {
            }
            return recievedFromServer.Dequeue();
        }

        public static void sendToServer(string messageToServer)
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

        private static bool checkIfSuccess(string thisMessageSuccessCode = successCode) //Because it has default value this is an optional parameter
        { //Function checks if last command was successful or not and returns value
            string lastMessageFromQueue = getLastFromQueue(); //Reading the latest message from server
            bool res = false;

            if (lastMessageFromQueue.Contains(thisMessageSuccessCode)) // Checking if we have a success
            {
                //MessageBox.Show(thisMessageSuccessCode); //This is for debug
                res = true;
            }
            return res;
        }

        public static bool SignIn(string thePassword)
        {
            bool res = true;

            sendToServer("sgin," + uid + "," + thePassword);

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

            if(checkIfSuccess(acceptConnection + "," + targetUser)) // Checking if we have a success
            { //^^We send the specific success message we expect so we won't mix this acc message with other users
                res = true;
                user2 = targetUser;
                isConnectedToUser = true;
            }
            return res;
        }

        public static bool ChangePass(string currPassword, string newPassword)
        {
            bool res = false;

            if (currPassword.Equals(password)) //Checking if the current password user provided is correct
            {
                sendToServer("nps," + uid + "," + newPassword);

                if (checkIfSuccess()) // Checking if we have a success
                {
                    res = true;
                    password = newPassword;
                }
            }

            return res;
        }

        public static string getUid()
        {
            return uid;
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            Form6 userInteractionForm = null;
            int oneMinuteInMiliseconds = 60000;
            string responseFromServer = "";
            Form2 f = new Form2(); //Opening connection form
            f.ShowDialog();

            if (isConnectedToUser)
            {
                sessionStatusBtn.Text = "Waiting for user information...";

                //Now we wait for inf message
                responseFromServer = getLastFromQueue();
                //Note that if the user is waiting for an inf message and other client tries to connect to this user-
                //there will be issues. TODO- Check that and fix that

                stopwatch.Start(); //Waiting for inf message for 60 seconds (timeout of 60 seconds)

                while (!responseFromServer.Contains(informationMessage) && stopwatch.ElapsedMilliseconds < oneMinuteInMiliseconds)
                { //Waiting for the inf message
                    responseFromServer = getLastFromQueue(); //Waiting for inf message
                }
                stopwatch.Stop();

                if (stopwatch.ElapsedMilliseconds >= oneMinuteInMiliseconds)
                {
                    //Timeout
                    stopwatch.Reset();
                    isConnectedToUser = false;
                    BeginInvoke((MethodInvoker)delegate ()
                    {
                        controlMenu(true); //Enabling the menu
                        sessionStatusBtn.Text = defaultStatusText;
                    });
                }
                else
                {
                    controlMenu(false); //Disabling the menu
                    sessionStatusBtn.Text = "Connected to: " + user2.ToUpper();

                    userInteractionForm = new Form6(responseFromServer, false, 0);
                    userInteractionForm.ShowDialog(); //Displaying the user interaction form as client

                    //TODO: P2P connection between both clients
                    //TODO: Add disconnect button that appears after the user is connected
                }
            }
        }

        private void signinBtn_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();

            f.ShowDialog();

            if (loggedIn)
            {
                loginStatusBtn.Text = "Logged in as: " + uid;
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
