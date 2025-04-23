using Gas.Api.Entity;
using Gas.Api.Enums;
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
    modelBuilder.Entity<User>()
      .Property(e => e.MeterReadingType)
      .HasConversion<string>();
    modelBuilder.Entity<User>().HasData(
      new { Id = 1, Name = "22E", MeterReadingType = MeterReadingType.Primary },
      new { Id = 2, Name = "22H", MeterReadingType = MeterReadingType.Secondary }
    );
    modelBuilder.Entity<GasMeterReading>();
    modelBuilder.Entity<GasMeterReading>().HasData(
      new { Id = 1, PrimaryReading = 0, SecondaryReading = 0, Date = new DateOnly(2024, 12, 1) },
      new { Id = 2, PrimaryReading = 299, SecondaryReading = 703, Date = new DateOnly(2025, 1, 1) }
    );
    modelBuilder.Entity<UserBill>();
  }
}
