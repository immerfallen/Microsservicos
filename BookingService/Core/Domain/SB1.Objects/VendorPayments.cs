using System.Collections.Generic;

namespace Domain.SB1.Objects
{

    public class VendorPayments
    {
        public int DocNum { get; set; }
        public string DocType { get; set; }
        public string HandWritten { get; set; }
        public string Printed { get; set; }
        public string DocDate { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string Address { get; set; }
        public string CashAccount { get; set; }
        public string DocCurrency { get; set; }
        public double CashSum { get; set; }
        public string CheckAccount { get; set; }
        public string TransferAccount { get; set; }
        public double TransferSum { get; set; }
        public string TransferDate { get; set; }
        public string TransferReference { get; set; }
        public string LocalCurrency { get; set; }
        public double DocRate { get; set; }
        public string Reference1 { get; set; }
        public string Reference2 { get; set; }
        public string CounterReference { get; set; }
        public string Remarks { get; set; }
        public string JournalRemarks { get; set; }
        public string SplitTransaction { get; set; }
        public int ContactPersonCode { get; set; }
        public string ApplyVAT { get; set; }
        public string TaxDate { get; set; }
        public int Series { get; set; }
        public string BankCode { get; set; }
        public string BankAccount { get; set; }
        public double DiscountPercent { get; set; }
        public string ProjectCode { get; set; }
        public string CurrencyIsLocal { get; set; }
        public double DeductionPercent { get; set; }
        public double DeductionSum { get; set; }
        public double CashSumFC { get; set; }
        public double CashSumSys { get; set; }
        public string BoeAccount { get; set; }
        public double BillOfExchangeAmount { get; set; }
        public string BillofExchangeStatus { get; set; }
        public double BillOfExchangeAmountFC { get; set; }
        public double BillOfExchangeAmountSC { get; set; }
        public string BillOfExchangeAgent { get; set; }
        public string WTCode { get; set; }
        public double WTAmount { get; set; }
        public double WTAmountFC { get; set; }
        public double WTAmountSC { get; set; }
        public string WTAccount { get; set; }
        public double WTTaxableAmount { get; set; }
        public string Proforma { get; set; }
        public string PayToBankCode { get; set; }
        public string PayToBankBranch { get; set; }
        public string PayToBankAccountNo { get; set; }
        public string PayToCode { get; set; }
        public string PayToBankCountry { get; set; }
        public string IsPayToBank { get; set; }
        public int DocEntry { get; set; }
        public string PaymentPriority { get; set; }
        public string TaxGroup { get; set; }
        public double BankChargeAmount { get; set; }
        public double BankChargeAmountInFC { get; set; }
        public double BankChargeAmountInSC { get; set; }
        public double UnderOverpaymentdifference { get; set; }
        public double UnderOverpaymentdiffSC { get; set; }
        public double WtBaseSum { get; set; }
        public double WtBaseSumFC { get; set; }
        public double WtBaseSumSC { get; set; }
        public string VatDate { get; set; }
        public string TransactionCode { get; set; }
        public string PaymentType { get; set; }
        public double TransferRealAmount { get; set; }
        public string DocObjectCode { get; set; } = "bopot_OutgoingPayments";
        public string DocTypte { get; set; } = "rSupplier";
        public string DueDate { get; set; }
        public string LocationCode { get; set; }
        public string Cancelled { get; set; }
        public string ControlAccount { get; set; }
        public double UnderOverpaymentdiffFC { get; set; }
        public string AuthorizationStatus { get; set; }
        public int BPLID { get; set; }
        public string BPLName { get; set; }
        public string VATRegNum { get; set; }
        public string BlanketAgreement { get; set; }
        public string PaymentByWTCertif { get; set; }
        public string Cig { get; set; }
        public string Cup { get; set; }
        public string AttachmentEntry { get; set; }
        public string SignatureInputMessage { get; set; }
        public string SignatureDigest { get; set; }
        public string CertificationNumber { get; set; }
        public string PrivateKeyVersion { get; set; }
        public List<Paymentinvoice> PaymentInvoices { get; set; }
        public List<Cashflowassignments> CashFlowAssignments { get; set; }
    }
    public class Billofexchange
    {
    }
    public class Cashflowassignments
    {
        public int CashFlowAssignmentsID { get; set; }
        public int CashFlowLineItemID { get; set; }
        public double Credit { get; set; }
        public string PaymentMeans { get; set; } = "pmtBankTransfer";
        public string CheckNumber { get; set; }
        public double AmountLC { get; set; }
        public double AmountFC { get; set; }
        public int JDTLineId { get; set; }
    }
    public class Paymentinvoice
    {
        public int LineNum { get; set; }
        public int DocEntry { get; set; }
        public int DocNum { get; set; }
        public double SumApplied { get; set; }
        public double AppliedFC { get; set; }
        public double AppliedSys { get; set; }
        public double DocRate { get; set; }
        public int DocLine { get; set; }
        public string InvoiceType { get; set; }
        public double DiscountPercent { get; set; }
        public double PaidSum { get; set; }
        public int InstallmentId { get; set; }
        public double WitholdingTaxApplied { get; set; }
        public double WitholdingTaxAppliedFC { get; set; }
        public double WitholdingTaxAppliedSC { get; set; }
        public string LinkDate { get; set; }
        public string DistributionRule { get; set; }
        public string DistributionRule2 { get; set; }
        public string DistributionRule3 { get; set; }
        public string DistributionRule4 { get; set; }
        public string DistributionRule5 { get; set; }
        public double TotalDiscount { get; set; }
        public double TotalDiscountFC { get; set; }
        public double TotalDiscountSC { get; set; }
    }


}
