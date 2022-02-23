using ManegerTests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_Builder;

namespace ManagerTests
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Directory.Exists("Tests"))
            {
                Application.Run(new ManagerTestsForm());
            }
            else
            {
                Application.Run(new StartForm());
                Application.Run(new ManagerTestsForm());
            }
        }
    }
}
