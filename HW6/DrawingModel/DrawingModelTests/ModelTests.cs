using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Moq;

namespace ClassLibrary.Tests
{
    [TestClass()]
    public class ModelTests
    {
        PrivateObject privateObject;
        Model _model;
        public Shapes _shapes;
        const string TRIANGLE = "Triangle";
        const string RECTANGLE = "Rectangle";
        Mock<IGraphics> _mock;

        //TestInitialize
        [TestInitialize()]
        public void TestInitialize()
        {
            _model = new Model();
            _shapes = new Shapes();
            _mock = new Mock<IGraphics>();
            privateObject = new PrivateObject(_model);
        }

        //Test
        [TestMethod()]
        public void SetTypeTest()
        {
            _model.SetType(TRIANGLE);
            Assert.AreEqual(TRIANGLE, _model.GetTypeString());
            _model.SetType(RECTANGLE);
            Assert.AreEqual(RECTANGLE, _model.GetTypeString());
        }

        //Test
        [TestMethod()]
        public void PressedPointerTest()
        {
            _model.SetType(TRIANGLE);
            _model.PressedPointer(1, 2);
            Assert.AreEqual(1, _model.GetShape().X1);
            Assert.AreEqual(2, _model.GetShape().Y1);
        }

        //Test
        [TestMethod()]
        public void MovedPointerTest()
        {
            _model.SetType(TRIANGLE);
            _model.PressedPointer(1, 2);
            _model.MovedPointer(2, 3);
            Assert.AreEqual(2, _model.GetShape().X2);
            Assert.AreEqual(3, _model.GetShape().Y2);
        }

        //Test
        [TestMethod()]
        public void ReleasedPointerTest()
        {
            _model.SetType(TRIANGLE);
            _model.PressedPointer(1, 2);
            _model.MovedPointer(2, 3);
            _model.ReleasedPointer(2, 3);
            Assert.AreEqual(1, _model.GetShapes().GetShapes().First().X1);
            Assert.AreEqual(2, _model.GetShapes().GetShapes().First().Y1);
            Assert.AreEqual(2, _model.GetShapes().GetShapes().First().X2);
            Assert.AreEqual(3, _model.GetShapes().GetShapes().First().Y2);
        }

        //Test
        [TestMethod()]
        public void ClearTest()
        {
            _model.SetType(TRIANGLE);
            _model.PressedPointer(1, 2);
            _model.MovedPointer(2, 3);
            _model.ReleasedPointer(2, 3);
            _model.Clear();
            Assert.AreEqual(0, _model.GetShapes().GetShapes().Count());
        }

        //Test
        [TestMethod()]
        public void DrawTest()
        {
            _model.SetType(TRIANGLE);
            _model.PressedPointer(1, 2);
            _model.MovedPointer(2, 3);
            _model.Draw(_mock.Object);
            _mock.Verify(obj => obj.DrawTriangle(1, 2, 2, 3));
        }

        //Test
        [TestMethod()]
        public void TestUseAction()
        {
            Model.ModelChangedEventHandler action1 = null;
            int test = 0;
            privateObject.SetFieldOrProperty("_modelChanged", action1);
            //_shapes.NotifyModelChanged();
            privateObject.Invoke("NotifyModelChanged");
            Assert.AreEqual(0, test);
            action1 += () => {
                test = 2;
            };
            privateObject.SetFieldOrProperty("_modelChanged", action1);
            privateObject.Invoke("NotifyModelChanged");

            //model.UpdateBookItem();
            Assert.AreEqual(2, test);
        }
    }
}