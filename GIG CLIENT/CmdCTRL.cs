using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GIG.Client;
using DevComponents.DotNetBar;

namespace GIG_CLIENT
{
    public partial class CmdCTRL : UserControl
    {
        public CmdCTRL()
        {
            InitializeComponent();
 

        }
        // Init
        public void Init()
        {
            try
            {
                messagesListView.Items.Clear();
                GigSpace.SetSTAT("Recherche des commandes...");
    
              
                    foreach (GigCommand cmd in GigSpace.Client.GetMyCommands())
                        AddCMD(cmd);
                    
       
                GigSpace.SetSTAT("Recherche terminé");
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }
        private delegate void addMessageDelegate(GigCommand cmd);
        private void addMessageToList(GigCommand cmd)
        {
            try
            {
                ListViewItem item = messagesListView.Items.Add(new ListViewItem(cmd.SID));
                item.Tag = cmd;
                item.SubItems.Add(cmd.Username);
                item.SubItems.Add(cmd.GTAUsername);
                item.SubItems.Add(cmd.Name);
                item.SubItems.Add(cmd.Email);
                item.SubItems.Add(cmd.Pack);
                item.SubItems.Add(cmd.TimeStamp.ToString());

                item.SubItems.Add(cmd.Price.ToString());
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }
        public void AddCMD(GigCommand cmd)
        {
            try
            {

                if (messagesListView.InvokeRequired)
                {
                    addMessageDelegate d = new addMessageDelegate(addMessageToList);
                    messagesListView.Invoke(d, cmd);
                }
                else
                {
                    addMessageToList(cmd);
                }

            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                Init();
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }
        string CMDMSG(GigCommand cmd)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Nom d'utilisateur GTA : " + cmd.GTAUsername);
            sb.AppendLine("Nom d'utilisateur : " + cmd.Username);
            sb.AppendLine("Pack : " + cmd.Pack);
            sb.AppendLine("Prix : " + cmd.Price.ToString());
            sb.AppendLine("Cette commande doit être traité");

            return sb.ToString();

        }
       
    }
}
