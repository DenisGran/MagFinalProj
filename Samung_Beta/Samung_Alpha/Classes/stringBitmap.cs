using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samung_Alpha.Classes
{
    class stringBitmap
    {
        public static string bitmapToString(Bitmap sImage)
        { //Converting bitmap to base64 encoded string

            MemoryStream ms = new MemoryStream();
            sImage.Save(ms, ImageFormat.Jpeg); //TODO TRY DIFFERENT IMAGE FORMATS
            byte[] byteArray = ms.ToArray();

            return Convert.ToBase64String(byteArray); //Converting to base64 and sending
        }

        public static Bitmap stringToBitmap(string base64encoded)
        { //Base64 encoded string to bitmap

            byte[] bytes = Convert.FromBase64String(base64encoded);
            MemoryStream ms = new MemoryStream(bytes);
            Image final = Image.FromStream(ms);

            return (Bitmap)final;
        }
    }
}
