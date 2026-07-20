using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            return _context.Students
                .Include(s => s.Department)
                .ToList()
                .Select(ToDto)
                .ToList();
        }

        public StudentDto GetStudentById(int id)
        {
            var student = _context.Students
                .Include(s => s.Department)
                .FirstOrDefault(s => s.Id == id);

            return student == null ? null : ToDto(student);
        }

        public StudentDto CreateStudent(CreateStudentDto dto)
        {
            var student = new Student
            {
                Name = dto.Name,
                LastName = dto.LastName,
                StudentNumber = dto.StudentNumber,
                DepartmentId = dto.DepartmentId
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return GetStudentById(student.Id);
        }

        public StudentDto UpdateStudent(int id, CreateStudentDto dto)
        {
            var student = _context.Students.Find(id);
            if (student == null) return null;

            student.Name = dto.Name;
            student.LastName = dto.LastName;
            student.StudentNumber = dto.StudentNumber;
            student.DepartmentId = dto.DepartmentId;
            _context.SaveChanges();

            return GetStudentById(id);
        }

        public bool DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null) return false;

            _context.Students.Remove(student);
            _context.SaveChanges();
            return true;
        }

        private static StudentDto ToDto(Student s)
        {
            return new StudentDto
            {
                Id = s.Id,
                FullName = s.Name + " " + s.LastName,
                StudentNumber = s.StudentNumber,
                DepartmentName = s.Department != null ? s.Department.Name : null
            };
        }
    }
}
