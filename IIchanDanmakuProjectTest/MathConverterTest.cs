using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFML.System;
using IIchanDanmakuProject.Helpers;

namespace IIchanDanmakuProjectTest
{
    [TestClass]
    public class MathConverterTest
    {
        [TestMethod]
        public void CartesianToPolarCoordinateTestMethod()
        {
            Vector2f cartesian = new Vector2f(5,3);
            PolarVector polarVectorDegree = cartesian.CartesianToPolarCoordinateDegrees();
            Assert.IsTrue(Math.Abs(polarVectorDegree.r - 5.83) < 0.05 & Math.Abs(polarVectorDegree.theta - 30.963) < 0.05);
        }

        [TestMethod]
        public void PolarToCartesianCoordinateTestMethod()
        {
            PolarVector polarVectorDegree = new PolarVector(5, 30);
            Vector2f vector = polarVectorDegree.PolarToCartesianCoordinateDegrees();
            Assert.IsTrue(Math.Abs(vector.X - 4.33) < 0.05 & Math.Abs(vector.Y - 2.5) < 0.05);
        }

    }
}
