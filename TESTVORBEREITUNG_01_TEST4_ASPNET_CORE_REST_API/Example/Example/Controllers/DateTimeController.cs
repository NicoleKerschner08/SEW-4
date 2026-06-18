using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Example.Controllers
{

    // Endpoint /api/DateTime
    // --> liefert das aktuelle Datum (als JSON)
    [Route("api/[controller]")]
    [ApiController]
    public class DateTimeController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetDateTime()
        {
            string dateTime = DateTime.Now.ToString();
            return Ok(new { DateTime = dateTime });
        }
    }
}