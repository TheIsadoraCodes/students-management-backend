using Students.Models;

namespace Students.DTOs
{
    public class StudentRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public List<SubjectGrade> Grades { get; set; } = new();
        public double Attendance { get; set; }

    }

}

