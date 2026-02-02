using Microsoft.AspNetCore.Mvc.Formatters;
using Students.DTOs;
using Students.Models;

namespace Students.Services
{
    public class StudentService
    {
        public static List<Student> StudentsList = new List<Student>();
        
        public Student AddStudent(StudentRequestDto studentDto)
        {
            Student student = new Student();
            student.Name = studentDto.Name;
            student.GradesBySubject = studentDto.Grades;
            student.Attendance = studentDto.Attendance;

            StudentsList.Add(student);

            return student;

        }

        public ResultResponseDto GetGeneralData()
        {
            ResultResponseDto result = new ResultResponseDto();
            result.StudentsAboveClassAverage = GetStudentsAboveAverage();
            result.StudentsWithLowAttendance = GetStudentsWithLowAttendance();
            result.StudentAverages = GetStudentsWithAverages();
            result.ClassAverageBySubject = GetAverageBySubject();
            return result;
        }

        private List<StudentAverageResponseDto> GetStudentsWithAverages()
        {
            List<StudentAverageResponseDto> result = new List<StudentAverageResponseDto>();
            foreach (var student in StudentsList)
            {
                StudentAverageResponseDto item = new StudentAverageResponseDto() 
                { 
                    Attendance = student.Attendance, 
                    Name = student.Name, 
                    Average = student.CalculateAverageGrade() 
                };

                result.Add(item);
            }
            return result;
        }

        public List<StudentAverageResponseDto> GetAllStudents()
        {
            var returnList = new List<StudentAverageResponseDto>();

            foreach(var student in StudentsList)
            {
                var item = new StudentAverageResponseDto();

                item.Name = student.Name;
                item.Average = student.CalculateAverageGrade();
                item.Attendance = student.Attendance;

                returnList.Add(item);
            }
            
            return returnList;

        }

        public List<ClassAverageDto> GetAverageBySubject()
        {
            var result = StudentsList
                .SelectMany(static student => student.GradesBySubject) 
                .GroupBy(static grade => grade.SubjectName)                
                .Select(static group => new ClassAverageDto
                {
                    SubjectName = group.Key,
                    Average = group.Average(grade => grade.Grade)
                })
                .ToList();

            return result;
        }

        public List<StudentsAboveAverageDto> GetStudentsAboveAverage()
        {
            var result = new List<StudentsAboveAverageDto>();

            var averageBySubjectList = GetAverageBySubject();

            foreach (var subjectAverage in averageBySubjectList)
            {
                var subject = subjectAverage.SubjectName;
                var subjectAverageValue = subjectAverage.Average;

                var studentsAboveAverage = StudentsList
                    .Where(student =>
                        student.GradesBySubject.Any(n =>
                            n.SubjectName == subject &&
                            student.CalculateAverageGrade() > subjectAverageValue)).Select(e => e.Name)
                    .ToList();

                if (!studentsAboveAverage.Any())
                    continue;

                var item = new StudentsAboveAverageDto
                {
                    SubjectName = subject,
                    AverageGrade = subjectAverageValue,
                    StudentList = studentsAboveAverage
                };

                result.Add(item);
            }

            return result;
        }

        public List<StudentLowAttendanceDto> GetStudentsWithLowAttendance()
        {
            return StudentsList
                .Where(s => s.Attendance < 75)
                .Select(s => new StudentLowAttendanceDto
                {
                    StudentName = s.Name,
                    Attendance = s.Attendance
                })
                .ToList();
        }

    }

}
