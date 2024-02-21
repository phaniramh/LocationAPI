using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("{location}")]
        public IActionResult GetUser()
        {
            var filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "mydata", "Location.json");
            var jsonData = System.IO.File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(jsonData))
                return NotFound();

            var locations = JsonConvert.DeserializeObject<List<Location>>(jsonData);

            if (locations == null || locations.Count == 0)
                return NotFound();
            return Ok(locations);
        }

    }
}
