using Microsoft.AspNetCore.Mvc;

namespace RestApiDestinations.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class DefinitionController : ControllerBase
        {
            [HttpGet]
            public IActionResult Get()
            {
                return new JsonResult(new
                {
                    destination = "Ein bestimmter Ort, der als Reiseziel fuer Erholung und Urlaub ausgewaehlt wird.",
                    example = "Mauritius"
                });
            }

        [HttpPost]
        public IActionResult Post()
        {
            return BadRequest("Post auf diesen Endpunkt nicht erlaubt!");
        }

    }
}
