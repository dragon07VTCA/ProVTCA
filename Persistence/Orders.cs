using System;
using System.Collections.Generic;
namespace Persistence
{
    public class OrderDetails
    {
        public Books book = new Books();
        public int quantity;
    }
    public static class OrderStatus
    {
        public const int create_new_order = 1;    }
    public class Orders
    {
        public int? ID_Order{get;set;}
        public int ID_E{get; set;}
        public DateTime creation_time{get; set;}
        public string note {get; set;}
        public int? status{get; set;}
        public List<OrderDetails> BooksList {get; set;}
        public OrderDetails this[int index]
        {
            get
            {
                if (BooksList == null || BooksList.Count == 0 || index < 0 || BooksList.Count <index)
                {
                    return null;
                };
                return BooksList[index];
            }
            set
            {
                if (BooksList == null) BooksList = new List<OrderDetails>();
                BooksList.Add(value);
            }
        }
        public Orders()
        {
            BooksList = new List<OrderDetails>();
        }
        public override bool Equals(object obj)
        {
            if(obj is Orders )
            {
                return ((Orders)obj).ID_Order.Equals(ID_Order);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ID_Order.GetHashCode();
        }
    }
}