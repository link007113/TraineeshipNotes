namespace Dag08.InterfaceExcersice.Lib
{
    public class Sphere : IShape
    {
        private double Radius;

        public Sphere(double radius)
        {
            Radius = radius;
        }

        public double CalculateVolume() => 4.0 / 3 * Math.PI * Radius * Radius * Radius;

        public double CalculateSurface() => 4.0 * Math.PI * Radius * Radius;
    }
}