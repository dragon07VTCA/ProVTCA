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
        public Employees GetEmployeeByUserPassword(string user_name , string password)
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = $"select ID_E, full_name, Phone_number,Address from Employees where User_name='{user_name}' and User_Password='{password}';";
            reader = (new MySqlCommand(query,connection)).ExecuteReader();
            Employees c = null;
            if (reader.Read())
            {
                c = GetEmployee(reader);
            }
            reader.Close();
            return c;
        }
        internal Employees GetEmployeeByUserPassword(string user_name , string password,MySqlConnection connection)
        {
            query = $"select ID_E, full_name, Phone_number,Address from Employees where User_name='{user_name}' and User_Password='{password}';";
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
            c.ID_E = reader.GetInt32("ID_E");
            c.full_name = reader.GetString("full_name");
            c.phone_number = reader.GetString("Phone_number");
            c.address = reader.GetString("Address");
            return c;
        }
    }
}