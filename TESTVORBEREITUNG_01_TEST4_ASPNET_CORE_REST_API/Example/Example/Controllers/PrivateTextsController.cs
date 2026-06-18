using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Example;
using Example.Models;

namespace Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivateTextsController : ControllerBase
    {
        private readonly ExampleDbContext _context;
        private readonly EncodingService _encodingService;

        public PrivateTextsController(ExampleDbContext context, EncodingService encodingService)
        {
            _context = context;
            _encodingService = encodingService;
        }

        // GET: api/PrivateTexts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrivateText>>> GetPrivateText()
        {
            return await _context.PrivateText.ToListAsync();
        }

        // GET: api/PrivateTexts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrivateText>> GetPrivateText(int id)
        {
            var privateText = await _context.PrivateText.FindAsync(id);

            if (privateText == null)
            {
                return NotFound();
            }

            return privateText;
        }

        [HttpGet("MaxLen")]
        public ActionResult<PrivateText> GetPrivateTextMaxLen()
        {
            PrivateText maxLenText = null;
            var PrivateTexts = _context.PrivateText.ToList();
            foreach (var privateText in PrivateTexts)
            {
                if(maxLenText == null || maxLenText.text.Length < privateText.text.Length)
                {
                    maxLenText = privateText;
                }
            }
            return Ok(maxLenText);
        }


        // POST: api/PrivateTexts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PrivateText>> PostPrivateText(PrivateText privateText)
        {
            privateText.text = _encodingService.ToAscii(privateText.text);
            _context.PrivateText.Add(privateText);
            await _context.SaveChangesAsync();

            return Ok();
        }

        

    }
}
