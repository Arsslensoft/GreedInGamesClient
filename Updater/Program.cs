using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using DevComponents.DotNetBar;

namespace Updater
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                string[] l = Environment.GetCommandLineArgs();
                for (int i = 0; i < l.Length; i++)
                {
                    if (l[i].StartsWith("procid="))
                        UpdateManager.LauncherID = int.Parse(l[i].Replace("procid=", ""));
                }
              
                if (UpdateManager.Initialize())
                {
                    if (UpdateManager.CheckForUpdate())
                    {
                        MessageBoxEx.Show("Une mise à jour est disponible.\n GIG Client va se fermer pour terminer le processus","Mise à Jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Process.GetProcessById(UpdateManager.LauncherID).Kill();
                        UpdateManager.Update();
                        Process.Start(Application.StartupPath + @"\GIG Client.exe", "noupdate");
                    }
                }
            }
            catch
            {

            }
        }
    }
}
