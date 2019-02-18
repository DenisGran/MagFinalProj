using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samung_Alpha.Classes
{
    class screenCapture
    {
        public static Bitmap CaptureScreen(int defaultScreenWidth = 640, int defaultScreenHeight = 480)
        {
            //Takes screenshot in the size given

            Rectangle bounds = Screen.GetBounds(Point.Empty);
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
            }
            bitmap.SetResolution(defaultScreenHeight, defaultScreenHeight);

            return bitmap;
        }
    }
}
