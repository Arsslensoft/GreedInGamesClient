namespace GIG_CLIENT
{
    partial class HomeCtrl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeCtrl));
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.shopbtn = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.salesTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.unpaidTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.reportTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.ytdTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.helpTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.devCoTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem1 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.compteGIGP = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem2 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.appViewTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.metroTileItem3 = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX2
            // 
            resources.ApplyResources(this.labelX2, "labelX2");
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Name = "labelX2";
            this.labelX2.TextChanged += new System.EventHandler(this.labelX2_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labelX2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GIG_CLIENT.Properties.Resources.logo;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::GIG_CLIENT.Properties.Resources.user;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.itemPanel1);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // itemPanel1
            // 
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            resources.ApplyResources(this.itemPanel1, "itemPanel1");
            this.itemPanel1.ForeColor = System.Drawing.Color.White;
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1});
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.ItemSpacing = 6;
            this.itemContainer1.MinimumSize = new System.Drawing.Size(740, 180);
            this.itemContainer1.MultiLine = true;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.ResizeItemsToFit = false;
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.shopbtn,
            this.salesTile,
            this.unpaidTile,
            this.reportTile,
            this.ytdTile,
            this.helpTile,
            this.devCoTile,
            this.metroTileItem1,
            this.compteGIGP,
            this.metroTileItem2,
            this.appViewTile,
            this.metroTileItem3});
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // shopbtn
            // 
            this.shopbtn.Image = global::GIG_CLIENT.Properties.Resources.shop_cart_icon;
            this.shopbtn.Name = "shopbtn";
            this.shopbtn.SymbolColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.shopbtn, "shopbtn");
            this.shopbtn.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            // 
            // 
            // 
            this.shopbtn.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(83)))), ((int)(((byte)(117)))));
            this.shopbtn.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(155)))));
            this.shopbtn.TileStyle.BackColorGradientAngle = 45;
            this.shopbtn.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.shopbtn.TileStyle.PaddingBottom = 4;
            this.shopbtn.TileStyle.PaddingLeft = 4;
            this.shopbtn.TileStyle.PaddingRight = 4;
            this.shopbtn.TileStyle.PaddingTop = 4;
            this.shopbtn.TileStyle.TextColor = System.Drawing.Color.White;
            this.shopbtn.TitleText = "GTA";
            this.shopbtn.Click += new System.EventHandler(this.shopbtn_Click);
            // 
            // salesTile
            // 
            this.salesTile.Image = global::GIG_CLIENT.Properties.Resources.JETONS;
            this.salesTile.Name = "salesTile";
            this.salesTile.SymbolColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.salesTile, "salesTile");
            this.salesTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Coffee;
            // 
            // 
            // 
            this.salesTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(76)))), ((int)(((byte)(41)))));
            this.salesTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(67)))), ((int)(((byte)(37)))));
            this.salesTile.TileStyle.BackColorGradientAngle = 45;
            this.salesTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.salesTile.TileStyle.PaddingBottom = 4;
            this.salesTile.TileStyle.PaddingLeft = 4;
            this.salesTile.TileStyle.PaddingRight = 4;
            this.salesTile.TileStyle.PaddingTop = 4;
            this.salesTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.salesTile.TitleText = "GIGP";
            this.salesTile.Click += new System.EventHandler(this.salesTile_Click);
            // 
            // unpaidTile
            // 
            this.unpaidTile.Image = global::GIG_CLIENT.Properties.Resources.user_business;
            this.unpaidTile.Name = "unpaidTile";
            this.unpaidTile.SymbolColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.unpaidTile, "unpaidTile");
            this.unpaidTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange;
            // 
            // 
            // 
            this.unpaidTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(60)))), ((int)(((byte)(0)))));
            this.unpaidTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(57)))), ((int)(((byte)(0)))));
            this.unpaidTile.TileStyle.BackColorGradientAngle = 45;
            this.unpaidTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.unpaidTile.TileStyle.PaddingBottom = 4;
            this.unpaidTile.TileStyle.PaddingLeft = 4;
            this.unpaidTile.TileStyle.PaddingRight = 4;
            this.unpaidTile.TileStyle.PaddingTop = 4;
            this.unpaidTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.unpaidTile.TitleText = "My Account";
            this.unpaidTile.Click += new System.EventHandler(this.unpaidTile_Click);
            // 
            // reportTile
            // 
            this.reportTile.Image = global::GIG_CLIENT.Properties.Resources.users_business;
            this.reportTile.Name = "reportTile";
            this.reportTile.SymbolColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.reportTile, "reportTile");
            this.reportTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange;
            // 
            // 
            // 
            this.reportTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(131)))), ((int)(((byte)(0)))));
            this.reportTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(136)))), ((int)(((byte)(0)))));
            this.reportTile.TileStyle.BackColorGradientAngle = 45;
            this.reportTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.reportTile.TileStyle.PaddingBottom = 4;
            this.reportTile.TileStyle.PaddingLeft = 4;
            this.reportTile.TileStyle.PaddingRight = 4;
            this.reportTile.TileStyle.PaddingTop = 4;
            this.reportTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.reportTile.TitleText = "Friends";
            this.reportTile.Click += new System.EventHandler(this.reportTile_Click);
            // 
            // ytdTile
            // 
            this.ytdTile.Image = global::GIG_CLIENT.Properties.Resources.bank_transaction_clock;
            this.ytdTile.Name = "ytdTile";
            this.ytdTile.SymbolColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.ytdTile, "ytdTile");
            this.ytdTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Magenta;
            // 
            // 
            // 
            this.ytdTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(85)))), ((int)(((byte)(148)))));
            this.ytdTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(98)))), ((int)(((byte)(185)))));
            this.ytdTile.TileStyle.BackColorGradientAngle = 45;
            this.ytdTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ytdTile.TileStyle.PaddingBottom = 4;
            this.ytdTile.TileStyle.PaddingLeft = 4;
            this.ytdTile.TileStyle.PaddingRight = 4;
            this.ytdTile.TileStyle.PaddingTop = 4;
            this.ytdTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.ytdTile.TitleText = "My commands";
            this.ytdTile.Click += new System.EventHandler(this.ytdTile_Click);
            // 
            // helpTile
            // 
            this.helpTile.Image = global::GIG_CLIENT.Properties.Resources.e_mail;
            this.helpTile.Name = "helpTile";
            this.helpTile.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.TopRight;
            this.helpTile.SymbolColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.helpTile, "helpTile");
            this.helpTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue;
            // 
            // 
            // 
            this.helpTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(102)))), ((int)(((byte)(168)))));
            this.helpTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(120)))), ((int)(((byte)(190)))));
            this.helpTile.TileStyle.BackColorGradientAngle = 45;
            this.helpTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.helpTile.TileStyle.PaddingBottom = 4;
            this.helpTile.TileStyle.PaddingLeft = 4;
            this.helpTile.TileStyle.PaddingRight = 4;
            this.helpTile.TileStyle.PaddingTop = 4;
            this.helpTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.helpTile.TitleText = "Messenger";
            this.helpTile.Click += new System.EventHandler(this.helpTile_Click);
            // 
            // devCoTile
            // 
            this.devCoTile.Image = global::GIG_CLIENT.Properties.Resources.notification_done;
            this.devCoTile.Name = "devCoTile";
            this.devCoTile.NotificationMarkPosition = DevComponents.DotNetBar.eNotificationMarkPosition.TopRight;
            this.devCoTile.SymbolColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.devCoTile, "devCoTile");
            this.devCoTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Olive;
            // 
            // 
            // 
            this.devCoTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(0)))), ((int)(((byte)(70)))));
            this.devCoTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(0)))), ((int)(((byte)(61)))));
            this.devCoTile.TileStyle.BackColorGradientAngle = 45;
            this.devCoTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.devCoTile.TileStyle.PaddingBottom = 4;
            this.devCoTile.TileStyle.PaddingLeft = 4;
            this.devCoTile.TileStyle.PaddingRight = 4;
            this.devCoTile.TileStyle.PaddingTop = 4;
            this.devCoTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.devCoTile.TitleText = "Servers";
            this.devCoTile.Click += new System.EventHandler(this.devCoTile_Click);
            // 
            // metroTileItem1
            // 
            this.metroTileItem1.Image = global::GIG_CLIENT.Properties.Resources.samp;
            this.metroTileItem1.Name = "metroTileItem1";
            this.metroTileItem1.SymbolColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.metroTileItem1, "metroTileItem1");
            this.metroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Plum;
            // 
            // 
            // 
            this.metroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem1.TitleText = "SA-MP Intégré";
            this.metroTileItem1.Click += new System.EventHandler(this.metroTileItem1_Click);
            // 
            // compteGIGP
            // 
            this.compteGIGP.Image = global::GIG_CLIENT.Properties.Resources.gig;
            this.compteGIGP.Name = "compteGIGP";
            this.compteGIGP.SymbolColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.compteGIGP, "compteGIGP");
            this.compteGIGP.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green;
            // 
            // 
            // 
            this.compteGIGP.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(151)))), ((int)(((byte)(42)))));
            this.compteGIGP.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(177)))), ((int)(((byte)(51)))));
            this.compteGIGP.TileStyle.BackColorGradientAngle = 45;
            this.compteGIGP.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.compteGIGP.TileStyle.PaddingBottom = 4;
            this.compteGIGP.TileStyle.PaddingLeft = 4;
            this.compteGIGP.TileStyle.PaddingRight = 4;
            this.compteGIGP.TileStyle.PaddingTop = 4;
            this.compteGIGP.TileStyle.TextColor = System.Drawing.Color.White;
            this.compteGIGP.TitleText = "Community";
            this.compteGIGP.Click += new System.EventHandler(this.compteGIGP_Click);
            // 
            // metroTileItem2
            // 
            this.metroTileItem2.Image = global::GIG_CLIENT.Properties.Resources.cs;
            this.metroTileItem2.Name = "metroTileItem2";
            this.metroTileItem2.SymbolColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.metroTileItem2, "metroTileItem2");
            this.metroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Yellowish;
            // 
            // 
            // 
            this.metroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem2.TitleText = "Counter Strike";
            this.metroTileItem2.Click += new System.EventHandler(this.metroTileItem2_Click);
            // 
            // appViewTile
            // 
            this.appViewTile.Image = global::GIG_CLIENT.Properties.Resources.users;
            this.appViewTile.Name = "appViewTile";
            this.appViewTile.SymbolColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.appViewTile, "appViewTile");
            this.appViewTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.PlumWashed;
            // 
            // 
            // 
            this.appViewTile.TileStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(55)))), ((int)(((byte)(76)))));
            this.appViewTile.TileStyle.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(46)))), ((int)(((byte)(64)))));
            this.appViewTile.TileStyle.BackColorGradientAngle = 45;
            this.appViewTile.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.appViewTile.TileStyle.PaddingBottom = 4;
            this.appViewTile.TileStyle.PaddingLeft = 4;
            this.appViewTile.TileStyle.PaddingRight = 4;
            this.appViewTile.TileStyle.PaddingTop = 4;
            this.appViewTile.TileStyle.TextColor = System.Drawing.Color.White;
            this.appViewTile.TitleText = "GTA space";
            this.appViewTile.Click += new System.EventHandler(this.appViewTile_Click);
            // 
            // metroTileItem3
            // 
            this.metroTileItem3.Image = global::GIG_CLIENT.Properties.Resources.help_contents;
            this.metroTileItem3.Name = "metroTileItem3";
            this.metroTileItem3.SymbolColor = System.Drawing.Color.Empty;
            resources.ApplyResources(this.metroTileItem3, "metroTileItem3");
            this.metroTileItem3.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.DarkBlue;
            // 
            // 
            // 
            this.metroTileItem3.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.metroTileItem3.TitleText = "Aide et Support";
            this.metroTileItem3.Click += new System.EventHandler(this.metroTileItem3_Click);
            // 
            // HomeCtrl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(62)))), ((int)(((byte)(67)))));
            this.BackgroundImage = global::GIG_CLIENT.Properties.Resources.BGE;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "HomeCtrl";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTileItem shopbtn;
        private DevComponents.DotNetBar.Metro.MetroTileItem compteGIGP;
        private DevComponents.DotNetBar.Metro.MetroTileItem appViewTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem salesTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem unpaidTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem reportTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem ytdTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem1;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem2;
        private DevComponents.DotNetBar.Metro.MetroTileItem metroTileItem3;
        private System.Windows.Forms.PictureBox pictureBox2;
        internal DevComponents.DotNetBar.Metro.MetroTileItem devCoTile;
        internal DevComponents.DotNetBar.Metro.MetroTileItem helpTile;

    }
}
