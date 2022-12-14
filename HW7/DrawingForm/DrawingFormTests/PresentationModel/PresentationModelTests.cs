using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingForm.PresentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using DrawingForm;
using Moq;

namespace DrawingForm.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        FormPresentationModel presentationModel;
        Model model;
        Mock<IGraphics> _mock;

        //TestInitialize
        [TestInitialize()]
        public void TestInitialize()
        {
            model = new Model();
            presentationModel = new FormPresentationModel(model);
            _mock = new Mock<IGraphics>();
        }

        //Test
        [TestMethod()]
        public void DrawTest()
        {
            presentationModel.Draw(_mock.Object);
        }
    }
}