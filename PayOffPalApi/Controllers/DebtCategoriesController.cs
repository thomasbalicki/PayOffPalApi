using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayOffPalApi.Data;

namespace PayOffPalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtCategoriesController : ControllerBase
    {
        private readonly PayOffPalDbContext _context;

        public DebtCategoriesController(PayOffPalDbContext context)
        {
            _context = context;
        }

        // GET: api/DebtCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DebtCategory>>> GetDebtCategories()
        {
            var debtCategories = await _context.DebtCategories.ToListAsync();
            return Ok(debtCategories);
        }

        // GET: api/DebtCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DebtCategory>> GetDebtCategory(int id)
        {
            var debtCategory = await _context.DebtCategories.FindAsync(id);

            if (debtCategory == null)
            {
                return NotFound();
            }

            return Ok(debtCategory);
        }

        // PUT: api/DebtCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDebtCategory(int id, DebtCategory debtCategory)
        {
            if (id != debtCategory.DebtCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(debtCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DebtCategoryExists(id))
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

        // POST: api/DebtCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DebtCategory>> PostDebtCategory(DebtCategory debtCategory)
        {
            _context.DebtCategories.Add(debtCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDebtCategory", new { id = debtCategory.DebtCategoryId }, debtCategory);
        }

        // DELETE: api/DebtCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDebtCategory(int id)
        {
            var debtCategory = await _context.DebtCategories.FindAsync(id);
            if (debtCategory == null)
            {
                return NotFound();
            }

            _context.DebtCategories.Remove(debtCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DebtCategoryExists(int id)
        {
            return _context.DebtCategories.Any(e => e.DebtCategoryId == id);
        }
    }
}
