using System;
using System.Drawing;

namespace _2DDFT
{
    public class Display
    {
        public static Bitmap ReadImage(string path)
        {
            return new Bitmap(Image.FromFile(path));
        }

        public static void Picture(float[,] transform, string path)
        {
            var image = new Bitmap(256, 256);

            var max = 0.0;
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    if (max < transform[i, j])
                        max = transform[i, j];
                }
            }

            for (var l = 0; l < 256; l++)
            {
                for (var k = 0; k < 256; k++)
                {
                    var pixelValue = transform[l, k];
                    var color = Color.FromArgb((int)(pixelValue / max * 255), (int)(pixelValue / max * 255), (int)(pixelValue / max * 255));
                    image.SetPixel(l, k, color);
                }
            }
            image.Save(path);
        }

        //FROM MUTIDIMENTIONAL ARRAY TO JAGGED ARRAY
        public static void Magnitude(Complex[,] transform, string path)
        {
            Complex[][] floatTransform = new Complex[256][];

            for (var i = 0; i < 256; i++)
            {
                floatTransform[i] = new Complex[256];

                for (var j = 0; j < 256; j++)
                {
                    floatTransform[i][j] = transform[i,j];
                }
            }

            Magnitude(floatTransform, path);
        }

        public static void Magnitude(Complex[][] transform, string path)
        {
            float[,] floatTransform = new float[256, 256];

            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    floatTransform[i, j] = Complex.Modulus(transform[i][j]);
                }
            }

            var max = 0.0;
            for (var i = 0; i < 256; i++)
            {
                for (var j = 0; j < 256; j++)
                {
                    if (max < floatTransform[i, j])
                        max = floatTransform[i, j];
                }
            }

            var image = new Bitmap(256, 256);

            for (var l = 0; l < 256; l++)
            {
                for (var k = 0; k < 256; k++)
                {
                    var pixelValue = Math.Log10(1 + floatTransform[l, k]) * 255 / Math.Log10(1 + max);
                    var color = Color.FromArgb((int)pixelValue, (int)pixelValue, (int)pixelValue);

                    image.SetPixel(l, k, color);
                }
            }
            image.Save(path);
        }
    }
}
