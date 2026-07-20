using Microsoft.AspNetCore.Mvc;
using University.Business.Abstract;
using University.Business.DTOs;

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
            return Ok(_studentService.GetAllStudents());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _studentService.GetStudentById(id);
            return student == null ? NotFound() : Ok(student);
        }

        [HttpPost]
        public IActionResult Create(CreateStudentDto dto)
        {
            var created = _studentService.CreateStudent(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateStudentDto dto)
        {
            var updated = _studentService.UpdateStudent(id, dto);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _studentService.DeleteStudent(id) ? NoContent() : NotFound();
        }
    }
}
