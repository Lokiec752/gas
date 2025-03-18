namespace Gas.Api.Dto;

public record class InvoiceDto(
  int Id,
  float GasAmount,
  float Subscription,
  float ConstDistribution,
  float VariableDistribution,
  DateOnly Date
);
