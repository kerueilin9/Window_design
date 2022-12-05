using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using GeoAPI.Geometries;
using Moq;

namespace ClassLibrary.Tests
{
    [TestClass()]
    public class RectangleTests
    {
        Mock<IGraphics> _mock;
        Rectangle _rectangle;
        const string RECTANGLE = "Rectangle";

        //TestInitialize
        [TestInitialize()]
        public void TestInitialize()
        {
            _mock = new Mock<IGraphics>();
            _rectangle = new Rectangle();
            _rectangle.X1 = 500;
            _rectangle.Y1 = 400;
            _rectangle.X2 = 600;
            _rectangle.Y2 = 500;
        }

        //Test
        [TestMethod()]
        public void DrawTest()
        {
            _rectangle.Draw(_mock.Object);
        }

        //Test
        [TestMethod()]
        public void GetShapeTypeTest()
        {
            Assert.AreEqual(RECTANGLE, _rectangle.GetShapeType());
        }
    }
}