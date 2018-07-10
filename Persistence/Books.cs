using System;

namespace Persistence
{
    public class Books
    {
        public int? ID_Book{get; set ;}
        public string book_title {get; set;}
        public string author {get; set;}
        public int amount {get;set;}
        public decimal unit_price {get;set;}
        public override bool Equals(object obj)
        {
            if(obj is Books)
            {
                return ((Books)obj).ID_Book.Equals(ID_Book);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ID_Book.GetHashCode();
        }
    }
}