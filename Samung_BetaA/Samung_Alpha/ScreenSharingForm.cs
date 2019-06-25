﻿using System;
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
using static Desktop_Viewer.Classes.usefulValues;

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

        //Threads
        Thread executingThread = new Thread(()=>sessionServer.readFromSocketAndExecute(client));

        //Useful variables
        PictureBox screenBox = new PictureBox();
        static bool sendMouseMovement = true;

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

            screenBox.SizeMode = PictureBoxSizeMode.StretchImage;
            screenBox.Dock = DockStyle.Fill;
            screenBox.SendToBack();

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

                        executingThread.Start();

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

                        this.Invoke((MethodInvoker)delegate
                        {
                            //Inform the user that we are connected
                            this.Text = "Connected to " + userUID;
                            actualStatusLabel.Text = this.Text;
                            Controls.Add(screenBox);
                        });

                        screenBox.MouseMove += new MouseEventHandler(screenBox_OnMouseMove); //For mouse movement
                        screenBox.MouseClick += new MouseEventHandler(screenBox_OnMouseClick); //Mouse click events

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

                networkStreamFunctions.sendMessage( usefulValues.keyCode + e.KeyData.ToString(), client.GetStream());
            }
        }

        public void screenBox_OnMouseMove(object sender, object e)
        {
            if (screenBox.Image != null && sendMouseMovement)
            {
                int numberOfFramesPerSecond = 1;

                sendMouseMovement = false;
                networkStreamFunctions.sendMessage(usefulValues.mouseCode + new Point((int)((Cursor.Position.X - this.Location.X) * (float)screenBox.Image.Width / screenBox.Size.Width), (int)((Cursor.Position.Y - this.Location.Y) * (float)screenBox.Image.Height / screenBox.Size.Height)).ToString(), client.GetStream());
                //Calculating Mouse position based on ratio

                Thread.Sleep(oneSecondInMiliseconds / numberOfFramesPerSecond); //Sleeping according to the amount of fps
                sendMouseMovement = true;
            }
        }

        public void screenBox_OnMouseClick(object sender, MouseEventArgs e)
        {
            if (screenBox.Image != null)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        try
                        {
                            networkStreamFunctions.sendMessage(usefulValues.leftMouseCode.ToString() + "leftmousebutton", client.GetStream());
                            //Sending left mouse click
                            //Also adding the text "leftmousebutton" because the we can't send one character over the stream 
                        }
                        catch
                        {
                            //This may fail so we will catch the exception
                        }
                        break;

                    case MouseButtons.Right:
                        try
                        {
                            networkStreamFunctions.sendMessage(usefulValues.rightMouseCode.ToString() + "rightmousebutton", client.GetStream());
                            //Sending right mouse click
                            //Also adding the text "rightmousebutton" because the we can't send one character over the stream 
                        }
                        catch
                        {
                            //This may fail so we will catch the exception
                        }
                        break;
                }
            }
        }
    }
}