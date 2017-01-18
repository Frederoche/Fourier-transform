using System;
using System.Drawing;

namespace _2DDFT
{
    public class Display
    {
        public int Size { get; set; }
        
        public Display(int size)
        {
            Size = size;
        }

        public Bitmap ReadImage(string path)
        {
            return new Bitmap(Image.FromFile(path));
        }

        public  void Picture(float[,] transform, string path)
        {
            var image = new Bitmap(Size, Size);

            var max = 0.0;
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (max < transform[i, j])
                        max = transform[i, j];
                }
            }

            for (var l = 0; l < Size; l++)
            {
                for (var k = 0; k < Size; k++)
                {
                    var pixelValue = transform[l, k];
                    var color = Color.FromArgb((int)(pixelValue / max * 255), (int)(pixelValue / max * 255), (int)(pixelValue / max * 255));
                    image.SetPixel(l, k, color);
                }
            }
            image.Save(path);
        }

        //FROM MUTIDIMENTIONAL ARRAY TO JAGGED ARRAY 
        public void Magnitude(Complex[,] transform, string path)
        {
            Complex[][] floatTransform = new Complex[Size][];

            for (var i = 0; i < Size; i++)
            {
                floatTransform[i] = new Complex[Size];

                for (var j = 0; j < Size; j++)
                {
                    floatTransform[i][j] = transform[i,j];
                }
            }

            Magnitude(floatTransform, path);
        }

        public  void Magnitude(Complex[][] transform, string path)
        {
            float[,] floatTransform = new float[Size, Size];

            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    floatTransform[i, j] = Complex.Modulus(transform[i][j]);
                }
            }

            var max = 0.0;
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (max < floatTransform[i, j])
                        max = floatTransform[i, j];
                }
            }

            var image = new Bitmap(Size, Size);

            for (var l = 0; l < Size; l++)
            {
                for (var k = 0; k < Size; k++)
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
