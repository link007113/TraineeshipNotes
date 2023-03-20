using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag05.VolumeExerciseLibrary
{
    public class Sphere
    {
        double Radius;

        public Sphere(double radius)
        {
            Radius = radius;
        }

        public double CalculateVolume() => 4.0 / 3 * Math.PI * Radius * Radius * Radius;
        public double CalculateSurface() => 4.0 * Math.PI * Radius * Radius;
    }
}
