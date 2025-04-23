namespace Gas.Api.Mapping;

public static class TaxCalculator
{
  private const float VAT_RATE = 1.23f;

  public static float ToGross(this float value) => value * VAT_RATE;
  public static float ToNet(this float value) => value / VAT_RATE;
}
