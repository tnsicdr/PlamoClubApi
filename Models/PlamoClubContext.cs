using Microsoft.EntityFrameworkCore;

namespace PlamoClubApi.Models;

public class PlamoClubContext : DbContext
{
  public PlamoClubContext(DbContextOptions<PlamoClubContext> options) : base(options) { }
  public DbSet<Producer> Producers { get; set; } = null!;
  public DbSet<ModelKit> ModelKits { get; set; } = null!;
}