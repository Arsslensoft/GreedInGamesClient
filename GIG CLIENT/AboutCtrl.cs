using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.IO;

namespace GIG_CLIENT
{
    public partial class AboutCtrl : UserControl
    {
        public AboutCtrl()
        {
            InitializeComponent();
        }
        public void SetLanguage(string lang)
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
                // Sets the UI culture to French (France)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            }
            catch(Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }
        
    }
}
