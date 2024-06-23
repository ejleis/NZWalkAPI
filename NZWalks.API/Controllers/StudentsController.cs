using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{

    // https:/localhost:<port number>/api/students
    // [controller] will take the name of the controller or class name minus the "controller" word which is students since it's StudentsController
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET: https:/localhost:<port number>/api/students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "Elijah", "Angela", "Barky", "Bitoy", "Chikabebe" };

            return Ok(studentNames);
        }
    }
}
