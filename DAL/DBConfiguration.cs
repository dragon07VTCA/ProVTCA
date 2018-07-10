using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.IO;
namespace DAL
{
    public class DbConfiguration
    {
        private static MySqlConnection connection  = null;
        public static MySqlConnection OpenConnection()
        {
            try
            {
                string connectionString;
                FileStream fileStream = File.OpenRead("ConnectionString.txt");
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
        public static void CloseConnection()
        {
            if (connection != null) connection.Close();
        }
        public static bool ExecTransaction(List<string> queries)
        {
            bool result = true;
            OpenConnection();
            MySqlCommand command = connection.CreateCommand();
            MySqlTransaction trans = connection.BeginTransaction();

            command.Connection = connection;
            command.Transaction = trans;

            try
            {
                foreach (var query in queries)
                {
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    trans.Commit();
                }
                result = true;
            }
            catch
            {
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
                CloseConnection();
            }
            return result;
        }
    }
}