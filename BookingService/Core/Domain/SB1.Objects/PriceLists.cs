
namespace Domain.SB1.Objects
{
    public class PriceLists
  {
    public string RoundingMethod { get; set; }
    public string GroupNum { get; set; }
    public int BasePriceList { get; set; }
    public float Factor { get; set; }
    public int PriceListNo { get; set; }
    public string PriceListName { get; set; }
    public string IsGrossPrice { get; set; }
    public string Active { get; set; }
    public string ValidFrom { get; set; }
    public string ValidTo { get; set; }
    public string DefaultPrimeCurrency { get; set; }
    public string DefaultAdditionalCurrency1 { get; set; }
    public string DefaultAdditionalCurrency2 { get; set; }
    public string RoundingRule { get; set; }
    public float FixedAmount { get; set; }
  }
}
