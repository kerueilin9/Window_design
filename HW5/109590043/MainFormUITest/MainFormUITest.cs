using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace MainFormUITest
{
    /// <summary>
    /// Summary description for MainFormUITest
    /// </summary>
    [TestClass()]
    public class MainFormUITest
    {
        private Robot _robot;
        private const string APP_NAME = "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App";
        private const string CALCULATOR_TITLE = "小算盤";
        private const string EXPECTED_VALUE = "顯示是 444";
        private const string RESULT_CONTROL_NAME = "CalculatorResults";
        private string targetAppPath;
        private const string MENU_FORM = "MenuForm";
        private const string BOOK_BORROWING_FORM = "BookBorrowingForm";
        private const string BOOKPACK_FORM = "BackPackForm";
        private const string LIMIT_MESSAGE = "同一本書限借兩次";
        private DateTime date = new DateTime();
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

        /// <summary>
        /// Launches the Calculator
        /// </summary>
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

        /// <summary>
        /// Tests that the result of 123 + 321 should be 444
        /// </summary>
        [TestMethod()]
        public void TestAddButton()
        {
            _robot.ClickElementById("_bookBorrowingSystem");
            _robot.SwitchTo(BOOK_BORROWING_FORM);
            _robot.ClickElementById("2");
            _robot.AssertEnable("加入借書單", true);
            _robot.ClickButton("加入借書單");
            _robot.ClickDataGridViewCellBy("_dataGridView1", 0, "數量");
            _robot.SendKey("3");
            _robot.AssertMessageBox(LIMIT_MESSAGE);
            _robot.ClickButton("確定");
            _robot.ClickButton("確認借書");
            _robot.AssertMessageBox("【暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫】2本\r\n\r\n已成功借出!");
            _robot.ClickButton("確定");
        }

        //test
        [TestMethod()]
        public void TestReturnBook()
        {
            _robot.ClickElementById("_bookBorrowingSystem");
            _robot.SwitchTo(BOOK_BORROWING_FORM);
            _robot.ClickButton("查看我的書包");
            _robot.ClickElementById("2");
            _robot.ClickButton("加入借書單");
            _robot.ClickButton("確認借書");
            _robot.ClickButton("確定");
            _robot.AssertText("_restCount", "剩餘數量：2");
            _robot.SwitchTo(BOOKPACK_FORM);
            _robot.AssertDataGridViewRowDataBy("_dataGridView1", 0, _array);
            _robot.ClickDataGridViewCellBy("_dataGridView1", 0, "還書");
            _robot.AssertDataGridViewRowCountBy("_dataGridView1", 0);
            _robot.ClickButton("確定");
            _robot.SwitchTo(BOOK_BORROWING_FORM);
            _robot.AssertText("_restCount", "剩餘數量：3");
        }
    }
}