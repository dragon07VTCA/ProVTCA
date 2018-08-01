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
            or.ID_E = new Employees();
            OrderDetails od = new OrderDetails();
            or.BooksList = new List<OrderDetails>();
            or.ID_E.ID_E = 1;
            od.book = new Books();
            od.book.ID_Book= 1;
            od.book.unit_price = 10;
            od.quantity = 10;
            or.BooksList.Add(od);
            Assert.NotNull(order.AddOrder(or));
        }

        [Fact]
        public void TestGetIDOrder()
        {
            Assert.NotEqual(0, order.GetIDOrder());
        }
        [Fact]
        public void TestGetOrderID()
        {
            int ID_Order = 2;
            Assert.NotNull(order.GetOrderByID(ID_Order));
        }

    }
}