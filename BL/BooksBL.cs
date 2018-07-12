using System;
using System.Collections.Generic;
using Persistence;
using DAL;
namespace BL
{
    public class BooksBL
    {
        private BooksDAL B_BL = new BooksDAL();
        public Books GetBookById(int ID_Book)
        {
            return B_BL.GetBookById(ID_Book);
        }
    }
}
