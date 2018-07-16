using System;
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
        public void Menu0()
        {
            BL.EmployeesBL employee = new BL.EmployeesBL();
            Console.WriteLine("---Chao mung den voi cua hang sach TG---");
            Console.WriteLine("=========================================\n");
            Console.WriteLine("1. Dang nhap he thong");
            Console.WriteLine("2. Exit\n");
            for (; ; )
            {
                Console.Write("#Chon: ");
                string select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Dang nhap he thong:");
                        Console.WriteLine("======================================");
                        for (; ; )
                        {

                            Console.Write("-Ten dang nhap: ");
                            string user = Console.ReadLine();
                            Console.Write("-Mat khau: ");
                            string password = Console.ReadLine();
                            employee.GetEmployeeByUserPassword(user, password);
                            if (employee.GetEmployeeByUserPassword(user,password) != null)
                            {
                                Console.WriteLine("gafsfsdafgsgsdg");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("sai r r r r");
                            }
                        }
                        break;
                    case "2":
                        break;
                    default:
                        Console.WriteLine("- Ky tu ban nhap khong dung ! Vui long thu lai !");
                        break;
                }
                if (select == "2")
                {
                    break;
                }
            }
        }
    }

}
