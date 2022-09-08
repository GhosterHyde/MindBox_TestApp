using System;

namespace AreaCalculator
{
    public class Circle : IFigure
    {
        private readonly double _radius;
        public Circle(double radius)
        {
            if(radius < 0)
            {
                throw new ArgumentException("Радиус круга не может быть отрицательным!");
            }
            _radius = radius;
        }
        public double CountArea()
        {
            return Math.Round(Math.PI * Math.Pow(_radius, 2), 2);
        }
    }
}
