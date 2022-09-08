using System;

namespace AreaCalculator
{
    public class Triangle : IFigure
    {
        private double _sideA;
        private double _sideB;
        private double _sideC;
        private const double Accuracy = 0.000001;

        public Triangle(double sideA, double sideB, double sideC)
        {
            if(sideA < 0 || sideB < 0 || sideC < 0)
            {
                throw new ArgumentException("Все стороны треугольника должны быть положительными!");
            }
            _sideA = sideA;
            _sideB = sideB;
            _sideC = sideC;
            CorrectSides();
        }

        public double CountArea()
        {
            var area = IsRightTriangle() ? CountRightTriangleArea() : CountSimpleArea();
            return Math.Round(area, 2);
        }

        private void CorrectSides()
        {
            if (_sideA > _sideC)
            {
                _sideA = ChangeSideC(_sideA);
            }

            if (_sideB > _sideC)
            {
                _sideB = ChangeSideC(_sideB);
            }
        }

        private double ChangeSideC(double side)
        {
            var temp = _sideC;
            _sideC = side;
            return temp;
        }

        //Проверка на теорему Пифагора
        private bool IsRightTriangle()
        {
            return Math.Abs(_sideA * _sideA + _sideB * _sideB - _sideC * _sideC) < Accuracy; // Если в треугольнике присутствуют стороны, длина которых не является целым числом,
                                                                                             // сказать, что треугольник прямоугольный, можно только с определенной точностью
        }

        private double CountRightTriangleArea()
        {
            return _sideA * _sideB / 2;
        }

        private double CountSimpleArea()
        {
            var semiPerimeter = CountSemiPerimeter();
            return Math.Sqrt(semiPerimeter * (semiPerimeter - _sideA) * (semiPerimeter - _sideB) * (semiPerimeter - _sideC));
        }

        private double CountSemiPerimeter()
        {
            return (_sideA + _sideB + _sideC) / 3;
        }
    }
}