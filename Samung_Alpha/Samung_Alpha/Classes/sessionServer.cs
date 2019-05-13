using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Samung_Alpha.Classes.networkStreamFunctions;
using static Samung_Alpha.Classes.usefulValues;
using System.Threading;

namespace Samung_Alpha.Classes
{
    public class sessionServer
    {

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

        public void serverControl(string query)
        { //This handles the different code types

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
    }
}
