using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Samung_Alpha.Classes
{
    public class networkStreamFunctions
    {
        public static string readSocket(NetworkStream thisStream)
        {
            // Buffer to store the response bytes.
            Byte[] data = new Byte[1000000]; //TODO CHANGE SIZE LATER
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

        public static void sendMessage(string messageToServer, NetworkStream thisStream)
        { //This function sends a message 

            byte[] buffer = System.Text.Encoding.Unicode.GetBytes(messageToServer);

            thisStream.Write(buffer, 0, buffer.Length);
            thisStream.Flush(); //Send message
        }
    }
}
