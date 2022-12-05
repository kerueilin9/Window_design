using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using GeoAPI.Geometries;
using System.Drawing;

namespace ClassLibrary.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        Mock<IGraphics> _mock;
        Triangle _triangle;
        const string TRIANGLE = "Triangle";

        //TestInitialize
        [TestInitialize()]
        public void TestInitialize()
        {
            _mock = new Mock<IGraphics>();
            _triangle = new Triangle();
            _triangle.X1 = 500;
            _triangle.Y1 = 400;
            _triangle.X2 = 600;
            _triangle.Y2 = 500;
        }

        //Test
        [TestMethod()]
        public void DrawTest()
        {
            _triangle.Draw(_mock.Object);
        }

        //Test
        [TestMethod()]
        public void GetShapeTypeTest()
        {
            Assert.AreEqual(TRIANGLE, _triangle.GetShapeType());
        }
    }
}