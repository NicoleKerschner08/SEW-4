using Microsoft.AspNetCore.Mvc;

namespace RestApiBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfoController : ControllerBase
    {
        private readonly CounterService _counterService;
        public InfoController(CounterService counterService)
        {
            _counterService = counterService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            _counterService.Increment();
            return new JsonResult(new
            {
                description = "A book is a collection of written, printed, or illustrated pages usually protected by a cover.",
                counter = _counterService.GetCounter()
            });
        }

        [HttpPost]
        public IActionResult Post()
        {
            return StatusCode(201);
        }
    }
}