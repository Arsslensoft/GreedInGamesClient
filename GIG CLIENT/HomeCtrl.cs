using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Diagnostics;
using GIG.Client;

namespace GIG_CLIENT
{
    public partial class HomeCtrl : UserControl
    {
        public HomeCtrl()
        {
            InitializeComponent();
        }
        public void SetLanguage(string lang)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
                // Sets the UI culture to French (France)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }
        public void SetUserInfo(string username, string name)
        {
            labelX2.Text = "<div align=\"right\"><font size=\"+4\" color=\"#810000\">" + username + "<br/>" + name + "</font></div>";
        }

        private void shopbtn_Click(object sender, EventArgs e)
        {
            try
            {
                GigSpace.ShopControl.Init();
                GigSpace.MainForm.ShowPanel(GigSpace.ShopControl);
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }

        private void salesTile_Click(object sender, EventArgs e)
        {
            try
            {
                GigSpace.GIGPControl.LoadCtrl();
                GigSpace.MainForm.ShowPanel(GigSpace.GIGPControl);
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }

        private void unpaidTile_Click(object sender, EventArgs e)
        {
            try
            {
                GigSpace.ProfileControl.SelectTAB("");
                GigSpace.ProfileControl.SetProfileInfo(GigSpace.Client.MyAccount);
                GigSpace.MainForm.ShowPanel(GigSpace.ProfileControl);
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }

        private void reportTile_Click(object sender, EventArgs e)
        {
            try
            {
                GigSpace.ProfileControl.SelectTAB("");
                GigSpace.ProfileControl.SetProfileInfo(GigSpace.Client.MyAccount);
                GigSpace.MainForm.ShowPanel(GigSpace.ProfileControl);
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }

        private void ytdTile_Click(object sender, EventArgs e)
        {
            try
            {
                GigSpace.CommandControl.Init();
                GigSpace.MainForm.ShowPanel(GigSpace.CommandControl);
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }

        private void helpTile_Click(object sender, EventArgs e)
        {
            try
            {
                helpTile.NotificationMarkText = "";
                GigSpace.MessagesControl.Init();
                GigSpace.MainForm.ShowPanel(GigSpace.MessagesControl);
            }
            catch
            {

            }
        }

        private void devCoTile_Click(object sender, EventArgs e)
        {
            try
            {
                devCoTile.NotificationMarkText = "";
           
                GigSpace.ProfileControl.SetProfileInfo(GigSpace.Client.MyAccount);
                GigSpace.ProfileControl.SelectTAB("notify");
                GigSpace.MainForm.ShowPanel(GigSpace.ProfileControl);
            }
            catch
            {

            }
        }

        private void metroTileItem2_Click(object sender, EventArgs e)
        {
            Process.Start("http://hof.greedingames.com/");
        }

        private void compteGIGP_Click(object sender, EventArgs e)
        {
            try
            {
                GigSpace.CommunityControl.Init();
                GigSpace.MainForm.ShowPanel(GigSpace.CommunityControl);
            }
            catch
            {

            }
        }

        private void appViewTile_Click(object sender, EventArgs e)
        {
            Process.Start("http://ogrp.greedingames.com/");
        }

        private void metroTileItem3_Click(object sender, EventArgs e)
        {
            Process.Start("http://greedingames.com/");
        }

        private void metroTileItem1_Click(object sender, EventArgs e)
        {
            try
            {

                SAMP.StartGame(GigSpace.GTA_HOST, GigSpace.GTA_PORT, GigSpace.Client.MyAccount.Username, GigSpace.GTA_PASSWORD);
            }
            catch
            {

            }
        }

        private void labelX2_TextChanged(object sender, EventArgs e)
        {
            try
            {

                labelX2.ForeColor = Color.DarkRed;
            }
            catch
            {

            }
        }
    }
}
