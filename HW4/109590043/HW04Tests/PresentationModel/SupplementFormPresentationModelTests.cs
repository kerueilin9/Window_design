using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework.PresentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.PresentationModel.Tests
{
    [TestClass()]
    public class SupplementFormPresentationModelTests
    {
        private Model model;
        SupplementFormPresentationModel presentationModel;

        [TestInitialize()]
        public void Initialize()
        {
            model = new Model("hw4_books_source.txt");
            presentationModel = new SupplementFormPresentationModel(model);
        }

        [TestMethod()]
        public void ReturnCountTest()
        {
            Assert.AreEqual(0, presentationModel.ReturnCount(""));
            Assert.AreEqual(0, presentationModel.ReturnCount("0"));
        }
    }
}