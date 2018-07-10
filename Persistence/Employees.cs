using System;

namespace Persistence
{
    public class Employees
    {
        public int? ID_E{get; set;}
        public string full_name {get; set;}
        public string address {get; set;}
        public string phone_number {get; set;}
        public string user {get; set;}
        public string password {get; set;}
        public override bool Equals(object obj){
            if(obj is Employees){
                return ((Employees)obj).ID_E.Equals(ID_E);
            }
            return false;
        }
        public override int GetHashCode()
        {
            return ID_E.GetHashCode();
        }
    }
    
    
}
