using System;
using Xunit;
using MySql.Data.MySqlClient;
using DAL;

namespace DAL.Test
{
    public class DbConfiguratonTest
    {
        [Fact]
        public void OpenConnectionTest()
        {
            Assert.NotNull(DbConfiguration.OpenConnection());
        }

        [Theory]
        [InlineData("server=localhost;user id=root;password=07101999;port=3306;database=DB;SslMode=None")]
        public void OpenConnectionWithStringTest(string connectionString)
        {
            Assert.NotNull(DbConfiguration.OpenConnection(connectionString));
        }

        [Theory]
        [InlineData("server=localhost1;user id=vtca;password=vtcacademy;port=3306;database=OrderDB;SslMode=None")]
        public void OpenConnectionWithStringFailTest(string connectionString)
        {
            Assert.Null(DbConfiguration.OpenConnection(connectionString));
        }

        [Fact]
        public void OpenDefaultConnectionTest()
        {
            Assert.NotNull(DbConfiguration.OpenConnection());
        }
    }
}