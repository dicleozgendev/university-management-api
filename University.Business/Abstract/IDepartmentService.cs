using System.Collections.Generic;
using University.Business.DTOs;

namespace University.Business.Abstract
{
    public interface IDepartmentService
    {
        List<DepartmentDto> GetAllDepartments();
        DepartmentDto GetDepartmentById(int id);
        DepartmentDto CreateDepartment(CreateDepartmentDto dto);
        DepartmentDto UpdateDepartment(int id, CreateDepartmentDto dto);
        bool DeleteDepartment(int id);
    }
}
