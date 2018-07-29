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
        public void TestAddOrder_Null()
        {
            Orders or = new Orders();
            Assert.Null(order.AddOrder(or));
        }
        [Fact]
        public void TestAddOrder_NotNull()
        {
            Orders or = new Orders();
            Employees e = new Employees();
            OrderDetails od = new OrderDetails();
            or.BooksList = new List<OrderDetails>();
            e.ID_E = 1;
            or.ID_E = e;
            Books b = new Books();
            b.ID_Book = 1;
            b.unit_price = 10;
            od.book.ID_Book = b.ID_Book;
            od.book.unit_price = b.unit_price;
            od.quantity = 10;
            or.BooksList.Add(od);
            Assert.NotNull(order.AddOrder(or));
        }

        [Fact]
        public void TestGetIDOrder()
        {
            Assert.Equal(1, order.GetIDOrder());
        }

    }
}