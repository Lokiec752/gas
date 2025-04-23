namespace Gas.Api.Dto.GasMeterReading;

public record class UpdateGasMeterReadingDto
(
  int PrimaryReading,
  int SecondaryReading,
  DateOnly Date
);
