using Microsoft.AspNetCore.Mvc;
using Student_Management_No_Sql.Entities.Entities;
using Student_Management_No_Sql.Services.Interfaces;

namespace Student_Management_No_Sql.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [Route("gets")]
        public async Task<IActionResult> GetsAsync() 
        {
            var courses = await _courseService.GetsAsync();
            return Ok(courses);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> Get(string id)
        {
            var course = await _courseService.FindByIdAsync(id);

            if (course is null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Course newCourse)
        {
            await _courseService.CreateAsync(newCourse);

            return CreatedAtAction(nameof(Get), new { id = newCourse.Id }, newCourse);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Course updatedCourse)
        {
            await _courseService.UpdateAsync(updatedCourse);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _courseService.RemoveAsync(id);
            return NoContent();
        }
    }
}
