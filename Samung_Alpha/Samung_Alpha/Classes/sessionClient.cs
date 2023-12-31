﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Drawing;
using static Samung_Alpha.Classes.networkStreamFunctions;
using static Samung_Alpha.Classes.usefulValues;

namespace Samung_Alpha.Classes
{
    public class sessionClient
    {
        public static Bitmap getImage(TcpClient client)
        { //This function handles messages, from and to controlled user

            string query = "";
            Byte[] byteQuery = new Byte[1000000]; //TODO CHANGE SIZE LATER
            NetworkStream ns = client.GetStream();
            System.Drawing.Bitmap returnValue = null;

            query = readSocket(ns);

            try
            {
                returnValue = stringBitmap.stringToBitmap(query);
            }
            catch { } //If there is an exception we just ignore it

            return returnValue;
        }

        public static bool connectToUser(ref TcpClient client, IPEndPoint serverEndPoint, string userUID)
        { //This function connects to the user

            NetworkStream clientStream = null;
            Stopwatch stopwatch = null;
            bool isSucceesful = false;
            int connectionTimout = 5; //In minutes

            try
            {
                stopwatch = new Stopwatch();
                stopwatch.Start();
                client = new TcpClient();

                client.Connect(serverEndPoint);

                while (!client.Connected && stopwatch.ElapsedMilliseconds < oneMinuteInMiliseconds * connectionTimout)
                {
                    client.Connect(serverEndPoint); //Retrying the connection...
                }

                stopwatch.Stop();

                if (stopwatch.ElapsedMilliseconds >= oneMinuteInMiliseconds * connectionTimout)
                { //If we timedout
                    MessageBox.Show("TIMEOUT: Couldn't connect to user " + userUID);
                }
                else
                {
                    clientStream = client.GetStream();
                    clientStream.ReadTimeout = oneMinuteInMiliseconds;
                    isSucceesful = true;
                }
            }
            catch
            {
                MessageBox.Show("Couldn't connect to the user. Please try again later!");
            }

            return isSucceesful;
        }
    }
}
