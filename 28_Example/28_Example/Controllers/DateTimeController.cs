using Microsoft.AspNetCore.Mvc;
namespace _28_Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DateTimeController: ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetDateTime()
        {
            string date = DateTime.Now.ToString();
            return Ok(date);
        }
        
    }
}
