// SteamLauncher: Copyright ©  2018 - Corey Harwell
using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace SteamLauncher
{
    class Program
    {
        static void Main( string[] args )
        {
            string appID = string.Empty;
            IniFile ini = new IniFile(".\\SteamLauncher.ini");

            if (args.Length > 0)
                appID = args[0];
            else if (File.Exists(ini.FileName))
                appID = ini.ReadValue("Launch", "AppID");
            else
                ini.WriteValue("Launch", "AppID", ""); //<--- creates the file if it is missing

            if (appID == string.Empty)
            {
                MessageBox.Show(
                    "You must specify the App to launch by adding it's ID to the SteamLauncher.ini file.",
                    "Launch Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            try
            {
                ProcessStartInfo app = new ProcessStartInfo("steam://rungameid/" + appID);
                app.UseShellExecute = true;
                Process.Start(app);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Launch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
