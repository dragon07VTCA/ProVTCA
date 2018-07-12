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
            try
            {
                //Khoa cap nhat tat ca table , bao dam tinh toan ven du lieu
                cmd.CommandText = "lock tables Employees write, Orders write, Books write, List_Order_ID write;";
                cmd.ExecuteNonQuery();
                MySqlTransaction trans = connection.BeginTransaction();
                cmd.Transaction = trans;
                // Nhap du lieu cho bang Order
                cmd.CommandText = "insert into Orders(ID_Order , ID_E , Creation_Time) values (@ID_Order , @ID_E , @Creation_Time)";
                cmd.Parameters.AddWithValue("@ID_Order", order.ID_Order);
                cmd.Parameters.AddWithValue("@ID_E", order.ID_E);
                cmd.Parameters.AddWithValue("@Creation_Time", order.creation_time);
                //Nhập dữ liệu cho bảng OrderDetail
                for (int i = 0; i < order.BooksList.Count; i++)
                {
                    cmd.CommandText = $@"insert into OrderDetails(ID_Order,ID_Book,unit_price,quantity) values
                    ({order.ID_Order},
                     {order.BooksList[i].book.ID_Book},
                     {order.BooksList[i].quantity},
                     {order.BooksList[i].quantity * order.BooksList[i].book.unit_price})";
                    cmd.CommandText = $"update Books set amount = amount - {order.BooksList[i].quantity} where ID_Book = {order.BooksList[i].book.unit_price};";

                    // cmd.CommandText = "insert into OrderDetails(ID_Order,ID_Book,unit_price,quantity) values (@ID_Order, @ID_Book, @unit_price,@quantity);";                    
                    // cmd.Parameters.Clear();
                    // cmd.Parameters.AddWithValue("@ID_Order", order.ID_Order);
                    // cmd.Parameters.AddWithValue("@ID_Book", order.BooksList[i].book.ID_Book);
                    // cmd.Parameters.AddWithValue("@quantity", order.BooksList[i].quantity);
                    // cmd.Parameters.AddWithValue("@unit_price", order.BooksList[i].quantity * order.BooksList[i].book.unit_price);
                    // cmd.CommandText = "update Books set amount = amount - " + order.BooksList[i].quantity + " where id_book =" + order.BooksList[i].book.ID_Book + ";";
                }
            }
            catch
            {

            }
            finally
            {
                cmd.CommandText = "unlock tables;";
                cmd.ExecuteNonQuery();
                DbConfiguration.CloseConnection();
            }

            return order;
        }
    }

}