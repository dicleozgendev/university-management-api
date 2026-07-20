namespace University.Business.DTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        public int StudentCount { get; set; }
        public int TeacherCount { get; set; }
    }

    public class CreateDepartmentDto
    {
        public string Name { get; set; }
        public string Faculty { get; set; }
    }
}
