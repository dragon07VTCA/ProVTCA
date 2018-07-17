using System;
using System.Collections.Generic;
using Persistence;
using DAL;

namespace BL
{
    public class OrderBL
    {
        private OrderDAL O_BL = new OrderDAL();
        public Orders AddOrder(Orders order)
        {
            return O_BL.AddOrder(order);
        }
    }
}
