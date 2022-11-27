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
        private const string BOOK_MANAGEMENT_FORM = "BookManagementForm";
        private const string BOOKPACK_FORM = "BackPackForm";
        private const string BOOK_INVENTORY_FORM = "BookInventoryForm";
        private const string REPLENISHMENT_FORM = "SupplementForm";
        private const string LIMIT_MESSAGE = "同一本書限借兩次";
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

        //test
        [TestMethod()]
        public void TestInventoryView()
        {
            _robot.ClickElementById("_bookBorrowingSystem");
            _robot.ClickElementById("_bookInventorySystem");
            _robot.SwitchTo(BOOK_BORROWING_FORM);
            _robot.ClickButton("查看我的書包");
            _robot.ClickElementById("2");
            _robot.ClickButton("加入借書單");
            _robot.ClickButton("確認借書");
            _robot.ClickButton("確定");
            //_robot.AssertText("_restCount", "剩餘數量：2");
            _robot.SwitchTo(BOOK_INVENTORY_FORM);
            _robot.AssertDataGridViewDataBy("_dataGridView1", 2, "數量", "2");
            _robot.SwitchTo(BOOKPACK_FORM);
            _robot.AssertDataGridViewRowDataBy("_dataGridView1", 0, _array);
            _robot.ClickDataGridViewCellBy("_dataGridView1", 0, "還書");
            _robot.ClickButton("確定");
            _robot.SwitchTo(BOOK_INVENTORY_FORM);
            _robot.AssertDataGridViewDataBy("_dataGridView1", 2, "數量", "3");
        }

        //test
        [TestMethod()]
        public void TestInventoryFunction()
        {
            _robot.ClickElementById("_bookInventorySystem");
            _robot.SwitchTo(BOOK_INVENTORY_FORM);
            _robot.ClickDataGridViewCellBy("_dataGridView1", 6, "數量");
            _robot.AssertText("_richTextBox1", "草莓與灰燼\r編號：863.55 8533 2022\r作者：房慧真\r麥田出版 : 英屬蓋曼群島商家庭傳媒股份有限公司城邦分公司發行, 2022[民111]");
            _robot.ClickDataGridViewCellBy("_dataGridView1", 6, "補貨");
            _robot.AssertText("_richTextBox2", "書籍名稱：草莓與灰燼\r\r書籍類別：4月暢銷書\r庫存數量：1");
            _robot.ClickElementById("_cancel");
            _robot.AssertDataGridViewDataBy("_dataGridView1", 6, "數量", "1");
        }

        //test
        [TestMethod()]
        public void TestInventoryAndBorrowingView()
        {
            _robot.ClickElementById("_bookBorrowingSystem");
            _robot.ClickElementById("_bookInventorySystem");
            _robot.SwitchTo(BOOK_INVENTORY_FORM);
            _robot.ClickDataGridViewCellBy("_dataGridView1", 0, "補貨");
            _robot.ClickElementById("_textSupplyCount");
            _robot.SendKey("2");
            _robot.Sleep(1);
            _robot.ClickElementById("_confirm");
            _robot.AssertDataGridViewDataBy("_dataGridView1", 0, "數量", "7");
            _robot.SwitchTo(BOOK_BORROWING_FORM);
            _robot.ClickElementById("0");
            _robot.AssertText("_restCount", "剩餘數量：7");
        }

        //test
        [TestMethod()]
        public void TestManagementForm1()
        {
            _robot.ClickElementById("_bookManagementSystem");
            _robot.SwitchTo(BOOK_MANAGEMENT_FORM);
            _robot.ClickButton("零零落落");
            _robot.ClickElementById("_nameTextBox");
            _robot.SendKey("我");
            _robot.AssertEnable("儲存", true);
            _robot.ClickElementById("_idTextBox");
            _robot.SendKey("^a{BACKSPACE}");
            _robot.AssertEnable("儲存", false);
        }

        //test
        [TestMethod()]
        public void TestManagementForm2()
        {
            _robot.ClickElementById("_bookBorrowingSystem");
            _robot.ClickElementById("_bookManagementSystem");
            _robot.SwitchTo(BOOK_MANAGEMENT_FORM);
            _robot.ClickButton("微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書");
            _robot.ClickElementById("_authorTextBox");
            _robot.SendKeyToTextBox("_authorTextBox", "^aJames Clear");
            _robot.ClickElementById("_idTextBox");
            _robot.SendKeyToTextBox("_idTextBox", "^a1234567");
            _robot.ClickElementById("_nameTextBox");
            _robot.SendKeyToTextBox("_nameTextBox", "^a原子習慣");
            _robot.ClickElementById("_categoryComboBox");
            _robot.ClickButton("職場必讀");
            _robot.ClickButton("儲存");

            _robot.SwitchTo(BOOK_BORROWING_FORM);
            _robot.ClickTabControl("職場必讀");
            _robot.ClickButton("下一頁");
            _robot.ClickElementById("19");
            _robot.AssertText("_richTextBox1", "原子習慣\r編號：1234567\r作者：James Clear\r原點出版 : 大雁發行, 2021[民110]");
        }

        //test
        [TestMethod()]
        public void TestManagementForm3()
        {
            _robot.ClickElementById("_bookInventorySystem");
            _robot.ClickElementById("_bookManagementSystem");
            _robot.SwitchTo(BOOK_MANAGEMENT_FORM);
            _robot.ClickButton("微調有差の日系新版面設計 : 一本前所未有、聚焦於「微調細節差很大」的設計參考書");
            _robot.ClickElementById("_authorTextBox");
            _robot.SendKeyToTextBox("_authorTextBox", "^aJames Clear");
            _robot.ClickElementById("_idTextBox");
            _robot.SendKeyToTextBox("_idTextBox", "^a1234567");
            _robot.ClickElementById("_nameTextBox");
            _robot.SendKeyToTextBox("_nameTextBox", "^a原子習慣");
            _robot.ClickElementById("_categoryComboBox");
            _robot.ClickButton("職場必讀");
            _robot.ClickButton("儲存");

            _robot.SwitchTo(BOOK_INVENTORY_FORM);
            _robot.ClickButton("向下翻頁");
            _robot.ClickDataGridViewCellBy("_dataGridView1", 19, "數量");
            _robot.AssertText("_richTextBox1", "原子習慣\r編號：1234567\r作者：James Clear\r原點出版 : 大雁發行, 2021[民110]");
        }
    }
}