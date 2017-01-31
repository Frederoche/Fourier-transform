using System;

namespace Fourier
{
    public class Distributions
    {
        public int Seed { get; set; }
        private Random Random { get;}

        public Distributions(int seed)
        {
            Seed = seed;
            Random = new Random(Seed);
        }
        public double Rand()
        {
            return Random.NextDouble();
        }
    }
}
