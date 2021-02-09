using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitMidTerm
{
    public class BookstoreFunctionsTest
    {

        [Fact]
        public void GetBookByTitle()
        {
            var result = MidTerm.BookStoreFunctions.GetBookBytitle("The Travels of Marco Polo");
            Assert.True(result.Count == 1);
            
        }

        [Fact]
        public void GetAllBooks()
        {
            var result = MidTerm.BookStoreFunctions.GetAllBooks();
            Assert.True(result.Count == 2);
        }

        [Fact]
        public void GetAllBooksByAuthorLast()
        {
            var result = MidTerm.BookStoreFunctions.GetAllBooksByAuthorLast("Polo");
            Assert.True(result.Count == 1);
        }

    }
}
