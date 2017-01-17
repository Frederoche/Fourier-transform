using System;


namespace _2DDFT
{
    public class Filters
    {
        public int Size { get; set; }
        public Filters(int size)
        {
            Size = size;
        }
        public  Complex[][] OneOnFBeta(Complex[][] complex)
        {
            var result = new Complex[Size][];

            for (var i = 0; i < Size; i++)
            {
                result[i] = new Complex[Size];

                for (var j = 0; j < Size; j++)
                {
                    var d = Math.Sqrt((i - 128)*(i - 128)/ Size + (j - 128)*(j - 128)/ Size);
                    d = d < 1.0/256 ? 1.0/ Size : d;

                    result[i][j] = complex[i][j] * (float)( 1.0 / Math.Pow(d, 1.3));
                }
            }
            return result;
        }
    }
    
}
