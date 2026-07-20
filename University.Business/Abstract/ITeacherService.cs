using System.Collections.Generic;
using University.Business.DTOs;

namespace University.Business.Abstract
{
    public interface ITeacherService
    {
        List<TeacherDto> GetAllTeachers();
        TeacherDto GetTeacherById(int id);
        TeacherDto CreateTeacher(CreateTeacherDto dto);
        TeacherDto UpdateTeacher(int id, CreateTeacherDto dto);
        bool DeleteTeacher(int id);
    }
}
