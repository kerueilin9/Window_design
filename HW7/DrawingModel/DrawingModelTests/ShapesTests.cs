using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using Moq;

namespace ClassLibrary.Tests
{
    [TestClass()]
    public class ShapesTests
    {
        public Shapes _shapes;
        const string TRIANGLE = "Triangle";
        const string RECTANGLE = "Rectangle";
        Mock<IGraphics> _mock;

        //TestInitialize
        [TestInitialize()]
        public void TestInitialize()
        {
            _shapes = new Shapes();
            _mock = new Mock<IGraphics>();
        }

        //Test
        [TestMethod()]
        public void CreateShapeHintTest()
        {
            Assert.AreEqual(TRIANGLE, _shapes.CreateShapeHint(TRIANGLE).GetShapeType());
            Assert.AreEqual(RECTANGLE, _shapes.CreateShapeHint(RECTANGLE).GetShapeType());
            Assert.AreEqual(null, _shapes.CreateShapeHint(""));
        }

        //Test
        [TestMethod()]
        public void CreateShapeTest()
        {
            _shapes.CreateShape(TRIANGLE, new double[] { 1, 2, 3, 4 });
            Assert.AreEqual(_shapes.GetShapes().First().X1, 1);
            Assert.AreEqual(_shapes.GetShapes().First().Y1, 2);
            Assert.AreEqual(_shapes.GetShapes().First().X2, 3);
            Assert.AreEqual(_shapes.GetShapes().First().Y2, 4);
        }

        //Test
        [TestMethod()]
        public void DrawTest()
        {
            _shapes.CreateShape(TRIANGLE, new double[] { 1, 2, 3, 4 });
            _shapes.Draw(_mock.Object);
        }

        //Test
        [TestMethod()]
        public void ClearTest()
        {
            _shapes.CreateShape(TRIANGLE, new double[] { 1, 2, 3, 4 });
            _shapes.Clear();
            Assert.AreEqual(0, _shapes.GetShapes().Count());
        }
    }
}