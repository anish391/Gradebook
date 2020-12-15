using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name) 
        {

        }

        public override event GradeAddedDelegate GradeAdded;

        public override bool AddGrade(double grade)
        {
            using(var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if(GradeAdded!=null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            return true;
        }

        public override int GetGradeBookSize()
        {
            return 0;
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while(line!=null)
                {
                    double grade = double.Parse(line);
                    result.Add(grade);
                    line = reader.ReadLine();
                }
            }
            result.displayStatistics();
            return result;
        }
    }
}