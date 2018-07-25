using System;
using Xunit;

namespace BL.Test
{
    public class EmployeesBLTest
    {
        [Fact]
        public void GetEmployeeByUserPassword()
        {
            string a = " " , b = " ";
            EmployeesBL ebl = new EmployeesBL();
            Assert.Null(ebl.GetEmployeeByUserPassword(a,b));
        }
        [Fact]
        public void GetEmployeeByUserPassword1()
        {
            string a = "1" , b = "1";
            EmployeesBL ebl = new EmployeesBL();
            Assert.NotNull(ebl.GetEmployeeByUserPassword(a,b));
        }
    }
    
}