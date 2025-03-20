using Gas.Api.Constants;

namespace Gas.Api.Dto.GasMeterReading;

public record class UpdateGasMeterReadingDto
(
  int Reading,
  int UserId,
  DateOnly Date,
  MeterReadingTypes Type
);
