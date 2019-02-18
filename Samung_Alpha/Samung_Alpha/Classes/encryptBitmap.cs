using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samung_Alpha.Classes
{
    class encryptBitmap
    {
        public static string bitmapToBase64(Bitmap sImage)
        { //Converting bitmap to base64

            System.IO.MemoryStream ms = new MemoryStream();

            sImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] byteImage = ms.ToArray(); //Converting to bytes
            string SigBase64 = Convert.ToBase64String(byteImage); // Get Base64

            ms.Close();
            sImage.Dispose();

            return SigBase64;
        }

        public static Bitmap base64ToBitmap(string base64EncodedStringImage)
        { //Base64 to bitmap

            MemoryStream ms = new MemoryStream(Convert.FromBase64String(base64EncodedStringImage));
            Bitmap thisBitmap = new Bitmap(ms);

            return thisBitmap;
        }
    }
}
