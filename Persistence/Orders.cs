using System;
using System.Collections.Generic;
namespace Persistence
{
    public static class OrderStatus
    {
        public const int create_new_order = 1;    }
    public class Orders
    {
        public int? ID_Order{get;set;}
        public Employees ID_E{get; set;}
        public DateTime creation_time{get; set;}
        public string note {get; set;}
        public int? status{get; set;}
        public List<Books> BooksList {get; set;}
        public Books this[int index]
        {
            get
            {
                if (BooksList == null || BooksList.Count == 0 || index < 0 || BooksList.Count <index) return null;
                return BooksList[index];
            }
            set
            {
                if (BooksList == null) BooksList = new List<Books>();
                BooksList.Add(value);
            }
        }
        public Orders()
        {
            BooksList = new List<Books>();
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