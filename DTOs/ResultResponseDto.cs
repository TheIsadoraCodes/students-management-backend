namespace Students.DTOs
{
    public class ResultResponseDto
    {
        public List<StudentAverageResponseDto> StudentAverages { get; set; } = new();
        public List<ClassAverageDto> ClassAverageBySubject { get; set; } = new();
        public List<StudentsAboveAverageDto> StudentsAboveClassAverage { get; set; } = new();
        public List<StudentLowAttendanceDto> StudentsWithLowAttendance { get; set; } = new();
    }
}

