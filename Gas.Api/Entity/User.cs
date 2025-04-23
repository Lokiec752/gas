using Gas.Api.Enums;

namespace Gas.Api.Entity;

public class User
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public MeterReadingType MeterReadingType { get; set; }
}
