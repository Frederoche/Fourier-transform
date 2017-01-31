using System;

namespace Fourier.Filter
{
    public class Filters
    {
        public int Size { get; set; }
        public Filters(int size)
        {
            Size = size;
        }
        public  Complex[][] ButterWorthLowPassFilter(Complex[][] complex) 
        {
            var result = new Complex[Size][];

            for (var i = 0; i < Size; i++)
            {
                result[i] = new Complex[Size];

                for (var j = 0; j < Size; j++)
                {
                    var d = Math.Sqrt((i- Size/2) * (i-Size/2)/ Size + (j-Size/2)*(j-Size/2) / Size );

                    d = d < 1.0/Size ? 1.0 / Size : d;

                    result[i][j] = complex[i][j] * (float)(1.0f / Math.Pow(d, 1.2));
                }
            }
            return result;
        }

        
    }
    
}
