using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingForm.PresentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using Moq;

namespace DrawingForm.PresentationModel.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        PresentationModel presentation;
        Model model;
        Mock<IGraphics> _mock;

        //TestInitialize
        [TestInitialize()]
        public void TestInitialize()
        {
            model = new Model();
            presentation = new PresentationModel(model);
            _mock = new Mock<IGraphics>();
        }

        [TestMethod()]
        public void DrawTest()
        {
            presentation.Draw(_mock.Object);
        }
    }
}