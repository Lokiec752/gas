using Gas.Api.Dto.GasMeterReading;
using Gas.Api.Entity;

namespace Gas.Api.Mapping;

public static class GasMeterReadingMapping
{
  public static GasMeterReadingDto toDto(this GasMeterReading reading)
  {
    return new GasMeterReadingDto(
      Id: reading.Id,
      Reading: reading.Reading,
      UserId: reading.UserId,
      Date: reading.Date,
      Type: reading.Type
    );
  }

  public static GasMeterReading toEntity(this CreateGasMeterReadingDto reading)
  {
    return new GasMeterReading()
    {
      Reading = reading.Reading,
      UserId = reading.UserId,
      Date = reading.Date,
      Type = reading.Type
    };
  }

  public static GasMeterReading toEntity(this UpdateGasMeterReadingDto reading, int id)
  {
    return new GasMeterReading()
    {
      Id = id,
      Reading = reading.Reading,
      UserId = reading.UserId,
      Date = reading.Date,
      Type = reading.Type
    };
  }

}
