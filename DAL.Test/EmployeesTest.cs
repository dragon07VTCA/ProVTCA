// using System;
// using Xunit;
// using MySql.Data.MySqlClient;
// using DAL;

// namespace DAL.Test
// {
//     public class EmployeesTest
//     {
//         [Fact]
//         public void GetEmployeeByUserPasswrod(string user_name , string password)
//         {
//             EmployeesDAL e = new EmployeesDAL();
//             Assert.NotNull(e.GetEmployeeByUserPassword(user_name , password));
//         }
//         [Theory]
//         [InlineData("select id_e, full_name, phone_number,address from Employee where user_name=user_name and password=password;")]
//         [Fact]
//         public void TestName()
//         {
//         //Given
        
//         //When
        
//         //Then
//         }
//     }
// }