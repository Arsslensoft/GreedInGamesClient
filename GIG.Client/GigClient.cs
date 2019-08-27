using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace GIG.Client
{
    public class GigClient
    {
        #region Splitters
        static Regex SPSplitter = new Regex(@"<SP>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        static Regex NLSplitter = new Regex(@"<NL>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        static Regex GIGDSplitter = new Regex(@"<GIG_DATA>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        #endregion

        public GigUser MyAccount;
        public string AccessToken = "";

        public string Host = "https://client.greedingames.com/";
        string HOST;
        public GigClient()
        {
            HOST = Host;
        }
        public GigClient(string host)
        {
            Host = host;
            HOST = host;
        }
        public string Username;
        public string ErrorMSG = "";
        public bool Login(string username, string password)
        {

            string passhash = Utils.MD5Hash(password);
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Connect.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "username=" + username + "&pass=" + passhash;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();
                    AccessToken = GIGDSplitter.Split(responseFromServer.Replace("OK:", ""), 3)[1];
                    Username = username;
                    return true;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public bool Logout()
        {
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Disconnect.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();
                    AccessToken = "NO TOKEN";
                    return true;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public GigUser GetUserInfo(string username)
        {
            GigUser user = new GigUser();
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Answer.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=GETINFO&username=" + username + "&AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();
                    string p = GIGDSplitter.Split(responseFromServer.Replace("OK:", ""), 3)[1];
                    string[] ln = NLSplitter.Split(p);
                    user.Username = ln[0];
                    user.Name = ln[1];
                    user.GTAUsername = ln[2];
                    user.Email = ln[3];
                    user.VIP = (ln[4] == "1");
                    user.Role = (GIGRoles)byte.Parse(ln[5]);
                    user.GIGP = int.Parse(ln[6]);
                    user.RegistrationDate = DateTime.Parse(ln[7]);
                    user.Friends.AddRange(SPSplitter.Split(ln[8]));


                    return user;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return user;
                }
                else
                    return user;
            }
            catch
            {
                return user;
            }
        }
        public bool IsConnected()
        {
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Online.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();

                    return true;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public Dictionary<string, string> FindUser(string pattern)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Answer.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=FINDUSER&username=" + pattern + "&AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();
                    string p = GIGDSplitter.Split(responseFromServer.Replace("OK:", ""), 3)[1];
                    if (p.Contains("<NL>"))
                    {
                        string[] ln = NLSplitter.Split(p);
                        for (int i = 0; i < ln.Length - 1; i++)
                        {
                            string found = ln[i];
                            string[] u = SPSplitter.Split(found);
                            if (!users.ContainsKey(u[0]))
                                users.Add(u[0], u[1]);
                        }

                    }

                    return users;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return users;
                }
                else
                    return users;
            }
            catch
            {
                return users;
            }
        }
        public bool AddUser(string username)
        {

            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Answer.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=ADDUSER&username=" + MyAccount.Username + "&friend=" + username + "&AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();

                    return true;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public bool RemoveUser(string username)
        {

            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Answer.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=REMOVEUSER&username=" + MyAccount.Username + "&friend=" + username + "&AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();

                    return true;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public bool SendMessage(string from, string to, string message)
        {
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Answer.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=SENDMSG&from=" + from + "&to=" + to + "&msg=" + Utils.ToHex(message) + "&AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:SENT"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();
                    return true;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public List<GigMessage> GetMessages()
        {
            List<GigMessage> pg = new List<GigMessage>();
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Answer.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=GETMSG&receiver=" + MyAccount.Username + "&AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();
                    string p = GIGDSplitter.Split(responseFromServer.Replace("OK:", ""), 3)[1];
                    File.WriteAllText(Application.StartupPath + @"\Data\MSG.dat", p);
                    string[] x = NLSplitter.Split(p);
                    foreach (string xa in x)
                    {
                        if (xa.Length > 0)
                        {
                            string[] a = SPSplitter.Split(xa, 3);
                            GigMessage msg = new GigMessage();
                            msg.Sender = a[0];
                            msg.Message = Utils.FromHex(a[1]);
                            msg.RD = DateTime.Parse(a[2]);
                            pg.Add(msg);
                        }
                    }

                    return pg;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return pg;
                }
                else
                    return pg;
            }
            catch
            {
                return pg;
            }
        }
        public bool TransferGIGP(string username, int amount, string secret, string to)
        {

            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Answer.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=TGIGP&username=" + username + "&amount=" + amount.ToString() + "&secret=" + secret + "&dst=" + to + "&AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();

                    return true;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public bool ConvertGIGP(int amount, string secret)
        {

            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Answer.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=CGIGP&username=" + MyAccount.Username + "&to=" + MyAccount.GTAUsername + "&amount=" + amount.ToString() + "&secret=" + secret + "&AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();

                    return true;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public List<GigVehicle> GetVehicles()
        {
            List<GigVehicle> pg = new List<GigVehicle>();
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Answer.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=GETVEHICLES&AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();
                    string p = GIGDSplitter.Split(responseFromServer.Replace("OK:", ""), 3)[1];
                    string[] x = NLSplitter.Split(p);

                    foreach (string veh in x)
                    {
                        if (veh.Length > 0)
                        {
                            string[] ve = SPSplitter.Split(veh, 4);
                            GigVehicle v = new GigVehicle();
                            v.ID = int.Parse(ve[0]);
                            v.Model = int.Parse(ve[3]);
                            v.Name = ve[1];
                            v.Price = double.Parse(ve[2]); // possible replacement by .
                            pg.Add(v);
                        }
                    }

                    return pg;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return pg;
                }
                else
                    return pg;
            }
            catch
            {
                return pg;
            }
        }
        public List<GigWeapon> GetWeapons()
        {
            List<GigWeapon> pg = new List<GigWeapon>();
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Answer.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=GETWEAPONS&AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();
                    string p = GIGDSplitter.Split(responseFromServer.Replace("OK:", ""), 3)[1];
                    string[] x = NLSplitter.Split(p);

                    foreach (string veh in x)
                    {
                        if (veh.Length > 0)
                        {
                            string[] ve = SPSplitter.Split(veh, 3);
                            GigWeapon v = new GigWeapon();
                            v.ID = int.Parse(ve[0]);
                            v.Name = ve[1];
                            v.Price = double.Parse(ve[2]); // possible replacement by .
                            pg.Add(v);
                        }
                    }

                    return pg;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return pg;
                }
                else
                    return pg;
            }
            catch
            {
                return pg;
            }
        }
        public List<GigHouse> GetHouses()
        {
            List<GigHouse> pg = new List<GigHouse>();
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Answer.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=GETHOUSES&AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();
                    string p = GIGDSplitter.Split(responseFromServer.Replace("OK:", ""), 3)[1];
                    string[] x = NLSplitter.Split(p);

                    foreach (string veh in x)
                    {
                        if (veh.Length > 0)
                        {
                            string[] ve = SPSplitter.Split(veh, 3);
                            GigHouse v = new GigHouse();
                            v.ID = int.Parse(ve[0]);
                            v.Name = ve[1];
                            v.Price = double.Parse(ve[2]); // possible replacement by .
                            pg.Add(v);
                        }
                    }

                    return pg;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return pg;
                }
                else
                    return pg;
            }
            catch
            {
                return pg;
            }
        }
        public List<GigServer> GetServers()
        {
            List<GigServer> pg = new List<GigServer>();
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Answer.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=GETSV&AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();
                    string p = GIGDSplitter.Split(responseFromServer.Replace("OK:", ""), 3)[1];
                    string[] x = NLSplitter.Split(p);

                    foreach (string veh in x)
                    {
                        if (veh.Length > 0)
                        {
                            string[] ve = SPSplitter.Split(veh, 2);
                            GigServer v = new GigServer();
                            v.Name = ve[0];
                            v.EP = new IPEndPoint(IPAddress.Parse(ve[1].Split(':')[0]), int.Parse(ve[1].Split(':')[1]));
                            pg.Add(v);
                        }
                    }

                    return pg;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return pg;
                }
                else
                    return pg;
            }
            catch
            {
                return pg;
            }
        }
        public CommunityInfo GetCommunityInfo()
        {
            CommunityInfo pg = new CommunityInfo();
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Answer.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=GETCI&AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();
                    string p = GIGDSplitter.Split(responseFromServer.Replace("OK:", ""), 3)[1];
                    string[] x = NLSplitter.Split(p);

                    foreach (string tr in SPSplitter.Split(x[0]))
                    {
                        if (tr.Length > 0)
                        {
                            pg.TopTenRich.Add(tr);
                        }
                    }
                    foreach (string tp in SPSplitter.Split(x[1]))
                    {
                        if (tp.Length > 0)
                        {
                            pg.TopTenPlayers.Add(tp);
                        }
                    }
                    pg.NumberPlayers = int.Parse(x[2]);
                    pg.Servers = GetServers();
                    return pg;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return pg;
                }
                else
                    return pg;
            }
            catch
            {
                return pg;
            }
        }
        public List<GIGNewsEntry> GetNews()
        {
            List<GIGNewsEntry> gn = new List<GIGNewsEntry>();
            try
            {
                WebClient cl = new WebClient();
                cl.DownloadFile(Host + "/News.xml", Application.StartupPath + @"\Data\News.xml");
                XmlDocument doc = new XmlDocument();
                doc.Load(Application.StartupPath + @"\Data\News.xml");
                foreach (XmlElement el in doc.DocumentElement.ChildNodes)
                {
                    GIGNewsEntry n = new GIGNewsEntry();
                    n.Name = el.GetAttribute("name");
                    n.Content = el.InnerText;
                    gn.Add(n);
                }
            }
            catch
            {

            }
            return gn;
        }
        public bool CleanNotifications()
        {

            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Answer.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=NOTIF&clean=CLEAN&username=" + MyAccount.Username + "&AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();


                    return true;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public bool CleanMessages()
        {

            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Answer.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=GETMSG&clean=CLEAN&receiver=" + MyAccount.Username + "&AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();


                    return true;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return false;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public List<string> GetNotifications()
        {
            List<string> pg = new List<string>();
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Answer.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=NOTIF&username=" + MyAccount.Username + "&AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();
                    string p = GIGDSplitter.Split(responseFromServer.Replace("OK:", ""), 3)[1];
                    string[] x = NLSplitter.Split(p);

                    foreach (string veh in x)
                    {
                        if (veh.Length > 0)
                        {
                            pg.Add(veh);
                        }
                    }

                    return pg;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return pg;
                }
                else
                    return pg;
            }
            catch
            {
                return pg;
            }
        }
        public List<string> GetFriends()
        {
            List<string> pg = new List<string>();
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Answer.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=GFRIENDS&username=" + MyAccount.Username + "AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();
                    string p = GIGDSplitter.Split(responseFromServer.Replace("OK:", ""), 3)[1];
                    string[] x = NLSplitter.Split(p);

                    foreach (string veh in x)
                    {
                        if (veh.Length > 0)
                        {
                            pg.Add(veh);
                        }
                    }

                    return pg;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return pg;
                }
                else
                    return pg;
            }
            catch
            {
                return pg;
            }
        }
        public List<GigCommand> GetMyCommands()
        {
            List<GigCommand> pg = new List<GigCommand>();
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Answer.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=SHOWCMD&AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();
                    string p = GIGDSplitter.Split(responseFromServer.Replace("OK:", ""), 3)[1];
                    string[] x = NLSplitter.Split(p);

                    foreach (string veh in x)
                    {
                        if (veh.Length > 0)
                        {
                            string[] s = SPSplitter.Split(veh);
                            GigCommand cmd = new GigCommand();
                            cmd.SID = s[0];
                            cmd.Username = s[1];
                            cmd.GTAUsername = s[2];
                            cmd.Email = s[3];
                            cmd.ContactEmail = s[4];
                            cmd.TimeStamp = DateTime.Parse(s[5]);
                            cmd.Pack = s[6];
                            cmd.Name = s[7];

                            pg.Add(cmd);
                        }
                    }

                    return pg;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return pg;
                }
                else
                    return pg;
            }
            catch
            {
                return pg;
            }
        }

        public List<GigTransaction> GetTransactions()
        {
            List<GigTransaction> pg = new List<GigTransaction>();
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HOST + "/Admin.php");
                request.Method = "POST";
                request.Accept = "gzip, deflate";
                request.Proxy = null;
                request.Timeout = 15000;
                request.KeepAlive = true;
                request.UserAgent = "GIG_CLIENT/UserAgent 1.0";
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                string postData = "token=SHOWTRANS&action=SHOW&AT=" + AccessToken;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();
                // Get the response.
                WebResponse sresponse = request.GetResponse();
                dataStream = sresponse.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();
                if (responseFromServer.Contains("OK:"))
                {

                    reader.Close();
                    dataStream.Close();
                    sresponse.Close();
                    string p = GIGDSplitter.Split(responseFromServer.Replace("OK:", ""), 3)[1];
                    string[] x = NLSplitter.Split(p);

                    foreach (string veh in x)
                    {
                        if (veh.Length > 0)
                        {
                            string[] s = SPSplitter.Split(veh);
                            GigTransaction cmd = new GigTransaction();
                            cmd.Sender = s[0];
                            cmd.Receiver = s[1];
                            cmd.Amount = int.Parse(s[2]);
                            cmd.TimeStamp = DateTime.Parse(s[3]);


                            pg.Add(cmd);
                        }
                    }

                    return pg;



                }
                else if (responseFromServer.Contains("DENIED:"))
                {
                    ErrorMSG = GIGDSplitter.Split(responseFromServer.Replace("DENIED:", ""), 3)[1];
                    return pg;
                }
                else
                    return pg;
            }
            catch
            {
                return pg;
            }
        }
    }
}
