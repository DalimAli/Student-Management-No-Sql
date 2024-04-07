using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management_No_Sql.Entities.Entities;
using Student_Management_No_Sql.Services.Interfaces;

namespace Student_Management_No_Sql.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("gets")]
        public async Task<IActionResult> GetsAsync() 
        {
            var students = await _studentService.GetAsync();
            return Ok(students);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var student = await _studentService.GetAsync(id);

            if (student is null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student newStudent)
        {
            await _studentService.CreateAsync(newStudent);

            return CreatedAtAction(nameof(Get), new { id = newStudent.Id }, newStudent);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Student updatedStudent)
        {
            var student = await _studentService.GetAsync(id);

            if (student is null)
            {
                return NotFound();
            }

            updatedStudent.Id = student.Id;

            await _studentService.UpdateAsync(id, updatedStudent);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var student = await _studentService.GetAsync(id);

            if (student is null)
            {
                return NotFound();
            }

            await _studentService.RemoveAsync(id);

            return NoContent();
        }
    }
}
