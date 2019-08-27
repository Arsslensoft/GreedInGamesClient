using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using System.IO;
using System.Runtime.InteropServices;
using DevComponents.DotNetBar;

namespace GIG_CLIENT
{
    internal delegate void InvokeLabel(string text, LabelItem CurFile);
    internal delegate void InvokeTile(int count, MetroTileItem tile);
    public partial class Home : MetroAppForm
    {

        public void UpdateTile(MetroTileItem label, int val)
        {
            try
            {
                if (label.NotificationMarkText.Length > 0)
                {
                    label.NotificationMarkText = (int.Parse(label.NotificationMarkText) + val).ToString();
                }
                else
                label.NotificationMarkText = val.ToString();
                this.Refresh();
            }
            catch
            {

            }

        }
      

        public void UpdateLabel(LabelItem label, string val)
        {
          
            InvokeLabel d = new InvokeLabel(UpdateCurFile);
          label.Invoke(d, new object[2] { val, label});
       
        }
        void UpdateCurFile(string text, LabelItem CurFile)
        {
            CurFile.Text = text;
            this.Refresh();

        }
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
        public void ShowPanel(Control panel)
        {
            if (panel == GigSpace.HomeControl)
                GigSpace.HomeControl.SetUserInfo(GigSpace.Client.MyAccount.Username, GigSpace.Client.MyAccount.Name);
            panel.Size = new Size(768, 406);
            this.ShowModalPanel(panel, RandomSlide());
        }
        public Home()
        {
            InitializeComponent();
            try
            {
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
                GigSpace.MainForm = this;
                GigSpace.MessageArrived += new OnNotif(GigSpace_MessageArrived);
                GigSpace.NotificationArrived += new OnNotif(GigSpace_NotificationArrived);
                // Run Thread
                AsyncExec exec = new AsyncExec(GigSpace.Run);
                exec.BeginInvoke(null, null);
            }
            catch
            {

            }
        }
        void GigSpace_MessageArrived(int val)
        {
            try
            {
                UpdateTile(GigSpace.HomeControl.helpTile, val);
                notifyIcon1.ShowBalloonTip(2000, "Messages", "vous avez reçu des messages", ToolTipIcon.Info);

            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }
        void GigSpace_NotificationArrived(int val)
        {
            try
            {
                UpdateTile(GigSpace.HomeControl.devCoTile, val);
                notifyIcon1.ShowBalloonTip(2000, "Notifications", "vous avez reçu des notifications", ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }
    
        Random rd = new Random();
        DevComponents.DotNetBar.Controls.eSlideSide RandomSlide()
        {
            int r = rd.Next(0, 3);
            switch (r)
            {
                case 0:
                    return DevComponents.DotNetBar.Controls.eSlideSide.Bottom;
             
                case 1:
                    return DevComponents.DotNetBar.Controls.eSlideSide.Left;
                
                case 2:
                    return DevComponents.DotNetBar.Controls.eSlideSide.Top;
              
                case 3:
                    return DevComponents.DotNetBar.Controls.eSlideSide.Right;
                  
            }
            return DevComponents.DotNetBar.Controls.eSlideSide.Right;

        }
        private void findfriendbtn_Click(object sender, EventArgs e)
        {
            try
            {
                GigSpace.FriendControl.Init();
              ShowPanel(GigSpace.FriendControl);
            }
            catch
            {

            }
        }

        private void sendmsgbtn_Click(object sender, EventArgs e)
        {
            try
            {
                MSGSendfrm frm = new MSGSendfrm();
                frm.ShowDialog();
            }
            catch
            {

            }
        }

   

        private void showtrans_Click(object sender, EventArgs e)
        {
            try
            {
                GigSpace.TransactionControl.Init();
                ShowPanel(GigSpace.TransactionControl);
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }

      
        private void disconbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(Application.StartupPath + @"\Data\AT.dat"))
                    File.Delete(Application.StartupPath + @"\Data\AT.dat");
                close = true;
                GigSpace.Client.Logout();
                Application.Exit();


            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }

        private void metroShell1_SettingsButtonClick(object sender, EventArgs e)
        {
            try
            {
                ShowPanel(GigSpace.HomeControl);
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }

        private void metroShell1_HelpButtonClick(object sender, EventArgs e)
        {
            try
            {
                Form1 frm = new Form1();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            try
            {
                buttonItem1.Visible = true;
                buttonItem1.Enabled = true;
     

            }
            catch
            {

            }
        }

        private void Home_Resize(object sender, EventArgs e)
        {
            try
            {
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            }
            catch
            {

            }
        }

        private void aboutbtn_Click(object sender, EventArgs e)
        {

            try
            {
                ShowPanel(GigSpace.AboutControl);
            }
            catch
            {

            }
        }

        private void buttonItem1_EnabledChanged(object sender, EventArgs e)
        {
            buttonItem1.Enabled = true;
        }

        private void Home_Shown(object sender, EventArgs e)
        {
            try
            {

             GigSpace.CommunityControl.Init();
             GigSpace.SetSTAT("Prêt");
                ShowPanel(GigSpace.HomeControl);

                GPlayer.Welcome();
            }
            catch
            {

            }
        }
        bool close = false;
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            close = true;
            this.Close();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !close;
            if (!close)
                this.Hide();
            else if(SettingsManager.GetBool("CONNECT"))
            {
                if (File.Exists(Application.StartupPath + @"\Data\AT.dat"))
                    File.Delete(Application.StartupPath + @"\Data\AT.dat");
                GigSpace.Client.Logout();
            }

            if (close)
                GPlayer.Goodbye();
        }

        private void avuibtn_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            bEditPopup.Displayed = false;
            bEditPopup.PopupMenu(MousePosition);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

       



  

        private void Skinbtn_Click(object sender, EventArgs e)
        {
            try
            {
           
                ShowPanel(GigSpace.SkinControl);
            }
            catch
            {

            }
        }

    }
}
