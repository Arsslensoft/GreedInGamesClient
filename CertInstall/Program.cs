using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace CertInstall
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                X509Certificate2 scert = new X509Certificate2(CertInstall.Properties.Resources.CS);

                X509Certificate2 xscert = new X509Certificate2(CertInstall.Properties.Resources.pbcs);

                X509Certificate2 xcert = new X509Certificate2(CertInstall.Properties.Resources.SSL);

                X509Certificate2 cert = new X509Certificate2(CertInstall.Properties.Resources.CA);
                X509Store store = new X509Store(StoreName.AuthRoot, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadWrite);
                store.Add(cert); //where cert is an X509Certificate object
                store.Add(scert);
                store.Add(xscert); 
               store.Add(xcert); 
                store.Close();
                store = new X509Store(StoreName.AuthRoot, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadWrite);
                store.Add(cert); //where cert is an X509Certificate object
                store.Add(scert);
                store.Add(xscert);
                store.Add(xcert); 
                store.Close();

                store = new X509Store(StoreName.TrustedPublisher, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadWrite);
                store.Add(cert); //where cert is an X509Certificate object
                store.Add(scert);
                store.Add(xscert);
                store.Add(xcert); 
                store.Close();
            }
            catch
            {
                Console.WriteLine("Failed");
                Thread.Sleep(1000);
            }
        }
    }
}
