using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Diagnostics;

namespace GIG_CLIENT
{
    public partial class GIGPCtrl : UserControl
    {
        public GIGPCtrl()
        {
            InitializeComponent();
        }
        
        public void LoadCtrl()
        {
            try
            {
                GigSpace.SetSTAT("Recherche de votre solde...");
                GigSpace.Client.MyAccount = GigSpace.Client.GetUserInfo(GigSpace.Client.MyAccount.Username);
                GigSpace.SetSTAT("Terminé");
                labelX2.Text = GigSpace.Client.MyAccount.GIGP.ToString();
                if (GigSpace.Client.MyAccount.GIGP > 10)
                    labelX2.ForeColor = Color.LimeGreen;
                else
                    labelX2.ForeColor = Color.Red;
            }
            catch
            {

            }
        }

        private void shopbtn_Click(object sender, EventArgs e)
        {
            try
            {
                TransferFrm frm = new TransferFrm();
                if (GigSpace.Client.MyAccount.GIGP > 3)
                {
                    frm.integerInput1.MaxValue = GigSpace.Client.MyAccount.GIGP - 1;
                    frm.ShowDialog();
                    if (frm.Done && frm.textBoxX1.Text.Length > 0 && GigSpace.Client.MyAccount.Friends.Contains(frm.textBoxX1.Text) && frm.textBoxX2.Text.Length > 0)
                    {
                        GigSpace.SetSTAT("Transfert des points...");
                        if (GigSpace.Client.TransferGIGP(GigSpace.Client.MyAccount.Username, frm.integerInput1.Value, frm.textBoxX2.Text, frm.textBoxX1.Text))
                        {
                            GigSpace.Client.MyAccount = GigSpace.Client.GetUserInfo(GigSpace.Client.MyAccount.Username);
                            LoadCtrl();
                            MessageBoxEx.Show("Points transfèrè avec succès", "GIGP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBoxEx.Show("Transfert échouè", "GIGP", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                else MessageBoxEx.Show("Solde insuffisant", "GIGP", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GigSpace.SetSTAT("Terminé");
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
                CGIGPfrm frm = new CGIGPfrm();
                if (GigSpace.Client.MyAccount.GIGP > 3)
                {
                    frm.integerInput1.MaxValue = GigSpace.Client.MyAccount.GIGP - 1;
                    frm.ShowDialog();
                    if (frm.Done && frm.textBoxX2.Text.Length > 0)
                    {
                        GigSpace.SetSTAT("Convertion des points...");
                        if (GigSpace.Client.ConvertGIGP(frm.integerInput1.Value, frm.textBoxX2.Text))
                        {
                            GigSpace.Client.MyAccount = GigSpace.Client.GetUserInfo(GigSpace.Client.MyAccount.Username);
                            LoadCtrl();
                            MessageBoxEx.Show("Points transfèrè au jeu avec succès", "GIGP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBoxEx.Show("Transfert échouè", "GIGP", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                else MessageBoxEx.Show("Solde insuffisant", "GIGP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GigSpace.SetSTAT("Terminé");
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
                     Process.Start(GigSpace.ShopLink + "buy/buy_gigp.php");
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }

        private void labelX2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (GigSpace.Client.MyAccount.GIGP > 10)
                    labelX2.ForeColor = Color.LimeGreen;
                else
                    labelX2.ForeColor = Color.Red;
            }
            catch
            {

            }
        }
    }
}
