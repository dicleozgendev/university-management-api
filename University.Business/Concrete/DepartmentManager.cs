using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using University.Business.Abstract;
using University.Business.DTOs;
using University.DataAccess;
using University.Entity;

namespace University.Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly AppDbContext _context;

        public DepartmentManager(AppDbContext context)
        {
            _context = context;
        }

        public List<DepartmentDto> GetAllDepartments()
        {
            return _context.Departments
                .Include(d => d.Students)
                .Include(d => d.Teachers)
                .ToList()
                .Select(ToDto)
                .ToList();
        }

        public DepartmentDto GetDepartmentById(int id)
        {
            var department = _context.Departments
                .Include(d => d.Students)
                .Include(d => d.Teachers)
                .FirstOrDefault(d => d.Id == id);

            return department == null ? null : ToDto(department);
        }

        public DepartmentDto CreateDepartment(CreateDepartmentDto dto)
        {
            var department = new Department
            {
                Name = dto.Name,
                Faculty = dto.Faculty
            };

            _context.Departments.Add(department);
            _context.SaveChanges();

            return GetDepartmentById(department.Id);
        }

        public DepartmentDto UpdateDepartment(int id, CreateDepartmentDto dto)
        {
            var department = _context.Departments.Find(id);
            if (department == null) return null;

            department.Name = dto.Name;
            department.Faculty = dto.Faculty;
            _context.SaveChanges();

            return GetDepartmentById(id);
        }

        public bool DeleteDepartment(int id)
        {
            var department = _context.Departments.Find(id);
            if (department == null) return false;

            _context.Departments.Remove(department);
            _context.SaveChanges();
            return true;
        }

        private static DepartmentDto ToDto(Department d)
        {
            return new DepartmentDto
            {
                Id = d.Id,
                Name = d.Name,
                Faculty = d.Faculty,
                StudentCount = d.Students != null ? d.Students.Count : 0,
                TeacherCount = d.Teachers != null ? d.Teachers.Count : 0
            };
        }
    }
}
