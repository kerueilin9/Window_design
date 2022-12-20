using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DrawingModel.Tests
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

        //Test
        [TestMethod()]
        public void GetSelectedPositionTest()
        {
            const string SAMPLE = "Selectde：Triangle(500, 400, 600, 500)";
            _triangle.IsContains(550, 450);
            Assert.AreEqual(SAMPLE, _triangle.GetSelectedPosition());
        }
    }
}