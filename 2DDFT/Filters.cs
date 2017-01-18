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
        public  Complex[][] ButterWorthLowPassFilter(Complex[][] complex) //DO NOT WORK
        {
            var result = new Complex[Size][];

            for (var i = 0; i < Size; i++)
            {
                result[i] = new Complex[Size];

                for (var j = 0; j < Size; j++)
                {
                    var d = Math.Sqrt((i) * (i) + (j)*(j));

                    var h = 1/((1 + 2*d/Size)*(1 + 2*d/Size * (1 + 2 * d /Size)));

                    

                    result[i][j] = complex[i][j] * (float)h;
                }
            }
            return result;
        }
    }
    
}
