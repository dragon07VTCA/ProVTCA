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
            //Khoa cap nhat tat ca table , bao dam tinh toan ven du lieu
            cmd.CommandText = "lock tables Employees write, Orders write, Books write, List_Order_ID write;";
            cmd.ExecuteNonQuery();
            MySqlTransaction trans = connection.BeginTransaction();
            cmd.Transaction = trans;
            MySqlDataReader reader = null;
            if(order.ID_E == null || order.ID_E.full_name == null || order.ID_E.full_name == "")
            {
                
            }
            
        }
    }
}