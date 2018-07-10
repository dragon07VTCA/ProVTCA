using System;
using Xunit;
using MySql.Data.MySqlClient;
using DAL;

namespace DAL.Test
{
    public class BooksTest
    {
        [Theory]
        [InlineData(1)]
        public void TestGetBookByID(int ID_Book)
        {
            BooksDAL book = new BooksDAL();
            Assert.NotNull(book.GetBookById(ID_Book));
        }
        
    }
}