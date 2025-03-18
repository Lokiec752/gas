namespace Gas.Api.Dto;

public record class UpdateInvoiceDto
(
  float GasAmount,
  float Subscription,
  float ConstDistribution,
  float VariableDistribution,
  DateOnly Date
);
