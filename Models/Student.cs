using System.Linq;

namespace Students.Models
{
    public class Student
    {
        public string Name { get; set; } = string.Empty;
        public List<SubjectGrade> GradesBySubject { get; set; } = new();
        public double Attendance { get; set; }

        public double CalculateAverageGrade()
        {
            return GradesBySubject.Any() ? GradesBySubject.Average(n => n.Grade) : 0;
        }

    }

}

