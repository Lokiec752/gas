using Gas.Api.Constants;

namespace Gas.Api.Entity;

public class GasMeterReading
{
  public int Id { get; set; }
  public int Reading { get; set; }
  public int UserId { get; set; }
  public User? User { get; set; }
  public DateOnly Date { get; set; }
  public required MeterReadingTypes Type { get; set; }
}
