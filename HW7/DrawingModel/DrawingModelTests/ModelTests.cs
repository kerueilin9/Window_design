using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class ModelTests
    {
        PrivateObject privateObject;
        Model _model;
        public Shapes _shapes;
        const string TRIANGLE = "Triangle";
        const string RECTANGLE = "Rectangle";
        const string LINE = "Line";
        Mock<IGraphics> _mock;

        //TestInitialize
        [TestInitialize()]
        public void TestInitialize()
        {
            _model = new Model();
            _shapes = new Shapes();
            _mock = new Mock<IGraphics>();
            privateObject = new PrivateObject(_model);
            _model.SetType(RECTANGLE);
            _model.PressedPointer(10, 11);
            _model.ReleasedPointer(100, 101);
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
            _model.SetType("");
            _model.PressedPointer(1, 2);
            _model.SetType(LINE);
            _model.PressedPointer(15, 20);
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
            _model.PressedPointer(100, 101);
            _model.ReleasedPointer(200, 201);
            Assert.AreEqual(2, _model.GetShapes().GetShapes().Count);
            _model.SetType(LINE);
            _model.PressedPointer(50, 50);
            _model.ReleasedPointer(150, 150);
            Assert.AreEqual(3, _model.GetShapes().GetShapes().Count);
            _model.SetType(LINE);
            _model.PressedPointer(50, 50);
            _model.ReleasedPointer(150, 300);
            Assert.AreEqual(false, _model.IsLineEnabled());
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
            _model.Undo();
            _model.Redo();
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
            _model.SetType("");
            _model.PressedPointer(50, 50);
            _model.Draw(_mock.Object);
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

        //Test
        [TestMethod()]
        public void TestGetSelectedPosition()
        {
            const string SAMPLE = "Selectde：Rectangle(10, 11, 100, 101)";
            Assert.AreEqual("", _model.GetSelectedPosition());
            _model.PressedPointer(15, 20);
            Assert.AreEqual(SAMPLE, _model.GetSelectedPosition());
        }

        //Test
        [TestMethod()]
        public void TestUndo()
        {
            Assert.AreEqual(true, _model.IsUndoEnabled);
            _model.Undo();
            Assert.AreEqual(false, _model.IsUndoEnabled);
        }

        //Test
        [TestMethod()]
        public void TestRedo()
        {
            Assert.AreEqual(false, _model.IsRedoEnabled);
            _model.Undo();
            Assert.AreEqual(true, _model.IsRedoEnabled);
            _model.Redo();
            Assert.AreEqual(false, _model.IsRedoEnabled);
        }
    }
}