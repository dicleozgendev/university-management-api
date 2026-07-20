namespace University.Business.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string StudentNumber { get; set; }
        public string DepartmentName { get; set; }
    }

    public class CreateStudentDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string StudentNumber { get; set; }
        public int DepartmentId { get; set; }
    }
}
