using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _28_Example;

namespace _28_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RechnungsController : ControllerBase
    {
        private readonly ExampleDbContext _context;
        private readonly RechenService _rechenService;

        public RechnungsController(ExampleDbContext context, RechenService rechenService)
        {
            _context = context;
            _rechenService = rechenService;
        }

        // GET: api/Rechnungs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rechnung>>> GetRechnungen()
        {
            return await _context.Rechnungen.ToListAsync();
        }

        // GET: api/Rechnungs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rechnung>> GetRechnung(int id)
        {
            var rechnung = await _context.Rechnungen.FindAsync(id);

            if (rechnung == null)
            {
                return NotFound();
            }

            return rechnung;
        }

        // PUT: api/Rechnungs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRechnung(int id, Rechnung rechnung)
        {
            if (id != rechnung.Id)
            {
                return BadRequest();
            }

            _context.Entry(rechnung).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RechnungExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Rechnungs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rechnung>> PostRechnung(Rechnung rechnung)
        {
            _context.Rechnungen.Add(rechnung);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRechnung", new { id = rechnung.Id }, rechnung);
        }

        [HttpPost("Berechnen")]
        public async Task<ActionResult<Rechnung>> PostRechnungBerechnen(Rechnung rechnung)
        {
            //RechenService r = new RechenService();
            //r.Berechnen(rechnung);
            _rechenService.Berechnen(rechnung);
            _context.Rechnungen.Add(rechnung);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetRechnung", new { id = rechnung.Id }, rechnung);
        }

        // DELETE: api/Rechnungs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRechnung(int id)
        {
            var rechnung = await _context.Rechnungen.FindAsync(id);
            if (rechnung == null)
            {
                return NotFound();
            }

            _context.Rechnungen.Remove(rechnung);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RechnungExists(int id)
        {
            return _context.Rechnungen.Any(e => e.Id == id);
        }
    }
}
