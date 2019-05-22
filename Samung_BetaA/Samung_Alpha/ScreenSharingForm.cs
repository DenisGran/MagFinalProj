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
using Desktop_Viewer.Classes;

namespace Desktop_Viewer
{
    public partial class ScreenSharingForm : Form
    {

        //Connection user information
        private static string recievedMessage = "inf,Unknown,127.0.0.1,0";
        private static string userUID = "Unknown";
        private static string userIP = "127.0.0.1";
        private static int userPort = 0;
        private static bool isServer = false;

        //Networking stuff
        public static TcpClient client;
        public static IPEndPoint serverEndPoint = null;
        private static int thisServerPort = 0;
        private static string thisUserIP = "127.0.0.1";

        public ScreenSharingForm(string theMessageFromServer, bool isThisServer, int thisUserPort = 0, string ipOfThisUser = "127.0.0.1")
        { //Constructor

            //Indexes
            int userUIDIndex = 1; //User who want to interact
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
            thisUserIP = ipOfThisUser;

            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        { //We try to connect to the user/create server

            thisUserLabel.Text += MainMenuForm.getUid();

            if (isServer)
            { //Server initiation here

                this.Text = "Creating a server...";
                serverIPLbl.Text = thisUserIP;
                serverPortLbl.Text = thisServerPort.ToString();
                actualStatusLabel.Text = this.Text;

                new Thread(() =>
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Text = "Waiting for " + userUID + " To connect";
                        actualStatusLabel.Text = this.Text;
                    });

                    if (sessionServer.createServer(thisUserIP, thisServerPort, ref client)) //Trying to create a new server
                    { //If the user connected successfully after server initiated

                        PictureBox screenBox = new PictureBox();

                        screenBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        screenBox.SendToBack();
                        screenBox.Dock = DockStyle.Fill;

                        this.Invoke((MethodInvoker)delegate
                        {
                            this.Text = userUID + " connected";
                            actualStatusLabel.Text = this.Text;
                            Controls.Add(screenBox);
                        });

                        new Thread(() =>
                        {
                            while (client.Connected)
                            { //Making sure we are still connected
                                screenBox.Image = sessionServer.shareScreen(client);
                            }

                            MessageBox.Show("User " + userUID + " disconnected");
                        }).Start();
                    }
                }).Start();
            }
            else
            { //Client initiation here

                this.Text = "Connecting to: " + userUID;
                serverIPLbl.Text = userIP;
                serverPortLbl.Text = userPort.ToString();
                actualStatusLabel.Text = this.Text;
                serverEndPoint = new IPEndPoint(IPAddress.Parse(userIP), userPort);

                new Thread(() =>
                {
                    if (sessionClient.connectToUser(ref client, serverEndPoint, userUID))
                    { //If we connected successfully to the user

                        //Creating a picturebox for the screen to be displayed
                        System.Drawing.Bitmap tempImage = null;
                        PictureBox screenBox = new PictureBox();

                        screenBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        screenBox.SendToBack();
                        screenBox.Dock = DockStyle.Fill;

                        this.Invoke((MethodInvoker)delegate
                        {
                            //Inform the user that we are connected
                            this.Text = "Connected to " + userUID;
                            actualStatusLabel.Text = this.Text;
                            Controls.Add(screenBox);
                        });

                        while (client.Connected)
                        {
                            tempImage = sessionClient.getImage(client);

                            if(tempImage != null)
                            {
                                screenBox.Image = tempImage;
                            }
                        }

                        MessageBox.Show("User " + userUID + " disconnected.");

                    }
                }).Start();
            }
        }

        private void ScreenSharingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!isServer)
            { //If its the controlling computer

                networkStreamFunctions.sendMessage( usefulValues.keyPressingCode + e.KeyData.ToString(), client.GetStream());
            }
        }
    }
}
