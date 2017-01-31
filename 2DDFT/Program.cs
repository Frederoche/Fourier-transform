using System;
using System.Drawing;
using Fourier;
using Fourier.DFT;
using Fourier.Filter;
using Fourier.Noise;

namespace _2DDFT
{
    class Program
    {
        private static readonly string Path = AppDomain.CurrentDomain.BaseDirectory;
        static Bitmap GenerateWhiteNoise()
        {
            var whiteNoise = new WhiteNoise(256, 1);
            return whiteNoise.Create($"{Path}\\whitenoise.jpg");
        }

        static Complex[][] GeneratePhillipsSpectrum()
        {
            var phillips = new Fourier.Phillips.Phillips(256, 1);
            return phillips.Create();
        }

        static void Main(string[] args)
        {
            //WHITE NOISE GENERATION
            var whitenoise = GenerateWhiteNoise();

            //PHILLIPS SPECTRUM FREQUENCY AND SPATIAL DOMAIN
            var phillipsSpectrum = GeneratePhillipsSpectrum().Magnitude($"{Path}\\phillipsSpectrum.jpg");
            new FFT2D(256).Inverse(phillipsSpectrum).ToPicture($"{Path}\\phillipsSpatialDomain.jpg");

            //BUTTERWORTH FILTERING IN FREQUESNCY DOMAIN
            var bitmap2 = Display.ReadImage($"{Path}\\Pictures\\lena.gif");

            var transform2 = new FFT2D(256).Forward(bitmap2).Magnitude($"{Path}\\SpectrumForwardTransform.jpg");
            
            var result = new Filters(256).ButterWorthLowPassFilter(transform2);

            result.Magnitude($"{Path}\\filteredImageWithButterWorth.jpg");

            new FFT2D(256).Inverse(result).ToPicture($"{Path}\\Inversetransform.jpg");
        }
    }
}
