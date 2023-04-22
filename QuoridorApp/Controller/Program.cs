using System;
using System.Windows.Forms;
using QuoridorApp.View;

namespace QuoridorApp.Controller
{
    // class that contains the main function of the program and runs the game
    static class Program
    {
        /// <summary>
        /// The main entry point for the application. it runs the game by creating a new HomeForm object and running it.
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