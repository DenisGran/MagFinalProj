using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static Samung_Alpha.Classes.usefulValues;

namespace Samung_Alpha.Classes
{
    public class networkStreamFunctions
    {
        public static string readSocket(NetworkStream thisStream)
        {
            // Buffer to store the response bytes.
            Byte[] data = new Byte[usefulValues.sendReadBufferSize];
            string responseData = "", tempString = "";
            bool continueReading = true;

            // Read the TcpServer response bytes.
            try
            {
                while (continueReading)
                {
                    Int32 bytes = thisStream.Read(data, 0, data.Length);
                    tempString = System.Text.Encoding.Unicode.GetString(data, 0, bytes);

                    if(!tempString.Contains(usefulValues.endHeader))
                    { //Untill we didn't read the end header we continue to read

                        responseData += tempString;
                    }
                    else
                    { //If we finished reading we stop the loop

                        continueReading = false;
                    }
                }
            }
            catch
            {
                //In case we couldn't read from stream dont raise an exception thank you
            }

            return responseData;
        }

        public static void sendMessage(string messageToSend, NetworkStream thisStream)
        { //This function sends a message 

            int amountOfMessages = (int)Math.Ceiling((double)messageToSend.Length / (double)usefulValues.sendReadBufferSize);
            int i = 0; //(Counter)
            byte[] buffer = null;

            for (i = 0; i < amountOfMessages; i++)
            { //Fragmentation and sending

                buffer = System.Text.Encoding.Unicode.GetBytes(messageToSend.Substring(i * usefulValues.sendReadBufferSize, usefulValues.sendReadBufferSize));
                thisStream.Write(buffer, 0, buffer.Length);
                thisStream.Flush(); //Send message now
            }

            //After we finished sending the whole image we are sending the end 
            thisStream.Write(System.Text.Encoding.Unicode.GetBytes(usefulValues.endHeader), 0, usefulValues.endHeader.Length);
            thisStream.Flush(); //Send message now
        }
    }
}
