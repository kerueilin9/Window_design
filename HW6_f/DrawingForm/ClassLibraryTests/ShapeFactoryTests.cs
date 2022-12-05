using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Tests
{
    [TestClass()]
    public class ShapeFactoryTests
    {
        const string TRIANGLE = "Triangle";
        const string RECTANGLE = "Rectangle";

        //Test
        [TestMethod()]
        public void CreateShapeTest()
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            Assert.AreEqual(null, shapeFactory.CreateShape(""));
            Assert.AreEqual(TRIANGLE, shapeFactory.CreateShape(TRIANGLE).GetShapeType());
            Assert.AreEqual(RECTANGLE, shapeFactory.CreateShape(RECTANGLE).GetShapeType());
        }
    }
}