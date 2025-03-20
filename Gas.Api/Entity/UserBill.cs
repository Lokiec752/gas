namespace Gas.Api.Entity;

public class UserBill
{
  public int Id { get; set; }
  public int UserId { get; set; }
  public User? User { get; set; }
  public int InvoiceId { get; set; }
  public Invoice? Invoice { get; set; }
  public int PreviousReadingId { get; set; }
  public GasMeterReading? PreviousReading { get; set; }
  public int CurrentReadingId { get; set; }
  public GasMeterReading? CurrentReading { get; set; }
  public float TotalAmount { get; set; }
}
