using System.Drawing;
using System.Drawing.Imaging;

namespace _2DDFT
{
    public class WhiteNoise : Distributions
    {
        public int Height { get; set; }
        public int Width  { get; set; }
        
        public WhiteNoise(int height, int width, int seed) : base(seed)
        {
            Height = height;
            Width = width;
        }

        public Bitmap Create(string filePath)
        {
            var bitmap = new Bitmap(Width, Height);

            for(var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
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
