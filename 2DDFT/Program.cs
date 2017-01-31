using System;
using System.Drawing;
using _2DDFT.Fourier;
using _2DDFT.Noise;

namespace _2DDFT
{
    class Program
    {
        static Bitmap GenerateWhiteNoise()
        {
            var whiteNoise = new WhiteNoise(256, 1);
            return whiteNoise.Create("C:\\tmp\\whitenoise.jpg");
        }

        static Complex[][] GeneratePhillipsSpectrum()
        {
            var phillips = new Phillips.Phillips(256, 1);
            return phillips.Create();
        }

        static void Main(string[] args)
        {
            //WHITE NOISE GENERATION
            var whitenoise = GenerateWhiteNoise();

            //PHILLIPS SPECTRUM FREQUENCY AND SPATIAL DOMAIN
            var phillipsSpectrum = GeneratePhillipsSpectrum().Magnitude("C:\\tmp\\phillipsSpectrum.jpg");
            new FFT2D(256).Inverse(phillipsSpectrum).ToPicture("C:\\tmp\\phillipsSpatialDomain.jpg");

            //BUTTERWORTH FILTERING IN FREQUESNCY DOMAIN
            var bitmap2 = Display.ReadImage("C:\\tmp\\lena.gif");

            var transform2 = new FFT2D(256).Forward(bitmap2).Magnitude("C:\\tmp\\SpectrumForwardTransform.jpg");
            
            var result = new Filters(256).ButterWorthLowPassFilter(transform2);

            result.Magnitude("C:\\tmp\\filteredImageWithButterWorth.jpg");

            new FFT2D(256).Inverse(result).ToPicture("C:\\tmp\\Inversetransform.jpg");
        }
    }
}
