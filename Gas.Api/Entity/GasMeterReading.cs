namespace Gas.Api.Entity;

// TODO: need to change this -> one record should contain primary and secondary reading
public class GasMeterReading
{
  public int Id { get; set; }
  public int PrimaryReading { get; set; }
  public int SecondaryReading { get; set; }
  public DateOnly Date { get; set; }
}
