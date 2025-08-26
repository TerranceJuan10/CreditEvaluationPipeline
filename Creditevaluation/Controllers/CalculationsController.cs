using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Creditevaluation.Model;
using LibraryManagement.Data;

namespace Creditevaluation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CalculationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Calculations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calculation>>> GetCalcualations()
        {
            return await _context.Calcualations.ToListAsync();
        }

        // GET: api/Calculations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Calculation>> GetCalculation(int id)
        {
            var calculation = await _context.Calcualations.FindAsync(id);

            if (calculation == null)
            {
                return NotFound();
            }

            return calculation;
        }

        // PUT: api/Calculations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalculation(int id, Calculation calculation)
        {
            if (id != calculation.Id)
            {
                return BadRequest();
            }

            _context.Entry(calculation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalculationExists(id))
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

        // POST: api/Calculations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Calculation>> PostCalculation(Calculation calculation)
        {
            _context.Calcualations.Add(calculation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalculation", new { id = calculation.Id }, calculation);
        }

        // DELETE: api/Calculations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalculation(int id)
        {
            var calculation = await _context.Calcualations.FindAsync(id);
            if (calculation == null)
            {
                return NotFound();
            }

            _context.Calcualations.Remove(calculation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalculationExists(int id)
        {
            return _context.Calcualations.Any(e => e.Id == id);
        }
    }
}
