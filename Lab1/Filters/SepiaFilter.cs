using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    class SepiaFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap SourceImage, int x, int y)
        {
            double k = 25.0;
            Color sourceColor = SourceImage.GetPixel(x, y);
            double Intensity = (0.299 * sourceColor.R) + (0.587 * sourceColor.G) + (0.114 * sourceColor.B);
            double colorR = Intensity + 2 * k;
            double colorG = Intensity + 0.5 * k;
            double colorB = Intensity - 1 * k;
            Color resultColor = Color.FromArgb(Clamp((int)colorR, 0, 255), Clamp((int)colorG, 0, 255), Clamp((int)colorB, 0, 255));
            return resultColor;
        }
    }
}
