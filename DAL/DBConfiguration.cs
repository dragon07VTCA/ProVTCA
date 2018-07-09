using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.IO;
namespace DAL
{
    public class DbConfiguration
    {
        public static MySqlConnection OpenConnection()
        {
            try
            {
                string connectionString;
                FileStream fileStream = new FileStream("ConnectionString.txt", FileMode.Open);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    connectionString = reader.ReadLine();
                }
                return OpenConnection(connectionString);
            }
            catch
            {
                return null;
            }
        }
        public static MySqlConnection OpenConnection(string connectionString)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection
                {
                    ConnectionString = connectionString
                };
                connection.Open();
                return connection;
            }
            catch
            {
                return null;
            }
        }
    }
}