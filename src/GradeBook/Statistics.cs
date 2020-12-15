using System;

namespace GradeBook 
{
    public class Statistics
    {
        public double Sum;
        public double High
        {
            get; set;
        }
        public double Low
        {
            get; set;
        }
        public double Average{
            get
            {
                return Sum/Count;
            }
        }
        public char Letter
        {
            get
            {
                switch(Average)
                {
                    case var d when d>=90.0:
                        return 'A';
                        
                    case var d when d>=80.0:
                        return 'B';
                        
                    case var d when d>=70.0:
                        return 'C';
                        
                    case var d when d>=60.0:
                        return 'D';
                        
                    default:
                        return 'F';
                        
                }
            }
        }
        public int Count;
        public Statistics()
        {
            this.Sum = 0.0;
            this.Count = 0;
            this.High = double.MinValue;
            this.Low = double.MaxValue;
        }

        public void Add(double number)
        {
            Sum+=number;
            Count+=1;
            High = Math.Max(number, High);
            Low = Math.Min(number, Low);
        }

        public void displayStatistics()
        {
            Console.WriteLine($"Highest grade is: {High}");   
            Console.WriteLine($"Lowest grade is: {Low}");    
            Console.WriteLine($"Average grade is: {Average:N1}");
            Console.WriteLine($"Letter grade is: {Letter}");
        }
    }
}