using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag08.InterfaceExcersice.Lib
{
    public class Bar : IShape
    {
        private double Height;
        private double Width;
        private double Length;

        public Bar(double height, double width, double length)
        {
            Height = height;
            Width = width;
            Length = length;
        }

        public double CalculateVolume() => Height * Width * Length;

        public double CalculateSurface()
        {
            double surfaceLongWalls = (Height * Width) * 2;
            double surfaceShortWalls = (Height * Length) * 2;
            return surfaceLongWalls + surfaceShortWalls;
        }
    }
}