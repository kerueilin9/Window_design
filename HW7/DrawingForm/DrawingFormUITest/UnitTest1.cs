using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace DrawingFormUITest
{
    [TestClass]
    public class UnitTest1
    {
        private Robot _robot;
        private string targetAppPath;
        private const string FROM = "Form1";
        const string TRIANGLE = "Triangle";
        const string RECTANGLE = "Rectangle";
        const string LINE = "Line";
        const string CANVAS = "Canvas";
        const string LABEL = "_shapePosition";

        /// <summary>
        /// Launches the Calculator
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
            var projectName = "DrawingForm";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "DrawingForm.exe");
            _robot = new Robot(targetAppPath, FROM);
        }

        /// <summary>
        /// Closes the launched program
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        //DragAndDrop
        [TestMethod]
        [Obsolete]
        public void TestDrawTriangle()
        {
            _robot.ClickButton(TRIANGLE);
            _robot.DragAndDrop(CANVAS, 50, 50, 200, 200);
            _robot.ClickOnCanvas(CANVAS, 100, 100);
            _robot.AssertText(LABEL, "Selectde：Triangle(50, 50, 200, 200)");
        }

        //DragAndDrop
        [TestMethod]
        [Obsolete]
        public void TestDrawRectangle()
        {
            _robot.ClickButton(RECTANGLE);
            _robot.DragAndDrop(CANVAS, 50, 50, 200, 200);
            _robot.ClickOnCanvas(CANVAS, 100, 100);
            _robot.AssertText(LABEL, "Selectde：Rectangle(50, 50, 200, 200)");
        }

        //DragAndDrop
        [TestMethod]
        [Obsolete]
        public void TestDrawLine()
        {
            _robot.ClickButton(RECTANGLE);
            _robot.DragAndDrop(CANVAS, 50, 50, 200, 200);
            _robot.ClickOnCanvas(CANVAS, 100, 100);
            _robot.AssertText(LABEL, "Selectde：Rectangle(50, 50, 200, 200)");
            _robot.ClickButton(TRIANGLE);
            _robot.DragAndDrop(CANVAS, 250, 50, 400, 200);
            _robot.ClickOnCanvas(CANVAS, 300, 100);
            _robot.AssertText(LABEL, "Selectde：Triangle(250, 50, 400, 200)");
            _robot.ClickButton(LINE);
            _robot.DragAndDrop(CANVAS, 100, 100, 300, 100);
        }
    }
}
