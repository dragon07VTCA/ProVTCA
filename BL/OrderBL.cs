using System;
using System.Collections.Generic;
using Persistence;
using DAL;

namespace BL
{
    public class OrderBL
    {
        private OrderDAL O_BL = new OrderDAL();
        public bool AddOrder(Orders order)
        {
            bool result = O_BL.AddOrder(order);
