using System;
using System.Windows.Forms;

namespace Homework
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
            MenuForm menu = new MenuForm(model);
            Application.Run(menu);
        }
    }
}
