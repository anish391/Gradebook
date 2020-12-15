using System;

namespace GradeBook
{
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public virtual event GradeAddedDelegate GradeAdded;

        public abstract bool AddGrade(double grade);
        public abstract int GetGradeBookSize();

        public virtual Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }
}