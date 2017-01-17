using System;
using System.Drawing;


namespace _2DDFT
{
    public class FFT2D : FFT
    {
        public static float[,] Inverse(Complex[][] inputComplex)
        {
            var p = new Complex[256][];
            var f = new Complex[256][];
            var t = new Complex[256][];

            var floatImage = new float[256, 256];

            //CALCULATE P
            for (var l = 0; l < 256; l++)
            {
                p[l] = FFT1DInv(inputComplex[l]);
            }

            //TRANSPOSE AND COMPUTE
            for (var l = 0; l < 256; l++)
            {
                t[l] = new Complex[256];

                for (var k = 0; k < 256; k++)
                {
                    t[l][k] = p[k][l];
                }

                f[l] = FFT1DInv(t[l]);
            }

            for (var k = 0; k < 256; k++)
            {
                for (var l = 0; l < 256; l++)
                {
                    floatImage[k, l] = Math.Abs(f[k][l].Real);
                }
            }
            return floatImage;
        }

        public static Complex[][] Forward(Bitmap image)
        {
            var p = new Complex[image.Width][];
            var f = new Complex[image.Width][];
            var t = new Complex[image.Width][];

            //CONVERT TO COMPLEX NUMBERS
            var complexImage = ToComplex(image);

            //CALCULATE P
            for (var l = 0; l < image.Width; l++)
            {
                p[l] = FFT1D(complexImage[l]);
            }

            //TANSPOSE AND COMPUTE
            for (var l = 0; l < image.Width; l++)
            {
                t[l] = new Complex[image.Width];

                for (var k = 0; k < image.Width; k++)
                {
                    t[l][k] = p[k][l];
                }

                f[l] = FFT1D(t[l]);
            }

            return f;
        }
    }
}
