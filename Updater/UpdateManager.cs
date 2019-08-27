using System;
using System.Collections.Generic;
using System.Text;
using GIG.Client;
using System.Net;
using System.IO;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Diagnostics;
using System.Xml;
using System.Security.Cryptography.X509Certificates;

namespace Updater
{
   internal static class UpdateManager
    {
       internal static GIGV CurrentVersion;
       internal static int LauncherID = 0;
       static string URL = "";
       static string uver = "";
       internal static bool CheckForUpdate()
       {
           try
           {
               string version = wb.DownloadString("http://client.greedingames.com/updates/ver.txt");
               GIGV versi = new GIGV();
               URL = "http://client.greedingames.com/updates/" + version.Replace("/", "-") + "/update.xml";
               uver = version;
               if (versi.Parse(version))
                   return (GIGV.Compare(versi, CurrentVersion) == 1);
               else return false;
           }
           catch
           {
               return false;
           }
       }
       internal static Dictionary<string, string> PDef = new Dictionary<string, string>();
       internal static bool Initialize()
       {
           try
           {
               // Parse Definitions
               if (!File.Exists(Application.StartupPath + @"\Data\PDEF.dat"))
               {
                   PDef.Add("$.curdir.$", Application.StartupPath);
                   if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Rockstar Games\GTA San Andreas"))
                       PDef.Add("$.gtapath.$", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Rockstar Games\GTA San Andreas");
                   else if(Directory.Exists(@"C:\Program Files (x86)\Rockstar Games\GTA San Andreas"))
                       PDef.Add("$.gtapath.$", @"C:\Program Files (x86)\Rockstar Games\GTA San Andreas");
                   else
                   {
                       MessageBoxEx.Show(@"Vous devez prèciser l'emplacement de GTA SA. \n Exemple : C:\Program Files\Rockstar Games\GTA San Andreas","Emplacement GTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       FolderBrowserDialog fw = new FolderBrowserDialog();
                       if (fw.ShowDialog() == DialogResult.OK)
                       {
                           while(!Directory.Exists(fw.SelectedPath) || !File.Exists(fw.SelectedPath + @"\samp.exe"))
                           {
                             MessageBoxEx.Show(@"Verifier que vous avez choisi le bon répértoire et que vous avez installè SA-MP Client 0.3x  \n Exemple : C:\Program Files\Rockstar Games\GTA San Andreas","Emplacement GTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               fw.ShowDialog();
                           }
                            PDef.Add("$.gtapath.$", fw.SelectedPath);
                       }
                       else
                       {
                           Process.GetProcessById(LauncherID).Kill();
                           Process.GetCurrentProcess().Kill();
                       }
                   }
                   List<string> ls = new List<string>();
                   foreach(KeyValuePair<string,string> p in PDef)
                       ls.Add(p.Key + "=" + p.Value);
                 
                   File.WriteAllLines(Application.StartupPath + @"\Data\PDEF.dat",ls.ToArray());
               }
               else
               {
                   string[] ln = File.ReadAllLines(Application.StartupPath + @"\Data\PDEF.dat");
                   foreach (string line in ln)
                   {
                       string[] s = line.Split('=');
                       if(!PDef.ContainsKey(s[0]))
                           PDef.Add(s[0],s[1]);
                   }
               }
               string v =File.ReadAllText(Application.StartupPath + @"\Data\GV.dat");
               CurrentVersion = new GIGV();
               return CurrentVersion.Parse(v);
                
           }
           catch
           {
               return false;
           }
       }
       static string FixPath(string path)
       {
           try
           {
               string pa = path;
               foreach (KeyValuePair<string, string> p in PDef)
                   pa = pa.Replace(p.Key, p.Value);
               return pa;
           }
           catch
           {
               return path;
           }
       }
       internal static WebClient wb = new WebClient();
       internal static bool Download(string file, string path)
       {
           try
           {
               wb.DownloadFile(file, FixPath(path));
               return File.Exists(FixPath(path));
           }
           catch
           {
               return false;
           }
       }
       internal static List<string> Errors = new List<string>();
       internal static bool Update()
       {
           try
           {
               Errors.Clear();
               wb.DownloadFile(URL, Application.StartupPath + @"\update.xml");
               XmlDocument doc = new XmlDocument();
               doc.Load(Application.StartupPath + @"\update.xml");
               foreach (XmlElement el in doc.DocumentElement.ChildNodes)
               {
                   if (!Execute(el))
                       Errors.Add("Failed! : "+el.ToString());
               }
               File.WriteAllText(Application.StartupPath + @"\Data\GV.dat", uver);
               return true;
           }
           catch
           {
               return false;
           }

       }
       internal static bool Execute(XmlElement el)
       {
           try
           {
               if (el.GetAttribute("type") == "folder")
                   Directory.CreateDirectory(FixPath(el.GetAttribute("path")));
               else if (el.GetAttribute("type") == "cert")
               {
                   byte[] data = wb.DownloadData(el.GetAttribute("url"));

                   X509Certificate2 cert = new X509Certificate2(data);
                   X509Store store = new X509Store(StoreName.AuthRoot, StoreLocation.CurrentUser);
                   store.Open(OpenFlags.ReadWrite);
                   store.Add(cert); //where cert is an X509Certificate object
                   store.Close();
                   store = new X509Store(StoreName.AuthRoot, StoreLocation.LocalMachine);
                   store.Open(OpenFlags.ReadWrite);
                   store.Add(cert); //where cert is an X509Certificate object
                   store.Close();
               }
               else
                  return Download(el.GetAttribute("url"), FixPath(el.GetAttribute("path")));
               return true;
           }
           catch
           {
               return false;
           }
       }
    }
}
