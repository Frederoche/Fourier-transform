using System;

namespace _2DDFT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------2DDFT--------------------------");
            var whiteNoise = new WhiteNoise(256, 256,1);
            var bitmap = whiteNoise.Create("C:\\tmp\\whitenoise.jpg");
            Console.WriteLine("--------------------Read Image---------------------");
            var bitmap2 = Display.ReadImage("C:\\tmp\\whitenoise.jpg");

            /*Console.WriteLine("--------------------Beginning DDFT-----------------");
            var transform =  DFT2D.Forward(bitmap2);
            Display.Magnitude(transform, "C:\\tmp\\transform.jpg");
            Console.WriteLine("--------------------Ending DDFT--------------------");*/

            Console.WriteLine("--------------------Beginning FFT------------------");
            var transform2 = FFT2D.Forward(bitmap2);
            Display.Magnitude(transform2, "C:\\tmp\\transform2.jpg");
            Console.WriteLine("--------------------Ending FFT---------------------");
            Console.WriteLine("--------------------Beging FFTInv------------------");

            var result = Filters.OneOnFBeta(transform2);

            var transform3 = FFT2D.Inverse(result);
            Display.Picture(transform3, "C:\\tmp\\transform3.jpg");

            Console.WriteLine("--------------------Ending FFT---------------------");

            Console.ReadLine();
        }
    }
}
