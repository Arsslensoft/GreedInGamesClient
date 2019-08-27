namespace GIG_CLIENT
{
    partial class GIGPCtrl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.itemPanel1 = new DevComponents.DotNetBar.ItemPanel();
            this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
            this.shopbtn = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.unpaidTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.helpTile = new DevComponents.DotNetBar.Metro.MetroTileItem();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 55);
            this.panel1.TabIndex = 1;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.DarkRed;
            this.labelX1.Location = new System.Drawing.Point(287, 9);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(209, 43);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "<b>Banque Points GIG</b>";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelX2.Location = new System.Drawing.Point(287, 146);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(209, 43);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "0 GIGP";
            this.labelX2.TextChanged += new System.EventHandler(this.labelX2_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(16, 351);
            this.panel2.TabIndex = 3;
            // 
            // itemPanel1
            // 
            this.itemPanel1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.itemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemPanel1.ContainerControlProcessDialogKey = true;
            this.itemPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.itemPanel1.ForeColor = System.Drawing.Color.White;
            this.itemPanel1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1});
            this.itemPanel1.Location = new System.Drawing.Point(16, 299);
            this.itemPanel1.Name = "itemPanel1";
            this.itemPanel1.Size = new System.Drawing.Size(792, 107);
            this.itemPanel1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.itemPanel1.TabIndex = 18;
            this.itemPanel1.Text = "itemPanel1";
            // 
            // itemContainer1
            // 
            // 
            // 
            // 
            this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.itemContainer1.ItemSpacing = 6;
            this.itemContainer1.MinimumSize = new System.Drawing.Size(740, 100);
            this.itemContainer1.MultiLine = true;
            this.itemContainer1.Name = "itemContainer1";
            this.itemContainer1.ResizeItemsToFit = false;
            this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.shopbtn,
            this.unpaidTile,
            this.helpTile});
            // 
            // 
            // 
            this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // shopbtn
            // 
            this.shopbtn.Name = "shopbtn";
            this.shopbtn.SymbolColor = System.Drawing.Color.Empty;
            this.shopbtn.Text = "<font size=\"+4\">Transférer<br/>des points</font>";
            this.shopbtn.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Default;
            this.shopbtn.TileSize = new System.Drawing.Size(240, 90);
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
            this.shopbtn.TitleText = "GIGP";
            this.shopbtn.Click += new System.EventHandler(this.shopbtn_Click);
            // 
            // unpaidTile
            // 
            this.unpaidTile.Name = "unpaidTile";
            this.unpaidTile.SymbolColor = System.Drawing.Color.Empty;
            this.unpaidTile.Text = "<font size=\"+4\">Convertir<br/>des points</font>";
            this.unpaidTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedOrange;
            this.unpaidTile.TileSize = new System.Drawing.Size(240, 90);
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
            this.unpaidTile.TitleText = "GTA";
            this.unpaidTile.Click += new System.EventHandler(this.unpaidTile_Click);
            // 
            // helpTile
            // 
            this.helpTile.Name = "helpTile";
            this.helpTile.SymbolColor = System.Drawing.Color.Empty;
            this.helpTile.Text = "<font size=\"+4\">Acheter des points</font>";
            this.helpTile.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Blue;
            this.helpTile.TileSize = new System.Drawing.Size(240, 90);
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
            this.helpTile.TitleText = "Shop";
            this.helpTile.Click += new System.EventHandler(this.helpTile_Click);
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.Color.Gray;
            this.labelX3.Location = new System.Drawing.Point(248, 97);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(248, 43);
            this.labelX3.TabIndex = 19;
            this.labelX3.Text = "<font color=\"#787878\"><b>Votre   solde   est :</b></font>";
            // 
            // GIGPCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(62)))), ((int)(((byte)(67)))));
            this.BackgroundImage = global::GIG_CLIENT.Properties.Resources.BGE;
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.itemPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.panel1);
            this.Name = "GIGPCtrl";
            this.Size = new System.Drawing.Size(808, 406);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.ItemPanel itemPanel1;
        private DevComponents.DotNetBar.ItemContainer itemContainer1;
        private DevComponents.DotNetBar.Metro.MetroTileItem shopbtn;
        private DevComponents.DotNetBar.Metro.MetroTileItem unpaidTile;
        private DevComponents.DotNetBar.Metro.MetroTileItem helpTile;
        private DevComponents.DotNetBar.LabelX labelX3;
    }
}
