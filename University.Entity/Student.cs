using System.Collections.Generic;

namespace University.Entity
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string StudentNumber { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
    }
}