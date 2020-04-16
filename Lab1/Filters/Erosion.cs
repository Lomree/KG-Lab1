using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab1
{
    class Erosion : MathMorphologyFilter
    {
        public Erosion()
        {
            kernel = new int[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } };
            radius = kernel.GetLength(0) / 2;
        }

        public Erosion(int[,] kernel)
        {
            this.kernel = kernel;
            radius = kernel.GetLength(0) / 2;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color min = Color.FromArgb(255, 255, 255);
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    if ((kernel[i + radius, j + radius] == 1) && (sourceImage.GetPixel(x + i, y + j).GetBrightness() < min.GetBrightness()))
                    {
                        min = sourceImage.GetPixel(x + i, y + j);
                    }
                }
            }
            return min;
        }
    }
}
