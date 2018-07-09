using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistence;
namespace DAL
{
    public class EmployeesDAL
    {
        private string query;
        private MySqlConnection connection = DbConfiguration.OpenConnection();
        private MySqlDataReader reader;
        public Employees GetEmployeeByUserPasswrod(string user_name , string password)
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = @"select id_e, full_name, email, phone_number,address
                        from Employee where user_name=" + user_name + "and password=" + password +";";
            reader = (new MySqlCommand(query,connection)).ExecuteReader();
            Employees c = null;
            if (reader.Read())
            {
                c = GetEmployee(reader);
            }
            reader.Close();
            return c;
        }
        internal Employees GetEmployeeByUserPasswrod(string user_name , string password,MySqlConnection connection)
        {
            query = @"select id_e, full_name, email, phone_number,address
                        from Employee where user_name=" + user_name + "and password=" + password +";";
            Employees c = null;
            reader = (new MySqlCommand(query,connection)).ExecuteReader();
            if (reader.Read())
            {
                c = GetEmployee(reader);
            }
            reader.Close();
            return c;
        }
        private Employees GetEmployee(MySqlDataReader reader)
        {
            Employees c = new Employees();
            c.ID_E = reader.GetInt32("id_e");
            c.full_name = reader.GetString("full_name");
            c.email = reader.GetString("email");
            c.phone_number = reader.GetString("phone_number");
            c.address = reader.GetString("address");
            return c;
        }
    }
}