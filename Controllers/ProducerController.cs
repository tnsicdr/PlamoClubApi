using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlamoClubApi.Models;

namespace PlamoClubApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProducersController : ControllerBase
  {
    private readonly PlamoClubContext _context;

    public ProducersController(PlamoClubContext context)
    {
      _context = context;
    }

    // GET: api/manufacturers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Producer>>> GetProducers()
    {
      if (_context.ModelKits == null)
      {
        return NotFound();
      }

      return await _context.Producers.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Producer>> GetProducer(Guid id)
    {
      if (_context.Producers == null)
      {
        return NotFound();
      }

      var producer = await _context.Producers.FindAsync(id);

      if (producer == null)
      {
        return NotFound();
      }

      return producer;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProducer(Guid id, Producer producer)
    {
      if (id != producer.Id)
      {
        return BadRequest();
      }

      _context.Entry(producer).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ProducerExists(id))
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

    [HttpPost]
    public async Task<ActionResult<Producer>> PostProducer(Producer producer)
    {
      if (_context.Producers == null)
      {
        return Problem("Entity set 'PlamoClubContext.Producers' is null.");
      }
      _context.Producers.Add(producer);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(GetProducer), new { id = producer.Id }, producer);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProducer(Guid id)
    {
      if (_context.Producers == null)
      {
        return NotFound();
      }

      var producer = await _context.Producers.FindAsync(id);

      if (producer == null)
      {
        return NotFound();
      }

      var hasModelKits = await _context.ModelKits.AnyAsync(modelKit => modelKit.ProducerId == id);

      if (!hasModelKits)
      {
        _context.Producers.Remove(producer);
        await _context.SaveChangesAsync();
      }
      else
      {
        return BadRequest();
      }

      return NoContent();
    }

    private bool ProducerExists(Guid id)
    {
      return (_context.Producers?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}