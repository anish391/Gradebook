using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Scott";
            name = MakeUpperCase(name);

            Assert.Equal("SCOTT", name);
        }

        private string MakeUpperCase(string name)
        {
            return name.ToUpper();
        }

        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(x);
            Assert.Equal(3, x);
        }
        private int GetInt()
        {
            return 3;
        }
        private void SetInt(int x)
        {
            x = 42;
        }
        [Fact]
        public void CSharpCanPassByReference()
        {
            // arrange
            var book1 = GetBook("Book 1");
            GetBookRefSetName(ref book1, "Book Change");
            
            Assert.Equal("Book Change", book1.Name);
        }
        private void GetBookRefSetName(ref Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            // arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "Book Change");
            // Since we pass by value, changes made to Book object don't affect book1 above.
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
            book.Name = name;
        }


        [Fact]
        public void CanSetNameFromReference()
        {
            // arrange
            var book1 = GetBook("Book 1");
            SetName(book1, "Book Change");
            // assert    
            Assert.Equal("Book Change", book1.Name);
        }
        private void SetName(Book book, string name)
        {
            book.Name = name;
        }
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");          
            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsReferSameObject()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;
            // assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }


        private Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
