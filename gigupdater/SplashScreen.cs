using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Xml;
using System.Net;
using System.IO;
using DevComponents.DotNetBar;
using System.Diagnostics;
using System.Threading;

namespace gigupdater
{
    internal delegate void InvokeLabel(string text, LabelX CurFile);
   internal delegate void AsyncRun();
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class SplashScreen : System.Windows.Forms.Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
         );

        public SplashScreen()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreen));
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.panelEx1 = new System.Windows.Forms.Panel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.progressBarX1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(62)))), ((int)(((byte)(67))))), System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(120)))), ((int)(((byte)(143))))));
            // 
            // panelEx1
            // 
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.progressBarX1);
            this.panelEx1.Controls.Add(this.pictureBox1);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(297, 178);
            this.panelEx1.TabIndex = 0;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(12, 116);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(273, 23);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "Mise à jour...";
            // 
            // progressBarX1
            // 
            // 
            // 
            // 
            this.progressBarX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBarX1.Location = new System.Drawing.Point(12, 145);
            this.progressBarX1.Name = "progressBarX1";
            this.progressBarX1.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee;
            this.progressBarX1.Size = new System.Drawing.Size(273, 18);
            this.progressBarX1.TabIndex = 1;
            this.progressBarX1.Text = "progressBarX1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::gigupdater.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(-240, -18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(547, 128);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SplashScreen
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(62)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(297, 178);
            this.Controls.Add(this.panelEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SplashScreen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Greed In Games";
            this.Load += new System.EventHandler(this.SplashScreen_Load);
            this.Shown += new System.EventHandler(this.SplashScreen_Shown);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        internal static XmlDocument UpdateCode;
        internal static WebClient WD;
        internal static bool UpdateAvailable(int cbid)
        {
            try
            {
                WD.DownloadFile("http://www.greedingames.net/GIG_CLIENT/update.xml", Application.StartupPath + @"\update.xml");
                XmlDocument doc = new XmlDocument();
                doc.Load(Application.StartupPath + @"\update.xml");
                XmlElement el = (XmlElement)doc.DocumentElement.ChildNodes[0];
                int bid = int.Parse(el.GetAttribute("bid"));
                if (bid > cbid)
                {
                    WD.DownloadFile(el.GetAttribute("url"), Application.StartupPath + @"\update1.xml");
                    UpdateCode = new XmlDocument();
                    UpdateCode.Load(Application.StartupPath + @"\update1.xml");
                    return true;

                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {

                WD = new WebClient();
                int cbid = int.Parse(File.ReadAllText(Application.StartupPath + @"\Data\CB.dat"));
                bool up = UpdateAvailable(cbid);
                if (up && UpdateCode != null)
                    Application.Run(new SplashScreen());

             

            }
            catch
            {

            }
        }
        public void UpdateLabel(LabelX label, string val)
        {

            InvokeLabel d = new InvokeLabel(UpdateCurFile);
            label.Invoke(d, new object[2] { val, label });

        }
        void UpdateCurFile(string text, LabelX CurFile)
        {
            CurFile.Text = text;
            this.Refresh();

        }
        private IContainer components;
        void UpdateGIG()
        {
            try
            {
                foreach (Process p in Process.GetProcessesByName("GIGC.exe"))
                    p.Kill();
                foreach (XmlElement el in UpdateCode.DocumentElement.ChildNodes)
                {
                    UpdateLabel(labelX1, el.InnerText);
                    if (el.GetAttribute("type") == "folder")
                        Directory.CreateDirectory(el.GetAttribute("path").Replace("$_curdir_$", Application.StartupPath));
                    else
                        WD.DownloadFile(el.GetAttribute("url"), el.GetAttribute("path").Replace("$_curdir_$", Application.StartupPath));
                }
              
                File.WriteAllText(Application.StartupPath + @"\Data\RD.dat", UpdateCode.DocumentElement.GetAttribute("rd"));
                File.WriteAllText(Application.StartupPath + @"\Data\CB.dat", UpdateCode.DocumentElement.GetAttribute("bid"));
                UpdateLabel(labelX1, "Mise à jour terminé");
                Thread.Sleep(1500);
                Process.Start(Application.StartupPath + @"\GIGC.exe");
                this.Close();
            }
            catch
            {

            }
        }
        private void SplashScreen_Shown(object sender, EventArgs e)
        {

            try
            {

                AsyncRun b = new AsyncRun(UpdateGIG);
                b.BeginInvoke(null, null);
            }
            catch
            {

            }
         
            
        }
     
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private Panel panelEx1;
        private PictureBox pictureBox1;
        private DevComponents.DotNetBar.Controls.ProgressBarX progressBarX1;
        private DevComponents.DotNetBar.LabelX labelX1;

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch
            {

            }
        }
    }
}


