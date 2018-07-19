using System;
using Persistence;
using BL;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

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
        private string selectChar;
        public string _selectChar
        {
            get { return selectChar; }
            set
            {
                // while (true)
                // {
                //     if (string.Compare(value, "\n") != 0 || value == "C" || value == "c" || value == "K" || value == "k")
                //     {
                //         break;
                //     }
                //     else
                //     {
                //         Console.WriteLine("- Ky tu ban nhap khong chinh xac ! Vui long nhap lai !");
                //         Console.Write("#Chon: ");
                //         value = Console.ReadLine();
                //     }
                // }
                selectChar = value;
            }
        }
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
                string password = Console.ReadLine();
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
        public EmployeesBL employee = new EmployeesBL();
        public BooksBL book = new BooksBL();
        public OrderBL order = new OrderBL();
        public Orders o = new Orders();
        public Books b = new Books();
        public OrderDetails od = new OrderDetails();
        public void Menu011()
        {
            Console.Clear();
            Console.WriteLine("                         Cua hang sach TG");
            Console.WriteLine("=========================================");
            for (; ; )
            {
                o.BooksList = new List<OrderDetails>();
                o.ID_E = ListE[0];
                o.creation_time = DateTime.Now;
                Console.Write("- Nhap ID Book: ");
                b.ID_Book = Convert.ToInt32(Console.ReadLine());
                b = book.GetBookById(b.ID_Book);
                if (b != null)
                {
                    od.book.ID_Book = b.ID_Book;
                    od.book.unit_price = b.unit_price;
                    Console.Write("- Nhap so luong: ");
                    od.quantity = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(b.amount);
                    Console.WriteLine(b.unit_price);
                    Console.WriteLine("\n=========================================");
                    Console.Write("Ban co muon tiep tuc mua them sach(C/K): ");
                    selectChar = Console.ReadLine();
                    o.BooksList.Add(od);
                    for (; ; )
                    {
                        switch (selectChar)
                        {
                            case "C":
                                order.AddOrder(o);
                                break;
                            case "c":
                                order.AddOrder(o);
                                break;
                            case "K":
                                order.AddOrder(o);
                                Display();
                                Menu010();
                                break;
                            case "k":
                                order.AddOrder(o);
                                Display();
                                Menu010();
                                break;
                            default:
                                Console.WriteLine("- Ky tu ban nhap khong dung ! Vui long nhap lai !");
                                Console.Write("Ban co muon tiep tuc mua them sach(C/K): ");
                                selectChar = Console.ReadLine();
                                break;
                        }
                        if(selectChar == "C" || selectChar == "c")
                        {
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("- Sach khong ton tai ! Vui long nhap lai ID !");
                }
            }
        }
        public void Display()
        {

        }
    }
}
