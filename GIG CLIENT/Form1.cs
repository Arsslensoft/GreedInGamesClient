using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace GIG_CLIENT
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsManager.SetString("DELAY", integerInput1.Value.ToString());
                SettingsManager.SetBool("CONNECT", checkBoxX2.Checked);
                SettingsManager.Save();
                this.Close();
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                integerInput1.Value = SettingsManager.GetInt("DELAY");
              checkBoxX2.Checked =  SettingsManager.GetBool("CONNECT");
            }
            catch (Exception ex)
            {
                GigSpace.LogError(ex);
            }
        }
    }
}