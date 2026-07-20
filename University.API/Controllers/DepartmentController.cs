using Microsoft.AspNetCore.Mvc;
using University.Business.Abstract;
using University.Business.DTOs;

namespace University.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_departmentService.GetAllDepartments());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            return department == null ? NotFound() : Ok(department);
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmentDto dto)
        {
            var created = _departmentService.CreateDepartment(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CreateDepartmentDto dto)
        {
            var updated = _departmentService.UpdateDepartment(id, dto);
            return updated == null ? NotFound() : Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _departmentService.DeleteDepartment(id) ? NoContent() : NotFound();
        }
    }
}
