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
namespace GIG_CLIENT
{
    public partial class SkinCtrl : UserControl
    {
        public SkinCtrl()
        {
            InitializeComponent();
        }
        int current = 0;
        List<GSkin> SkinsOwned = new List<GSkin>();
       
        public void Init()
        {
            try
            {
               
            }
            catch
            {

            }
        }
        void btn_Click(object sender, EventArgs e)
        {
            try
            {

              
            }
            catch
            {

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
             
            }
            catch
            {

            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                current++;
                if (current > 9)
                {
                    if (File.Exists(Application.StartupPath + @"\SKINS\" + current.ToString() + ".png"))
                    {
                        pictureBox1.Image = new Bitmap(Application.StartupPath + @"\SKINS\" + current.ToString() + ".png");
                    }
                    else
                        pictureBox1.Image = new Bitmap(Application.StartupPath + @"\SKINS\00.png");
                }
                else
                {
                    if (File.Exists(Application.StartupPath + @"\SKINS\0" + current.ToString() + ".png"))
                    {
                        pictureBox1.Image =new Bitmap( Application.StartupPath + @"\SKINS\0" + current.ToString() + ".png");
                    }
                    else
                        pictureBox1.Image = new Bitmap(Application.StartupPath + @"\SKINS\00.png");
                }
                stepIndicator1.CurrentStep = current + 1;
            }
            catch
            {

            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            try
            {
                current--;
                if (current > 9)
                {
                    if (File.Exists(Application.StartupPath + @"\SKINS\" + current.ToString() + ".png"))
                    {
                        pictureBox1.Image = new Bitmap(Application.StartupPath + @"\SKINS\" + current.ToString() + ".png");
                    }
                    else
                        pictureBox1.Image = new Bitmap(Application.StartupPath + @"\SKINS\00.png");
                }
                else
                {
                    if (File.Exists(Application.StartupPath + @"\SKINS\0" + current.ToString() + ".png"))
                    {
                        pictureBox1.Image = new Bitmap(Application.StartupPath + @"\SKINS\0" + current.ToString() + ".png");
                    }
                    else
                        pictureBox1.Image = new Bitmap(Application.StartupPath + @"\SKINS\00.png");
                }
                stepIndicator1.CurrentStep = current + 1;
            }
            catch
            {

            }
        }
    }
}
