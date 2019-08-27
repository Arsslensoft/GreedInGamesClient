using System;
using System.Collections.Generic;
using System.Text;
using Google.YouTube;
using Google.GData.YouTube;
using Google.GData.Client;

namespace GIG_CLIENT
{
    public static class Youtube
    {
        static YouTubeRequest yourequest;
        static YouTubeRequestSettings yousettings;

        public static void Initialize()
        {
            try
            {
                YouTubeService service = new YouTubeService("Manager");
                service.setUserCredentials("arsslensoft.gig@gmail.com", "AI39si7k1PTGjYF");

                service.QueryClientLoginToken();

                yousettings = new YouTubeRequestSettings("You Manager", "AIzaSyAeo7byS85LCZUtrBodQ6E6OqlFlJROnMA");
                yourequest = new YouTubeRequest(yousettings);
       

            }
            catch
            {
               
            }
        }

        public static double Match(string a, string b)
        {
            double prob = 0;
            double max = 0;
            if (a.Split(' ').Length > b.Split(' ').Length)
            {
                max = b.Split(' ').Length;
                foreach (string s in b.Split(' '))
                {
                    if (a.Contains(s))
                        prob++;
                }
            }
            else
            {
                max = a.Split(' ').Length;
                foreach (string s in a.Split(' '))
                {
                    if (b.Contains(s))
                        prob++;
                }

            }

            return (prob / max) * 100;
        }
        public static Random rd = new Random();
        public static List<Video> Search(string text)
        {
            try
            {
                List<Video> vids = new List<Video>();
                YouTubeQuery query = new YouTubeQuery(YouTubeQuery.DefaultVideoUri);

                query.OrderBy = "viewCount";
                query.Query = text;
                Feed<Video> videofeed = yourequest.Get<Video>(query);

                foreach (Video entry in videofeed.Entries)
                    vids.Add(entry);


                return vids;
            }
            catch
            {
                return null;
            }
        }
        public static List<Video> SearchNorm(string text)
        {
            try
            {
                List<Video> vids = new List<Video>();
                YouTubeQuery query = new YouTubeQuery(YouTubeQuery.DefaultVideoUri);

                query.Query = text;
                Feed<Video> videofeed = yourequest.Get<Video>(query);

                foreach (Video entry in videofeed.Entries)
                    vids.Add(entry);


                return vids;
            }
            catch
            {
                return null;
            }
        }
        public static List<Video> RandomSearch()
        {
            try
            {
   
                List<Video> vids = new List<Video>();
                YouTubeQuery query = new YouTubeQuery(YouTubeQuery.DefaultVideoUri);

                query.OrderBy = "viewCount";
                query.Query = "Smartest machine on earth documentary";
                int cat = rd.Next(0, 1);
                string feu = "https://gdata.youtube.com/feeds/api/standardfeeds/top_rated?time=today";
                if (cat == 1)
                    feu += "&duration=long";


                Feed<Video> videofeed = yourequest.Get<Video>(new System.Uri(feu + "&genre=" + cat.ToString()));

                foreach (Video entry in videofeed.Entries)
                    vids.Add(entry);


                return vids;
            }
            catch
            {
                return null;
            }
        }
        public static Video GetBestVideo(int cat, string lang)
        {
            try
            {
                YouTubeQuery query = new YouTubeQuery(YouTubeQuery.DefaultVideoUri);

                query.OrderBy = "viewCount";
                query.Query = "Smartest machine on earth";
                string feu = "https://gdata.youtube.com/feeds/api/standardfeeds/top_rated?time=today&hl=" + lang;

                Feed<Video> videofeed = yourequest.Get<Video>(new System.Uri(feu + "&genre=" + cat.ToString()));

                Video vid = null;
                int max = 0;
                foreach (Video entry in videofeed.Entries)
                {
                    if (entry.ViewCount > max)
                    {
                        max = entry.ViewCount;
                        vid = entry;
                    }
                }

                return vid;
            }
            catch
            {
                return null;
            }
        }
    }
}
