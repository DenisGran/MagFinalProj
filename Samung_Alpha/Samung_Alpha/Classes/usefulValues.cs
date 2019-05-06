using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samung_Alpha.Classes
{
    public class usefulValues
    {
        //Times
        public const int oneSecondInMiliseconds = 1000;
        public const int oneMinuteInMiliseconds = 60 * oneSecondInMiliseconds;

        //Networking
        public const int sendReadBufferSize = 1024; //The maximum amount of bytes we can send/recieve
        public const string endHeader = "</end>"; //Ending the message (Header)

        //Codes
        public const string screenSharingCode = "scrn";
    }
}
