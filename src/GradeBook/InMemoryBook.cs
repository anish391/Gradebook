using System;
using System.Collections.Generic;

namespace GradeBook
{
    
    public class InMemoryBook : Book
    {
        
        public override event GradeAddedDelegate GradeAdded;
        public InMemoryBook(string name) : base(name)
        {       
            grades = new List<double>();
        }
        public override bool AddGrade(double grade)
        {
            if(grade<=100 && grade>=0)
            {
                grades.Add(grade);
                if(GradeAdded!=null)
                {
                    GradeAdded(this, new EventArgs());
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddGrade(char letter)
        {
            switch(letter)
            {
                case 'A':
                    return AddGrade(90.0);
                case 'B':
                    return AddGrade(80.0);
                case 'C':
                    return AddGrade(70.0);
                case 'D':
                    return AddGrade(60.0);
                default:
                    return AddGrade(0);
            }
        }

        public override Statistics GetStatistics() {
            var result = new Statistics();
            foreach(double grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);
                result.Sum+=grade;    
            }
            int gradeSize = grades.Count;
            result.Average = result.Sum/gradeSize;
            switch(result.Average)
            {
                case var d when d>=90.0:
                    result.Letter = 'A';
                    break;
                case var d when d>=80.0:
                    result.Letter = 'B';
                    break;
                case var d when d>=70.0:
                    result.Letter = 'C';
                    break;
                case var d when d>=60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;
            }
            displayStatistics(result);
            return result;
        }
        public override int GetGradeBookSize(){
            return grades.Count;
        }

        private List<double> grades;

        private void displayStatistics(Statistics statistics)
        {
            Console.WriteLine($"Highest grade is: {statistics.High}");   
            Console.WriteLine($"Lowest grade is: {statistics.Low}");    
            Console.WriteLine($"Average grade is: {statistics.Average:N1}");
            Console.WriteLine($"Letter grade is: {statistics.Letter}");
        }


    }
}
