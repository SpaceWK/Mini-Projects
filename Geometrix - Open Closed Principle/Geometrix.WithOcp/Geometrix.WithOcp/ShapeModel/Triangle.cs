using System;

namespace RemoteLearning.Geometrix.WithOcp.ShapeModel
{
    internal class Triangle : IShape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public double CalculateArea()
        {
            double semiperimeter = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(semiperimeter * (semiperimeter - SideA) * (semiperimeter - SideB) * (semiperimeter - SideC));
        }
    }
}
