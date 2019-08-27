using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GIG.Client;
using DevComponents.DotNetBar;
using System.IO;
using System.Diagnostics;

namespace GIG_CLIENT
{
    public partial class ShopCtrl : UserControl
    {
        public ShopCtrl()
        {
            InitializeComponent();
        }
 
        public void Init()
        {
            try
            {
              
             
                    GigSpace.SetSTAT("Recherche des articles...");
                    itemPanel1.Items.Clear();
                    itemPanel2.Items.Clear();
                    itemPanel3.Items.Clear();
                foreach (GigVehicle c in GigSpace.Client.GetVehicles())
                {
                    ButtonItem b = new ButtonItem();
                    if (File.Exists(Application.StartupPath + @"\CARS\Vehicle_" + c.Model + ".jpg"))
                        b.Image = new Bitmap(Application.StartupPath + @"\CARS\Vehicle_" + c.Model + ".jpg");

                    if (c.Price <= GigSpace.Client.MyAccount.GIGP)
                        b.ForeColor = Color.LimeGreen;
                    else
                        b.ForeColor = Color.Red;
                    b.ButtonStyle = eButtonStyle.ImageAndText;
                    b.Text = c.ID.ToString() + ". "+c.Name;
                    b.Name = c.ID.ToString();
                    b.Tag = c;
                    b.Click += new EventHandler(b_Click);
                    itemPanel1.Items.Add(b);
                }
                foreach (GigHouse h in GigSpace.Client.GetHouses())
                {
                    ButtonItem b = new ButtonItem();
                    b.Text = h.ID.ToString() + ". " + h.Name.Replace("?", "è");

                    if (h.Price <= GigSpace.Client.MyAccount.GIGP)
                        b.ForeColor = Color.LimeGreen;
                    else
                        b.ForeColor = Color.Red;
                    b.Name = h.ID.ToString();
                    b.Tag = h;
                    b.Click += new EventHandler(h_Click);
                    itemPanel2.Items.Add(b);
                }

                foreach (GigWeapon w in GigSpace.Client.GetWeapons())
                {
                    ButtonItem b = new ButtonItem();
                    if (File.Exists(Application.StartupPath + @"\WEAPONS\" + w.ID + ".gif"))
                        b.Image = new Bitmap(Application.StartupPath + @"\WEAPONS\" + w.ID + ".gif");
                    b.Name = w.ID.ToString();
                    b.ButtonStyle = eButtonStyle.ImageAndText;
                    if (w.Price <= GigSpace.Client.MyAccount.GIGP)
                        b.ForeColor = Color.LimeGreen;
                    else
                        b.ForeColor = Color.Red;

                    b.Text = w.ID.ToString() + ". " + w.Name;
                    b.Tag = w;
                    b.Click += new EventHandler(w_Click);
                    itemPanel3.Items.Add(b);
                    GigSpace.SetSTAT("Terminé");
              
            }
            }
            catch
            {

            }
        }
        void b_Click(object sender, EventArgs e)
        {
            ButtonItem b = (ButtonItem)sender;
            GigVehicle c = (GigVehicle)b.Tag;

            if (GigSpace.Client.MyAccount.GIGP < c.Price)
                MessageBoxEx.Show("Votre solde est insuffisant!", "Achat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBoxEx.Show("Votre solde est suffisant. \r\n Vous serez redirigé vers la boutique en ligne.", "Achat", MessageBoxButtons.OK, MessageBoxIcon.Information);
             Process.Start(GigSpace.ShopLink + "index.php?p=product&id=" + c.ID.ToString() + "&type=vehicle");
            }
         
        }
        void h_Click(object sender, EventArgs e)
        {
            ButtonItem b = (ButtonItem)sender;
            GigHouse c = (GigHouse)b.Tag;

            if (GigSpace.Client.MyAccount.GIGP < c.Price)
                MessageBoxEx.Show("Votre solde est insuffisant!", "Achat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBoxEx.Show("Votre solde est suffisant. \r\n Vous serez redirigé vers la boutique en ligne.", "Achat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(GigSpace.ShopLink + "index.php?p=product&id=" + c.ID.ToString() + "&type=house");
            }

        }
        void w_Click(object sender, EventArgs e)
        {
            ButtonItem b = (ButtonItem)sender;
            GigWeapon c = (GigWeapon)b.Tag;

            if (GigSpace.Client.MyAccount.GIGP < c.Price)
                MessageBoxEx.Show("Votre solde est insuffisant!", "Achat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                MessageBoxEx.Show("Votre solde est suffisant. \r\n Vous serez redirigé vers la boutique en ligne.", "Achat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(GigSpace.ShopLink + "index.php?p=product&id=" + c.ID.ToString() + "&type=weapon");
            }

        }

    }
}
