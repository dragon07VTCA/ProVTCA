using System;
using Xunit;
using MySql.Data.MySqlClient;
using DAL;
using Persistence;
namespace DAL.Test
{
    public class OrderTest
    {
        [Fact]
        public void CreateOrder()
        {
            OrderDAL order = new OrderDAL();
            Orders a = new Orders();
        
            Assert.True(order.CreateOrder(a));
        }
    }
}

        