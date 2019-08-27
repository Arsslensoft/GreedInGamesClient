using System;
using System.Collections.Generic;
using System.Text;
using GIG.Client;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Text;
using System.Diagnostics;

namespace GIG_CLIENT
{
    public delegate void OnNotif(int count);

    public delegate void AsyncExec();
    internal static class GigSpace
    {
     


        internal static ProfileCtrl ProfileControl;
        internal static CICtrl CommunityControl;
        internal static CmdCTRL CommandControl;
        internal static FriendCtrl FriendControl;
        internal static GIGPCtrl GIGPControl;
        internal static HomeCtrl HomeControl;
        internal static MessagesCtrl MessagesControl;
        internal static ShopCtrl ShopControl;
        internal static Transacfrm TransactionControl;
        internal static AboutCtrl AboutControl;
        internal static AllUsersCtrl AllUsersControl;

        internal static Home MainForm;

        internal static GigClient Client;
        internal static string ShopLink = "https://shop.greedingames.com/";
        internal static string NewsLink = "http://37.187.45.80:9685/News.xml";
        internal static string HOST = "http://37.187.45.80:9685/";
        internal static string GTA_HOST = "ogrp.greedingames.com";
        internal static string GTA_PASSWORD = "D5XU6AQ4HBOC";
        internal static string GTA_PORT = "7777";
        internal static event OnNotif NotificationArrived;
        internal static event OnNotif MessageArrived;
        internal static event EventHandler OnDone;
        internal static void SetCON(int con)
        {
            try
            {
                if(con < 2)
                     MainForm.UpdateLabel(MainForm.conlb, con.ToString() + " connecté");
                else
                    MainForm.UpdateLabel(MainForm.conlb, con.ToString() + " connecté(s)");
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }
   
        internal static void SetSTAT(string stat)
        {
            try
            {
                MainForm.UpdateLabel(MainForm.slb, stat);
       
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }
        internal static int Connected = 0;
        public static void ShowUserInfo(GigUser u)
        {
            try
            {
                ProfileControl.SetProfileInfo(u);
                MainForm.ShowModalPanel(ProfileControl);
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }
        static void GetUI()
        {
            try
            {
                Client.MyAccount = Client.GetUserInfo(Client.Username);
                ProfileControl.SetProfileInfo(Client.MyAccount);
            }
            catch
            {

            }
        }
        public static void Initialize()
        {
            try
            {
                SettingsManager.Init();
                if (!File.Exists(Application.StartupPath + @"\FIRSTRUN.dat"))
                {
                    File.Create(Application.StartupPath + @"\FIRSTRUN.dat");
                    GPlayer.Install();
                }
       
                Client = new GigClient(HOST);
                SplashScreen.frm.Refresh();
                if (!File.Exists(Application.StartupPath + @"\Data\AT.dat") || SettingsManager.GetBool("CONNECT") )
                {
             
                    LoginFrm frm = new LoginFrm();
                    frm.ShowDialog();
                    if (frm.close)
                    {
                        File.WriteAllText(Application.StartupPath + @"\Data\AT.dat", Client.AccessToken);
                           File.WriteAllText(Application.StartupPath + @"\Data\UN.dat", Client.Username);
                         Client.MyAccount = Client.GetUserInfo(Client.Username);
                           //AsyncExec ae = new AsyncExec(GetUI);
                           //ae.BeginInvoke(null, null);
                    }
                    else
                        Application.Exit();
                }
                else
                {
                   SplashScreen.frm.Show();
                    Client.AccessToken = File.ReadAllText(Application.StartupPath + @"\Data\AT.dat");
                    Client.Username = File.ReadAllText(Application.StartupPath + @"\Data\UN.dat");
                
                    // check AT
                    if (!Client.IsConnected())
                    {

                        LoginFrm frm = new LoginFrm();
                        frm.ShowDialog();
                        if (frm.close)
                        {
                            File.WriteAllText(Application.StartupPath + @"\Data\AT.dat", Client.AccessToken);
                            File.WriteAllText(Application.StartupPath + @"\Data\UN.dat", Client.Username);
                        }
                        else
                            Application.Exit();
                    }
                    else
                    {
                     Client.MyAccount = Client.GetUserInfo(Client.Username);
                        //AsyncExec ae = new AsyncExec(GetUI);
                        //ae.BeginInvoke(null, null);
                    }
       
                }

                if(!File.Exists(Application.StartupPath + @"\Data\"+Client.Username + ".dat"))
                    File.WriteAllLines(Application.StartupPath + @"\Data\" + Client.Username + ".dat", new string[2] { "m1", "n1" });
            
           

             
                // Initialize Controls
                     ProfileControl = new ProfileCtrl();
                    CommunityControl = new CICtrl();
          CommandControl = new CmdCTRL();
         FriendControl = new FriendCtrl();
         GIGPControl = new GIGPCtrl();
      HomeControl = new HomeCtrl();
          MessagesControl = new MessagesCtrl();
         ShopControl = new ShopCtrl();
          TransactionControl = new Transacfrm();
          AboutControl = new AboutCtrl();
          AllUsersControl = new AllUsersCtrl();
    
          SplashScreen.frm.Close();
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }
        internal static bool Exec = true;
       internal static void Run()
        {
            
            try
            {
                string[] f = File.ReadAllLines(Application.StartupPath + @"\Data\"+Client.Username+".dat");
                string lm = f[0];
                string ln = f[1];
                int mc = 0;
                int nc = 0;
                   int i = 0;
                while (Exec)
                {
                    try
                    {
                        mc = 0;
                        nc = 0;
                        Connected = Client.GetCommunityInfo().NumberPlayers;
                        SetCON(Connected);
                        List<GigMessage> msg = GigSpace.Client.GetMessages();
                        string ma = "";
                        for (i = msg.Count - 1; i >= 0; i-- )
                        {
                            GigMessage m = msg[i];
                            if (lm == m.Message)
                                break;
                            mc++;
                            ma = m.Message;
                        }
                        if (ma.Length > 0)
                        {
                            lm = msg[msg.Count - 1].Message;
                            mc = msg.Count - i - 1;
                        }


                        List<string> noti = GigSpace.Client.GetNotifications();
                        ma = "";
                        for (i = noti.Count - 1; i >= 0; i--)
                        {
                            string m = noti[i];
                            if (ln == m)
                                break;
                            nc++;
                            ma = m;
                        }
                        if (ma.Length > 0)
                        {
                            ln = noti[noti.Count - 1];
                            nc = noti.Count - i-1;
                        }

                      if (mc > 0 || nc > 0)
                      {
                          File.WriteAllLines(Application.StartupPath + @"\Data\" + Client.Username + ".dat", new string[2] { lm, ln });
                          if (nc > 0 && NotificationArrived != null)
                          {
                              NotificationArrived(nc);
                              GPlayer.NEWNOTIF();
                          }
                          if (mc > 0 && MessageArrived != null)
                          {
                              MessageArrived(mc);
                              GPlayer.NEWMSG();
                          }
                      }
                    }
                    catch (Exception ex)
                    {
                        GigSpace.LogError(ex);
                    }

                    Thread.Sleep(SettingsManager.GetInt("DELAY") * 1000);
                }
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }
      
    
        public static void LogError(Exception ex)
        {
            try
            {
                using (StreamWriter str = new StreamWriter(Application.StartupPath + @"\Logs\Error.txt", true))
                {
                    str.WriteLine(DateTime.Now.ToString() + "----------------------------------------------------------");
                    str.WriteLine(ex.Message);
                    str.WriteLine(ex.Source);
                    str.WriteLine(ex.StackTrace);
                    str.WriteLine("****************************************************************************");
                }
            }
            catch
            {

            }
        }
    }
}
