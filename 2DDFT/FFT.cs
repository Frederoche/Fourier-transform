using System;
using System.Drawing;

namespace _2DDFT
{
    public class FFT
    {
        public static Complex[][] ToComplex(Bitmap image)
        {
            var result = new Complex[image.Width][];

            for (var i = 0; i < image.Width; i++)
            {
                result[i] = new Complex[image.Width];

                for (var j = 0; j < image.Height; j++)
                {
                    var pixel = new Complex(image.GetPixel(i, j).R, 0);

                    result[i][j] = pixel;
                }
            }
            return result;
        }

        public static Complex[] FFT1DInv(Complex[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = Complex.Conjugate(input[i]);
            }

            var transform = FFT1D(input);

            for (int i = 0; i < input.Length; i++)
            {
                transform[i] = Complex.Conjugate(transform[i]);
            }
            return transform;
        }

        public static Complex[] FFT1D(Complex[] input)
        {
            var result = new Complex[input.Length];
            var omega = (float)(-2.0 * Math.PI / input.Length);

            if (input.Length == 1)
            {
                result[0] = input[0];
                return result;
            }

            var evenInput = new Complex[input.Length / 2];
            var oddInput  = new Complex[input.Length / 2];

            for (var i = 0; i < input.Length/2; i++)
            {
                evenInput[i] = input[2 * i];
                oddInput[i]  = input[2 * i + 1];
            }

            var even = FFT1D(evenInput);
            var odd  = FFT1D(oddInput);

            for (var k = 0; k < input.Length/2; k++)
            {
                var tmp = Complex.Polar(1, omega * k);
                odd[k] *= tmp;
            }

            for (var k = 0; k < input.Length / 2; k++)
            {
                result[k]                     = even[k] +  odd[k];
                result[k + input.Length / 2]  = even[k] -  odd[k];
            }

            return result;
        }
    }
}
