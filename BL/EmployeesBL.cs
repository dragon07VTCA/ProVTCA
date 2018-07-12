using System;
using System.Collections.Generic;
using Persistence;
using DAL;

namespace BL
{
    public class EmployeesBL
    {
        private EmployeesDAL E_BL = new EmployeesDAL();
        public Employees GetEmployeeByUserPassword(string user_name , string password)
        {
            return E_BL.GetEmployeeByUserPassword(user_name , password);
        }
    }
}
