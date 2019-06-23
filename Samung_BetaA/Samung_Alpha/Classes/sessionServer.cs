using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Desktop_Viewer.Classes.networkStreamFunctions;
using static Desktop_Viewer.Classes.usefulValues;
using System.Threading;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace Desktop_Viewer.Classes
{
    public class sessionServer
    {
        //These are for the mouse click events
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static Bitmap shareScreen(TcpClient client)
        { //This function sends a screenshot to the connected user

            int numberOfFramesPerSecond = 1;
            int amountOfSleep = oneSecondInMiliseconds / numberOfFramesPerSecond;
            string tempQuery = "";
            Bitmap tempBitmap = sessionServer.getScreen();

            //tempQuery += temp.Width + "x" + temp.Height + "d"; //Skipping this for a test

            tempQuery = stringBitmap.bitmapToString(tempBitmap);

            Thread.Sleep(amountOfSleep);

            sendMessage(tempQuery, client.GetStream()); //Send screenshot to connected user

            return tempBitmap;
        }

        public static Bitmap getScreen()
        { //This function takes screenshot and returns it
            
            int primaryScreenWidthSize = Screen.PrimaryScreen.Bounds.Width;
            int primaryScreenHeightSize = Screen.PrimaryScreen.Bounds.Height;

            return screenCapture.CaptureScreen(primaryScreenWidthSize, primaryScreenHeightSize);
        }

        public static bool createServer(string thisUserIP, int thisServerPort, ref TcpClient client)
        { //This function creates a server and waits for a user to connect to it

            bool returnValue = false;
            int waitForClientToConnectTimeout = 5; //In minutes

            //---listen at the specified IP and port---
            IPAddress theServerIP = IPAddress.Parse(thisUserIP);
            TcpListener listener = new TcpListener(theServerIP, thisServerPort);
            listener.Server.ReceiveTimeout = oneMinuteInMiliseconds * waitForClientToConnectTimeout;
            listener.Server.SendTimeout = oneMinuteInMiliseconds * waitForClientToConnectTimeout;

            //Listening
            listener.Start();

            //---incoming client connected---
            client = listener.AcceptTcpClient();

            if(client.Connected)
            {
                returnValue = true;
            }

            return returnValue;
        }

        public static void readFromSocketAndExecute(TcpClient client)
        { //This function reads from socket and executes the command

            string recievedText = "", temp = "";
            NetworkStream ns = client.GetStream();
            int firstIndex = 0;

            while (client.Connected)
            { //While we are still connected to the other user

                recievedText = readSocket(ns);

                if (recievedText.Length > 1)
                { //if we recieved data with more than one character

                    temp = recievedText.Substring(firstIndex + 1);

                    if (recievedText[firstIndex] == usefulValues.chatCode)
                    {

                    }
                    else if (recievedText[firstIndex] == usefulValues.keyCode)
                    {
                        SendKeys.SendWait(temp); //Press the recieved key
                    }
                    else if (recievedText[firstIndex] == usefulValues.mouseCode)
                    {
                        string[] coords = temp.Split(',');
                        int xCord = int.Parse(Regex.Replace(coords[0], "[^0-9]", ""));
                        int yCord = int.Parse(Regex.Replace(coords[1], "[^0-9]", ""));
                        Point point = new Point(xCord, yCord);

                        Cursor.Position = point;
                    }
                    else if (recievedText[firstIndex] == usefulValues.leftMouseCode)
                    {
                        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    }
                    else if (recievedText[firstIndex] == usefulValues.rightMouseCode)
                    {
                        mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
                    }

                    recievedText = ""; //Resetting
                }
            }
        }
    }
}
