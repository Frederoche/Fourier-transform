using System;

namespace Fourier.Phillips
{
    public class Phillips : Distributions
    {
        public int Size { get; set; }

        public Phillips(int size, int seed) : base(seed)
        {
            Size = size;
        }

        public Complex[][] Create()
        {
            var result = new float[Size][];
            var complexResult = new Complex[Size][];

            float max = 0;

            for (var i = 0; i < Size; i++)
            {
                result[i] = new float[Size];
                complexResult[i] = new Complex[Size];

                for (var j = 0; j < Size; j++)
                {
                    var parameter = new PhillipsParameter
                    {
                        K = new K
                        {
                            Kx = (float) (2.0 * Math.PI / Size) * (-Size/2 + i),
                            Ky = (float) (2.0 * Math.PI / Size) * (-Size/2 + j)
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
