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
    public class PassengersController : ControllerBase
    {
        private readonly NammametroContext _context = new NammametroContext();

        //public PassengersController(NammametroContext context)
        //{
        //    _context = context;
        //}


        [HttpGet]
        [Route("details")]
        public async Task<ActionResult<IEnumerable<VwCardDetail>>> GetDetail()
        {
            return await _context.VwCardDetails.ToListAsync();
        }


        [HttpGet]
        [Route("details/{id}")]
        public IActionResult GetDetail(long id)
        {

            var data = _context.VwCardDetails.Where(p => p.PhoneNo == id).Single();
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound("Sorry passenger with this number is not found");
        }
        // GET: api/Passengers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passenger>>> GetPassengers()
        {
            if (_context.Passengers == null)
            {
                return NotFound();
            }
            return await _context.Passengers.ToListAsync();
        }

        // GET: api/Passengers/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Passenger>> GetPassenger(long id)
        {
            if (_context.Passengers == null)
            {
                return NotFound();
            }
            var passenger = await _context.Passengers.FindAsync(id);

            if (passenger == null)
            {
                return NotFound();
            }

            return passenger;
        }


        // PUT: api/Passengers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassenger(long id, Passenger passenger)
        {
            if (id != passenger.PhoneNo)
            {
                return BadRequest();
            }

            _context.Entry(passenger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerExists(id))
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

        // POST: api/Passengers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passenger>> PostPassenger(Passenger passenger)
        {
            if (_context.Passengers == null)
            {
                return Problem("Entity set 'NammametroContext.Passengers'  is null.");
            }
            _context.Passengers.Add(passenger);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PassengerExists(passenger.PhoneNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPassenger", new { id = passenger.PhoneNo }, passenger);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterPassenger([FromBody] Passenger passenger)
        {
            if (_context.Passengers == null)
            {
                return Problem("Entity set 'NammametroContext.Passengers' is null.");
            }

            if (_context.Metrocards == null)
            {
                return Problem("Entity set 'NammametroContext.Metrocards' is null.");
            }

            // Add the passenger to the Passengers table
            _context.Passengers.Add(passenger);

            // Create a new Metrocard entry linked with the passenger's PhoneNo
            var metrocard = new Metrocard
            {
                PhoneNo = passenger.PhoneNo, // Assuming there's a method to generate a unique card number
                WalletBalance = 200
            };

            // Add the metrocard to the Metrocards table
            _context.Metrocards.Add(metrocard);

            try
            {
                await _context.SaveChangesAsync(); // Save changes for both Passenger and Metrocard
            }
            catch (DbUpdateException)
            {
                if (PassengerExists(passenger.PhoneNo))
                {
                    return Conflict(); // Handle case when the passenger already exists
                }
                else
                {
                    throw; // Rethrow exception if something else goes wrong
                }
            }

            // Return the created passenger and associated phone number in the response
            return CreatedAtAction("GetPassenger", new { id = passenger.PhoneNo }, passenger);
        }

        // Example of a method to generate a unique card number for the metrocard
        private string GenerateUniqueCardNumber()
        {
            return Guid.NewGuid().ToString(); // Example: using a GUID for simplicity
        }


        // DELETE: api/Passengers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassenger(long id)
        {
            if (_context.Passengers == null)
            {
                return NotFound();
            }
            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger == null)
            {
                return NotFound();
            }

            _context.Passengers.Remove(passenger);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassengerExists(long id)
        {
            return (_context.Passengers?.Any(e => e.PhoneNo == id)).GetValueOrDefault();
        }
    }
}
