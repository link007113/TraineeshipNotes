namespace Dag05.VolumeExerciseLibrary
{
    public abstract record Shape
    {
        public double Diameter() => this switch
        {
            Cube(double z) => Math.Sqrt(z),
            Bar(double x, double y, double z) => Math.Sqrt(x * x + y * y + z * z),
            Sphere(double r) => 2 * r,
        };
    }

    public record Bar(double height, double width, double length) : Shape;
    public record Sphere(double Straal) : Shape;
    public record Cube(double Edge) : Bar(Edge, Edge, Edge);
}