using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SleepTrackerAPI.Data;
using SleepTrackerAPI.Model;

namespace SleepTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SleepDatasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SleepDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SleepDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SleepData>>> GetSleepDatas()
        {
          if (_context.SleepDatas == null)
          {
              return NotFound();
          }
            return await _context.SleepDatas.ToListAsync();
        }

        // GET: api/SleepDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SleepData>> GetSleepData(int id)
        {
          if (_context.SleepDatas == null)
          {
              return NotFound();
          }
            var sleepData = await _context.SleepDatas.FindAsync(id);

            if (sleepData == null)
            {
                return NotFound();
            }

            return sleepData;
        }

        // PUT: api/SleepDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSleepData(int id, SleepData sleepData)
        {
            if (id != sleepData.Id)
            {
                return BadRequest();
            }

            _context.Entry(sleepData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SleepDataExists(id))
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

        // POST: api/SleepDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SleepData>> PostSleepData(SleepData sleepData)
        {
          if (_context.SleepDatas == null)
          {
              return Problem("Entity set 'ApplicationDbContext.SleepDatas'  is null.");
          }
            _context.SleepDatas.Add(sleepData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSleepData", new { id = sleepData.Id }, sleepData);
        }

        // DELETE: api/SleepDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSleepData(int id)
        {
            if (_context.SleepDatas == null)
            {
                return NotFound();
            }
            var sleepData = await _context.SleepDatas.FindAsync(id);
            if (sleepData == null)
            {
                return NotFound();
            }

            _context.SleepDatas.Remove(sleepData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SleepDataExists(int id)
        {
            return (_context.SleepDatas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
