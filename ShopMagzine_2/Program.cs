using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopMagzine_2
{
   public  class Program
    {
   
       public static List<Books> _booksGallary;
       public static List<Authors> _Authors;
       public static Clients _CurrantUser = new Clients() {
           ClientId = 1, 
           ClientName = "Mohamed Sallam",
           Phone="+79292369570",
           Email="M@csu.ru",
           Password="123",
           Adress= "Russia ,ChliaBinsk,454921  5 Bratov Kashrin st",
           
           };
       public static CarsShop _MyCarShoping = new CarsShop();
       
        public static void LoadGallaryBooks()
        {
            _booksGallary = new List<Books>()
            {
            new Books()
            {
                BookId = 1,
                BookName = "Birds",
                BookType = Books.EBookType.Papers,
                Price = 300,
                Authers = new Authors() { AuthorsId = 1, AutherName = "Igor" }
            },
            new Books()
            {
                BookId = 2,
                BookName = "Animals",
                BookType = Books.EBookType.Elctronic,
                Price = 600,
                Authers = new Authors() { AuthorsId = 2, AutherName = "Evan" }
            },
            new Books()
            {
                BookId = 3,
                BookName = "Peoples",
                BookType = Books.EBookType.Papers,
                Price = 1200,
                Authers = new Authors() { AuthorsId = 3, AutherName = "Sallam" }
            },
            new Books()
            {
                BookId = 4,
                BookName = "Wars",
                BookType = Books.EBookType.Papers,
                Price = 700,
                Authers = new Authors() { AuthorsId = 1, AutherName = "Igor" }
            },
            new Books()
            {
                BookId = 5,
                BookName = "LoveInRussia",
                BookType = Books.EBookType.Papers,
                Price = 800,
                Authers = new Authors() { AuthorsId = 1, AutherName = "Igor" }
            },
            new Books()
            {
                BookId = 6,
                BookName = "GrilsWhatWant",
                BookType = Books.EBookType.Elctronic,
                Price = 900,
                Authers = new Authors() { AuthorsId = 2, AutherName = "Evan" }
            },
            new Books()
            {
                BookId = 7,
                BookName = "Econimics",
                BookType = Books.EBookType.Elctronic,
                Price = 450,
                Authers = new Authors() { AuthorsId = 1, AutherName = "Igor" }
            },
            new Books()
            {
                BookId = 8,
                BookName = "ComputersProgramming",
                BookType = Books.EBookType.Papers,
                Price = 500,
                Authers = new Authors() { AuthorsId = 2, AutherName = "Evan" }
            },
            new Books()
            {
                BookId = 9,
                BookName = "EasyC#Book",
                BookType = Books.EBookType.Papers,
                Price = 800,
                Authers = new Authors() { AuthorsId = 3, AutherName = "Sallam" }
            },
            new Books()
            {
                BookId = 10,
                BookName = "SaveyourMoney",
                BookType = Books.EBookType.Elctronic,
                Price = 650,
                Authers = new Authors() { AuthorsId = 2, AutherName = "Evan" }
            },
            new Books()
            {
                BookId = 11,
                BookName = "Dogs",
                BookType = Books.EBookType.Elctronic,
                Price = 900,
                Authers = new Authors() { AuthorsId = 2, AutherName = "Evan" }
            },
            new Books()
            {
                BookId = 12,
                BookName = "Life In Russia",
                BookType = Books.EBookType.Elctronic,
                Price = 230,
                Authers = new Authors() { AuthorsId = 1, AutherName = "Igor" }
            },
            new Books()
            {
                BookId = 13,
                BookName = "Egyptian Programmers",
                BookType = Books.EBookType.Elctronic,
                Price = 980,
                Authers = new Authors() { AuthorsId = 1, AutherName = "Igor" }
            },
            };
        }
        public static void DisplayGallaryBooks() {
            Console.WriteLine("Welcome To Gallary CSU Shop Books \n\n");
            foreach (var itm in _booksGallary)
                Console.WriteLine(itm.BookId + " : Book Name:" + itm.BookName + ">> Price:" + itm.Price + ">> By:" + itm.Authers.AutherName + ">> Type:" + Enum.GetName(itm.BookType.GetType(), itm.BookType));

        }
        public static void DisplayMyCarBooks()
        {
            Console.WriteLine("Books In Your Car now \n");

            foreach (var itm in _MyCarShoping.Books)
            {

                Console.WriteLine(itm.BookId +
                    " >> Book Name:" + itm.BookName +
                    " >> Price:" + itm.Price + " Count:" + itm.Count +
                    " >> WritenBy:" + itm.Authers.AutherName +
                    " >> Type:" + Enum.GetName(itm.BookType.GetType(), itm.BookType));
            }
            CalculateCostCar();
            Console.WriteLine("\nTotal Cost:" + _MyCarShoping.CostOf_AllBooks);
        }
        public static void DisplayShipmentData()
        {
            CalculateCostCar();
            Console.WriteLine("\n<<<<<<<<Client Information>>>>>>>>>>>> "
                + "\n Id: " + _MyCarShoping.Client.ClientId
                + "\n Name: " + _MyCarShoping.Client.ClientName
                + "\n Adress: " + _MyCarShoping.Client.Adress
                + "\n Email: " + _MyCarShoping.Client.Email
                + "\n Phone: " + _MyCarShoping.Client.Phone
                + "\n\n<<<<<<<Cost Information>>>>>>>>>> \n\n"
                + "Elctornic Books: " + _MyCarShoping.CostOf_ElctronicBooks + " RUB"
                + "\nPapers Book: " + _MyCarShoping.CostOf_PapersBooks + " RUB"
                + "\nTotal Cost: " + _MyCarShoping.CostOf_AllBooks + " RUB"
                + "\nDiscount Percent: " + _MyCarShoping.PrecentDiscount + " %"
                + "\nDiscount Cost:" + _MyCarShoping.CostDiscount + " RUB"
                + "\n  Net Payment:" + (_MyCarShoping.CostOf_AllBooks - _MyCarShoping.CostDiscount) + " RUB"
                );
        }
        public static void loadAuthersData()
        {
            _Authors = new List<Authors>
            {
                new Authors{AuthorsId=1, AutherName="Igor"},
                new Authors{AuthorsId=2, AutherName="Evan"},
                new Authors{AuthorsId=3, AutherName="Sallam"},
                new Authors{AuthorsId=3, AutherName="Ahmed"}
            };
        }         
        public static void CalculateCostCar()
        {
          
            foreach (var itm in _MyCarShoping.Books)
                _MyCarShoping.CostOf_AllBooks += itm.Price * itm.Count;

            var GroupAuthar = from x in _MyCarShoping.Books
                              where x.BookType== Books.EBookType.Papers 
                              group x by x.Authers.AuthorsId;
 
            foreach (var k in GroupAuthar)
            {
                int c = k.Count() ;
               if( c> 1)
                {
                    var AuthId = k.FirstOrDefault().Authers.AuthorsId;
                    
                    Console.WriteLine("\n<<<<<<<<<<<<<Congratulation You Have Gift Elctronic Book For Auther: "+ k.FirstOrDefault().Authers.AutherName+">>>>>>>>>>>>>");
                    var Authar_EBook_Gifts = from x in _booksGallary
                                             where x.BookType ==  Books.EBookType.Elctronic && x.Authers.AuthorsId == AuthId
                                             select x;
                    Console.WriteLine("\n\n<<<<<<<<<<<<<< Select Book You Want>>>>>>>>>>>>\n");
                    foreach (var itm in Authar_EBook_Gifts) {
                        Console.WriteLine(itm.BookId +
                               " >> Book Name:" + itm.BookName +
                               " >> Price:" + itm.Price+"\n") ;
                         
                    }
                    string BookId = Console.ReadLine();
                    if (BookId != "" && BookId != null)
                    {
                        var SelectedBook = _booksGallary.Find(m => m.BookId == int.Parse(BookId));
                        if (SelectedBook != null)
                            _MyCarShoping.Books.Add(SelectedBook);
                         
                    }



                }
            }


          

            _MyCarShoping.PrecentDiscount = 0.1;
            _MyCarShoping.CostDiscount = _MyCarShoping.CostOf_AllBooks * _MyCarShoping.PrecentDiscount;
            

        }
   
        public static void AddBookToCar(int BookId)
        {
            var SelectedBook = _booksGallary.Find(m => m.BookId == BookId);
            if (SelectedBook != null)
                _MyCarShoping.Books.Add(SelectedBook);
        }
        public static void AddNewBook()
        {
        addNewBook:
            Console.Write("<<<<<<Add New Books>>>>>>\n\n");

            try
            {


                Books _newBook = new Books();
                _newBook.Authers = new Authors();
                _newBook.BookId = _booksGallary.Last().BookId + 1;
                Console.Write("\n BookName :");
                _newBook.BookName = Console.ReadLine();
                Console.Write("\n BookType 0 for Papers 1 For Elctronic :");
                _newBook.BookType = (Books.EBookType)int.Parse(Console.ReadLine());
                Console.Write("\n Price :");
                _newBook.Price = double.Parse(Console.ReadLine());
                _newBook.Count = 1;

                Console.Write("\n AutherId :");

                _newBook.Authers.AuthorsId = int.Parse(Console.ReadLine());
                _booksGallary.Add(_newBook);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto addNewBook;
            }
        }
        public static void AddAuther()
        {
        addAuther:
            Console.Write("<<<<<<Add New Auther>>>>>>\n\n");

            try
            {
                Authors _newAuther = new Authors();
                _newAuther.AuthorsId = _Authors.Last().AuthorsId + 1;
                Console.Write("\n AutherName :");
                _newAuther.AutherName = Console.ReadLine();
                _Authors.Add(_newAuther);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                goto addAuther;
            }
           
        }

        static void Main(string[] args)
        {
            LoadGallaryBooks();
            _MyCarShoping.Client = _CurrantUser;
        str:
            DisplayGallaryBooks();


        AddPoint:
            Console.Write("\nInsert Book Number Or Enter To Goto Your Car: ");
            string BookId=     Console.ReadLine();
            if (BookId != "" && BookId!=null)
            {                
                AddBookToCar(int.Parse(BookId));
                goto AddPoint;
            }  
            else
            {
                Console.Clear();
                Console.WriteLine("You are now in Your Car \n\nF1 To Main Menue\nF2 To Add New Book\nF3 To Add New Auther\nF5 To Display Books You Selected\nOther Keys to Close:\n"); 
                ConsoleKeyInfo cmd=   Console.ReadKey();             
                if(cmd.Key== ConsoleKey.F1) {
                    Console.Clear();
                    goto str;
                }
                else if (cmd.Key == ConsoleKey.F2)
                {
                    AddNewBook();

                }
                else if (cmd.Key == ConsoleKey.F3)
                {
                    AddAuther();
                }
                else if(cmd.Key == ConsoleKey.F5) {
                   
                    if (_MyCarShoping.Books.Count > 0)
                    {
                        car:
                       
                        DisplayMyCarBooks();
                        Console.WriteLine("\n\nPress F1 to Main Menue \nPress F6 to Shipment \n\n");
                         cmd = Console.ReadKey();
                        if (cmd.Key == ConsoleKey.F1)
                        {
                            Console.Clear();
                            goto str;
                        }
                        else if (cmd.Key == ConsoleKey.F6)
                        {
                            CalculateCostCar();
                            Console.Clear();
                            Console.WriteLine("You are now in Shipment Step Press \n\nF1 To Main Menue\nF2 To Cars \nF7 To Payment and Shipment Info  \nOther Keys to Close\n");
                            cmd = Console.ReadKey();
                                 if (cmd.Key == ConsoleKey.F1) {  Console.Clear();   goto str;}
                            else if (cmd.Key == ConsoleKey.F2) {  Console.Clear();   goto car;}
                            else if (cmd.Key == ConsoleKey.F7) {
                                DisplayShipmentData();                              
                                Console.WriteLine("You are now in Shipment Step Press \n\nF1 To Main Menue\nF2 To Cars   \nOther Keys to Close:\n");
                                cmd = Console.ReadKey();
                                if (cmd.Key == ConsoleKey.F1) { Console.Clear(); goto str; }
                           else if (cmd.Key == ConsoleKey.F2) { Console.Clear(); goto car; }

                            }
                         
                        }

                    }
                    else
                    {
                        Console.WriteLine("Your Car Is Empty \nPress F1 to Main Menue \nAny key to Close\n");
                        if (Console.ReadKey().Key == ConsoleKey.F1)
                        {
                            Console.Clear();
                            goto str;
                        }
                    }

                }

            }

           
        }
    }
}
