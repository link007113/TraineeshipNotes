using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag08.InterfaceExcersice.Lib
{
    public class Cube : IShape
    {
        public double Side { get; set; }

        public Cube(double side)
        {
            Side = side;
        }

        public double CalculateVolume() => Side * Side * Side;

        public double CalculateSurface()
        {
            return ((Side * Side) * 4) * 2;
        }
    }
}