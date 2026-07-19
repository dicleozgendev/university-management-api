using System.Collections.Generic;

namespace University.Entity
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}