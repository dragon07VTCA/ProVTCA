using System;
using Persistence;
using BL;
using System.Collections.Generic;
using System.Text;

namespace PL_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Menu menu = new Menu();
            menu.Menu0();
        }
    }
    public class Menu
    {
        /////////////////////////////////////////////////////////////////////////////////////////////
        public List<Thanhtoan> ltt = new List<Thanhtoan>();
        public Thanhtoan tt = new Thanhtoan();
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
                        Console.WriteLine("- Ký tự bạn nhập không chính xác ! Vui lòng nhập lại !");
                        Console.Write("#Chọn: ");
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
                        Console.WriteLine("- Ký tự bạn nhập không chính xác ! Vui lòng nhập lại !");
                        Console.Write("#Chọn: ");
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
        public static Employees e = new Employees();
        public void Menu0()
        {
            // try
            // {
            Console.Clear();
            Console.WriteLine("--- CHÀO MỪNG BẠN ĐẾN VỚI CỬA HÀNG SÁCH TG ---");
            Console.WriteLine("==============================================\n");
            Console.WriteLine("1. Đăng nhập hệ thống");
            Console.WriteLine("2. Thoát\n");
            Console.Write("#Chọn: ");
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
                        Console.WriteLine("- Ký tự bạn nhập không đúng ! Vui lòng thử lại !");
                        Console.Write("#Chọn: ");
                        selectNumber = Console.ReadLine();
                        break;
                }
            }
            // }
            // catch (System.Exception)
            // {
            //     Console.WriteLine("- Lỗi không xác định !!!!");
            //     Menu0();
            // }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////
        public EmployeesBL employee = new EmployeesBL();
        public void Menu01()
        {

            Console.Clear();
            Console.WriteLine("       +++ ĐĂNG NHẬP HỆ THỐNG +++      ");
            Console.WriteLine("=======================================");
            for (; ; )
            {
                Console.Write("-Tên đăng nhập: ");
                string user = Console.ReadLine();
                Console.Write("-Mật khẩu: ");
                string password = Password();
                e = employee.GetEmployeeByUserPassword(user, password);
                if (e != null)
                {
                    Menu010();
                    break;
                }
                else
                {
                    Console.WriteLine("- Thông tin quý khách vừa nhập không chính xác !");
                    for (; ; )
                    {
                        Console.WriteLine("1. Nhập lại");
                        Console.WriteLine("2. Thoát\n");
                        Console.Write("#Chọn: ");
                        string chon = Console.ReadLine();
                        if (chon == "1")
                        {
                            break;
                        }
                        else if (chon == "2")
                        {
                            Environment.Exit(0);
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("- Ký tự bạn vừa chọn không đúng !");
                        }
                    }
                }
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////
        public void Menu010()
        {
            Console.Clear();
            Console.WriteLine("                         CỬA HÀNG SÁCH TG");
            Console.WriteLine("===============================================================\n");
            Console.WriteLine("1. Tạo đơn hàng");
            Console.WriteLine("2. Lịch sử giao dịch");
            Console.WriteLine("3. Đăng xuất\n");
            Console.Write("#Chọn: ");
            selectNumber = Console.ReadLine();
            for (; ; )
            {
                switch (selectNumber)
                {
                    case "1":
                        Menu011();
                        break;
                    case "2":
                        Menu013();
                        break;
                    case "3":
                        Menu0();
                        break;
                    default:
                        Console.WriteLine("- Ký tự bạn vừa nhập không đúng ! Vui lòng nhập lại !");
                        Console.Write("#Chọn: ");
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
        public List<Books> lb = new List<Books>();
        public Orders o = new Orders();
        public int nsl = 0;
        public OrderBL order = new OrderBL();
        public BooksBL book = new BooksBL();
        public void Menu011()
        {
            Console.Clear();
            Console.WriteLine("                                       CỬA HÀNG SÁCH TG                        ");
            Console.WriteLine("========================================================================================\n");
            o.ID_E = e;
            for (; ; )
            {
                Books b = new Books();
                OrderDetails od = new OrderDetails();
                for (; ; )
                {
                    string IdB;
                    Console.Write("- Nhập mã sách: MN");
                    IdB = Console.ReadLine();
                    int IdBook = TryParse(IdB);
                    if (IdBook > 0 && book.GetBookById(IdBook) != null)
                    {
                        b.ID_Book = IdBook;
                        b = book.GetBookById(b.ID_Book);
                        Console.WriteLine("\n    ====================================================================================");
                        Console.WriteLine("    | Mã sách    | Tên sách              | Tên giác giả          | Đơn giá      | SL   |");
                        Console.WriteLine("    | -------      --------                ------------            -------        --   |");
                        string idbook = "    | MN" + b.ID_Book + new string(' ', 9 - b.ID_Book.ToString().Length);
                        string bookname = " " + b.book_title + new string(' ', 22 - b.book_title.Length);
                        string author = " " + b.author + new string(' ', 22 - b.author.Length);
                        string dongia = " " + string.Format("{0:0,0}", b.unit_price) + new string(' ', 10 - string.Format("{0:0,0}", b.unit_price).ToString().Length) + "VNĐ";
                        string sl = " " + b.amount + new string(' ', 5 - b.amount.ToString().Length);
                        Console.WriteLine(idbook + "|" + bookname + "|" + author + "|" + dongia + "|" + sl + "|");
                        Console.WriteLine("    ====================================================================================\n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("- Mã sách bạn nhập không đúng !");
                        for (; ; )
                        {
                            Console.WriteLine("1. Nhập lại");
                            Console.WriteLine("2. Thoát\n");
                            Console.Write("#Chọn: ");
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
                                Console.WriteLine("- Ký tự bạn nhập không đúng !");
                            }
                        }
                    }
                }
                b = book.GetBookById(b.ID_Book);
                if (b != null)
                {
                    od.book = b;
                    for (; ; )
                    {
                        Console.Write("- Nhập số lượng: ");
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
                            Console.WriteLine("- Số lượng bạn nhập không đúng !");
                            for (; ; )
                            {
                                Console.WriteLine("1. Nhập lại");
                                Console.WriteLine("2. Thoát\n");
                                Console.Write("#Chọn: ");
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
                                    Console.WriteLine("- Ký tự bạn nhập không đúng !");
                                }
                            }
                            Console.WriteLine("- Tổng số quyển sách trong kho {0}", b.amount);
                        }
                    }
                    Console.WriteLine("\n=========================================\n");
                    if (lb == null)
                    {
                        lb.Add(b);
                    }
                    else
                    {
                        int check = 0;
                        for (int i = 0; i < lb.Count; i++)
                        {
                            if (lb[i].ID_Book == b.ID_Book)
                            {
                                lb[i] = b;
                                check = 1;
                                break;
                            }
                        }
                        if (check == 0)
                        {
                            lb.Add(b);
                        }
                    }
                    if (o.BooksList == null)
                    {
                        o.BooksList.Add(od);
                    }
                    else
                    {
                        int check1 = 0;
                        for (int i = 0; i < o.BooksList.Count; i++)
                        {
                            if (o.BooksList[i].book.ID_Book == od.book.ID_Book)
                            {
                                o.BooksList[i].quantity = o.BooksList[i].quantity + od.quantity;
                                check1 = 1;
                                break;
                            }
                        }
                        if (check1 == 0)
                        {
                            o.BooksList.Add(od);
                        }
                    }
                    for (; ; )
                    {
                        Console.Write("#Bạn có muốn tiếp tục mua thêm sách(C/K): ");
                        selectChar = Console.ReadLine();
                        if (selectChar == "C" || selectChar == "c")
                        {
                            break;
                        }
                        else if (selectChar == "K" || selectChar == "k")
                        {
                            Console.Clear();
                            Console.WriteLine(o.ID_E);
                            Menu012();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("- Ký tự bạn nhập không đúng ! Vui lòng nhập lại !");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("- Mã sách bạn nhập không đúng !");
                    for (; ; )
                    {
                        Console.WriteLine("1. Nhập lại");
                        Console.WriteLine("2. Thoát\n");
                        Console.Write("#Chọn: ");
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
                            Console.WriteLine("- Ký tự bạn nhập không đúng !");
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
                Console.Write("- Chưa tạo đơn hàng ! Bấm phím bất kỳ để quay lại ....");
                Console.ReadKey();
                Menu010();
            }
            Console.Clear();
            decimal a = 0;
            Console.WriteLine("=======================================================================================================");
            Console.WriteLine("                                        CỬA HÀNG SÁCH THẾ GIỚI                                         \n");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                                             ĐƠN HÀNG SÁCH                                             ");
            Console.WriteLine(" Mã đơn hàng: OD{0}", order.GetOrder());
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" Mã sách  | Tên sách                | Tên tác giả              | Đơn giá     | SL   | Thành tiền       ");
            Console.WriteLine(" -------    --------                  -----------                -------       --     ----------       ");
            for (int i = 0; i < lb.Count; i++)
            {
                string idbook = " MN" + lb[i].ID_Book + new string(' ', 7 - lb[i].ID_Book.ToString().Length);
                string bookname = " " + lb[i].book_title + new string(' ', 24 - lb[i].book_title.Length);
                string author = " " + lb[i].author + new string(' ', 25 - lb[i].author.Length);
                string dongia = " " + string.Format("{0:0,0}", lb[i].unit_price) + new string(' ', 9 - string.Format("{0:0,0}", lb[i].unit_price).ToString().Length) + "VNĐ";
                string sl = " " + o.BooksList[i].quantity + new string(' ', 5 - o.BooksList[i].quantity.ToString().Length);
                string tt = " " + string.Format("{0:0,0}", o.BooksList[i].quantity * lb[i].unit_price) + new string(' ', 14 - string.Format("{0:0,0}", o.BooksList[i].quantity * lb[i].unit_price).ToString().Length) + "VNĐ";
                Console.WriteLine(idbook + "|" + bookname + "|" + author + "|" + dongia + "|" + sl + "|" + tt + "|");
                a = a + lb[i].unit_price * o.BooksList[i].quantity;
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("                                                                    Tổng tiền: " + string.Format("{0:0,0}", a) + new string(' ', 20 - string.Format("{0:0,0}", a).ToString().Length) + "VNĐ\n");
            Console.WriteLine("                                                                    -----------------------------------\n");
            for (; ; )
            {
                Console.Write("-Xác nhận thanh toán(C/K): ");
                string chon = Console.ReadLine();
                if (chon == "C" || chon == "c")
                {
                    string price = "";
                    for (; ; )
                    {
                        Console.Write("-Nhập số tiền khách thanh toán: ");
                        price = Console.ReadLine();
                        if (TryParse(price) >= Convert.ToInt32(a))
                        {
                            tt.Tienthanhtoan = Convert.ToDecimal(price);
                            order.AddOrder(o);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("- Số tiền bạn nhập không đúng ! Vui lòng nhập lại !");
                        }
                    }
                    Console.Clear();
                    decimal b = 0;
                    o.creation_time = DateTime.Now;
                    Console.WriteLine("=======================================================================================================");
                    Console.WriteLine("                                          CỬA HÀNG SÁCH TG                                          \n");
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("                                                                         Ngày bán: " + new string(' ', 20 - string.Format("{0:dd/MM/yyyy hh:mm tt}",o.creation_time).ToString().Length) + string.Format("{0:dd/MM/yyyy hh:mm tt}",o.creation_time));
                    Console.WriteLine("                                       ***HÓA ĐƠN BÁN HÀNG***                                          ");
                    Console.WriteLine("- Mã hóa đơn : BL{0}", o.ID_Order);
                    Console.WriteLine("- Người bán  : " + e.full_name);
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                    Console.WriteLine(" Mã sách  | Tên sách                | Tên tác giả              | Đơn giá     | SL   | Thành tiền       ");
                    Console.WriteLine(" -------    --------                  -----------                -------       --     ----------       ");
                    for (int i = 0; i < lb.Count; i++)
                    {

                        string idbook = " MN" + lb[i].ID_Book + new string(' ', 7 - lb[i].ID_Book.ToString().Length);
                        string bookname = " " + lb[i].book_title + new string(' ', 24 - lb[i].book_title.Length);
                        string author = " " + lb[i].author + new string(' ', 25 - lb[i].author.Length);
                        string dongia = " " + string.Format("{0:0,0}", lb[i].unit_price) + new string(' ', 9 - string.Format("{0:0,0}", lb[i].unit_price).ToString().Length) + "VNĐ";
                        string sl = " " + o.BooksList[i].quantity + new string(' ', 5 - o.BooksList[i].quantity.ToString().Length);
                        string tt = " " + string.Format("{0:0,0}", o.BooksList[i].quantity * lb[i].unit_price) + new string(' ', 14 - string.Format("{0:0,0}", o.BooksList[i].quantity * lb[i].unit_price).ToString().Length) + "VNĐ";
                        Console.WriteLine(idbook + "|" + bookname + "|" + author + "|" + dongia + "|" + sl + "|" + tt + "|");
                        b = b + lb[i].unit_price * o.BooksList[i].quantity;
                    }
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------\n");
                    Console.WriteLine("                                                            + Tổng tiền      : " + string.Format("{0:0,0}", b) + new string(' ', 20 - string.Format("{0:0,0}", b).ToString().Length) + "VNĐ");
                    Console.WriteLine("                                                            + Tiền thanh toán: " + string.Format("{0:0,0}", Convert.ToDecimal(price)) + new string(' ', 20 - string.Format("{0:0,0}", Convert.ToDecimal(price)).ToString().Length) + "VNĐ");
                    Console.WriteLine("                                                            + Hoàn tiền      : " + string.Format("{0:0,0}", Convert.ToDecimal(price) - b) + new string(' ', 20 - string.Format("{0:0,0}", Convert.ToDecimal(price) - b).ToString().Length) + "VNĐ");
                    tt.Hoantien = Convert.ToDecimal(price) - b;
                    Console.WriteLine("---------------------------------------Hẹn gặp lại !!!-------------------------------------------------\n");
                    Console.Write("Bấm phím bất kỳ để quay lại.....");
                    Console.ReadKey();
                    ltt.Add(tt);
                    lb = new List<Books>();
                    o = new Orders();
                    Menu010();
                    break;
                }
                else if (chon == "K" || chon == "k")
                {
                    lb = new List<Books>();
                    o = new Orders();
                    Menu010();
                    break;
                }
                else
                {
                    Console.WriteLine("- Ký tự bạn nhập không đúng ! Vui lòng nhập lại !");
                }
            }
        }
        public void Menu013()
        {
            Console.Clear();
            Orders o1 = new Orders();
            o1.BooksList = new List<OrderDetails>();
            OrderDetails od = new OrderDetails();
            o1.BooksList.Add(od);
            List<Orders> lo = new List<Orders>();
            lo = order.GetAllOrderInDay();
            if (lo == null || lo.Count == 0)
            {
                Console.Clear();
                Console.Write("-Chưa có hóa đơn được tạo trong ngày hôm nay ! Bấm phím bất kỳ để quay lại....");
                Console.ReadKey();
                Menu010();
            }
            Employees ebl = new Employees();
            Console.WriteLine("=======================================================================================================");
            Console.WriteLine("                                      +++ CỬA HÀNG SÁCH TG +++                                        \n");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Lịch sử giao dịch:");
            Console.WriteLine("================================================================================");
            Console.WriteLine("| Mã hóa đơn  | Người tạo           | Thời gian tạo       | Tổng tiền          |");
            Console.WriteLine("| ----------    ---------             -------------         ---------          |");
            decimal ttn = 0;
            foreach (var item in lo)
            {
                string id_b = "| BL" + item.ID_Order + new string(' ', 10 - item.ID_Order.ToString().Length);
                ebl = employee.GetEmployeeByID(item.ID_E.ID_E);
                string name = " " + ebl.full_name + new string(' ', 20 - ebl.full_name.Length);
                string time = " " + string.Format("{0:dd/MM/yyyy hh:mm tt}",item.creation_time) + new string(' ', 20 - string.Format("{0:dd/MM/yyyy hh:mm tt}",item.creation_time).ToString().Length);
                decimal tongtien = 0;
                lo = order.GetOrderByID(item.ID_Order);
                foreach (var item1 in lo)
                {
                    for (int i = 0; i < item1.BooksList.Count; i++)
                    {
                        tongtien = tongtien + item1.BooksList[i].book.unit_price;
                    }
                }
                string tt = " " + string.Format("{0:0,0}", tongtien) + new string(' ', 16 - string.Format("{0:0,0}", tongtien).ToString().Length) + "VNĐ";
                Console.WriteLine(id_b + "|" + name + "|" + time + "|" + tt + "|");
                ttn = ttn + tongtien;
            }
            Console.WriteLine("================================================================================\n");
            Console.WriteLine("TỔNG THU NHẬP ({0}) : {1}    VNĐ", string.Format("{0:dd/MM/yyyy}", lo[0].creation_time) , string.Format("{0:0,0}",ttn));
            Console.WriteLine("-------------------------------------------------------------------------------------------------------\n");
            Console.WriteLine("BL0 .Quay lại");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------\n");
            Console.Write("#Chọn: BL");
            string id = Console.ReadLine();
            if(id == "0")
            {
                Menu010();
            }
            int a = TryParse(id);
            if (order.GetOrderByID(a) != null && a > 0)
            {
                Console.Clear();
                lo = order.GetOrderByID(TryParse(id));
                Console.WriteLine("=======================================================================================================");
                Console.WriteLine("                                          CỬA HÀNG SÁCH TG                                          \n");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                                                         Ngày bán: " + new string(' ', 20 - string.Format("{0:dd/MM/yyyy hh:mm tt}",lo[0].creation_time).ToString().Length) + string.Format("{0:dd/MM/yyyy hh:mm tt}",lo[0].creation_time));
                Console.WriteLine("                                       ***HÓA ĐƠN BÁN HÀNG***                                          ");
                Console.WriteLine("- Mã hóa đơn : BL{0}", id);
                Console.WriteLine("- Người bán  : " + employee.GetEmployeeByID(lo[0].ID_E.ID_E).full_name);
                Console.WriteLine("=========================================================================================================");
                Console.WriteLine("| Mã sách  | Tên sách                | Tên tác giả              | Đơn giá     | SL   | Thành tiền       |");
                Console.WriteLine("| -------    --------                  -----------                -------       --     ----------       |");
                decimal tt = 0;
                foreach (var item in lo)
                {
                    for (int i = 0; i < item.BooksList.Count; i++)
                    {
                        string id_book = "| MN" + item.BooksList[i].book.ID_Book + new string(' ', 7 - item.BooksList[i].book.ID_Book.ToString().Length);
                        string name = " " + book.GetBookById(item.BooksList[i].book.ID_Book).book_title + new string(' ', 24 - book.GetBookById(item.BooksList[i].book.ID_Book).book_title.Length);
                        string author = " " + book.GetBookById(item.BooksList[i].book.ID_Book).author + new string(' ', 25 - book.GetBookById(item.BooksList[i].book.ID_Book).author.Length);
                        string dongia = " " + string.Format("{0:0,0}",item.BooksList[i].book.unit_price/Convert.ToDecimal(item.BooksList[i].quantity)) + new string(' ', 9 - string.Format("{0:0,0}",item.BooksList[i].book.unit_price/Convert.ToDecimal(item.BooksList[i].quantity)).ToString().Length) + "VNĐ";
                        string sl = " " + item.BooksList[i].quantity +new string(' ', 5 - item.BooksList[i].quantity.ToString().Length);
                        string thanhtien = " " + string.Format("{0:0,0}",item.BooksList[i].book.unit_price) + new string(' ',14 - string.Format("{0:0,0}",item.BooksList[i].book.unit_price).ToString().Length) + "VNĐ";
                        Console.WriteLine(id_book + "|" + name + "|" + author + "|" + dongia + "|" + sl + "|" + thanhtien + "|");
                        tt = tt + item.BooksList[i].book.unit_price;
                    }
                }
                Console.WriteLine("=========================================================================================================");
                string _tt = string.Format("{0:0,0}",tt) + new string(' ', 16 - string.Format("{0:0,0}",tt).ToString().Length) + "VNĐ";
                Console.WriteLine("                                                                          Tổng tiền: " + _tt);
                Console.WriteLine("-----------------------------------------Hẹn gặp lại !!!-------------------------------------------------\n");
                Console.Write("Bấm phím bất kỳ để quay lại......");
                Console.ReadKey();
                Menu013();
            }
            else
            {
                Console.WriteLine("- Mã hóa đơn bạn nhập không tồn tại !");
                for (; ; )
                {
                    Console.WriteLine("1. Nhập lại");
                    Console.WriteLine("2. Thoát\n");
                    Console.Write("#Chọn: ");
                    string chon = Console.ReadLine();
                    if (chon == "1")
                    {
                        Menu013();
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
                        Console.WriteLine("- Ký tự bạn nhập không đúng !");
                    }
                }
            }
        }
    }
}
