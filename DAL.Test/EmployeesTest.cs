using System;
using Xunit;
using MySql.Data.MySqlClient;
using DAL;

namespace DAL.Test
{
    public class EmployeesTest
    {
        [Theory]
        [InlineData("abcd", "12345")]
        public void TestName(string user_name, string password)
        {
            EmployeesDAL e = new EmployeesDAL();
            Assert.Null(e.GetEmployeeByUserPassword(user_name, password));
        }
        [Theory]
        [InlineData("TruongVTCA","VTCA")]
        public void TestName1(string user_name, string password)
        {
            EmployeesDAL e = new EmployeesDAL();
            Assert.NotNull(e.GetEmployeeByUserPassword(user_name, password));
        }
    }
}