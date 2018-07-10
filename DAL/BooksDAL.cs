using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Persistence;
namespace DAL
{
    public class BooksDAL
    {
        private string query;
        private MySqlConnection connection;
        private MySqlDataReader reader;
        public BooksDAL()
        {
            connection = DbConfiguration.OpenConnection();
        }
        public Books GetBookById(int ID_Book)
        {
            if(connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            query = $"select ID_Book, book_title, author, amount, unit_price from Books where id_book='{ID_Book}';";
            MySqlCommand command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            Books book = null;
            if (reader.Read())
            {
                book = GetBook(reader);
            }
            reader.Close();
            connection.Close();
            return book;
        }
        private Books GetBook(MySqlDataReader reader)
        {
            Books book = new Books();
            book.ID_Book = reader.GetInt32("ID_Book");
            book.book_title = reader.GetString("book_title");
            book.author = reader.GetString("author");
            book.amount = reader.GetInt32("amount");
            book.unit_price = reader.GetDecimal("unit_price");
            return book;
        }
        private List<Books> GetBook(MySqlCommand command)
        {
            List<Books> ListBook = new List<Books>();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                ListBook.Add(GetBook(reader));
            }
            reader.Close();
            connection.Close();
            return ListBook;
        }
    }
}