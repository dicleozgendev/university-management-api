using Microsoft.AspNetCore.Mvc;
using University.Business.Abstract;
using University.Business.DTOs;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_teacherService.GetAllTeachers());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var teacher = _teacherService.GetTeacherById(id);
            return teacher == null ? NotFound() : Ok(teacher);
        }

        [HttpPost]
        public IActionResult Create(CreateTeacherDto dto)
        {
            var created = _teacherService.CreateTeacher(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateTeacherDto dto)
        {
            var updated = _teacherService.UpdateTeacher(id, dto);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _teacherService.DeleteTeacher(id) ? NoContent() : NotFound();
        }
    }
}
