using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EveTrader.Helpers;

namespace EveTrader
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SingleApplication.Run(new Main.MainWindow());
        }
    }
}
