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
                serverIPLbl.Text = userIP;
                serverPortLbl.Text = userPort.ToString();
                this.Text = "Connecting to: " + userUID;
                serverEndPoint = new IPEndPoint(IPAddress.Parse(userIP), userPort);
                actualStatusLabel.Text = this.Text;

                new Thread(() =>
                {
                    connectToUser(); //Turning on the connection function
                }).Start();
            }
        }

        private static string readSocket(NetworkStream thisStream)
        {
            // Buffer to store the response bytes.
            Byte[] data = new Byte[256];

            // String to store the response ASCII representation.
            string responseData = "";

            // Read the first batch of the TcpServer response bytes.
            try
            {
                Int32 bytes = thisStream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            }
            catch
            {
                //In case we couldn't read from stream dont raise an exception thank you
            }

            return responseData;
        }

        public static void sendMessage(string messageToServer, NetworkStream thisStream)
        { //This function sends a message to the server

            byte[] buffer = new ASCIIEncoding().GetBytes(messageToServer);

            thisStream.Write(buffer, 0, buffer.Length);
            thisStream.Flush(); //Send message
        }

        private void shareScreen()
        { //This function takes screenshot and sends it to the controlling user

            Bitmap temp = null;
            string fullQuery = screenSharingCode + ",";
            PictureBox screenBox = new PictureBox();


            while (!client.Connected)
            { //We wait for the user to connect
            }

            screenBox.SizeMode = PictureBoxSizeMode.StretchImage;
            screenBox.Dock = DockStyle.Bottom;

            this.Invoke((MethodInvoker)delegate
            {
                Controls.Add(screenBox);
            });

            while (client.Connected)
            { //Making sure we are still connected
                temp = screenCapture.CaptureScreen();
                screenBox.Image = temp;

                fullQuery += temp.Width + "x" + temp.Height + "d";
                fullQuery += encryptBitmap.bitmapToBase64(temp);

                sendMessage(fullQuery, clientStream); //Send base64 encrypted screenshot to connected user
                Thread.Sleep(1); //So we wont spam it
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

            //screenSharingThread.Start(); //Turning on the screen sharing function

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
            string base64EncodedScreenCode = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(screenSharingCode));
            PictureBox screenBox = new PictureBox();

            screenBox.Dock = DockStyle.Bottom;
            screenBox.SizeMode = PictureBoxSizeMode.StretchImage;

            this.Invoke((MethodInvoker)delegate
            {
                Controls.Add(screenBox);
            });

            while (client.Connected)
            {
                query = readSocket(ns);

                if(query.Contains(base64EncodedScreenCode))
                {
                    screenBox.Image = encryptBitmap.base64ToBitmap(query); //Decoding base64 and setting this in the picturebox
                }
            }

            MessageBox.Show("User " + userUID + " disconnected.");
            //sendMessage("99", clientStream); //Sending a test
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
