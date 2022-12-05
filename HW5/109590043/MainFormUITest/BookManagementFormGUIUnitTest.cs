using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace MainFormUITest
{
    [TestClass()]
    public class BookManagementFormGUIUnitTest
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
            _robot.ClickButton("Book Management System");
            _robot.SwitchTo("BookManagementForm");
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
        public void TestTextBoxEnable()
        {
            _robot.AssertEnableById("_nameTextBox", false);
            _robot.AssertEnableById("_idTextBox", false);
            _robot.AssertEnableById("_authorTextBox", false);
            _robot.AssertEnableById("_categoryComboBox", false);
            _robot.AssertEnableById("_publisherTextBox", false);
            _robot.AssertEnableById("_fileTextBox", false);
            _robot.AssertEnableById("_browse", false);
            _robot.ClickButton("零零落落");
            _robot.AssertEnableById("_nameTextBox", true);
            _robot.AssertEnableById("_idTextBox", true);
            _robot.AssertEnableById("_authorTextBox", true);
            _robot.AssertEnableById("_categoryComboBox", true);
            _robot.AssertEnableById("_publisherTextBox", true);
            _robot.AssertEnableById("_fileTextBox", true);
            _robot.AssertEnableById("_browse", true);
        }

        //test
        [TestMethod()]
        public void TestSaveEnable()
        {
            _robot.AssertEnableById("_save", false);
            _robot.ClickButton("零零落落");
            _robot.AssertEnableById("_save", false);
            _robot.ClickElementById("_nameTextBox");
            _robot.SendKey("我");
            _robot.AssertEnable("儲存", true);
            _robot.ClickElementById("_idTextBox");
            _robot.SendKey("^a{BACKSPACE}");
            _robot.AssertEnable("儲存", false);
        }
    }
}
