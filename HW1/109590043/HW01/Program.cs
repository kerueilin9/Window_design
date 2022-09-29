using System;
using System.Windows.Forms;

namespace Homework01
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Model model = new Model();
            Form1 bookBorrowingFrom = new Form1(model);
            Application.Run(bookBorrowingFrom);
        }
    }
}
