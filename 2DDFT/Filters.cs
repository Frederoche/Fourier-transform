using System;


namespace _2DDFT
{
    public class Filters
    {
        public static Complex[][] OneOnFBeta(Complex[][] complex)
        {
            var result = new Complex[256][];

            for (var i = 0; i < 256; i++)
            {
                result[i] = new Complex[256];

                for (var j = 0; j < 256; j++)
                {
                    var d = Math.Sqrt((i - 128)*(i - 128)/256 + (j - 128)*(j - 128)/256);
                    d = d < 1.0/256 ? 1.0/256.0 : d;

                    result[i][j] = complex[i][j] * (float)( 1.0 / Math.Pow(d, 1.3));
                }
            }
            return result;
        }
    }
    
}
