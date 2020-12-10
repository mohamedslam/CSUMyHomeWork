using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMagzine_2
{
   public class Books
    {
        public Books() { }
        public Books(int bookId, string bookName, EBookType bookType, double price, Authors authers)
        {
            BookId = bookId;
            BookName = bookName;
            BookType = bookType;
            Price = price;
            Authers = authers;
        }
        public enum EBookType
        { 
        Papers,Elctronic
        }
        public int BookId;
        public string BookName;
        public  Authors Authers ;
        public EBookType BookType;
        public double Price;
        public int Count = 1;

    }
}
