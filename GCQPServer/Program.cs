using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace GCQPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("GIG Client Query Protocol Server - GCQPv1");
                Console.Title = "GIG Client Query Protocol Server - GCQPv1";
                AsynchronousSocketListener s = new AsynchronousSocketListener();
                s.OnDataReceived += new GCQPDataHandler(DR);
                s.StartListening();
            }
            catch(Exception ex)
            {
                File.WriteAllText("CRASH.log", ex.StackTrace);
                Process.Start(Process.GetCurrentProcess().StartInfo.FileName);
            }
        }
        static byte[] DR(byte[] data, int read)
        {
            Console.WriteLine(read);
            return Encoding.UTF8.GetBytes("HI RT");
        }
    }
}
