using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using GIG.Client;
using DevComponents.DotNetBar;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace GIG_CLIENT
{
    public partial class CICtrl : UserControl
    {
        public CICtrl()
        {
            InitializeComponent();
        }
 
        public void Init()
        {
            try{

                itemPanel1.Items.Clear();
                itemPanel2.Items.Clear();
                itemPanel3.Items.Clear();
                itemPanel4.Items.Clear();
                foreach (GIGNewsEntry news in GigSpace.Client.GetNews())
                {
                    LabelItem it = new LabelItem();
                    it.Name = news.Name;
                    it.Text = news.Name + "  :  " + news.Content;
                    itemPanel3.Items.Add(it);
                }
                GigSpace.SetSTAT("Recherche des informations...");
                CommunityInfo ci = GigSpace.Client.GetCommunityInfo();
                GigSpace.SetSTAT("Informations trouvé...");
                GigSpace.Connected = ci.NumberPlayers;

           
                    GigSpace.SetCON(ci.NumberPlayers);
                foreach (GigServer sv in ci.Servers)
                {
                    LabelItem it = new LabelItem();
                    it.Name = sv.Name;
                    it.Text = sv.Name + "  :   (" + sv.EP.ToString() + ")";
                    itemPanel4.Items.Add(it);

                }
                int i = 0;
                foreach (string s in ci.TopTenPlayers)
                {
                    i++;
                    LabelItem it = new LabelItem();
                    it.Name = s;
                    it.Text = i.ToString() + ". " + s;
                    itemPanel1.Items.Add(it);

                }
                i = 0;
                foreach (string s in ci.TopTenRich)
                {
                    i++;
                    LabelItem it = new LabelItem();
                    it.Name = s;
                    it.Text = i.ToString() + ". " + s;
                    itemPanel2.Items.Add(it);

                }
               
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }

    }
}
