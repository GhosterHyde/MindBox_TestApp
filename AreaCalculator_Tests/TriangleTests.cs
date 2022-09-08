using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreaCalculator;
using System;

namespace AreaCalculator_Tests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void SimpleAreaCount()
        {
            const double sideA = 1;
            const double sideB = 7;
            const double sideC = 3;
            IFigure triangle = new Triangle(sideA, sideB, sideC);
            var expecting = CountSimpleTriangleArea(sideA, sideB, sideC);
            Assert.AreEqual(expecting, triangle.CountArea());
        }

        [TestMethod]
        public void RightTriangleAreaCount()
        {
            const double sideA = 3;
            const double sideB = 5;
            const double sideC = 4;
            IFigure triangle = new Triangle(sideA, sideB, sideC);
            var expecting = CountRightTriangleArea(sideA, sideC);
            Assert.AreEqual(expecting, triangle.CountArea());
        }

        [TestMethod]
        public void SimpleNonIntegerAreaCount()
        {
            const double sideA = 1.2;
            const double sideB = 7.53;
            const double sideC = 3.197;
            IFigure triangle = new Triangle(sideA, sideB, sideC);
            var expecting = CountSimpleTriangleArea(sideA, sideB, sideC);
            Assert.AreEqual(expecting, triangle.CountArea());
        }

        [TestMethod]
        public void RightTriangleNonIntegerAreaCount()
        {
            const double sideA = 3.2;
            const double sideB = 4.6;
            var sideC = Math.Sqrt(sideA * sideA + sideB * sideB);
            IFigure triangle = new Triangle(sideA, sideB, sideC);
            var expecting = CountRightTriangleArea(sideA, sideB);
            Assert.AreEqual(expecting, triangle.CountArea());
        }

        [TestMethod]
        public void NonIntegerFirstSideException()
        {
            const double sideA = -1;
            const double sideB = 7;
            const double sideC = 3;
            Assert.ThrowsException<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
        }

        [TestMethod]
        public void NonIntegerSecondSideException()
        {
            const double sideA = 1;
            const double sideB = -7;
            const double sideC = 3;
            Assert.ThrowsException<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
        }

        [TestMethod]
        public void NonIntegerThirdSideException()
        {
            const double sideA = 1;
            const double sideB = 7;
            const double sideC = -3;
            Assert.ThrowsException<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
        }

        private static double CountSimpleTriangleArea(double sideA, double sideB, double sideC)
        {
            var semiPerimeter = (sideA + sideB + sideC) / 3;
            return Math.Round(Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC)), 2);
        }
        private static double CountRightTriangleArea(double legA, double legB)
        {
            return Math.Round(legA * legB / 2, 2);
        }
    }
}
            