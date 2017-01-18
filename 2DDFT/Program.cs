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
            var display = new Display(256);

            var bitmap2 = display.ReadImage("C:\\tmp\\cln1.gif");

            /*Console.WriteLine("--------------------Beginning DDFT-----------------");
            var transform =  DFT2D.Forward(bitmap);
            display.Magnitude(transform, "C:\\tmp\\transform.jpg");
            Console.WriteLine("--------------------Ending DDFT--------------------");*/

            Console.WriteLine("--------------------Beginning FFT------------------");
            var fft2D = new FFT2D(256);

            var transform2 = fft2D.Forward(bitmap);
            display.Magnitude(transform2, "C:\\tmp\\transform2.jpg");
            Console.WriteLine("--------------------Ending FFT---------------------");
            Console.WriteLine("--------------------Beging FFTInv------------------");
        
            var result = new Filters(256).ButterWorthLowPassFilter(transform2);

            var transform3 = fft2D.Inverse(result);
            display.Picture(transform3, "C:\\tmp\\transform3.jpg");

            Console.WriteLine("--------------------Ending FFT---------------------");

            Console.ReadLine();
        }
    }
}
