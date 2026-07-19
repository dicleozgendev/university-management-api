using System.Collections.Generic;
using University.Business.DTOs;

namespace University.Business.Abstract
{
    public interface IStudentService
    {
        List<StudentDto> GetAllStudents();
    }
}