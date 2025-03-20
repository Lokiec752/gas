using Gas.Api.Dto.GasMeterReading;
using Gas.Api.Entity;

namespace Gas.Api.Mapping;

public static class GasMeterReadingMapping
{
  public static GasMeterReadingDto toDto(GasMeterReading reading)
  {
    return new GasMeterReadingDto(
      Id: reading.Id,
      Reading: reading.Reading,
      UserId: reading.UserId,
      Date: reading.Date,
      Type: reading.Type
    );
  }

  public static GasMeterReading toEntity(CreateGasMeterReadingDto reading)
  {
    return new GasMeterReading()
    {
      Reading = reading.Reading,
      UserId = reading.UserId,
      Date = reading.Date,
      Type = reading.Type
    };
  }

  public static GasMeterReading toEntity(UpdateGasMeterReadingDto reading)
  {
    return new GasMeterReading()
    {
      Reading = reading.Reading,
      UserId = reading.UserId,
      Date = reading.Date,
      Type = reading.Type
    };
  }

}
