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
                result.Add(grade);    
            }
            result.displayStatistics();
            return result;
        }
        public override int GetGradeBookSize(){
            return grades.Count;
        }

        private List<double> grades;

        


    }
}
