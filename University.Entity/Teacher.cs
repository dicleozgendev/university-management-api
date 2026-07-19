using System.Collections.Generic;

namespace University.Entity
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}