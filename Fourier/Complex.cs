using System;

namespace Fourier
{
    public class Complex
    {
        public float Real { get; set; }
        public float Imaginary { get; set; }

        public Complex(float real, float imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static float Modulus(Complex number)
        {
            return (float)Math.Sqrt(number.Real*number.Real + number.Imaginary*number.Imaginary);
        }

        public static Complex Polar(float r, float angle)
        {
            return new Complex((float)(r * Math.Cos(angle)),(float)( r * Math.Sin(angle)));
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }

        public static Complex operator +(float a, Complex b)
        {
            return new Complex(b.Real + a , b.Imaginary);
        }

        public static Complex operator +(Complex a, float b)
        {
            return new Complex(a.Real + b, a.Imaginary);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }

        public static Complex operator *(float a, Complex b)
        {
            return new Complex(b.Real*a, b.Imaginary*a);
        }

        public static Complex operator *(Complex a, float b)
        {
            return new Complex(a.Real * b, a.Imaginary * b);
        }

        public static Complex operator /(Complex b, float a)
        {
            return new Complex(b.Real / a, b.Imaginary / a);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Real * b.Imaginary + a.Imaginary * b.Real);
        }

        public static Complex Conjugate(Complex a)
        {
            return new Complex(a.Real,-a.Imaginary);
        }

        public static Complex operator /(float a, Complex b)
        {
            return new Complex(a/b.Real, a/b.Imaginary);
        }

        public static bool IsNaN(Complex a)
        {
            return float.IsNaN(a.Imaginary) || float.IsNaN(a.Real);
        }
    }
}
