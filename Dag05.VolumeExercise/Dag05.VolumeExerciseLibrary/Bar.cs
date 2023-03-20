namespace Dag05.VolumeExerciseLibrary
{
    public class Bar
    {
        double Height;
        double Width;
        double Length;

        public Bar(double height, double width, double length)
        {
            Height = height;
            Width = width;
            Length = length;
        }

        public double CalculateVolume() => Height * Width *Length;
        public double CalculateSurface()
        {
            double surfaceLongWalls = (Height * Width) * 2;
            double surfaceShortWalls = (Height * Length) * 2;
            return surfaceLongWalls + surfaceShortWalls;
        }

    }
}