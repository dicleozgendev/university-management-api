using Microsoft.AspNetCore.Mvc;
using University.Business.Abstract;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _studentService.GetAllStudents();
            return Ok(result);
        }
    }
}