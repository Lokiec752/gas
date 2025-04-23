namespace Gas.Api.Dto.GasMeterReading;

public record class GasMeterReadingDto
(
  int Id,
  int PrimaryReading,
  int SecondaryReading,
  DateOnly Date
);
