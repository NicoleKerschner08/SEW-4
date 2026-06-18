using System;
using Microsoft.AspNetCore.Mvc;
namespace Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToUpperCaseController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> PostToUpperCase(string input)
        {
            return new JsonResult(input.ToUpper());
        }
    }
}
