using Gas.Api.Dto;
using Gas.Api.Entity;

namespace Gas.Api.Mapping;

public static class InvoiceMapping
{
  public static Invoice ToEntity(this CreateInvoiceDto invoice)
  {
    return new Invoice()
    {
      GasAmount = invoice.GasAmount,
      Subscription = invoice.Subscription,
      ConstDistribution = invoice.ConstDistribution,
      VariableDistribution = invoice.VariableDistribution,
      Date = invoice.Date,
    };
  }

    public static Invoice ToEntity(this UpdateInvoiceDto invoice, int id)
  {
    return new Invoice()
    {
      Id = id,
      GasAmount = invoice.GasAmount,
      Subscription = invoice.Subscription,
      ConstDistribution = invoice.ConstDistribution,
      VariableDistribution = invoice.VariableDistribution,
      Date = invoice.Date,
    };
  }

  public static InvoiceDto ToDto(this Invoice invoice)
  {
    return new InvoiceDto(
      invoice.Id,
      invoice.GasAmount,
      invoice.Subscription,
      invoice.ConstDistribution,
      invoice.VariableDistribution,
      invoice.Date
    );
  }


}
