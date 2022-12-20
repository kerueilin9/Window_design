using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class CommandManagerTests
    {
        public Model _model;
        public Shapes _shapes;
        const string TRIANGLE = "Triangle";
        const string RECTANGLE = "Rectangle";
        const string LINE = "Line";
        CommandManager _command;

        //TestInitialize
        [TestInitialize()]
        public void TestInitialize()
        {
            _model = new Model();
            _shapes = new Shapes();
            _command = new CommandManager();
        }

        //Test
        [TestMethod()]
        public void UndoTest()
        {
            Shape shape = _shapes.CreateShape(TRIANGLE, new double[] { 1, 2, 3, 4 });
            _command.Execute(new DrawCommand(_model, shape));
            Assert.AreEqual(true, _command.IsUndoEnabled);
            _command.Undo();
            Assert.AreEqual(false, _command.IsUndoEnabled);
        }

        //Test
        [TestMethod()]
        public void RedoTest()
        {
            Shape shape = _shapes.CreateShape(TRIANGLE, new double[] { 1, 2, 3, 4 });
            _command.Execute(new DrawCommand(_model, shape));
            Assert.AreEqual(true, _command.IsUndoEnabled);
            _command.Undo();
            Assert.AreEqual(true, _command.IsRedoEnabled);
            _command.Redo();
            Assert.AreEqual(false, _command.IsRedoEnabled);
        }
    }
}