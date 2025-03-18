namespace Gas.Api.Entity;

public class Invoice
{
  public int Id { get; set; }
  public required float GasAmount { get; set; }
  public required float Subscription { get; set; }
  public required float ConstDistribution { get; set; }
  public required float VariableDistribution { get; set; }
  public required DateOnly Date { get; set; }
};
