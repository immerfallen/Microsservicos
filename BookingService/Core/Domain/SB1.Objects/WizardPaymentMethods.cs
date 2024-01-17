using System;

namespace Domain.SB1.Objects
{
  public class WizardPaymentMethods
  {
    public string PaymentMethodCode { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string PaymentMeans { get; set; }
    public string CheckAddress { get; set; }
    public string CheckBankDetails { get; set; }
    public string CollectionAuthorizationCheck { get; set; }
    public string BlockForeignPayment { get; set; }
    public string BlockForeignBank { get; set; }
    public string CurrencyRestriction { get; set; }
    public string PostOfficeBank { get; set; }
    public Nullable<decimal> MinimumAmount { get; set; }
    public Nullable<decimal> MaximumAmount { get; set; }
    public string DefaultBank { get; set; }
    public Nullable<int> UserSignature { get; set; }
    public string CreationDate { get; set; }
    public string BankCountry { get; set; }
    public string DefaultAccount { get; set; }
    public string GLAccount { get; set; }
    public string Branch { get; set; }
    public string KeyCode { get; set; }
    public string TransactionType { get; set; }
    public string Format { get; set; }
    public string AgentCollection { get; set; }
    public string SendforAcceptance { get; set; }
    public string GroupByDate { get; set; }
    public string DepositNorm { get; set; }
    public string DebitMemo { get; set; }
    public string GroupByPaymentReference { get; set; }
    public string GroupInvoicesbyPay { get; set; }
    public string DueDateSelection { get; set; }
    public string PaymentTermsCode { get; set; }
    public string PosttoGLInterimAccount { get; set; }
    public string BankAccountKey { get; set; }
    public string DocType { get; set; }
    public string Accepted { get; set; }
    public string PortfolioID { get; set; }
    public string CurCode { get; set; }
    public string Instruction1 { get; set; }
    public string Instruction2 { get; set; }
    public string PaymentPlace { get; set; }
    public string BarcodeDll { get; set; }
    public string Active { get; set; }
    public string GroupInvoicesByPayToBank { get; set; }
    public string GroupInvoicesByCurrency { get; set; }
    public Nullable<decimal> BankChargeRate { get; set; }
    public string ReportCode { get; set; }
    public string CancelInstruction { get; set; }
    public string OccurenceCode { get; set; }
    public string MovementCode { get; set; }
    public string DirectDebit { get; set; }
    //public string[] CurrencyRestrictions { get; set; }
  }
}
