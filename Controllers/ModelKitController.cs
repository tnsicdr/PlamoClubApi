using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlamoClubApi.Models;

namespace PlamoClubApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ModelKitsController : ControllerBase
  {
    private readonly PlamoClubContext _context;

    public ModelKitsController(PlamoClubContext context)
    {
      _context = context;
    }

    // GET: api/modelkits
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ModelKit>>> GetModelKits()
    {
      if (_context.ModelKits == null)
      {
        return NotFound();
      }

      return await _context.ModelKits.ToListAsync();
    }
  }
}