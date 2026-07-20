using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using University.Business.Abstract;
using University.Business.DTOs;
using University.DataAccess;
using University.Entity;

namespace University.Business.Concrete
{
    public class TeacherManager : ITeacherService
    {
        private readonly AppDbContext _context;

        public TeacherManager(AppDbContext context)
        {
            _context = context;
        }

        public List<TeacherDto> GetAllTeachers()
        {
            return _context.Teachers
                .Include(t => t.Department)
                .ToList()
                .Select(ToDto)
                .ToList();
        }

        public TeacherDto GetTeacherById(int id)
        {
            var teacher = _context.Teachers
                .Include(t => t.Department)
                .FirstOrDefault(t => t.Id == id);

            return teacher == null ? null : ToDto(teacher);
        }

        public TeacherDto CreateTeacher(CreateTeacherDto dto)
        {
            var teacher = new Teacher
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Title = dto.Title,
                DepartmentId = dto.DepartmentId
            };

            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return GetTeacherById(teacher.Id);
        }

        public TeacherDto UpdateTeacher(int id, CreateTeacherDto dto)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher == null) return null;

            teacher.Name = dto.Name;
            teacher.LastName = dto.LastName;
            teacher.Title = dto.Title;
            teacher.DepartmentId = dto.DepartmentId;
            _context.SaveChanges();

            return GetTeacherById(id);
        }

        public bool DeleteTeacher(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher == null) return false;

            _context.Teachers.Remove(teacher);
            _context.SaveChanges();
            return true;
        }

        private static TeacherDto ToDto(Teacher t)
        {
            return new TeacherDto
            {
                Id = t.Id,
                FullName = t.Name + " " + t.LastName,
                Title = t.Title,
                DepartmentName = t.Department != null ? t.Department.Name : null
            };
        }
    }
}
