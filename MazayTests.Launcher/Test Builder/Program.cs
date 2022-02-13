using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_Builder
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
            else Application.Run(new StartForm());
            FakeGenerateTest fakeTest = new();
            fakeTest.SerializeTest(fakeTest.GetInteractiveTest());
            fakeTest.Deserialize();
            
        }
    }
}
