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
            var gradebook = new InMemoryBook(bookName);
            gradebook.GradeAdded += OnGradeAdded;
            Console.WriteLine("Enter number of grades.");
            var numGrades = int.Parse(Console.ReadLine());
            EnterGrades(gradebook, numGrades);
            gradebook.GetStatistics();
        }

        private static void EnterGrades(IBook gradebook, int numGrades)
        {
            while (gradebook.GetGradeBookSize() != numGrades)
            {
                Console.WriteLine($"Enter grade: ");
                var input = Console.ReadLine();
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
