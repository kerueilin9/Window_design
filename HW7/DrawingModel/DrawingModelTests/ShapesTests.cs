using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class ShapesTests
    {
        public Shapes _shapes;
        const string TRIANGLE = "Triangle";
        const string RECTANGLE = "Rectangle";
        const string LINE = "Line";
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
            Shape shape =  _shapes.CreateShape(TRIANGLE, new double[] { 1, 2, 3, 4 });
            Assert.AreEqual(shape.X1, 1);
            Assert.AreEqual(shape.Y1, 2);
            Assert.AreEqual(shape.X2, 3);
            Assert.AreEqual(shape.Y2, 4);
            Shape shape1 = _shapes.CreateShape(TRIANGLE, new double[] { 1, 2, 3, 4 });
            Shape shape2 = _shapes.CreateShape(TRIANGLE, new double[] { 8, 9, 10, 11 });
            Shape shape3 = _shapes.CreateShape(LINE, new Shape[] { shape1, shape2 });
            Assert.AreEqual(shape3.FirstShape, shape1);
            Assert.AreEqual(shape3.SecondShape, shape2);
        }

        //Test
        [TestMethod()]
        public void RemoveTest()
        {
            Shape shape = _shapes.CreateShape(TRIANGLE, new double[] { 1, 2, 3, 4 });
            _shapes.AddShapeDirect(shape);
            Assert.AreEqual(_shapes.GetShapes().Count, 1);
            _shapes.Remove();
            Assert.AreEqual(_shapes.GetShapes().Count, 0);
        }

        //Test
        [TestMethod()]
        public void DrawTest()
        {
            Shape shape = _shapes.CreateShape(TRIANGLE, new double[] { 1, 2, 3, 4 });
            _shapes.AddShapeDirect(shape);
            Shape shape1 = _shapes.CreateShape(TRIANGLE, new double[] { 1, 2, 3, 4 });
            _shapes.AddShapeDirect(shape1);
            Shape shape3 = _shapes.CreateShape(LINE, new Shape[] { shape, shape1 });
            _shapes.AddShapeDirect(shape3);
            _shapes.Draw(_mock.Object);
        }

        //Test
        [TestMethod()]
        public void CheckPointContainsTest()
        {
            Shape shape = _shapes.CreateShape(TRIANGLE, new double[] { 10, 11, 50, 51 });
            _shapes.AddShapeDirect(shape);
            Shape shape1 = _shapes.CheckPointContains(15, 20);
            Assert.AreEqual(shape1.X1, 10);
            Assert.AreEqual(shape1.Y1, 11);
            Assert.AreEqual(shape1.X2, 50);
            Assert.AreEqual(shape1.Y2, 51);
            Shape shape2 = _shapes.CheckPointContains(1, 2);
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