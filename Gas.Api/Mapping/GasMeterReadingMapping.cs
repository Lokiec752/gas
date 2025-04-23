using Gas.Api.Dto.GasMeterReading;
using Gas.Api.Entity;

namespace Gas.Api.Mapping;

public static class GasMeterReadingMapping
{
  public static GasMeterReadingDto ToDto(this GasMeterReading reading)
  {
    return new GasMeterReadingDto
    (
      reading.Id,
      reading.PrimaryReading,
      reading.SecondaryReading,
      reading.Date
    );
  }

  public static GasMeterReading ToEntity(this GasMeterReadingDto reading)
  {
    return new GasMeterReading()
    {
      PrimaryReading = reading.PrimaryReading,
      SecondaryReading = reading.SecondaryReading,
      Date = reading.Date,
    };
  }
  public static GasMeterReading ToEntity(this CreateGasMeterReadingDto reading)
  {
    return new GasMeterReading()
    {
      PrimaryReading = reading.PrimaryReading,
      SecondaryReading = reading.SecondaryReading,
      Date = reading.Date,
    };
  }

  public static GasMeterReading ToEntity(this UpdateGasMeterReadingDto reading, int id)
  {
    return new GasMeterReading()
    {
      Id = id,
      PrimaryReading = reading.PrimaryReading,
      SecondaryReading = reading.SecondaryReading,
      Date = reading.Date,
    };
  }

}
