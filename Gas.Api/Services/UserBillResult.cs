using Gas.Api.Entity;

namespace Gas.Api.Services;

public record class UserBillResult
(
  UserBill PrimaryBill,
  UserBill SecondaryBill
);
