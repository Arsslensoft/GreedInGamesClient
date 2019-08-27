using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using GIG.Client;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Schedule;
using DevComponents.Schedule.Model;
using System.Xml;
using System.IO;

namespace GIG_CLIENT
{
    public partial class ProfileCtrl : UserControl
    {
        public ProfileCtrl()
        {
            InitializeComponent();
        }
 
        public void SelectTAB(string name)
        {
            if (name == "notify")
                superTabControl1.SelectedTab = Notificationtab;
            else
                superTabControl1.SelectedTab = superTabItem1;

        }
        public void SetProfileInfo(GigUser gigu)
        {
            try
            {
                if (gigu.Username == GigSpace.Client.MyAccount.Username)
                {
                    GigSpace.SetSTAT("Recherche de votre infos...");
                    GigSpace.Client.MyAccount = GigSpace.Client.GetUserInfo(GigSpace.Client.MyAccount.Username);
                    GigSpace.SetSTAT("Terminé");
                }
                    nlist.Items.Clear();
                    flist.Items.Clear();
                    vlist.Items.Clear();
                    if (gigu.Username == GigSpace.Client.MyAccount.Username)
                    {
                        Notificationtab.Visible = true;
                        foreach (string not in GigSpace.Client.GetNotifications())
                            nlist.AddItem(not);

                        superTabItem3.Visible = true;
                        buttonItem4.Visible = false;
                    }
                    else
                    {
                        Notificationtab.Visible = false;
                        nlist.Items.Clear();
                        superTabItem3.Visible = false;
                        buttonItem4.Visible = true;
                    }

                    unlb.Text = gigu.Username;
                    nlb.Text = gigu.Name;
                    elb.Text = gigu.Email;
                    rlb.Text = gigu.Role.ToString();
                    dlb.Text = gigu.RegistrationDate.ToString();

                    foreach (string friend in gigu.Friends)
                    {
                        if (friend.Length > 3)
                        {
                            ButtonItem item = new ButtonItem();
                            item.Image = GIG_CLIENT.Properties.Resources.my_friends;
                            item.Text = friend;
                            item.Name = friend;
                            item.ButtonStyle = eButtonStyle.ImageAndText;
                            item.Click += new EventHandler(item_Click);
                            flist.Items.Add(item);
                        }
                    }

                    gtaunlb.Text = gigu.GTAUsername;
                    gigplb.Text = gigu.GIGP.ToString();
                    vipgta.Text = gigu.VIP.ToString();
                    foreach (Car f in gigu.Cars)
                    {
                      vlist.AddItem(f.Name);
                    }


                    // Load Calender
                    calendarView1.CalendarModel.Appointments.Clear();
                    XmlDocument doc = new XmlDocument();
                    doc.Load(Application.StartupPath + @"\Data\Calender.dat");
                    foreach (XmlElement el in doc.DocumentElement.ChildNodes)
                    {
                        DateTime startDate = DateTime.Parse(el.GetAttribute("sd"));
                        DateTime endDate = DateTime.Parse(el.GetAttribute("ed"));

                        if (calendarView1.DateSelectionStart.HasValue &&
                            calendarView1.DateSelectionEnd.HasValue)
                        {
                            startDate = calendarView1.DateSelectionStart.Value;
                            endDate = calendarView1.DateSelectionEnd.Value;
                        }

                        Appointment ap = AddNewAppointment(startDate, endDate, el.GetAttribute("desc"), el.GetAttribute("subject"), el.GetAttribute("tooltip"));

                        // Make sure the appointment is visible

                        calendarView1.EnsureVisible(ap);
                 
                }
            }
            catch
            {

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
            catch
            {

            }
        }
        private void btnDay_Click(object sender, EventArgs e)
        {
            calendarView1.SelectedView = eCalendarView.Day;
        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            calendarView1.SelectedView = eCalendarView.Week;
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            calendarView1.SelectedView = eCalendarView.Month;
        }

        private void btnYear_Click(object sender, EventArgs e)
        {
            calendarView1.SelectedView = eCalendarView.Year;
        }
        Random rd = new Random();
        private void btnTimeLine_Click(object sender, EventArgs e)
        {
            calendarView1.SelectedView = eCalendarView.TimeLine;
        }
        private Appointment AddNewAppointment(DateTime startDate, DateTime endDate, string desc, string subject, string tooltip)
        {
            // Create new appointment and add it to the model
            // Appointment will show up in the view automatically

            Appointment appointment = new Appointment();

            appointment.StartTime = startDate;
            appointment.EndTime = endDate;

            appointment.Subject = subject;

            appointment.Description = desc;
            appointment.Tooltip = tooltip;

            // Add appointment to the model
            int r = rd.Next(0, 5);
            switch(r)
            {
                case 0:
                    appointment.CategoryColor = Appointment.CategoryRed;
                   break;
                case 1:
                   appointment.CategoryColor = Appointment.CategoryGreen;
                   break;
                case 2:
                   appointment.CategoryColor = Appointment.CategoryOrange;
                   break;
                case 3:
                   appointment.CategoryColor = Appointment.CategoryPurple;
                   break;
                case 4:
                   appointment.CategoryColor = Appointment.CategoryBlue;
                   break;
                case 5:
                   appointment.CategoryColor = Appointment.CategoryYellow;
                   break;
        }
            calendarView1.CalendarModel.Appointments.Add(appointment);

            return (appointment);
        }
        private void buttonItem1_Click(object sender, EventArgs e)
        {
            try
            {
                AddAppointmentFrm frm = new AddAppointmentFrm();
                frm.ShowDialog();
                if (frm.Done && frm.textBoxX1.Text.Length > 0 && frm.textBoxX2.Text.Length > 0 && frm.textBoxX3.Text.Length > 0 && frm.dateTimeInput1.Value < frm.dateTimeInput2.Value)
                {
                    DateTime startDate = frm.dateTimeInput1.Value;
                    DateTime endDate = frm.dateTimeInput2.Value;

                    if (calendarView1.DateSelectionStart.HasValue &&
                        calendarView1.DateSelectionEnd.HasValue)
                    {
                        startDate = calendarView1.DateSelectionStart.Value;
                        endDate = calendarView1.DateSelectionEnd.Value;
                    }

                    Appointment ap = AddNewAppointment(startDate, endDate, frm.textBoxX1.Text, frm.textBoxX3.Text, frm.textBoxX2.Text);

                    // Make sure the appointment is visible

                    calendarView1.EnsureVisible(ap);
                }
                else
                    MessageBoxEx.Show("Données invalides", "Rendez-vous", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

            }
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            try{
                foreach (AppointmentView a in calendarView1.SelectedAppointments)
                    calendarView1.CalendarModel.Appointments.Remove(a.Appointment);
            
            }
            catch{

            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            try
            {

              using(StreamWriter str = new StreamWriter(Application.StartupPath + @"\Data\Calender.dat", false))
              {  
                  str.WriteLine("<cal>");
                foreach (Appointment ap in calendarView1.CalendarModel.Appointments)
                {
                    str.WriteLine("<ap desc='"+ap.Description+"'  tooltip='"+ap.Tooltip+"' subject='"+ap.Subject+"' sd='"+ap.StartTime.ToString()+"' ed='"+ap.EndTime.ToString()+"'></ap>");
                }
                    str.WriteLine("</cal>");
                }
            }
            catch
            {

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                nlist.Items.Clear();
                GigSpace.MainForm.Refresh();
                GigSpace.Client.CleanNotifications();
            }
            catch
            {

            }
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            try
            {
                GigSpace.Client.RemoveUser(unlb.Text);
                GigSpace.MainForm.ShowPanel(GigSpace.HomeControl);
            }
            catch
            {

            }
        }
    }
}
