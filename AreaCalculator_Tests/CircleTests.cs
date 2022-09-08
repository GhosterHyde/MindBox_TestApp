using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreaCalculator;
using System;

namespace AreaCalculator_Tests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void CorrectIntegerRadiusAreaCount()
        {
            const double radius = 4;
            const double correctCircleArea = 16 * Math.PI;
            IFigure circle = new Circle(radius);
            Assert.AreEqual(correctCircleArea, circle.CountArea());
        }

        [TestMethod]
        public void CorrectNonIntegerRadiusAreaCount()
        {
            const double radius = 2.21;
            var correctCircleArea = Math.Round(Math.PI * Math.Pow(radius, 2), 2);
            IFigure circle = new Circle(radius);
            Assert.AreEqual(correctCircleArea, circle.CountArea());
        }

        [TestMethod]
        public void ZeroCircleArea()
        {
            const double radius = 0;
            const double expecting = 0;
            IFigure circle = new Circle(radius);
            Assert.AreEqual(expecting, circle.CountArea());
        }

        [TestMethod]
        public void NegativeRadiusException()
        {
            const double radius = -1;
            Assert.ThrowsException<ArgumentException>(() => new Circle(radius));
        }
    }
}
