using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Google.YouTube;
using GIG_CLIENT;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] term = new string[11]
        {
            "League of legends",
            "GTA Sandreas",
            "Rockstar Games",
            "Electronics Arts",
            "EA",
            "Ubisoft",
            "Activision",
            "Counter Strike",
            "Battle Field game",
            "Call of Duty",
            "World of warcraft"
        };
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
       
                Random rd = new Random();
                List<Video> v = Youtube.Search(term[rd.Next(0, 10)]);
                Video vid = v[rd.Next(0, v.Count)];
                axShockwaveFlash1.Movie = vid.WatchPage.ToString().Replace("watch?v=", "v/").Split('&')[0];
            }
            catch
            {
                Application.Exit();
            }
        }
    }
}
