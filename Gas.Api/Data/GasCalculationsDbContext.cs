using Gas.Api.Entity;
using Microsoft.EntityFrameworkCore;

namespace Gas.Api.Data;

public class GasCalculationsDbContext(DbContextOptions<GasCalculationsDbContext> options) : DbContext(options)
{
  public DbSet<Invoice> Invoices => Set<Invoice>();
  public DbSet<User> Users => Set<User>();
  public DbSet<GasMeterReading> Readings => Set<GasMeterReading>();
  public DbSet<UserBill> UserBills => Set<UserBill>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Invoice>();
    modelBuilder.Entity<User>().HasData(
      new { Id = 1, Name = "22E" },
      new { Id = 2, Name = "22H" }
    );
    modelBuilder.Entity<GasMeterReading>()
      .Property(e => e.Type)
      .HasConversion<string>();
    modelBuilder.Entity<UserBill>();
  }
}
