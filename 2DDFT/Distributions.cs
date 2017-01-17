using System;

namespace _2DDFT
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
