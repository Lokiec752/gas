using Gas.Api.Dto.GasMeterReading;

namespace Gas.Api.Dto;

public record class InvoiceRegistrationDto
(
  CreateInvoiceDto Invoice,
  GasMeterReadingDto Reading
);
