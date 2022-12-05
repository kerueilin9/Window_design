using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace MainFormUITest
{
    [TestClass()]
    public class BookInventoryFormGUIUnitTest
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
        public void TestRichTextBox()
        {
            _robot.ClickDataGridViewCellBy("_dataGridView1", 6, "數量");
            _robot.AssertText("_richTextBox1", "草莓與灰燼\r編號：863.55 8533 2022\r作者：房慧真\r麥田出版 : 英屬蓋曼群島商家庭傳媒股份有限公司城邦分公司發行, 2022[民111]");
        }
    }
}
