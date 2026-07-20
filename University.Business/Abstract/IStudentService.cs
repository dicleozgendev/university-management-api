using System.Collections.Generic;
using University.Business.DTOs;

namespace University.Business.Abstract
{
    public interface IStudentService
    {
        List<StudentDto> GetAllStudents();
        StudentDto GetStudentById(int id);
        StudentDto CreateStudent(CreateStudentDto dto);
        StudentDto UpdateStudent(int id, CreateStudentDto dto);
        bool DeleteStudent(int id);
    }
}
