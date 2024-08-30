using System;
using System.Windows.Forms;

namespace GameXO
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form startForm = new frmPlayers();
            Application.Run(startForm);
        }
    }
}
