using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    class TurnFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap SourceImage, int x, int y)
        {
            Color resultColor = SourceImage.GetPixel(Clamp(x + 45, 0, SourceImage.Width - 1), y);
            return resultColor;
        }
    }
}
