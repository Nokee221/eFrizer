using System;
using System.Management.Automation;
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

        private static void InstallCertificate()
        {
            SecureString theSecureString = new NetworkCredential("", "1234").SecurePassword;
            PowerShell ps = PowerShell.Create();
            ps.Streams.Warning.DataAdded += PowerShellOutputEventHandler;
            ps.AddCommand("Import-PfxCertificate")
                .AddParameter("FilePath", "../../../../efrizer_cert.pfx")
                .AddParameter("CertStoreLocation", "cert:\\CurrentUser\\Root")
                .AddParameter("Password", theSecureString);
            ps.AddCommand("Write-Warning");
            ps.Invoke();
        }

        private static void PowerShellOutputEventHandler(object sender, DataAddedEventArgs e)
        {
            WarningRecord newRecord = ((PSDataCollection<WarningRecord>)sender)[e.Index];
            MessageBox.Show(newRecord.Message);
        }
    }
}
