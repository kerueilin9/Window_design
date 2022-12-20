using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class ShapeFactoryTests
    {
        const string TRIANGLE = "Triangle";
        const string RECTANGLE = "Rectangle";
        const string LINE = "Line";

        //Test
        [TestMethod()]
        public void CreateShapeTest()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            Assert.AreEqual(null, shapeFactory.CreateShape(""));
            Assert.AreEqual(TRIANGLE, shapeFactory.CreateShape(TRIANGLE).GetShapeType());
            Assert.AreEqual(RECTANGLE, shapeFactory.CreateShape(RECTANGLE).GetShapeType());
            Assert.AreEqual(LINE, shapeFactory.CreateShape(LINE).GetShapeType());
        }
    }
}