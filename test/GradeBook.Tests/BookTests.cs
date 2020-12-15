using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new InMemoryBook("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();
            
            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.Letter);
        }

        [Fact]
        public void GradeIsValid()
        {
            InMemoryBook book = new InMemoryBook("Anish");
            Assert.True(book.AddGrade(0));
            Assert.True(book.AddGrade(100));
            Assert.True(book.AddGrade(50));
            Assert.False(book.AddGrade(-1));
            Assert.False(book.AddGrade(101));
        }
    }
}
