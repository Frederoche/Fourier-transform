using System;

namespace Fourier.DFT
{
    public class FFT
    {
        public int Size { get; set; }

        public FFT(int size)
        {
            Size = size;
        }

        public  Complex[] Inverse(Complex[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = Complex.Conjugate(input[i]);
            }

            var transform = Forward(input, false);

            for (int i = 0; i < input.Length; i++)
            {
                transform[i] = Complex.Conjugate(transform[i]);
            }
            return transform;
        }

        public  Complex[] Forward(Complex[] input, bool phaseShift = true)
        {
            var result = new Complex[input.Length];
            var omega = (float)(-2.0 * Math.PI / input.Length);

            if (input.Length == 1)
            {
                result[0] = input[0];

                if (Complex.IsNaN(result[0]))
                {
                    return new [] {new Complex(0,0)};
                }
                return result;
            }


            var evenInput = new Complex[input.Length / 2];
            var oddInput  = new Complex[input.Length / 2];

            for (var i = 0; i < input.Length/2; i++)
            {
                evenInput[i] = input[2 * i];
                oddInput[i]  = input[2 * i + 1];
            }

            var even = Forward(evenInput, phaseShift);
            var odd  = Forward(oddInput,  phaseShift);

            for (var k = 0; k < input.Length/2; k++)
            {
                int phase;

                if (phaseShift)
                    phase = k - Size/2;
                else
                    phase = k;

                odd[k] *= Complex.Polar(1, omega * phase);
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
