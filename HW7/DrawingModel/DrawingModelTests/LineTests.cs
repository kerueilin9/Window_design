using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class LineTests
    {
        Mock<IGraphics> _mock;
        Line _line;
        const string TRIANGLE = "Triangle";
        const string RECTANGLE = "Rectangle";
        const string LINE = "Line";
        public Shapes _shapes;

        //TestInitialize
        [TestInitialize()]
        public void TestInitialize()
        {
            _shapes = new Shapes();
            _mock = new Mock<IGraphics>();
            _line = new Line();
            Shape shape1 = _shapes.CreateShape(TRIANGLE, new double[] { 1, 2, 3, 4 });
            Shape shape2 = _shapes.CreateShape(TRIANGLE, new double[] { 8, 9, 10, 11 });
            _line.FirstShape = shape1;
            _line.SecondShape = shape2;
        }

        //Test
        [TestMethod()]
        public void DrawTest()
        {
            _line.Draw(_mock.Object);
            _line.SecondShape = null;
            _line.Draw(_mock.Object);
        }

        //Test
        [TestMethod()]
        public void IsContainsTest()
        {
            Assert.AreEqual(false, _line.IsContains(0, 0));
        }

        //Test
        [TestMethod()]
        public void GetShapeTypeTest()
        {
            Assert.AreEqual(LINE, _line.GetShapeType());
        }

        //Test
        [TestMethod()]
        public void GetSelectedPositionTest()
        {
            Assert.AreEqual("", _line.GetSelectedPosition());
        }
    }
}