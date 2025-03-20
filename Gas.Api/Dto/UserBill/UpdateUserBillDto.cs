namespace Gas.Api.Dto.UserBill;

public record class UpdateUserBillDto
(
  int UserId,
  int InvoiceId,
  int PreviousReadingId,
  int CurrentReadingId,
  float TotalAmount
);
