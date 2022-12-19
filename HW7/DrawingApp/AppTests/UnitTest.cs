using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using Moq;

namespace DrawingApp.PresentationModel.Tests
{
    [TestClass()]
    public class AppPresentationModelTests
    {
        AppPresentationModel presentation;
        Model model;
        Mock<IGraphics> _mock;

        //TestInitialize
        [TestInitialize()]
        public void TestInitialize()
        {
            model = new Model();
            _mock = new Mock<IGraphics>();
            presentation = new AppPresentationModel(model, _mock.Object);
        }

        //Test
        [TestMethod()]
        public void TestDraw()
        {
            presentation.Draw();
        }
    }
}
