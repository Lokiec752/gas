using Gas.Api.Dto.UserBill;
using Gas.Api.Entity;

namespace Gas.Api.Mapping;

public static class UserBillMapping
{
  public static UserBillDto toDto(this UserBill bill)
  {
    return new UserBillDto(
      bill.Id,
      bill.UserId,
      bill.InvoiceId,
      bill.PreviousReadingId,
      bill.CurrentReadingId,
      bill.TotalAmount
    );
  }

  public static UserBill toEntity(this CreateUserBillDto bill)
  {
    return new UserBill()
    {
      UserId = bill.UserId,
      InvoiceId = bill.InvoiceId,
      PreviousReadingId = bill.PreviousReadingId,
      CurrentReadingId = bill.CurrentReadingId,
      TotalAmount = bill.TotalAmount
    };
  }

  public static UserBill toEntity(this UpdateUserBillDto bill)
  {
    return new UserBill()
    {
      UserId = bill.UserId,
      InvoiceId = bill.InvoiceId,
      PreviousReadingId = bill.PreviousReadingId,
      CurrentReadingId = bill.CurrentReadingId,
      TotalAmount = bill.TotalAmount
    };
  }
}
