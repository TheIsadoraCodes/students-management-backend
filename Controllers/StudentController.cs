using Microsoft.AspNetCore.Mvc;
using Students.DTOs;
using Students.Models;
using Students.Services;

namespace Students.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentController(StudentService service)
        {
            _service = service;
        }


        [HttpPost("add")]
        public IActionResult Process([FromBody] StudentRequestDto student)
        {
            try
            {
                var result = _service.AddStudent(student);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            try
            {
                var result = _service.GetGeneralData();
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

