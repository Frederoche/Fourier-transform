using System;
using System.Drawing;

namespace Fourier.DFT
{
    public static class Display
    {
        public static Bitmap ReadImage(string path)
        {
            return new Bitmap(Image.FromFile(path));
        }

        public static void ToPicture(this float[,] transform, string path)
        {
            var size = transform.GetLength(1);

            var image = new Bitmap(size, size);

            var max = 0.0;
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    if (max < transform[i, j])
                        max = transform[i, j];
                }
            }

            for (var l = 0; l < size; l++)
            {
                for (var k = 0; k < size; k++)
                {
                    var pixelValue = transform[l, k];
                    var color = Color.FromArgb((int)(pixelValue / max * 255), (int)(pixelValue / max * 255), (int)(pixelValue / max * 255));
                    image.SetPixel(l, k, color);
                }
            }
            image.Save(path);
        }

        //FROM MUTIDIMENTIONAL ARRAY TO JAGGED ARRAY 
        public static void Magnitude(this Complex[,] transform, string path)
        {
            var size = transform.GetLength(1);

            Complex[][] floatTransform = new Complex[size][];

            for (var i = 0; i < size; i++)
            {
                floatTransform[i] = new Complex[size];

                for (var j = 0; j < size; j++)
                {
                    floatTransform[i][j] = transform[i,j];
                }
            }

            Magnitude(floatTransform, path);
        }

        public static Complex[][] Magnitude(this Complex[][] transform, string path)
        {
            var size = transform.Length;

            float[,] floatTransform = new float[size, size];

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    floatTransform[i, j] = Complex.Modulus(transform[i][j]);
                }
            }

            var max = 0.0;

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    if (max < floatTransform[i, j])
                        max = floatTransform[i, j];
                }
            }

            var image = new Bitmap(size, size);

            for (var l = 0; l < size; l++)
            {
                for (var k = 0; k < size; k++)
                {
                    var pixelValue = Math.Log10(1 + floatTransform[l, k]) * 255 / Math.Log10(1 + max);

                    if(!double.IsNaN(pixelValue))
                    { 
                        var color = Color.FromArgb((int)pixelValue, (int)pixelValue, (int)pixelValue);

                        image.SetPixel(l, k, color);
                    }
                }
            }
            image.Save(path);
            return transform;
        }
    }
}
