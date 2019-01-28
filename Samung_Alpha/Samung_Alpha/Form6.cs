using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samung_Alpha
{
    public partial class Form6 : Form
    {
        
        //User information
        private static string recievedMessage = "inf,Unknown,127.0.0.1,0";
        private static string userUID = "Unknown";
        private static string userIP = "127.0.0.1";
        private static int userPort = 0;
        private static bool isServer = false;

        //Networking stuff
        public static TcpClient client = new TcpClient();
        public static IPEndPoint serverEndPoint = null;
        private static NetworkStream clientStream;
        private static int thisServerPort = 0;
        const string SERVER_IP = "127.0.0.1";

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

        private void createServer()
        {
            //---listen at the specified IP and port no.---
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, thisServerPort);
            
            //Listening
            listener.Start();

            //---incoming client connected---
            TcpClient client = listener.AcceptTcpClient();

            this.Invoke((MethodInvoker)delegate
            {
                this.Text = "Waiting for " + userUID + " To connect";
                actualStatusLabel.Text = this.Text;
            });

            while (true)   //we wait for a connection
            {
                NetworkStream ns = client.GetStream(); //networkstream is used to send/receive messages

                while (client.Connected)  //while the client is connected, we look for incoming messages
                {
                    MessageBox.Show("Recieved: " + readSocket(ns));
                }
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

        private void connectToUser()
        {
            Stopwatch stopwatch = null;
            int oneSecondInMiliseconds = 1000;
            int oneMinuteInMiliseconds = 60 * oneSecondInMiliseconds;
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
                stopwatch.Reset();
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

            //If everything is ok we start sending messages
            sendMessage("This is a test message 1234", clientStream); //Sending a test
        }

        private void Form6_Load(object sender, EventArgs e)
        {
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
    }
}
