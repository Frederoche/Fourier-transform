using System;

namespace _2DDFT
{
    public class Phillips : Distributions
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Phillips(int height, int width, int seed) : base(seed)
        {
            Height = height;
            Width = width;
        }

        public Complex[][] Create()
        {
            var result = new float[256][];
            var complexResult = new Complex[256][];

            float max = 0;

            for (var i = 0; i < Width; i++)
            {
                result[i] = new float[Width];
                complexResult[i] = new Complex[Width];

                for (var j = 0; j < Height; j++)
                {
                    var parameter = new PhillipsParameter
                    {
                        K = new K
                        {
                            Kx = (float) (2.0 * Math.PI / Width) * (-Width/2 + i),
                            Ky = (float) (2.0 * Math.PI / Width) * (-Width/2 + j)
                        },
                        WindDirection = new WindDirection
                        {
                            X = 1,
                            Y = 0.7f
                        },

                        WindSpeed = 10000,
                        G = (float)9.81,
                        A = 100

                    };

                    complexResult[i][j] = CalculateH0(PhillipsSpectrum(parameter));
                    complexResult[i][j] += Complex.Conjugate(complexResult[i][j]);
                }
            }

           
            return complexResult;
        }

        private Complex CalculateH0(float input)
        {
            return Complex.Polar(1,(float)(Rand()*2*Math.PI)) * (float) (Math.Sqrt(input) / Math.Sqrt(2));
        } 
    
        private float PhillipsSpectrum(PhillipsParameter parameter)
        {
            var kNormalized = Math.Sqrt(parameter.K.Kx * parameter.K.Kx + parameter.K.Ky * parameter.K.Ky);
            var L = parameter.WindSpeed * parameter.WindSpeed / parameter.G;

            var kx = parameter.K.Kx / kNormalized;
            var ky = parameter.K.Ky / kNormalized;

            var windkdot = kx * parameter.WindDirection.X + ky*parameter.WindDirection.Y;

            return (float) (parameter.A/(kNormalized*kNormalized*kNormalized*kNormalized)*
                            Math.Exp(-1.0/(kNormalized*kNormalized*L*L))*windkdot*windkdot);
        }

    }
}
