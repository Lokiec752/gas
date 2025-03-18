using System.ComponentModel.DataAnnotations;

namespace Gas.Api.Dto;

public record class CreateInvoiceDto
(
  [Required] float GasAmount,
  [Required] float Subscription,
  [Required] float ConstDistribution,
  [Required] float VariableDistribution,
  [Required] DateOnly Date
);
