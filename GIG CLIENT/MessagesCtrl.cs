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
    public partial class MessagesCtrl : UserControl
    {
        public MessagesCtrl()
        {
            InitializeComponent();
        }
        public void Init()
        {
            try
            {
                itemPanel1.Items.Clear();
                int i = 0;
                GigSpace.SetSTAT("Recherche des messages...");
                foreach (GigMessage msg in GigSpace.Client.GetMessages())
                {
                    i++;
                    ButtonItem btn = new ButtonItem();
                    btn.Image = GIG_CLIENT.Properties.Resources.e_mail;
                    btn.Text = msg.Sender + " : " + msg.Message;
                    btn.ButtonStyle = eButtonStyle.ImageAndText;
                    btn.Name = msg.Sender+i.ToString() ;
                    btn.Tag = msg;
                    btn.Click += new EventHandler(btn_Click);
                    itemPanel1.Items.Add(btn);
                }
                GigSpace.SetSTAT("Terminé");
            }
            catch
            {

            }
        }
        void btn_Click(object sender, EventArgs e)
        {
            try
            {

                GigMessage msg = (GigMessage)(((ButtonItem)sender).Tag);
                MessageBoxEx.Show("Source : " + msg.Sender + " \r\n Message : " + msg.Message + " \r\n Date de réception : " + msg.RD.ToString(), "Messages", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                if(GigSpace.Client.CleanMessages())
                itemPanel1.Items.Clear();
            }
            catch
            {

            }
        }
    }
}
