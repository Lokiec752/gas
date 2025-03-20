namespace Gas.Api.Dto.UserBill;

public record class CreateUserBillDto
(
  int UserId,
  int InvoiceId,
  int PreviousReadingId,
  int CurrentReadingId,
  float TotalAmount
);
