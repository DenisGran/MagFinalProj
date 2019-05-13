using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Samung_Alpha.Classes;


namespace Samung_Alpha
{
    public partial class Form6 : Form
    {
        //Threads
        //Thread screenSharingThread = new Thread(shareScreen);

        //Connection user information
        private static string recievedMessage = "inf,Unknown,127.0.0.1,0";
        private static string userUID = "Unknown";
        private static string userIP = "127.0.0.1";
        private static int userPort = 0;
        private static bool isServer = false;

        //Networking stuff
        public static TcpClient client;
        public static IPEndPoint serverEndPoint = null;
        private static NetworkStream clientStream;
        private static int thisServerPort = 0;
        const string SERVER_IP = "127.0.0.1";

        //Codes
        private const string screenSharingCode = "scrn";

        public Form6(string theMessageFromServer, bool isThisServer, int thisUserPort = 0)
        {
            //Indexes
            int userUIDIndex = 1;
            int userIPIndex = 2;
            int userPortIndex = 3;

            //Holding the values
            string[] temp = theMessageFromServer.Split(','); //Splitting the recieved message
            
            //Setting the values
            recievedMessage = theMessageFromServer;
            userUID = temp[userUIDIndex];
            userIP = temp[userIPIndex];
            userPort = int.Parse(temp[userPortIndex]);
            thisServerPort = thisUserPort;
            isServer = isThisServer;

            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        { //We try to connect to the user/create server

            thisUserLabel.Text += Form1.getUid();

            if (isServer)
            {
                this.Text = "Creating a server...";
                serverIPLbl.Text = SERVER_IP;
                serverPortLbl.Text = thisServerPort.ToString();
                actualStatusLabel.Text = this.Text;

                new Thread(() =>
                {
                    createServer(); //Creating a new server
                }).Start();
            }
            else
            {
                this.Text = "Connecting to: " + userUID;
                serverIPLbl.Text = userIP;
                serverPortLbl.Text = userPort.ToString();
                actualStatusLabel.Text = this.Text;
                serverEndPoint = new IPEndPoint(IPAddress.Parse(userIP), userPort);

                new Thread(() =>
                {
                    connectToUser(); //Turning on the connection function
                }).Start();
            }
        }

        private static string readSocket(NetworkStream thisStream)
        {
            // Buffer to store the response bytes.
            Byte[] data = new Byte[1000000]; //TODO CHANGE SIZE LATER

            // String to store the response ASCII representation.
            string responseData = "";

            // Read the first batch of the TcpServer response bytes.
            try
            {
                Int32 bytes = thisStream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.Unicode.GetString(data, 0, bytes);
            }
            catch
            {
                //In case we couldn't read from stream dont raise an exception thank you
            }

            return responseData;
        }

        private static byte[] readBytes(NetworkStream thisStream)
        {
            // Buffer to store the response bytes.
            Byte[] data = new Byte[1000000]; //TODO CHANGE SIZE LATER

            // Read the first batch of the TcpServer response bytes.
            try
            {
                Int32 bytes = thisStream.Read(data, 0, data.Length);
            }
            catch
            {
                //In case we couldn't read from stream dont raise an exception thank you
            }

            return data;
        }

        public static void sendMessage(string messageToServer, NetworkStream thisStream)
        { //This function sends a message 

            byte[] buffer = new UnicodeEncoding().GetBytes(messageToServer);

            thisStream.Write(buffer, 0, buffer.Length);
            thisStream.Flush(); //Send message
        }

        public static void sendBytes(byte[] buffer, NetworkStream thisStream)
        { //This function sends bytes

            thisStream.Write(buffer, 0, buffer.Length);
            thisStream.Flush(); //Send message
        }

        private void shareScreen()
        { //This function takes screenshot and sends it to the controlling user

            Bitmap temp = null;
            const string fullQuery = screenSharingCode + ",";
            string tempQuery = ""; //Temporary query we create and send to user
            PictureBox screenBox = new PictureBox();
            int primaryScreenWidthSize = Screen.PrimaryScreen.Bounds.Width;
            int primaryScreenHeightSize = Screen.PrimaryScreen.Bounds.Height;
            int twentyFourFramesASecond = 41;

            while (!client.Connected)
            { //We wait for the user to connect
            }

            screenBox.SizeMode = PictureBoxSizeMode.StretchImage;
            screenBox.SendToBack();
            screenBox.Dock = DockStyle.Fill;

            this.Invoke((MethodInvoker)delegate
            {
                Controls.Add(screenBox);
            });

            while (client.Connected)
            { //Making sure we are still connected
                //tempQuery = fullQuery; //Creating a copy

                temp = screenCapture.CaptureScreen(primaryScreenWidthSize, primaryScreenHeightSize);
                //tempQuery += temp.Width + "x" + temp.Height + "d"; //Skipping this for a test
                //tempQuery = stringBitmap.bitmapToString(temp);
                tempQuery = stringBitmap.bitmapToString(temp);
                screenBox.Image = temp;

                sendMessage(tempQuery, clientStream); //Send screenshot to connected user
                Thread.Sleep(twentyFourFramesASecond); //So we wont spam it
            }
        }

        private void serverControl(string query)
        { //This handles the different code types
            
        }

        private void createServer()
        { //This function creates a server that listens to the user connected to it

            string tempQuery = "";

            //---listen at the specified IP and port no.---
            IPAddress theServerIP = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(theServerIP, thisServerPort);

            this.Invoke((MethodInvoker)delegate
            {
                this.Text = "Waiting for " + userUID + " To connect";
                actualStatusLabel.Text = this.Text;
            });

            //Listening
            listener.Start();

            //---incoming client connected---
            client = listener.AcceptTcpClient();

            clientStream = client.GetStream(); //networkstream is used to send/receive messages

            this.Invoke((MethodInvoker)delegate
            {
                this.Text = userUID + " connected";
                actualStatusLabel.Text = this.Text;
            });

            new Thread(() =>
            {
                shareScreen();
            }).Start();

                while (client.Connected)  //while the client is connected, we look for incoming messages
            {
                tempQuery = readSocket(clientStream);
                //MessageBox.Show("Recieved: " + tempQuery);
                serverControl(tempQuery);
            }

            MessageBox.Show("User " + userUID + " disconnected");
        }

        private void clientControlling()
        { //This function handles messages, from and to controlled user

            NetworkStream ns = client.GetStream();
            string query = "";

            // Buffer to store the response bytes.
            Byte[] byteQuery = new Byte[1000000]; //TODO CHANGE SIZE LATER

            string tempQuery = "";
            PictureBox screenBox = new PictureBox();

            screenBox.SizeMode = PictureBoxSizeMode.StretchImage;
            screenBox.SendToBack();
            screenBox.Dock = DockStyle.Fill;

            this.Invoke((MethodInvoker)delegate
            {
                Controls.Add(screenBox);
            });

            while (client.Connected)
            {
                query = readSocket(ns);
                //tempQuery = compressionClass.Unzip(byteQuery);

                screenBox.Image = stringBitmap.stringToBitmap(query);

                /*if (query.Contains(screenSharingCode))
                {
                    screenBox.Image = stringBitmap.stringToBitmap(query.Split('d')[1]); //Turning string into the picturebox
                }*/
            }

            MessageBox.Show("User " + userUID + " disconnected.");
        }

        private void connectToUser()
        { //This function connects to user and sends it messages

            Stopwatch stopwatch = null;
            int oneSecondInMiliseconds = 1000;
            int oneMinuteInMiliseconds = 60 * oneSecondInMiliseconds;
            client = new TcpClient();

            try
            {
                stopwatch = new Stopwatch();
                stopwatch.Start();
                client.Connect(serverEndPoint);

                while(!client.Connected && stopwatch.ElapsedMilliseconds < oneMinuteInMiliseconds)
                {
                    client.Connect(serverEndPoint); //Retrying the connection...
                }

                stopwatch.Stop();

                if (stopwatch.ElapsedMilliseconds >= oneMinuteInMiliseconds)
                { //If we timedout
                    MessageBox.Show("TIMEOUT: Couldn't connect to user " + userUID);
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Close(); //Close this form
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Text = "Connected to " + userUID;
                        actualStatusLabel.Text = this.Text;
                    });

                    clientStream = client.GetStream();
                    clientStream.ReadTimeout = 60000; //Creating timeout of 1 minute
                    clientControlling(); //If everything is ok we start sending messages
                }
            }
            catch
            {
                MessageBox.Show("Couldn't connect to the user. Please try again later!");
                this.Invoke((MethodInvoker)delegate
                {
                    this.Close(); //Close this form
                });
            }
        }
    }
}
