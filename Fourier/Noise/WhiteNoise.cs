using System.Drawing;
using System.Drawing.Imaging;

namespace Fourier.Noise
{
    public class WhiteNoise : Distributions
    {
        public int Size { get; set; }
        
        public WhiteNoise(int size, int seed) : base(seed)
        {
            Size = size;
        }

        public Bitmap Create(string filePath)
        {
            var bitmap = new Bitmap(Size, Size);

            for(var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    var pixelValue = Rand();
                    
                    var color = Color.FromArgb((int)(pixelValue*255), (int)(pixelValue*255), (int)(pixelValue*255));
                    
                    bitmap.SetPixel(i, j, color);
                }
            }
            
            bitmap.Save(filePath, ImageFormat.Jpeg);
            return bitmap;
        }
    }
}
