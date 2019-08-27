using System;
using System.Collections.Generic;
using System.Text;
using System.Media;
using System.Windows.Forms;

namespace GIG_CLIENT
{
   internal static class GPlayer
    {
       internal static SoundPlayer sp = new SoundPlayer();
       public static void Welcome()
       {
           try
           {
               sp.SoundLocation = Application.StartupPath + @"\WAV\welcome.wav";
               sp.Load();
               sp.Play();
           }
           catch
           {

           }

       }
       public static void Install()
       {
           try
           {
               sp.SoundLocation = Application.StartupPath + @"\WAV\install.wav";
               sp.Load();
               sp.Play();
           }
           catch
           {

           }

       }
       public static void NEWMSG()
       {
           try
           {
               sp.SoundLocation = Application.StartupPath + @"\WAV\message.wav";
               sp.Load();
               sp.Play();
           }
           catch
           {

           }

       }
       public static void NEWNOTIF()
       {
           try
           {
               sp.SoundLocation = Application.StartupPath + @"\WAV\notif.wav";
               sp.Load();
               sp.Play();
           }
           catch
           {

           }

       }
       public static void Goodbye()
       {
           try
           {
               sp.SoundLocation = Application.StartupPath + @"\WAV\goodbye.wav";
               sp.Load();
               sp.PlaySync();
           }
           catch
           {

           }

       }
    }
}
