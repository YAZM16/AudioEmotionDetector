using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AudioEmotionApp.Models; // Anpassa till din namespace
using AudioEmotionApp.Data;   // Anpassa till din namespace

namespace AudioEmotionApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AudioRecordsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AudioRecordsController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ GET: api/AudioRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AudioRecord>>> GetAll()
        {
            return await _context.AudioRecords.ToListAsync();
        }

        // ✅ GET: api/AudioRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AudioRecord>> GetById(int id)
        {
            var record = await _context.AudioRecords.FindAsync(id);
            if (record == null) return NotFound();
            return record;
        }

        // ✅ POST: api/AudioRecords
        [HttpPost]
        public async Task<ActionResult<AudioRecord>> Create(AudioRecord record)
        {
            _context.AudioRecords.Add(record);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = record.Id }, record);
        }

        // ✅ PUT: api/AudioRecords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AudioRecord updated)
        {
            if (id != updated.Id) return BadRequest();

            _context.Entry(updated).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.AudioRecords.Any(r => r.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // ✅ DELETE: api/AudioRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _context.AudioRecords.FindAsync(id);
            if (record == null) return NotFound();

            _context.AudioRecords.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
