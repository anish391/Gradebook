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
            var gradebook = new Book(bookName);
            Console.WriteLine("Enter number of grades.");
            var numGrades = int.Parse(Console.ReadLine());
            while(gradebook.GetGradeBookSize() != numGrades)
            {
                Console.WriteLine($"Enter grade: ");
                var input = Console.ReadLine();
                try
                {    
                    var grade = double.Parse(input);
                    gradebook.AddGrade(grade);
                }
                catch(ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch(FormatException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            gradebook.GetStatistics();
        }
    }
}
