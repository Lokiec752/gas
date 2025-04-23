namespace Gas.Api.Dto.UserBill;

public record class UserBillDto
(
  int Id,
  int UserId,
  int InvoiceId,
  int? PreviousReadingId,
  int? CurrentReadingId,
  float TotalAmount
);
