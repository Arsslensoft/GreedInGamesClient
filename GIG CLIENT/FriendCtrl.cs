using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using GIG.Client;

namespace GIG_CLIENT
{
    public partial class FriendCtrl : UserControl
    {
        public FriendCtrl()
        {
            InitializeComponent();
        }
        public void Init()
        {
            try
            {
                GigSpace.SetSTAT("Liste d'amis...");
                itemPanel1.Items.Clear();
                foreach (string friend in GigSpace.Client.MyAccount.Friends)
                {
                    if (friend.Length > 3)
                    {
                        ButtonItem item = new ButtonItem();
                        item.Image = GIG_CLIENT.Properties.Resources.my_friends;
                        item.Text = friend;
                        item.Name = friend;
                        item.ButtonStyle = eButtonStyle.ImageAndText;
                        item.Click += new EventHandler(item_Click);
                        itemPanel1.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }
        private void item_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonItem btn = (ButtonItem)sender;
                GigUser g = GigSpace.Client.GetUserInfo(btn.Text);
                GigSpace.ShowUserInfo(g);                
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxX1.Text.Length > 0)
                {
                    GigSpace.SetSTAT("Recherche des utilisateurs ("+textBoxX1.Text + ")...");
                    Dictionary<string, string> u = GigSpace.Client.FindUser(textBoxX1.Text);
                    itemPanel2.Items.Clear();
                    GigSpace.SetSTAT(u.Count.ToString() + " utilisateur(s) trouvé(s)");
                    foreach (KeyValuePair<string, string> user in u)
                    {
                        ButtonItem item = new ButtonItem();
                        item.Image = GIG_CLIENT.Properties.Resources.user;
                        item.Text = user.Key + "   Nom : " + user.Value;
                        item.Name = user.Key;
                        item.ButtonStyle = eButtonStyle.ImageAndText;
                        item.Click += new EventHandler(item1_Click);
                        itemPanel2.Items.Add(item);
                    }

                    this.Refresh();
                }

            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }
        private void item1_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonItem btn = (ButtonItem)sender;
                if (GigSpace.Client.Username != btn.Name && btn.Name.Length > 3)
                {
                    if (GigSpace.Client.AddUser(btn.Name))
                    {
                        ButtonItem item = new ButtonItem();
                        item.Image = GIG_CLIENT.Properties.Resources.my_friends;
                        item.Text = btn.Name;
                        item.Name = btn.Name;
                        item.ButtonStyle = eButtonStyle.ImageAndText;
                        item.Click += new EventHandler(item_Click);
                        itemPanel1.Items.Add(item);
                        GigSpace.Client.MyAccount.Friends.Add(btn.Name);
                        ToastNotification.ToastMargin = new DevComponents.DotNetBar.Padding(20); // Increase margin for the toast
                        // Show toast 1 second after the form is shown
                        BarUtilities.InvokeDelayed(new MethodInvoker(delegate
                        {
                            ToastNotification.Show(this, btn.Name + " a étè ajoutè a votre liste d'amis avec succès.", null, 3000, eToastGlowColor.Orange, eToastPosition.BottomCenter);
                        }), 1000);

                        GigSpace.MainForm.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }
    }
}
