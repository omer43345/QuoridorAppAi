using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuoridorApp.View;
using QuoridorApp.Controller;
using QuoridorApp.Model;

namespace QuoridorApp
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
            GameForm gameForm = new GameForm();
            GameFormController.GetInstance().InitializeGameFormController((GameForm) gameForm);
            Application.Run(gameForm);



            
        }
    }
}