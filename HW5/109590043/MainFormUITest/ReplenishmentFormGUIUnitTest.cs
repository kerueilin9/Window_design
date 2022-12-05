using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace MainFormUITest
{
    [TestClass()]
    public class ReplenishmentFormGUIUnitTest
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
            _robot.ClickButton("Book Inventory System");
            _robot.SwitchTo("BookInventoryForm");
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
        public void TestConfirmEnable()
        {
            _robot.ClickDataGridViewCellBy("_dataGridView1", 6, "補貨");
            _robot.AssertEnableById("_confirm", true);
            _robot.ClickElementById("_cancel");
        }

        //test
        [TestMethod()]
        public void TestCancelEnable()
        {
            _robot.ClickDataGridViewCellBy("_dataGridView1", 6, "補貨");
            _robot.AssertEnableById("_cancel", true);
            _robot.ClickElementById("_cancel");
        }

        //test
        [TestMethod()]
        public void TestTextBoxEnable()
        {
            _robot.ClickDataGridViewCellBy("_dataGridView1", 6, "補貨");
            _robot.AssertEnableById("_textSupplyCount", true);
            _robot.ClickElementById("_cancel");
        }

        //test
        [TestMethod()]
        public void TestRichTextBox()
        {
            _robot.ClickDataGridViewCellBy("_dataGridView1", 6, "補貨");
            _robot.AssertText("_richTextBox2", "書籍名稱：草莓與灰燼\r\r書籍類別：4月暢銷書\r庫存數量：1");
            _robot.ClickElementById("_cancel");
        }
    }
}
