using System;
using System.Windows.Forms;
using QuoridorApp.View;

namespace QuoridorApp.Controller
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            HomeForm homeForm = new HomeForm();
            Application.Run(homeForm);
        }
    }
}