
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ConsoleApplication1
{
    // Asynchronous Client Socket Example
    // http://msdn.microsoft.com/en-us/library/bew39x2a.aspx
   public class GCQ
    {
        Dictionary<string, string> Query = new Dictionary<string, string>();
        public string this[string index]
        {
            get
            {
                return Query[index];
            }
            set
            {
                Query[index] = value;
            }
        }
        public bool ISET(string key)
        {
            return Query.ContainsKey(key);
                 
        }
        public void Add(string key, string val)
        {
            Query.Add(key, val);
        }
        public void Destroy()
        {
            Query.Clear();
        }
       public static GCQ Parse(string query)
        {
            try
            {
                GCQ gc = new GCQ();
                
                // & split
                string[] spl = query.Split('&');
                foreach (string s in spl)
                {
                    // = value split
                    string[] v = s.Split('=');
                    if (!gc.ISET(v[0]))
                        gc.Add(v[0], v[1]);
                }

                return gc;
            }
            catch
            {
                return null;

            }

       }
    }



    public class AsynchronousClient
    {

        //static bool Send(byte[] data, IPEndPoint ep)
        //{
        //    try
        //    {
        //        TcpClient cl = new TcpClient();
        //        cl.Connect(ep);
        //        cl.SendBufferSize = 2048;
        //        NetworkStream str = cl.GetStream();
        //        str.Write(data, 0, data.Length);
        //        // Buffer to store the response bytes.
        //        data = new Byte[2048];

        //        // String to store the response ASCII representation.
        //        String responseData = String.Empty;

        //        // Read the first batch of the TcpServer response bytes.
        //        Int32 bytes = str.Read(data, 0, data.Length);
        //        responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
        //        Console.WriteLine("Received: {0}", responseData);

        //        // Close everything.
        //        str.Close();
        //        cl.Close();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        static Bitmap bmpImage;
        static Bitmap bmpCrop;
        private static Image cropImage(Image img)
        {
            bmpImage = new Bitmap(img);
            Rectangle cropArea = new Rectangle(new Point(0, 0), new Size(img.Width - 1, (int)(img.Height - (int)(img.Height / 6))));
            bmpCrop = bmpImage.Clone(cropArea,
            bmpImage.PixelFormat);
          
            return (Image)(bmpCrop);
        }
        public static void Main(String[] args)
        {
            //IPEndPoint ep = new IPEndPoint(IPAddress.Parse("192.168.1.6"), 9685);
            //Send(Encoding.UTF8.GetBytes("ARSSLEN"), ep);
            //GCQ gc = GCQ.Parse("username=Arsslen&KE=rere");
            //Console.WriteLine(gc["username"]);
            //Console.WriteLine(gc["KE"]);
            for (int i = 75; i <= 299; i++)
            {
                if (i < 10)
                    cropImage(new Bitmap(@"D:\GIG\GIG_CLIENT\GIG CLIENT\ConsoleApplication1\bin\Debug\S\0" + i.ToString() + ".jpg")).Save(@"D:\GIG\GIG_CLIENT\GIG CLIENT\ConsoleApplication1\bin\Debug\S\N\0" + i.ToString() + ".png");
                else cropImage(new Bitmap(@"D:\GIG\GIG_CLIENT\GIG CLIENT\ConsoleApplication1\bin\Debug\S\" + i.ToString() + ".jpg")).Save(@"D:\GIG\GIG_CLIENT\GIG CLIENT\ConsoleApplication1\bin\Debug\S\N\" + i.ToString() + ".png");

            }
   //         for (int i = 75; i <= 299; i++)
   //         {
   //if (i < 10)
   //         if(File.exi
   //          else cropImage(new Bitmap(@"D:\GIG_CLIENT\GIG CLIENT\ConsoleApplication1\bin\Debug\S\" + i.ToString() + ".jpg")).Save(@"D:\GIG_CLIENT\GIG CLIENT\ConsoleApplication1\bin\Debug\S\N\" + i.ToString() + ".png");
   //         }
            Console.Read();
        }
    }
}
