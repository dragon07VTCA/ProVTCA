using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistence;
namespace DAL
{
    public class OrderDAL
    {
        public bool CreateOrder(Orders order)
        {
            if(order == null || order.BooksList == null || order.BooksList.Count == 0)
            {
                return false;
            }
            bool result = true;
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
            MySqlDataReader reader = null;
            //Nhập dữ liệu cho bảng Order
            cmd.CommandText = "insert into Orders(Book_ID,Note) values (@Book_ID, @Note);";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Book_ID",order.OrderBooks.Book_ID);
            cmd.Parameters.AddWithValue("@Note",OrdersNote.CREATE_NEW_ORDER);
            cmd.ExecuteNonQuery();
            //Lấy Order_ID mới 
            cmd.CommandText = "select LAST_INSERT_ID() as ID_Order");
             if (reader.Read())
                {
                    order.OrderId = reader.GetInt32("order_id");
                }
                reader.Close();
            //Nhập vào bảng 
             foreach (var item in order.ItemsList)
                {
                    if (Books.Book_ID == null || Books.Amount <= 0)
                    {
                        throw new Exception("Not Exists Item");
                    }
            //Lấy unit_price Order_Details
            cmd.CommandText = "select unit_price from where Book_ID=@Book_ID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Book_ID",Books.Book_ID);
            reader = cmd.ExecuteReader();
             if (!reader.Read())
                    {
                        throw new Exception("Not Exists Item");
                    }
                    item.ItemPrice = reader.GetDecimal("unit_price");
                    reader.Close();
        
        //Nhập dữ liệu vào bảng Order_Details
         cmd.CommandText = @"insert into OrderDetails(ID_order,ID_Book,unit_price, quantity) values
                            (" Orders.ID_order + "," + Books.Book_ID + "," + Books.unit_price + "," + Books.Amount + ");";
         cmd.ExecuteNonQuery();
         //Cập nhập số lượng mới của sách
         cmd.CommandText = "update Books set amount=amount-@quantity where Books_ID=" + Books.Book_ID + ";";
          cmd.Parameters.Clear();
          cmd.Parameters.AddWithValue("@quantity", Books.Amount);
          cmd.ExecuteNonQuery();
          }
          //commit transaction
                trans.Commit();
                result = true;
        }   
            catch (Exception ex)
            {
                  Console.WriteLine(ex.Message);
                result = false;
                try
                {
                    trans.Rollback();
                }
                catch
                {
                }
            }
             finally
            {   
                //Mở khóa tất cả các bảng
                cmd.CommandText = "unlock tables;";
                cmd.ExecuteNonQuery();
                DBHelper.CloseConnection();
            }
            return result;
    }
}