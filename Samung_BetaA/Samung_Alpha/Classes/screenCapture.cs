using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Viewer.Classes
{
    class screenCapture
    {
        public static Bitmap CaptureScreen(int defaultScreenWidth = 640, int defaultScreenHeight = 480)
        {
            //Takes screenshot in the size given

            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(defaultScreenWidth, defaultScreenHeight, PixelFormat.Format24bppRgb);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(Point.Empty, Point.Empty, bitmap.Size);
            }

            bitmap.SetResolution(640, 480);

            return bitmap;
        }
    }
}
