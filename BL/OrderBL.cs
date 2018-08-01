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
        public int GetOrder()
        {
            return O_BL.GetIDOrder();
        }
        public List<Orders> GetAllOrderInDay()
        {
            
            return O_BL.GetAllOrderInDay();
        }
        public List<Orders> GetOrderByID(int ID_Order)
        {
            return O_BL.GetOrderByID(ID_Order);
        }
    }
}
