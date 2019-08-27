using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;

namespace GIG_CLIENT
{
    public partial class TransferFrm : MetroForm
    {
        public TransferFrm()
        {
            InitializeComponent();
        }
        internal bool Done = false;
        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Done = true;
            this.Close();

        }

        private void TransferFrm_Load(object sender, EventArgs e)
        {
            try
            {
                textBoxX1.Items.AddRange(GigSpace.Client.MyAccount.Friends.ToArray());
                textBoxX1.SelectedIndex = 0;
            }
            catch
            {

            }
        }
    }
}
