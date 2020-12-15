using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Book Name");
            var bookName = Console.ReadLine();
            
            Console.WriteLine("Enter number of grades.");
            var numGrades = int.Parse(Console.ReadLine());

            // Get grades and store in file.
            IBook gradeDiskBook = new DiskBook(bookName);
            gradeDiskBook.GradeAdded += OnGradeAdded;
            EnterGrades(gradeDiskBook, numGrades);
            gradeDiskBook.GetStatistics();
            
            Console.WriteLine("-------------------");

            // Get grades and store in memory.
            IBook gradeInMemoryBook = new InMemoryBook(bookName);
            gradeInMemoryBook.GradeAdded += OnGradeAdded;
            Console.WriteLine("Enter number of grades.");
            EnterGrades(gradeInMemoryBook, numGrades);
            gradeInMemoryBook.GetStatistics();
        }

        private static void EnterGrades(IBook gradebook, int numGrades)
        {
            while (true)
            {
                Console.WriteLine($"Enter grade: ");
                var input = Console.ReadLine();
                if(input=="q")
                    break;
                try
                {
                    var grade = double.Parse(input);
                    gradebook.AddGrade(grade);
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine("A grade has been added.");
        }
    }
}
