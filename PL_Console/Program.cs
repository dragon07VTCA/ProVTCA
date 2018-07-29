﻿using System;
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
        le = new List<Employees>();
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
                Menu0();
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////

        public Employees le;

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
                le.Add(e);
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
            Console.WriteLine("1. Tao don hang");
            Console.WriteLine("2. Lich su giao dich");
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
        public List<Books> lb = new List<Books>();
        public Orders o = new Orders();
        public int nsl = 0;
        public void Menu011()
        {
            Console.Clear();
            Console.WriteLine("                         Cua hang sach TG                        ");
            Console.WriteLine("=================================================================");
            OrderBL order = new OrderBL();
            BooksBL book = new BooksBL();
            for (; ; )
            {
                Books b = new Books();
                OrderDetails od = new OrderDetails();
                o.ID_E.ID_E = le[0].ID_E;
                o.ID_Order = i;
                for (; ; )
                {
                    string IdB;
                    int IdBook;
                    Console.Write("- Nhap ID Book: MN");
                    IdB = Console.ReadLine();
                    if (int.TryParse(IdB, out IdBook))
                    {
                        b.ID_Book = IdBook;
                        b = book.GetBookById(b.ID_Book);
                        
                        string id =" " + b.ID_Book + new string(' ', 9 - b.ID_Book.ToString().Length);
                        string name =" " + b.book_title + new string(' ', 24 - b.book_title.Length);
                        string author =" " + b.author + new string(' ', 25 - b.author.Length);
                        string amount =" " + string.Format("{0:0,0}",b.unit_price) + new string(' ', 9 - string.Format("{0:0,0}", b.unit_price).ToString().Length) + "VND";
                        Console.WriteLine(id + "|" + name + "|" + author + "|" + amount + "|");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("- ID ban nhap khong dung !");
                        for (; ; )
                        {
                            Console.WriteLine("1. Nhap lai");
                            Console.WriteLine("2. Thoat\n");
                            Console.Write("#Chon: ");
                            string chon = Console.ReadLine();
                            if (chon == "1")
                            {
                                break;
                            }
                            else if (chon == "2")
                            {
                                Menu010();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("- Ky tu ban nhap khong dung !");
                            }
                        }
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
                        int i = nsl + TryParse(q);
                        if (TryParse(q) > 0 && b.amount - i > 0)
                        {
                            nsl = i;
                            od.quantity = TryParse(q);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("- So luong ban nhap khong dung !");
                            for (; ; )
                            {
                                Console.WriteLine("1. Nhap lai");
                                Console.WriteLine("2. Thoat\n");
                                Console.Write("#Chon: ");
                                string chon = Console.ReadLine();
                                if (chon == "1")
                                {
                                    break;
                                }
                                else if (chon == "2")
                                {
                                    Menu010();
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("- Ky tu ban nhap khong dung !");
                                }
                            }
                            Console.WriteLine("- Tong so quyen trong kho {0}", b.amount);
                        }
                    }
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
                            i++;
                            order.AddOrder(o);
                            Menu012();
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
                    for (; ; )
                    {
                        Console.WriteLine("1. Nhap lai");
                        Console.WriteLine("2. Thoat\n");
                        Console.Write("#Chon: ");
                        string chon = Console.ReadLine();
                        if (chon == "1")
                        {
                            break;
                        }
                        else if (chon == "2")
                        {
                            Menu010();
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("- Ky tu ban nhap khong dung !");
                        }
                    }
                }
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////
        public void Menu012()
        {
            if (lb.Count == 0)
            {
                Console.Clear();
                Console.Write("- Chua tao don hang ! An phim bat ky de quay lai ....");
                Console.ReadKey();
                Menu010();
            }
            Console.Clear();
            decimal a = 0;
            Console.WriteLine("=======================================================================================================");
            Console.WriteLine("                                        Cua hang sach the gioi                                         \n");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                             DON HANG SACH                                             ");
            Console.WriteLine("Ma don hang: BLACK{0}", o.ID_Order);
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" Ma sach  | Ten sach                | Ten tac gia              | Don gia     | SL   | Thanh tien       ");
            Console.WriteLine(" -------    --------                  -----------                -------       --     ----------       ");
            for (i = 0; i < lb.Count; i++)
            {
                string idbook = " MN" + lb[i].ID_Book + new string(' ', 7 - lb[i].ID_Book.ToString().Length);
                string bookname = " " + lb[i].book_title + new string(' ', 24 - lb[i].book_title.Length);
                string author = " " + lb[i].author + new string(' ', 25 - lb[i].author.Length);
                string dongia = " " + string.Format("{0:0,0}", lb[i].unit_price) + new string(' ', 9 - string.Format("{0:0,0}", lb[i].unit_price).ToString().Length) + "VND";
                string sl = " " + o.BooksList[i].quantity + new string(' ', 5 - o.BooksList[i].quantity.ToString().Length);
                string tt = " " + string.Format("{0:0,0}", o.BooksList[i].quantity * lb[i].unit_price) + new string(' ', 14 - string.Format("{0:0,0}", o.BooksList[i].quantity * lb[i].unit_price).ToString().Length) + "VND";
                Console.WriteLine(idbook + "|" + bookname + "|" + author + "|" + dongia + "|" + sl + "|" + tt + "|");
                a = a + lb[i].unit_price * o.BooksList[i].quantity;
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("                                                                    Tong tien: " + string.Format("{0:0,0}", a) + new string(' ', 20 - string.Format("{0:0,0}", a).ToString().Length) + "VND\n");
            Console.WriteLine("                                                                    -----------------------------------\n");
            for (; ; )
            {
                Console.Write("-Xac nhan thanh toan(C/K): ");
                string chon = Console.ReadLine();
                if (chon == "C" || chon == "c")
                {
                    string price = "";
                    for (; ; )
                    {
                        Console.Write("-Nhap so tien cua khach hang: ");
                        price = Console.ReadLine();
                        if (TryParse(price) >= Convert.ToInt32(a))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("- So tien ban nhap khong dung ! Vui long nhap lai !");
                        }
                    }
                    Console.Clear();
                    decimal b = 0;
                    o.creation_time = DateTime.Now;
                    Console.WriteLine("=======================================================================================================");
                    Console.WriteLine("                                       Cua hang sach the gioi                                          \n");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                                                                            Ngay ban: " + new string(' ', 17 - (o.creation_time.Day + "-" + o.creation_time.Month + "-" + o.creation_time.Year + " " + o.creation_time.Hour + ":" + o.creation_time.Minute).ToString().Length) + o.creation_time.Day + "-" + o.creation_time.Month + "-" + o.creation_time.Year + " " + o.creation_time.Hour + ":" + o.creation_time.Minute);
                    Console.WriteLine("                                       ***HOA DON BAN HANG***                                          ");
                    Console.WriteLine("- Ma : DRAGON{0}", o.ID_Order);
                    Console.WriteLine("- Nguoi ban: " + le[0].full_name);
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(" Ma sach  | Ten sach                | Ten tac gia              | Don gia     | SL   | Thanh tien       ");
                    Console.WriteLine(" -------    --------                  -----------                -------       --     ----------       ");
                    for (i = 0; i < lb.Count; i++)
                    {

                        string idbook = " MN" + lb[i].ID_Book + new string(' ', 7 - lb[i].ID_Book.ToString().Length);
                        string bookname = " " + lb[i].book_title + new string(' ', 24 - lb[i].book_title.Length);
                        string author = " " + lb[i].author + new string(' ', 25 - lb[i].author.Length);
                        string dongia = " " + string.Format("{0:0,0}", lb[i].unit_price) + new string(' ', 9 - string.Format("{0:0,0}", lb[i].unit_price).ToString().Length) + "VND";
                        string sl = " " + o.BooksList[i].quantity + new string(' ', 5 - o.BooksList[i].quantity.ToString().Length);
                        string tt = " " + string.Format("{0:0,0}", o.BooksList[i].quantity * lb[i].unit_price) + new string(' ', 14 - string.Format("{0:0,0}", o.BooksList[i].quantity * lb[i].unit_price).ToString().Length) + "VND";
                        Console.WriteLine(idbook + "|" + bookname + "|" + author + "|" + dongia + "|" + sl + "|" + tt + "|");
                        b = b + lb[i].unit_price * o.BooksList[i].quantity;
                    }
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("                                                            + Tong tien      : " + string.Format("{0:0,0}", b) + new string(' ', 20 - string.Format("{0:0,0}", b).ToString().Length) + "VND");
                    Console.WriteLine("                                                            + Tien khach hang: " + string.Format("{0:0,0}", Convert.ToDecimal(price)) + new string(' ', 20 - string.Format("{0:0,0}", Convert.ToDecimal(price)).ToString().Length) + "VND");
                    Console.WriteLine("                                                            + Hoan tien      : " + string.Format("{0:0,0}", Convert.ToDecimal(price) - b) + new string(' ', 20 - string.Format("{0:0,0}", Convert.ToDecimal(price) - b).ToString().Length) + "VND");
                    Console.WriteLine("---------------------------------------Hen gap lai !!!-------------------------------------------------\n");
                    Console.Write("Bam phim bat ky de quay lai.....");
                    Console.ReadKey();
                    lb = new List<Books>();
                    Menu010();
                    break;
                }
                else if (chon == "K" || chon == "k")
                {
                    Menu010();
                    break;
                }
                else
                {
                    Console.WriteLine("- Ky tu ban nhap khong dung ! Vui long nhap lai !");
                }
            }
        }
    }
}
