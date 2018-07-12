using System;
using Xunit;
using MySql.Data.MySqlClient;
using DAL;
using Persistence;
using System.Collections.Generic;

namespace DAL.Test
{
    public class OrderTest
    {
        private OrderDAL order = new OrderDAL();
        [Fact]
        public void TestName()
        {
            Orders or = new Orders();
            Assert.Null(order.AddOrder(or));
        }
        [Fact]
        public void TestOrder()
        {
            Orders or = new Orders();
            or.ID_Order = 1;
            or.ID_E = 1;
            or.creation_time = DateTime.Now;
            or.BooksList = new List<OrderDetails>();
            OrderDetails orde = new OrderDetails();
            Books bo = new Books();
            bo.ID_Book = 1;
            orde.book.ID_Book = bo.ID_Book;
            bo.unit_price = 10;
            orde.quantity = 3;
            orde.book.unit_price = bo.unit_price;
            or.BooksList.Add(orde);
            Assert.NotNull(order.AddOrder(or));
        }

    }
}