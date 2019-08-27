using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GIG.Client;

namespace GIG_CLIENT
{
    public partial class Transacfrm : UserControl
    {
        public Transacfrm()
        {
            InitializeComponent();
        }

        public void Init()
        {
            try
            {
                messagesListView.Items.Clear();
            
                    GigSpace.SetSTAT("Recherche des transactions...");
                    foreach (GigTransaction t in GigSpace.Client.GetTransactions())
                    {
                        AddTRANS(t);
                    }
                    GigSpace.SetSTAT("Terminé");
          
            }
            catch
            {

            }
        }
        private delegate void addMessageDelegate(GigTransaction cmd);
        private void addMessageToList(GigTransaction cmd)
        {
            try
            {
                ListViewItem item = messagesListView.Items.Add(new ListViewItem(cmd.Sender));
                item.Tag = cmd;
                item.SubItems.Add(cmd.Receiver);
                item.SubItems.Add(cmd.Amount.ToString());
                item.SubItems.Add(cmd.TimeStamp.ToString());

           

            }
            catch
            {

            }
        }
        public void AddTRANS(GigTransaction trans)
        {
            try
            {

                if (messagesListView.InvokeRequired)
                {
                    addMessageDelegate d = new addMessageDelegate(addMessageToList);
                    messagesListView.Invoke(d, trans);
                }
                else
                {
                    addMessageToList(trans);
                }

            }
            catch
            {

            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                Init();
            }
            catch
            {

            }
        }

 
    }
}
