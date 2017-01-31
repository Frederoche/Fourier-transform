using System;
using System.Drawing;

namespace Fourier.DFT
{
    public class DFT2D
    {
        public static Complex[,] Forward(Bitmap image)
        {
            var omega = (float) (-2.0 * Math.PI/image.Width);

            var P = new Complex[image.Width, image.Width];
            var F = new Complex[image.Width,image.Width];

            //Calculate P
            for (var k = 0; k < image.Width; k++)
            {
                for (var b = 0; b < image.Width; b++)
                {
                    var p = new Complex(0, 0);

                    for (var a = 0; a < image.Width; a++)
                    {
                        p += image.GetPixel(a, b).R * Complex.Polar(1, omega * (k - image.Width / 2) * a); //Phase Shifted
                    }

                    P[k, b] = p;
                }
            }

            //Calculate F
            for (var k = 0; k < image.Width; k++)
            {
                for (var l = 0; l < image.Width; l++)
                {
                    var f = new Complex(0, 0);

                    for (var b = 0; b < image.Width; b++)
                    {
                        f += P[k, b] * Complex.Polar(1, omega * (l - image.Width / 2) * b);
                    }

                    F[k, l] = f;
                }
            }
            return F;
        }
    }
}
