using System.Collections.Generic;
using System.Linq;
using University.Business.Abstract;
using University.Business.DTOs;
using University.DataAccess;
using University.Entity;

namespace University.Business.Concrete
{
    public class StudentManager : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentManager(AppDbContext context)
        {
            _context = context;
        }

        public List<StudentDto> GetAllStudents()
        {
            return _context.Students.Select(s => new StudentDto
            {
                Id = s.Id,
                FullName = s.Name + " " + s.LastName,
                StudentNumber = s.StudentNumber
            }).ToList();
        }
    }
}