using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    class WavesFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int resultX = (int)((x - sourceImage.Width / 2) * Math.Cos(-120) - (y - sourceImage.Height / 2) * Math.Sin(-120) + sourceImage.Width / 2);
            int resultY = (int)((x - sourceImage.Width / 2) * Math.Sin(-120) + (y - sourceImage.Height / 2) * Math.Cos(-120) + sourceImage.Height / 2);
            Color resultColor = sourceImage.GetPixel(Clamp(resultX, 0, sourceImage.Width - 1), Clamp(resultY, 0, sourceImage.Height - 1));
            return resultColor;
        }
    }
}
