using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Lab1
{
    class GreyWorldFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            return sourceImage.GetPixel(x, y);
        }
        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            float resultR = 0;
            float resultG = 0;
            float resultB = 0;
            float average;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 50));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultR += sourceImage.GetPixel(i, j).R;
                    resultG += sourceImage.GetPixel(i, j).G;
                    resultB += sourceImage.GetPixel(i, j).B;
                }
            }
            resultR = resultR / (sourceImage.Width * sourceImage.Height);
            resultG = resultG / (sourceImage.Width * sourceImage.Height);
            resultB = resultB / (sourceImage.Width * sourceImage.Height);
            average = (resultR + resultG + resultB) / 3;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((float)(i + sourceImage.Width) / resultImage.Width * 50));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, Color.FromArgb(Clamp((int)(sourceImage.GetPixel(i, j).R * average / resultR), 0, 255),
                                                              Clamp((int)(sourceImage.GetPixel(i, j).G * average / resultG), 0, 255),
                                                              Clamp((int)(sourceImage.GetPixel(i, j).B * average / resultB), 0, 255)));
                }
            }
            return resultImage;
        }
    }
}
