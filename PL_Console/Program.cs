using System;
using Persistence;
using BL;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

namespace PL_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Menu0();
        }
    }
    public class Menu
    {
        /////////////////////////////////////////////////////////////////////////////////////////////
        private string selectChar;
        public string _selectChar
        {
            get { return selectChar; }
            set
            {
                while (true)
                {
                    if (string.Compare(value, "\n") != 0 || value == "C" || value == "c" || value == "K" || value == "k")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("- Ky tu ban nhap khong chinh xac ! Vui long nhap lai !");
                        Console.Write("#Chon: ");
                        value = Console.ReadLine();
                    }
                }
                selectChar = value;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////
        private string selectNumber;
        public string _selectNumber
        {
            get { return selectNumber; }
            set
            {
                while (true)
                {
                    if (string.Compare(value, "\n") != 0 || value == "0" || value == "1" || value == "2" || value == "3")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("- Ky tu ban nhap khong chinh xac ! Vui long nhap lai !");
                        Console.Write("#Chon: ");
                        value = Console.ReadLine();
                    }
                }
                selectNumber = value;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////
        public string Password()
        {
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (cki.Key == ConsoleKey.Backspace)
                {
                    if (sb.Length > 0)
                    {
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        sb.Length--;
                    }
                    continue;
                }
                Console.Write('*');

                sb.Append(cki.KeyChar);
            }
            return sb.ToString();
        }
        /////////////////////////////////////////////////////////////////////////////////////////////
        public void Menu0()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("----Chao mung den voi cua hang sach TG----");
                Console.WriteLine("==========================================\n");
                Console.WriteLine("1. Dang nhap he thong");
                Console.WriteLine("2. Thoat\n");
                Console.Write("#Chon: ");
                selectNumber = Console.ReadLine();
                for (; ; )
                {

                    switch (selectNumber)
                    {
                        case "1":
                            Menu01();
                            break;
                        case "2":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("- Ky tu ban nhap khong dung ! Vui long thu lai !");
                            Console.Write("#Chon: ");
                            selectNumber = Console.ReadLine();
                            break;
                    }
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("- Loi khong xac dinh !!!!");
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////

        public List<Employees> ListE = new List<Employees>();

        public void Menu01()
        {
            Employees e = new Employees();
            EmployeesBL employee = new EmployeesBL();
            Console.Clear();
            Console.WriteLine("Dang nhap he thong:");
            Console.WriteLine("======================================");
            for (; ; )
            {
                Console.Write("-Ten dang nhap: ");
                string user = Console.ReadLine();
                Console.Write("-Mat khau: ");

                string password = Password();
                e = employee.GetEmployeeByUserPassword(user, password);
                ListE.Add(e);
                if (e != null)
                {
                    Menu010();
                    break;
                }
                else
                {
                    Console.WriteLine("- Thong tin quy khach vua nhap khong chinh xac ! Vui long nhap lai !");
                }
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////
        public void Menu010()
        {
            Console.Clear();
            Console.WriteLine("                         Cua hang sach TG");
            Console.WriteLine("=========================================\n");
            Console.WriteLine("1. Tao hoa don");
            Console.WriteLine("2. Thanh toan");
            Console.WriteLine("3. Dang xuat\n");
            Console.Write("#Chon: ");
            selectNumber = Console.ReadLine();
            for (; ; )
            {
                switch (selectNumber)
                {
                    case "1":
                        Menu011();
                        break;
                    case "2":
                        Menu012();
                        break;
                    case "3":
                        Menu0();
                        break;
                    default:
                        Console.WriteLine("- Ky tu ban nhap khong dung ! Vui long nhap lai !");
                        Console.Write("#Chon: ");
                        selectNumber = Console.ReadLine();
                        break;
                }
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////
        public static int TryParse(string a)
        {
            int b;
            if (int.TryParse(a, out b))
            {
                return b;
            }
            return 0;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////
        public static int i = 1;
        public int amount{get; set;}
        public void Menu011()
        {
            Console.Clear();
            Console.WriteLine("                         Cua hang sach TG");
            Console.WriteLine("=========================================");
            List<Books> lb = new List<Books>();
            OrderBL order = new OrderBL();
            Orders o = new Orders();
            BooksBL book = new BooksBL();
            for (; ; )
            {
                Books b = new Books();
                OrderDetails od = new OrderDetails();
                o.ID_E = ListE[0];
                o.ID_Order = i;
                for (; ; )
                {
                    string IdB;
                    int IdBook;
                    Console.Write("- Nhap ID Book: ");
                    IdB = Console.ReadLine();
                    if (int.TryParse(IdB, out IdBook))
                    {
                        b.ID_Book = IdBook;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("- ID ban nhap khong dung ! Vui long nhap lai ID !");
                    }
                }
                b = book.GetBookById(b.ID_Book);
                if (b != null)
                {
                    lb.Add(b);
                    od.book = b;
                    for (; ; )
                    {
                        Console.Write("- Nhap so luong: ");
                        string q = Console.ReadLine();
                        if (TryParse(q) != 0 && b.amount - TryParse(q) > 0)
                        {
                            od.quantity = TryParse(q);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("- So luong ban nhap khong dung ! Vui long nhap lai !");
                            Console.WriteLine("- Con {0} trong kho !", b.amount);
                        }
                    }
                    Console.WriteLine(b.amount);
                    Console.WriteLine(b.unit_price);
                    Console.WriteLine("\n=========================================\n");
                    o.BooksList.Add(od);


                    for (; ; )
                    {
                        Console.Write("#Ban co muon tiep tuc mua them sach(C/K): ");
                        selectChar = Console.ReadLine();
                        if (selectChar == "C" || selectChar == "c")
                        {
                            break;
                        }
                        else if (selectChar == "K" || selectChar == "k")
                        {
                            Console.Clear();
                            Console.WriteLine("=======================================================================================================");
                            Console.WriteLine("                                                                                 Cua hang sach the gioi\n");
                            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("Danh sach sach duoc chon:\n");
                            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("Ma sach  | Ten sach                | Ten tac gia              | SL   |");
                            for (i = 0; i < lb.Count; i++)
                            {
                                string idbook = lb[i].ID_Book + new string(' ', 9 - lb[i].ID_Book.ToString().Length);
                                string bookname = " " + lb[i].book_title + new string(' ', 24 - lb[i].book_title.Length);
                                string author = " " + lb[i].author + new string(' ', 25 - lb[i].author.Length);
                                // string dongia = " " + lb[i].unit_price + new string(' ', 12 - lb[i].unit_price.ToString().Length);
                                string sl = " " + o.BooksList[i].quantity + new string(' ', 5 - o.BooksList[i].quantity.ToString().Length);
                                // string tt = " " + o.BooksList[i].quantity * lb[i].unit_price + new string(' ', 17 - (o.BooksList[i].quantity * lb[i].unit_price).ToString().Length);
                                Console.WriteLine(idbook + "|" + bookname + "|" + author + "|" + sl + "|");
                            }
                            Console.WriteLine("-------------------------------------------------------------------------------------------------------\n");
                            for (; ; )
                            {
                                Console.Write("#Xac nhan tao don hang(C/K): ");
                                selectChar = Console.ReadLine();
                                if (selectChar == "C" || selectChar == "c")
                                {
                                    i++;

                                    order.AddOrder(o);
                                    Menu010();
                                    break;
                                }
                                else if (selectChar == "K" || selectChar == "k")
                                {
                                    Menu010();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("- Ky tu ban nhap khong dung ! Vui long nhap lai !");
                                }
                            }

                            break;
                        }
                        else
                        {
                            Console.WriteLine("- Ky tu ban nhap khong dung ! Vui long nhap lai !");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("- ID ban nhap khong dung ! Vui long nhap lai ID !");
                }
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////
        public void Menu012()
        {
            
        }
    }
}
