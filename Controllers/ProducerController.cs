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
  }
}