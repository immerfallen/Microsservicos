using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.SB1.Objects
{
    /// <summary>
    /// PaymentTermsTypes is a business object that represents the types of payment terms in the Banking module. The payment terms define typical agreements that apply to transactions with customers and vendors.
    //Source table: OCTG.
    /// </summary>
    public class PaymentTermsTypes
  {
    public Nullable<int> GroupNumber { get; set; }
    public string PaymentTermsGroupName { get; set; }
    public string StartFrom { get; set; }
    public Nullable<int> NumberOfAdditionalMonths { get; set; }
    public Nullable<int> NumberOfAdditionalDays { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public Nullable<decimal> CreditLimit { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public Nullable<decimal> GeneralDiscount { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public Nullable<decimal> InterestOnArrears { get; set; }
    public Nullable<int> PriceListNo { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public Nullable<decimal> LoadLimit { get; set; }
    public string OpenReceipt { get; set; }
    public string DiscountCode { get; set; }
    public string DunningCode { get; set; }
    public string BaselineDate { get; set; }
    public Nullable<int> NumberOfInstallments { get; set; }
    public string NumberOfToleranceDays { get; set; }
  }
}
