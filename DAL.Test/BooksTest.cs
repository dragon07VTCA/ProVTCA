using System;
using Xunit;
using MySql.Data.MySqlClient;
using DAL;

namespace DAL.Test
{
    public class BooksTest
    {
        [Fact]
        public void TestGetBookByID1()
        {
            int ID_Book = -1000;
            BooksDAL bo = new BooksDAL();
            Assert.Null(bo.GetBookById(ID_Book));
        }
        [Theory]
        [InlineData(1)]
        public void TestGetBookByID(int ID_Book)
        {
            BooksDAL book = new BooksDAL();
            Assert.NotNull(book.GetBookById(ID_Book));
        }
    }
}