using System;

using System.Net;
using System.Security;
using System.Windows.Forms;

namespace eFrizer.Win
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //InstallCertificate();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InitScreen());
        }

        

        
    }
}
