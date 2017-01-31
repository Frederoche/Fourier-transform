namespace Fourier.Phillips
{
    public class WindDirection
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    public class K
    {
        public float Kx { get; set; }
        public float Ky { get; set; }
    }

    public class PhillipsParameter
    {
        public K K { get; set; }
        public WindDirection WindDirection { get; set; }
        public float WindSpeed { get; set; }
        public float A { get; set; }
        public float G { get; set; }
    }
}
