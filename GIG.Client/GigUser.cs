using System;
using System.Collections.Generic;
using System.Text;

namespace GIG.Client
{
    public class GSkin
    {
        public string Name;
        public int ID;
        public int Price;
    }
    public class GigCommand
    {
        public string SID;
        public string Username;
        public string GTAUsername;
        public string Email;
        public string ContactEmail;
        public string Name;
        public string Pack;
        public DateTime TimeStamp;
        public int Price = 0;
    }
    public class GigTransaction
    {
        public string Sender;
        public string Receiver;
        public int Amount;
        public DateTime TimeStamp;
    }
    public class GIGNewsEntry
    {
        public string Name;
        public string Content;
    }
    public enum GIGRoles : byte
    {
        Directeur = 4,
        Administrateur = 3 ,
        Moderateur = 2,
        Utilisateur = 1
    }

    public class Car
    {
        public string Name;
        public int ID;
    }
    public class GigMessage
    {
        public string Sender;
        public string Message;
        public DateTime RD;
    }
   public class GigUser
    {
       public string Username;
       public string Name;
       public string GTAUsername;
       public string Email;
       public bool VIP = false;
       public GIGRoles Role;
       public int GIGP;
       public List<Car> Cars = new List<Car>();
       public List<string> Friends = new List<string>();
       public DateTime RegistrationDate;
   
    }
}
