namespace GradeBook 
{
    public class Statistics
    {
        public double Sum;
        public double High;
        public double Low;
        public double Average;
        public char Letter;
        public Statistics()
        {
            this.Sum = 0.0;
            this.Average = 0.0;
            this.High = double.MinValue;
            this.Low = double.MaxValue;
        }
    }
}