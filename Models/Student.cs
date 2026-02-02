using System.Linq;

namespace Students.Models
{
    public class Student
    {
        public string Name { get; set; } = string.Empty;
        public List<SubjectGrade> NotasDisciplinas { get; set; } = new();
        public double Attendance { get; set; }

        public double CalculateAverageGrade()
        {
            return NotasDisciplinas.Any() ? NotasDisciplinas.Average(n => n.Grade) : 0;
        }

    }

}

