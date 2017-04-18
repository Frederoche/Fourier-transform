using System;
using System.CodeDom.Compiler;
using Fourier;
using Fourier.DFT;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FourierTestProject
{
    [TestClass]
    public class FourierTests
    {
        [TestMethod]
        public void FourierTest()
        {
            //ARRANGE
            var input = new []
            {
                new Complex(0,0),
                new Complex(1,0),
                new Complex(2,0),
                new Complex(3,0),
                new Complex(4,0),
                new Complex(5,0),
                new Complex(6,0),
                new Complex(7,0)
            };

            var fft = new FFT(input.Length);

            //ACT
            var result = fft.Forward(input, false);


            //ASSERT 
            var expected = new []
            {
                new Complex(28, 0),
                new Complex(-4.0f, 9.6569f),
                new Complex(-4.0f, 4.0f),
                new Complex(-4.0f, 1.6569f),
                new Complex(-4, 0.0f),
                new Complex(-4, -1.6569f),
                new Complex(-4, -4.0000f),
                new Complex(-4, -9.6569f)
            };

            for (var i = 0; i < expected.Length; i++)
            {
               Assert.AreEqual(expected[i].Real, Math.Round(result[i].Real), "fft result Real");
               Assert.AreEqual(Math.Round(expected[i].Imaginary, 4), Math.Round(result[i].Imaginary, 4), "fft result Imaginary");
            }
        }
    }
}
