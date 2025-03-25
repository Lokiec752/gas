using Gas.Api.Enums;

namespace Gas.Api.Dto.GasMeterReading;

public record class UpdateGasMeterReadingDto
(
  int Reading,
  int UserId,
  DateOnly Date,
  MeterReadingType Type
);
