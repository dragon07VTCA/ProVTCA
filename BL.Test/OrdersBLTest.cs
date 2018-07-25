using System;
using Xunit;
using Persistence;
using System.Collections.Generic;

namespace BL.Test
{
    public class OrderBLTest
    {
        [Fact]
        public void TestAddOrder()
        {
            OrderBL obl = new OrderBL();
            Orders or = new Orders();
            Employees e = new Employees();
            OrderDetails od = new OrderDetails();
            or.BooksList = new List<OrderDetails>();
            or.ID_Order = 1;
            or.creation_time = DateTime.Now;
            e.ID_E = 1;
            or.ID_E = e;
            od.book.ID_Book = 1;
            od.book.unit_price = 10000;
            od.quantity = 1;
            or.BooksList.Add(od);
            Assert.NotNull(obl.AddOrder(or));
        }
        [Fact]
        public void TestAddOrder1()
        {
            OrderBL obl = new OrderBL();
            Orders or = new Orders();
            Assert.Null(obl.AddOrder(or));
        }
    }
}