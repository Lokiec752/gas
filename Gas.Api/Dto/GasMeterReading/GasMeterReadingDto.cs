using Gas.Api.Constants;

namespace Gas.Api.Dto.GasMeterReading;

public record class GasMeterReadingDto
(
  int Id,
  int Reading,
  int UserId,
  DateOnly Date,
  MeterReadingTypes Type
);
