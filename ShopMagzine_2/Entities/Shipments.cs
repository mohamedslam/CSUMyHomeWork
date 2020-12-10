using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMagzine_2
{
 public   class Shipments
    {
        public int ShipmentId;        
        public double ShipmentCost=200;
        public Clients Client = new Clients();
        public List<Books> Books = new List<Books>();
    }
}
