using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using DevComponents.DotNetBar;

namespace GIG_CLIENT
{
    public partial class MSGSendfrm : MetroForm
    {
        public MSGSendfrm()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                                if (string.IsNullOrEmpty(textBoxX1.Text) || string.IsNullOrEmpty(textBoxX2.Text) || (textBoxX1.Text + textBoxX2.Text).Contains("&") || (textBoxX1.Text + textBoxX2.Text).Contains("=") || (textBoxX1.Text + textBoxX2.Text).Contains(".") || (textBoxX1.Text + textBoxX2.Text).Contains("?") && GigSpace.Client.MyAccount.Friends.Contains(textBoxX1.Text))
                    MessageBoxEx.Show("Enterer un message et un nom d'utilisateur valides", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else{
                                    GigSpace.SetSTAT("Envoi en cours...");
                                  if(GigSpace.Client.SendMessage(GigSpace.Client.MyAccount.Username, textBoxX1.Text,textBoxX2.Text))
                                      MessageBoxEx.Show("Envoyé!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                  else
                                      MessageBoxEx.Show("échoué : " + GigSpace.Client.ErrorMSG, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                                    GigSpace.SetSTAT("Terminé");

                }
            }
            catch
            {

            }
            finally
            {
                this.Close();
            }
        }

        private void MSGSendfrm_Load(object sender, EventArgs e)
        {
            try
            {
                textBoxX1.Items.AddRange(GigSpace.Client.MyAccount.Friends.ToArray());
                textBoxX1.SelectedIndex = 0;
            }
            catch{

            }
        }
    }
}
