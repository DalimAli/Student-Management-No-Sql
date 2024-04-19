using Microsoft.AspNetCore.Mvc;
using Student_Management_No_Sql.Cache;
using Student_Management_No_Sql.Entities.Entities;
using Student_Management_No_Sql.Services.Interfaces;

namespace Student_Management_No_Sql.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ICacheService _cacheService;

        public CourseController(ICourseService courseService, ICacheService cacheService)
        {
            _courseService = courseService;
            _cacheService = cacheService;
        }

        [HttpGet]
        [Route("gets")]
        public async Task<IActionResult> GetsAsync()
        {
            var cachedData = await _cacheService.GetCachedDataAsync<List<Course>>(nameof(Course).ToLower());

            if (cachedData != null)
                return Ok(cachedData);

            var courses = await _courseService.GetsAsync();

            await _cacheService.SetCachedDataAsync(nameof(Course).ToLower(), courses, new TimeSpan(0, 1, 0));
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
            await _cacheService.RemoveAsync(nameof(Course).ToLower());
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