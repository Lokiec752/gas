using Gas.Api.Entity;
using Gas.Api.Mapping;

namespace Gas.Api.Services;

public class BillingService
{
  public UserBillResult CreateUserBill
  (
    Invoice invoice,
    GasMeterReading currentReading,
    GasMeterReading previousReading,
    int primaryUserId,
    int secondaryUserId
  )
  {
    float primaryConsumption = currentReading.PrimaryReading - previousReading.PrimaryReading;
    float secondaryConsumption = currentReading.SecondaryReading - previousReading.SecondaryReading;

    float secondaryConsumptionProportion = secondaryConsumption / primaryConsumption;

    float secondaryVariableDistribution = secondaryConsumptionProportion * invoice.VariableDistribution.ToGross();
    float secondaryFees = (invoice.Subscription.ToGross() + invoice.ConstDistribution.ToGross()) / 2;

    float secondaryAllFees = secondaryVariableDistribution + secondaryFees;

    float secondaryGasCost = invoice.GasAmount.ToGross() * secondaryConsumptionProportion;

    float secondaryTotalAmount = secondaryAllFees + secondaryGasCost;

    float primaryTotalAmount = invoice.GasAmount.ToGross() + invoice.Subscription.ToGross() + invoice.VariableDistribution.ToGross() + invoice.ConstDistribution.ToGross() - secondaryTotalAmount;


    UserBill primaryBill = new UserBill()
    {
      UserId = primaryUserId,
      InvoiceId = invoice.Id,
      PreviousReadingId = previousReading.Id,
      CurrentReadingId = currentReading.Id,
      TotalAmount = primaryTotalAmount
    };

    UserBill secondaryBill = new UserBill()
    {
      UserId = secondaryUserId,
      InvoiceId = invoice.Id,
      PreviousReadingId = previousReading.Id,
      CurrentReadingId = currentReading.Id,
      TotalAmount = secondaryTotalAmount,
    };

    return new UserBillResult(primaryBill, secondaryBill);
  }

  public float CalculateBillAmount()
  {
    return 0;
  }
}
