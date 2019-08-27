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
    public partial class CGIGPfrm : MetroForm
    {
        public CGIGPfrm()
        {
            InitializeComponent();
        }
        internal bool Done = false;
        private void buttonX1_Click(object sender, EventArgs e)
        {
            Done = true;
            this.Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
