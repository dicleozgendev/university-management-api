namespace University.Business.DTOs
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string DepartmentName { get; set; }
    }

    public class CreateTeacherDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int DepartmentId { get; set; }
    }
}
