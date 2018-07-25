using System;
using Xunit;

namespace BL.Test
{
    public class BooksBLTest
    
    {
        [Fact]
        public void GetBookByIDTest()
        {
            int ID = 100;
            BooksBL bbl = new BooksBL();
            Assert.Null(bbl.GetBookById(ID));
        }
        [Fact]
        public void GetBookByIDTest1()
        {
            int ID = 1;
            BooksBL bbl = new BooksBL();
            Assert.NotNull(bbl.GetBookById(ID));
        }
    }
}
