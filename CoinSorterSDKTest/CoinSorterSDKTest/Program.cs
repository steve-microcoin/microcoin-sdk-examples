using Astrosys.Logging;
using System;
using System.Windows.Forms;

namespace CoinSorterSDKTest
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
            //Initialize logging form and pass it to main form
            Application.Run(new MainForm(new LoggingForm()));
        }
    }
}
