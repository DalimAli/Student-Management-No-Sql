using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [Route("get")]
        public IActionResult Gets()
        {
            return Ok( new { Name = "Dalim"});// _studentService.GetType();
        }
    }
}
