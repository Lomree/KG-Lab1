using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;


namespace Lab1
{
    abstract class MathMorphologyFilter : Filters
    {
        protected int radius;
        protected int[,] kernel = null;
        protected MathMorphologyFilter() { }
        public MathMorphologyFilter(int[,] kernel)
        {
            this.kernel = kernel;
            radius = kernel.GetLength(0) / 2;
        }

        public void setKernel(int[,] kernel)
        {
            this.kernel = kernel;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = radius; i < sourceImage.Width - radius; i++)
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = radius; j < sourceImage.Height - radius; j++)
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
            }
            return resultImage;
        }

        protected override Color calculateNewPixelColor(Bitmap SourceImage, int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
