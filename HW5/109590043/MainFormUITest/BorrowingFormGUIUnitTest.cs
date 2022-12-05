using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace MainFormUITest
{
    [TestClass()]
    public class BorrowingFormGUIUnitTest
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
            _robot.ClickButton("Book Borrowing System");
            _robot.SwitchTo("BookBorrowingForm");
        }

        // TestCleanup
        [TestCleanup()]
        public void Cleanup()
        {
            _robot.CleanUp();
        }

        // TestMethod
        [TestMethod()]
        public void TestTabControl()
        {
            _robot.ClickTabControl("4月暢銷書");
            _robot.AssertText("_richTextBox1", "");
            _robot.ClickElementById("4");
            string book4Content = "煤氣燈操縱 : 辨識人際中最暗黑的操控術, 走出精神控制與內疚, 重建自信與自尊\r編號：177.3 8333:3 2022\r作者：艾米.馬洛-麥柯\r麥田出版 : 家庭傳媒城邦分公司發行, 2022[民111]";
            _robot.AssertText("_richTextBox1", book4Content);
        }

        // TestMethod
        [TestMethod()]
        public void TestRichTextBox()
        {
            _robot.ClickElementById("0");
            string book0Content = "微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書\r編號：964 8394:2-5 2021\r作者：ingectar-e\r原點出版 : 大雁發行, 2021[民110]";
            _robot.AssertText("_richTextBox1", book0Content);
        }

        // TestMethod
        [TestMethod()]
        public void TestBookRestLabel()
        {
            _robot.ClickElementById("1");
            _robot.AssertText("_restCount", "剩餘數量：1");
        }

        // TestMethod
        [TestMethod()]
        public void TestPageLabel()
        {
            _robot.AssertText("_page", "Page：1/2");
            _robot.ClickButton("下一頁");
            _robot.AssertText("_page", "Page：2/2");
        }

        // TestMethod
        [TestMethod()]
        public void TestPageUp()
        {
            _robot.AssertEnable("上一頁", false);
            _robot.ClickButton("下一頁");
            _robot.AssertEnable("上一頁", true);
        }

        // TestMethod
        [TestMethod()]
        public void TestPageDown()
        {
            _robot.AssertEnable("下一頁", true);
            _robot.ClickButton("下一頁");
            _robot.AssertEnable("下一頁", false);
        }

        // TestMethod
        [TestMethod()]
        public void TestAddBook()
        {
            _robot.AssertEnable("加入借書單", false);
            _robot.ClickElementById("2");
            _robot.AssertEnable("加入借書單", true);
            _robot.ClickButton("加入借書單");
            _robot.AssertEnable("加入借書單", false);
        }

        // TestMethod
        [TestMethod()]
        public void TestBorrowingCountLabel()
        {
            _robot.AssertText("_borrowBookCount", "借書數量：");
            _robot.ClickElementById("1");
            _robot.ClickButton("加入借書單");
            _robot.AssertText("_borrowBookCount", "借書數量：1");
            _robot.ClickElementById("2");
            _robot.ClickButton("加入借書單");
            _robot.AssertText("_borrowBookCount", "借書數量：2");
        }

        // TestMethod
        [TestMethod()]
        public void TestBorrowingButton()
        {
            _robot.AssertEnable("確認借書", false);
            _robot.ClickElementById("0");
            _robot.ClickButton("加入借書單");
            _robot.AssertEnable("確認借書", true);
            _robot.ClickButton("確認借書");
            _robot.CloseMessageBox();
            _robot.AssertEnable("確認借書", false);
        }

        // TestMethod
        [TestMethod()]
        public void TestBorrowingDataView()
        {
            _robot.AssertDataGridViewRowCountBy("_dataGridView1", 0);
            _robot.ClickElementById("2");
            _robot.ClickButton("加入借書單");
            _robot.AssertDataGridViewRowCountBy("_dataGridView1", 1);
            string[] array = { "", "暴力犯罪的大腦檔案 : 從神經犯罪學探究惡行的生物根源, 慎思以治療取代懲罰的未來防治計畫", "1", "415.92 844 2021", "艾德里安.雷恩", "遠流, 2021[民110]" };
            _robot.AssertDataGridViewRowDataBy("_dataGridView1", 0, array);
            _robot.ClickDataGridViewCellBy("_dataGridView1", 0, "刪除");
            _robot.AssertDataGridViewRowCountBy("_dataGridView1", 0);
        }

        // TestMethod
        [TestMethod()]
        public void TestOpenBackPackButton()
        {
            _robot.AssertEnable("查看我的書包", true);
            _robot.ClickButton("查看我的書包");
            _robot.SwitchTo("BackPackForm");
            _robot.SwitchTo("BookBorrowingForm");
            _robot.AssertEnable("查看我的書包", false);
            _robot.SwitchTo("BackPackForm");
            _robot.CloseWindow();
            _robot.SwitchTo("BookBorrowingForm");
            _robot.AssertEnable("查看我的書包", true);

        }
    }
}
