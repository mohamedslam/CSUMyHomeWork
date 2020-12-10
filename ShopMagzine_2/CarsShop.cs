using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMagzine_2
{
   public class CarsShop
    {
        public CarsShop()
        {
          
        }
        public int CarId;
        public Clients Client;
        public List<Books> Books = new List<Books>();
        public List<Books> BooksGift = new List<Books>();
        public Shipments ShipEntity = new Shipments();

        public double CostOf_AllBooks;
        public double CostOf_PapersBooks;
        public double CostOf_ElctronicBooks;

        public double PrecentDiscount;
        public double CostDiscount;
        public double SumPayment;

    }
}
