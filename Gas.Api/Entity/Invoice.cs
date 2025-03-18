namespace Gas.Api.Entity;

public record class Invoice(
  int Id,
  float GasAmount,
  float Subscription,
  float ConstDistribution,
  float VariableDistribution,
  DateOnly Date
);
