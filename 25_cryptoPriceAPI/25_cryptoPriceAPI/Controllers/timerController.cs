using Microsoft.AspNetCore.Mvc;

namespace _25_cryptoPriceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimerController : ControllerBase
    {
        private PriceGenerator _generator;
        private ILogger<TimerController> _logger;

        public TimerController(PriceGenerator generator, ILogger<TimerController> logger)
        {
            _generator = generator;
            _logger = logger;
        }

        [HttpPost("Start")]
        public IActionResult Start()
        {
            _generator.Start();
            _logger.LogInformation("Timer gestartet"); 
            return Ok("Timer läuft");
        }

        [HttpPost("Stop")]
        public IActionResult Stop()
        {
            _generator.Stop();
            _logger.LogInformation("Timer gestoppt"); 
            return Ok("Timer gestoppt");
        }
    }
}
