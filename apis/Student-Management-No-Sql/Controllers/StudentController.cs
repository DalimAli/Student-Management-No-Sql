using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Management_No_Sql.Cache;
using Student_Management_No_Sql.Entities.Entities;
using Student_Management_No_Sql.Services.Interfaces;

namespace Student_Management_No_Sql.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ICacheService _cacheService;
        public StudentController(IStudentService studentService, ICacheService cacheService)
        {
            _studentService = studentService;
            _cacheService = cacheService;
        }

        [HttpGet]
        [Route("gets")]
        public async Task<IActionResult> GetsAsync() 
        {
            var cachedData = await _cacheService.GetCachedDataAsync<List<Student>>(nameof(Student).ToLower());

            if (cachedData != null)
                return Ok(cachedData);

            var students = await _studentService.GetsAsync();

            await _cacheService.SetCachedDataAsync(nameof(Student).ToLower(), students, new TimeSpan(0, 1, 0));
            
            return Ok(students);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var student = await _studentService.FindByIdAsync(id);

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
            await _cacheService.RemoveAsync(nameof(Student).ToLower());
            return CreatedAtAction(nameof(Get), new { id = newStudent.Id }, newStudent);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Student updatedStudent)
        {
            await _studentService.UpdateAsync(updatedStudent);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _studentService.RemoveAsync(id);
            return NoContent();
        }
    }
}
