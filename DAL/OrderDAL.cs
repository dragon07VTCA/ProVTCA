using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistence;
namespace DAL
{
    public class OrderDAL
    {
        public Orders AddOrder(Orders order)
        {
            if (order == null || order.BooksList == null || order.BooksList.Count == 0)
            {
                return null;
            }
            MySqlConnection connection = DbConfiguration.OpenConnection();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.Connection = connection;
            //Khoa cap nhat tat ca table , bao dam tinh toan ven du lieu
            cmd.CommandText = "lock tables Employees write, Orders write, Books write, OrderDetails write;";
            cmd.ExecuteNonQuery();
            MySqlTransaction trans = connection.BeginTransaction();
            cmd.Transaction = trans;
            try
            {
                // Nhap du lieu cho bang Order
                cmd.CommandText = $"insert into Orders(ID_E) value ({order.ID_E.ID_E});";
                cmd.ExecuteNonQuery();
                int ID_Order = GetIDOrder() + 1;
                //Nhập dữ liệu cho bảng OrderDetail
                for (int i = 0; i < order.BooksList.Count; i++)
                {
                    cmd.CommandText = $@"insert into OrderDetails(ID_Order,ID_Book,unit_price,quantity) values
                    ({ID_Order},
                     {order.BooksList[i].book.ID_Book},
                     {order.BooksList[i].quantity * order.BooksList[i].book.unit_price},
                     {order.BooksList[i].quantity})";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = $"update Books set amount = amount - {order.BooksList[i].quantity} where ID_Book = {order.BooksList[i].book.ID_Book};";
                    cmd.ExecuteNonQuery();
                    // cmd.CommandText = "insert into OrderDetails(ID_Order,ID_Book,unit_price,quantity) values (@ID_Order, @ID_Book, @unit_price,@quantity);";                    
                    // cmd.Parameters.Clear();
                    // cmd.Parameters.AddWithValue("@ID_Order", order.ID_Order);
                    // cmd.Parameters.AddWithValue("@ID_Book", order.BooksList[i].book.ID_Book);
                    // cmd.Parameters.AddWithValue("@quantity", order.BooksList[i].quantity);
                    // cmd.Parameters.AddWithValue("@unit_price", order.BooksList[i].quantity * order.BooksList[i].book.unit_price);
                    // cmd.CommandText = "update Books set amount = amount - " + order.BooksList[i].quantity + " where id_book =" + order.BooksList[i].book.ID_Book + ";";
                }
                trans.Commit();
            }
            catch
            {
                trans.Rollback();
                return null;
            }
            finally
            {
                cmd.CommandText = "unlock tables;";
                cmd.ExecuteNonQuery();
                DbConfiguration.CloseConnection();
            }

            return order;
        }

        public int GetIDOrder()
        {
            int result = 0;
            string query = "select ID_Order from Orders order by ID_Order desc limit 1;";
            MySqlConnection connection = DbConfiguration.OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    result = reader.GetInt32("ID_Order");
                }
            }
            connection.Close();
            return result;
        }
        private string query;
        public MySqlConnection connection = DbConfiguration.OpenConnection();
        public MySqlDataReader reader;
        public List<Orders> GetAllOrderInDay()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = $@"select * from Orders where day(Creation_Time) + month(Creation_Time) + year(Creation_Time) = '{DateTime.Now.Day}'
                                                                                                                  + '{DateTime.Now.Month}' 
                                                                                                                  + '{DateTime.Now.Year}';";
            reader = (new MySqlCommand(query,connection)).ExecuteReader();
            List<Orders> lo = new List<Orders>();
            Orders o = null;
            while (reader.Read())
            {
                o = new Orders();
                o = GetOrder0(reader);
                lo.Add(o);
            }
            if(lo == null || lo.Count == 0)
            {
                reader.Close();
                return null;
            }
            reader.Close();
            return lo;
        }
        private Orders GetOrder0(MySqlDataReader reader)
        {
            Orders o = new Orders();
            o.ID_E = new Employees();
            o.ID_Order = reader.GetInt32("ID_Order");
            o.ID_E.ID_E = reader.GetInt32("ID_E");
            o.creation_time = reader.GetDateTime("creation_time");
            return o;
        }
        public List<Orders> GetOrderByID(int ID_Order)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = $"select od.ID_Order , o.ID_E , o.Creation_Time , od.ID_Book , od.unit_price , od.quantity from orders o join OrderDetails od on o.ID_Order = od.ID_Order and od.ID_Order = {ID_Order} and day(o.Creation_Time) + month(o.Creation_Time) + year(o.Creation_Time) = '{DateTime.Now.Day}' + '{DateTime.Now.Month}' + '{DateTime.Now.Year}';";
            reader = (new MySqlCommand(query, connection)).ExecuteReader();
            List<Orders> lo = new List<Orders>();
            Orders o = null;
            while (reader.Read())
            {
                o = new Orders();
                o = GetOrder(reader);
                lo.Add(o);
            }
            if(lo == null || lo.Count == 0)
            {
                reader.Close();
                return null;
            }
            reader.Close();
            return lo;
        }
        private Orders GetOrder(MySqlDataReader reader)
        {
            Orders o = new Orders();
            OrderDetails od = new OrderDetails();
            o.ID_E = new Employees();
            o.BooksList = new List<OrderDetails>();
            o.ID_Order = reader.GetInt32("ID_Order");
            o.ID_E.ID_E = reader.GetInt32("ID_E");
            o.creation_time = reader.GetDateTime("creation_time");
            od.book.ID_Book = reader.GetInt32("ID_Book");
            od.book.unit_price = reader.GetDecimal("unit_price");
            od.quantity = reader.GetInt32("quantity");
            o.BooksList.Add(od);
            return o;
        }

    }

}