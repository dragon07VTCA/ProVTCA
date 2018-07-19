using System;
using Persistence;
using BL;
using System.Collections.Generic;

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
                while (true)
                {
                    if (string.Compare(value, "\n") != 0 || value == "Co" || value == "co" || value == "Khong" || value == "khong")
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
                EmployeesBL employee = new EmployeesBL();
                BooksBL book = new BooksBL();
                OrderBL order = new OrderBL();
                Orders o = new Orders();
                Books b = new Books();
                Employees e = new Employees();
                OrderDetails od = new OrderDetails();
                List<OrderDetails> ListOrderDetails = new List<OrderDetails>();
                Console.Clear();
                Console.WriteLine("----Chao mung den voi cua hang sach TG----");
                Console.WriteLine("==========================================\n");
                Console.WriteLine("1. Dang nhap he thong");
                Console.WriteLine("2. Thoat\n");
                for (; ; )
                {
                    Console.Write("#Chon: ");
                    selectNumber = Console.ReadLine();
                    switch (selectNumber)
                    {
                        case "1":
                            Menu01();
                            break;
                        case "2":
                            break;
                        default:
                            Console.WriteLine("- Ky tu ban nhap khong dung ! Vui long thu lai !");
                            break;
                    }
                }
            }
            catch (System.Exception)
            {
                Console.WriteLine("- Loi khong xac dinh !!!!");
            }
        }
        public void Menu01()
        {
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
                if (e != null)
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
                                Console.WriteLine("----Chao mung den voi cua hang sach TG----");
                                Console.WriteLine("==========================================\n");
                                Console.WriteLine("1. Dang nhap he thong");
                                Console.WriteLine("2. Thoat\n");
                                break;
                            default:
                                Console.WriteLine("- Ky tu ban nhap khong dung ! Vui long nhap lai !");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("- Thong tin quy khach vua nhap khong chinh xac ! Vui long nhap lai !");
                }
            }
        }
        public void Menu011()
        {
            Console.Clear();
            Console.WriteLine("                         Cua hang sach TG");
            Console.WriteLine("=========================================");
                for ( ; ; )
                {                      
                    int i = 0;
                    i++;
                    Console.Write("- Nhap ID Book: ");
                    od.book.ID_Book = Convert.ToInt32(Console.ReadLine());                        
                    b = book.GetBookById(od.book.ID_Book);
                    if (b != null)
                    {
                        Console.Write("- Nhap so luong: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        quantity = od.quantity;                            
                        od.book = b;                                                    
                        // Console.WriteLine(b.amount);
                        // Console.WriteLine(b.unit_price);
                        Console.WriteLine("\n=========================================");
                        Console.Write("Ban co muon tiep tuc mua them sach(Co/Khong): ");
                        selectChar = Console.ReadLine();
                        if (selectChar == "Co" || selectChar == "co")                            
                        {                                    
                            Console.Clear();
                            ListOrderDetails.Add(od);
                        }
                        else if (selectChar == "Khong" || selectChar == "khong")
                        {
                            order.AddOrder(o);                                
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("- Sach khong ton tai ! Vui long nhap lai ID !");
                    }
                }
        }
    }
}
