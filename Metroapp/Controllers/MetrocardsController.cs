using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Metroapp.Models;
using Microsoft.AspNetCore.Cors;

namespace Metroapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class MetrocardsController : ControllerBase
    {
        private readonly NammametroContext _context= new NammametroContext();

        //public MetrocardsController(NammametroContext context)
        //{
        //    _context = context;
        //}

        // GET: api/Metrocards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Metrocard>>> GetMetrocards()
        {
          if (_context.Metrocards == null)
          {
              return NotFound();
          }
            return await _context.Metrocards.ToListAsync();
        }

        // GET: api/Metrocards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Metrocard>> GetMetrocard(int id)
        {
          if (_context.Metrocards == null)
          {
              return NotFound();
          }
            var metrocard = await _context.Metrocards.FindAsync(id);

            if (metrocard == null)
            {
                return NotFound();
            }

            return metrocard;
        }

        // PUT: api/Metrocards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetrocard(int id, Metrocard metrocard)
        {
            if (id != metrocard.CardId)
            {
                return BadRequest();
            }

            _context.Entry(metrocard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetrocardExists(id))
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

        // POST: api/Metrocards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Metrocard>> PostMetrocard(Metrocard metrocard)
        {
          if (_context.Metrocards == null)
          {
              return Problem("Entity set 'NammametroContext.Metrocards'  is null.");
          }
            _context.Metrocards.Add(metrocard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMetrocard", new { id = metrocard.CardId }, metrocard);
        }

        // DELETE: api/Metrocards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetrocard(int id)
        {
            if (_context.Metrocards == null)
            {
                return NotFound();
            }
            var metrocard = await _context.Metrocards.FindAsync(id);
            if (metrocard == null)
            {
                return NotFound();
            }

            _context.Metrocards.Remove(metrocard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MetrocardExists(int id)
        {
            return (_context.Metrocards?.Any(e => e.CardId == id)).GetValueOrDefault();
        }
    }
}
