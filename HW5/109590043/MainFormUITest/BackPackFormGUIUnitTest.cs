using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace MainFormUITest
{
    [TestClass()]
    public class BackPackFormGUIUnitTest
    {
        private Robot _robot;
        private string targetAppPath;
        private const string MENU_FORM = "MenuForm";
        private const string BOOKPACK_FORM = "BackPackForm";
        private readonly string[] _array = new string[]
        {
            "歸還",
            "1",
            "暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫",
            "1",
            DateTime.Now.ToString("yyyy/MM/dd"),
            DateTime.Now.AddDays(30).ToString("yyyy/MM/dd"),
            "415.92 844 2021",
            "艾德里安.雷恩",
            "遠流, 2021[民110]"
        };

        // init
        [TestInitialize()]
        public void Initialize()
        {
            var projectName = "HW05";
            string solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
            targetAppPath = Path.Combine(solutionPath, projectName, "bin", "Debug", "HW03.exe");
            _robot = new Robot(targetAppPath, MENU_FORM);
            _robot.ClickButton("Book Borrowing System");
            _robot.SwitchTo("BookBorrowingForm");
            _robot.ClickButton("查看我的書包");
            _robot.SwitchTo(BOOKPACK_FORM);
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
        public void TestDGVData()
        {
            _robot.AssertDataGridViewRowCountBy("_dataGridView1", 0);
            _robot.SwitchTo("BookBorrowingForm");
            _robot.ClickElementById("2");
            _robot.ClickButton("加入借書單");
            _robot.ClickButton("確認借書");
            _robot.ClickButton("確定");
            _robot.SwitchTo(BOOKPACK_FORM);
            _robot.AssertDataGridViewRowCountBy("_dataGridView1", 1);
            _robot.AssertDataGridViewRowDataBy("_dataGridView1", 0, _array);
            _robot.ClickDataGridViewCellBy("_dataGridView1", 0, "還書");
            _robot.AssertDataGridViewRowCountBy("_dataGridView1", 0);
            _robot.ClickButton("確定");
        }
    }
}
