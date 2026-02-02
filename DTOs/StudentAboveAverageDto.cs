using Students.Models;

namespace Students.DTOs
{
    public class StudentsAboveAverageDto
    {
        public List<string> StudentList{ get; set; } 
        public string SubjectName {  get; set; } = string.Empty;
        public double AverageGrade { get; set; }
    }
}
