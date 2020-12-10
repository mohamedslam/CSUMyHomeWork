using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMagzine_2
{
   public class Clients
    {
        public Clients()
        {

        }
        public int ClientId;
        public String ClientName;
        public string Email;
        public string Password;
        public string Adress;
        public string Phone;
        public List<Books> Books = new List<Books>();

    }
}
