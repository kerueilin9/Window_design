using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace MainFormUITest
{
    [TestClass()]
    public class MenuFormGUIUnitTest
    {
        private Robot _robot;
        private string targetAppPath;
        private const string MENU_FORM = "MenuForm";

        // init
        [TestInitialize()]
        public void Initialize()
        {
            var projectName = "HW05";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "HW03.exe");
            _robot = new Robot(targetAppPath, MENU_FORM);
        }

        /// <summary>
        /// Closes the launched program
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        //test
        [TestMethod()]
        public void TestBorrowingBtn()
        {
            _robot.AssertEnable("Book Borrowing System", true);
            _robot.ClickButton("Book Borrowing System");
            _robot.AssertEnable("Book Borrowing System", false);
        }

        //test
        [TestMethod()]
        public void TestInventoryBtn()
        {
            _robot.AssertEnable("Book Inventory System", true);
            _robot.ClickButton("Book Inventory System");
            _robot.AssertEnable("Book Inventory System", false);
        }

        //test
        [TestMethod()]
        public void TestManagementBtn()
        {
            _robot.AssertEnable("Book Management System", true);
            _robot.ClickButton("Book Management System");
            _robot.AssertEnable("Book Management System", false);
        }
    }
}
