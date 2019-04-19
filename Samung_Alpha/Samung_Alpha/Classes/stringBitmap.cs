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
        public static string bitmapToString(System.Drawing.Bitmap sImage)
        { //This function converts bitmap to base64 encoded string

            long compressionLevel = 20;

            MemoryStream ms = GetCompressedBitmap(sImage, compressionLevel);
            sImage.Save(ms, ImageFormat.Jpeg);
            byte[] byteArray = ms.ToArray();

            return Convert.ToBase64String(byteArray); //Converting to base64 and returning
        }

        public static Bitmap stringToBitmap(string base64encoded)
        { //This function decodes base64 encoded string to bitmap

            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            byte[] bytes = Convert.FromBase64String(base64encoded);
            Image final = (Image)converter.ConvertFrom(bytes);

            return (Bitmap)final;
        }

        private static MemoryStream GetCompressedBitmap(System.Drawing.Bitmap bmp, long quality)
        { //This function compresses the bitmap to the required level

            using (var mss = new MemoryStream())
            {
                EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                ImageCodecInfo imageCodec = ImageCodecInfo.GetImageEncoders().FirstOrDefault(o => o.FormatID == ImageFormat.Jpeg.Guid);
                EncoderParameters parameters = new EncoderParameters(1);
                parameters.Param[0] = qualityParam;
                bmp.Save(mss, imageCodec, parameters);

                return mss;
            }
        }
    }
}
