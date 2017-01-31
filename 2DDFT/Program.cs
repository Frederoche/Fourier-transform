using System;

namespace _2DDFT
{
    class Program
    {
        static void Main(string[] args)
        {
            var display = new Display(256);

            var fft2D = new FFT2D(256);

            Console.WriteLine("--------------------2DDFT--------------------------");
            var whiteNoise = new WhiteNoise(256, 256,1);
            var bitmap = whiteNoise.Create("C:\\tmp\\whitenoise.jpg");
            
            var phillips = new Phillips(256,256,1);
            var phillipsSepctrum = phillips.Create();

            display.Magnitude(phillipsSepctrum, "C:\\tmp\\phillips.jpg");

            var transform4 = fft2D.Inverse(phillipsSepctrum);


            display.Picture(transform4, "C:\\tmp\\transform4.jpg");

            Console.WriteLine("--------------------Read Image---------------------");
            

            var bitmap2 = display.ReadImage("C:\\tmp\\cln1.gif");

            /*Console.WriteLine("--------------------Beginning DDFT-----------------");
            var transform =  DFT2D.Forward(bitmap);
            display.Magnitude(transform, "C:\\tmp\\transform.jpg");
            Console.WriteLine("--------------------Ending DDFT--------------------");*/

            Console.WriteLine("--------------------Beginning FFT------------------");
            

            var transform2 = fft2D.Forward(bitmap2);
            display.Magnitude(transform2, "C:\\tmp\\transform2.jpg");
            Console.WriteLine("--------------------Ending FFT---------------------");
            Console.WriteLine("--------------------Beging FFTInv------------------");
        
            var result = new Filters(256).ButterWorthLowPassFilter(transform2);
            
            display.Magnitude(result, "C:\\tmp\\filteredImage.jpg");


            var transform3 = fft2D.Inverse(result);
            display.Picture(transform3, "C:\\tmp\\transform3.jpg");

            Console.WriteLine("--------------------Ending FFT---------------------");

            Console.ReadLine();
        }
    }
}
