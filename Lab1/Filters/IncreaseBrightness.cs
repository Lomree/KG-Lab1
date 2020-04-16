using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    class IncreaseBrightness : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap SourceImage, int x, int y)
        {
            Color sourceColor = SourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(Clamp(sourceColor.R + 30, 0, 255), Clamp(sourceColor.G + 30, 0, 255), Clamp(sourceColor.B + 30, 0, 255));
            return resultColor;
        }
    }
}
