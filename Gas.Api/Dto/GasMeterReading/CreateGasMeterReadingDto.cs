namespace Gas.Api.Dto.GasMeterReading;

public record class CreateGasMeterReadingDto
(
  int PrimaryReading,
  int SecondaryReading,
  DateOnly Date
);

