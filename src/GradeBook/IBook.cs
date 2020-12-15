using System;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
    public interface IBook
    {
        bool AddGrade(double grade);
        Statistics GetStatistics();
        string Name {get;}
        event GradeAddedDelegate GradeAdded;
        int GetGradeBookSize();
    }
}