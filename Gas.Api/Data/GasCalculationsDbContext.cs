using Gas.Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace Gas.Api.Data;

public class GasCalculationsDbContext(DbContextOptions<GasCalculationsDbContext> options) : DbContext(options)
{
  public DbSet<Invoice> Invoices => Set<Invoice>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Invoice>();
  }
}
