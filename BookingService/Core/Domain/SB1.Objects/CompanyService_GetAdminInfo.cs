﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SB1.Objects
{
    public class CompanyService_GetAdminInfo
    {
        public string odatametadata { get; set; }
        public int Code { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string PrintingHeader { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string FaxNumber { get; set; }
        public string eMail { get; set; }
        public string ManagingDirector { get; set; }
        public string ChartofAccountsTemplate { get; set; }
        public string LocalCurrency { get; set; }
        public string SystemCurrency { get; set; }
        public string CreditBalancewithMinusSign { get; set; }
        public int StandardUnitofLength { get; set; }
        public int WeightUnitDefault { get; set; }
        public string DirectIndirectRate { get; set; }
        public float MinimumAmountfor347Report { get; set; }
        public string SetItemsWarehouses { get; set; }
        public string BankCountry { get; set; }
        public string FederalTaxID { get; set; }
        public string TaxOffice { get; set; }
        public string DeductionFileNo { get; set; }
        public string TaxCollection { get; set; }
        public string TaxDefinition { get; set; }
        public float TaxPercentage { get; set; }
        public float AdvancesonCorpIncomeTax { get; set; }
        public float WithTax { get; set; }
        public string WithholdingTaxVendorDdct { get; set; }
        public string CustomersDeductionatSource { get; set; }
        public float WithholdingTaxTdctPercnt { get; set; }
        public string WithholdingTaxDdctExpired { get; set; }
        public string WithholdingTaxDdctOffice { get; set; }
        public string CommitmentRestriction { get; set; }
        public string CreditRestriction { get; set; }
        public string RestrictSales { get; set; }
        public string RestrictDelNotesPO { get; set; }
        public string RestrictOrders { get; set; }
        public string ConsiderDelNotesinSalesR { get; set; }
        public string CreditDepositType { get; set; }
        public string UseTax { get; set; }
        public string SplitPO { get; set; }
        public string AltNameForApInvoice { get; set; }
        public string AltNameforCreditMemo { get; set; }
        public string AltNameForGoodsReceipt { get; set; }
        public string AltNameForGoodsReturn { get; set; }
        public string AltNameForPurchase { get; set; }
        public string AlertTypeforWHStock { get; set; }
        public string SetCommissionbyCustomer { get; set; }
        public string SetCommissionbyItem { get; set; }
        public string SetCommissionbySE { get; set; }
        public int DefaultCustomerPaymentTerms { get; set; }
        public int DefaultVendorPaymentTerms { get; set; }
        public string CalculateGrossProfitperTra { get; set; }
        public int PriceListforCostPrice { get; set; }
        public string GrossProfitAfterSale { get; set; }
        public string DisplayPriceforPriceOnly { get; set; }
        public string CalculateTaxinSalesQuotati { get; set; }
        public string BaseField { get; set; }
        public string AllowClosedSalesQuotations { get; set; }
        public string UserConversionCode { get; set; }
        public int CompanyColor { get; set; }
        public int TotalsAccuracy { get; set; }
        public int AccuracyofQuantities { get; set; }
        public int PriceAccuracy { get; set; }
        public int RateAccuracy { get; set; }
        public int PercentageAccuracy { get; set; }
        public int MeasuringAccuracy { get; set; }
        public int QueryAccuracy { get; set; }
        public string AddressinForeignLanguage { get; set; }
        public string DefaultTaxCode { get; set; }
        public string LetterHeaderinForeignLangu { get; set; }
        public string PhoneNumber1ForeignLang { get; set; }
        public string PhoneNumber2ForeignLang { get; set; }
        public string FaxNumberForeignLang { get; set; }
        public string ManagingDirectorForeignLan { get; set; }
        public string TimeTemplate { get; set; }
        public string DateTemplate { get; set; }
        public string DateSeparator { get; set; }
        public string FCCheckAccount { get; set; }
        public string ChangedExistingOrders { get; set; }
        public string MultiCurrencyCheck { get; set; }
        public int ISRType { get; set; }
        public string DisplayRoundingRemark { get; set; }
        public string ISRBillerID { get; set; }
        public string BlockSystemCurrencyEditing { get; set; }
        public string BlockPostingDateEditing { get; set; }
        public string DefaultWarehouse { get; set; }
        public string BlockTaxDate { get; set; }
        public string TaxDefinitionforVatitem { get; set; }
        public string TaxDefinitionforVatservice { get; set; }
        public string TaxGroupforPurchaseItem { get; set; }
        public string TaxGroupforServicePurchase { get; set; }
        public string CalculateBudget { get; set; }
        public string CustomerIdNumber { get; set; }
        public string BlockBudget { get; set; }
        public string BudgetAlert { get; set; }
        public string BlockPurchaseOrders { get; set; }
        public string BlockBookkeeping { get; set; }
        public int DefaultBudgetCostAssessMt { get; set; }
        public string ContinuousStockManagement { get; set; }
        public string ContinuousStockSystem { get; set; }
        public string RoundTaxAmounts { get; set; }
        public string BlockDelNotesforPurchase { get; set; }
        public string FileNumberinIncomeTax { get; set; }
        public string DeferredTax { get; set; }
        public string DefaultBankNo { get; set; }
        public string DefaultBankAccount { get; set; }
        public string DefaultBranch { get; set; }
        public string UsePASystem { get; set; }
        public string ServiceCode { get; set; }
        public string ServicePassword { get; set; }
        public string ParamFolderPath { get; set; }
        public string ExcelFolderPath { get; set; }
        public string FederalTaxID2 { get; set; }
        public string FederalTaxID3 { get; set; }
        public string DecimalSeparator { get; set; }
        public string ThousandsSeparator { get; set; }
        public string DisplayCurrencyontheRight { get; set; }
        public string AlertbyWarehouse { get; set; }
        public string PriceSystem { get; set; }
        public string WholdingTaxDedHierarchy { get; set; }
        public string DocConfirmation { get; set; }
        public string DefaultforBatchStatus { get; set; }
        public string GLMethod { get; set; }
        public string UniqueSerialNo { get; set; }
        public int MaxHistory { get; set; }
        public string ChangeDefReconAPAccounts { get; set; }
        public string ChangeDefReconARAccounts { get; set; }
        public string BPTypeCode { get; set; }
        public string PBSNumber { get; set; }
        public string PBSGroupNumber { get; set; }
        public string OrganizationNumber { get; set; }
        public string AccountSegmentsSeparator { get; set; }
        public string DisplayBookkeepingWindow { get; set; }
        public string SHandleWT { get; set; }
        public string SDefaultWTCode { get; set; }
        public string WithholdingTaxPHandle { get; set; }
        public string PDefaultWTCode { get; set; }
        public string WTLiableExpense { get; set; }
        public string UseNegativeAmounts { get; set; }
        public string HolidaysName { get; set; }
        public string OrderBlock { get; set; }
        public string RoundingMethod { get; set; }
        public string AdressFromWH { get; set; }
        public string OrderingParty { get; set; }
        public string CertificateNo { get; set; }
        public string ExpirationDate { get; set; }
        public string NationalInsuranceNo { get; set; }
        public string SalesOrderConfirmed { get; set; }
        public string PurchaseOrderConfirmed { get; set; }
        public string SDfltITWT { get; set; }
        public string PDfltITWT { get; set; }
        public string DefaultAccountCurrency { get; set; }
        public string DeferredTaxforVendors { get; set; }
        public string CreateAutoVATLineinJDT { get; set; }
        public string ConsumeForecast { get; set; }
        public string ConsumptionMethod { get; set; }
        public int DaysBackward { get; set; }
        public int DaysForward { get; set; }
        public string DefaultDunningTerm { get; set; }
        public string DefaultBankAccountKey { get; set; }
        public string MultiLanguageSupportEnable { get; set; }
        public string AllowFuturePostingDate { get; set; }
        public string AdditionalIdNumber { get; set; }
        public string State { get; set; }
        public string CalculateRowDiscount { get; set; }
        public string BankStatementInstalled { get; set; }
        public string UniqueTaxPayerReference { get; set; }
        public string EmployerReference { get; set; }
        public string PeriodStatusAutoChange { get; set; }
        public int PeriodStatusChangeDelay { get; set; }
        public float GrossProfitPercentForServiceDocuments { get; set; }
        public string XMLFileFolderPath { get; set; }
        public string PickList { get; set; }
        public string GeneralManager { get; set; }
        public string GeneralManagerForeignLanguage { get; set; }
        public string UseProductionProfitAndLossAccount { get; set; }
        public float WTAccumAmountAP { get; set; }
        public float WTAccumAmountAR { get; set; }
        public string CopyExchangeRateInCopyTo { get; set; }
        public string GTSOutboundFolder { get; set; }
        public string GTSInboundFolder { get; set; }
        public string GTSSeparateCode { get; set; }
        public string GTSDefaultChecker { get; set; }
        public string GTSDefaultPayee { get; set; }
        public float GTSMaxAmount { get; set; }
        public string GTSResponseToExceeding { get; set; }
        public string ApplicationOfIFRS { get; set; }
        public string StartingInFiscalYear { get; set; }
        public int ReportAccordingTo { get; set; }
        public string CopyOpenRowsToDelivery { get; set; }
        public string EnableApprovalProcedureInDI { get; set; }
        public string EnableUpdateDocAfterApproval { get; set; }
        public string EnableUpdateDraftDuringApproval { get; set; }
        public string EnableAuthorizerUpdatePendingDraft { get; set; }
        public string IssuePrimarilyBy { get; set; }
        public string IsRemoveUnpricedValue { get; set; }
        public string EnableAdvancedGLAccountDetermination { get; set; }
        public string CreateOnlineQuotation { get; set; }
        public string IsPrinterConnected { get; set; }
        public string EnableBranches { get; set; }
        public string IEMandatoryValidation { get; set; }
        public string EnablePaymentDueDates { get; set; }
        public int MaximumNumberOfDaysForDueDate { get; set; }
        public string AliasName { get; set; }
        public string EnableCentralizedIncomingPayments { get; set; }
        public string EnableCentralizedOutgoingPayments { get; set; }
        public string TaxRateDetermination { get; set; }
        public string BoletoFolderPath { get; set; }
        public string AllowMultipleBAOnSamePeriod { get; set; }
        public string BlockMultipleBAOnSameAPDocument { get; set; }
        public string BlockMultipleBAOnSameARDocument { get; set; }
        public string DisplayCancelDocInReport { get; set; }
        public int MaxDaysForCancel { get; set; }
        public string ReuseDocumentNum { get; set; }
        public string ReuseNotaFiscalNum { get; set; }
        public string AutoAddUoM { get; set; }
        public string AutoAddPackage { get; set; }
        public string DisplayInactivePriceListInReports { get; set; }
        public string DisplayInactivePriceListInDocuments { get; set; }
        public string DisplayInactivePriceListInSettings { get; set; }
        public string ApplyBaseInactiveStatusToSpecialPrices { get; set; }
        public string ApplyBaseInactiveStatusToPeriodVolumeDiscounts { get; set; }
        public string ApplyBaseInactiveStatusToPriceLists { get; set; }
        public string PriceProceedMethod { get; set; }
        public string RemoveUpdatePricesBasedOnNonStandardPriceLists { get; set; }
        public string SirenNo { get; set; }
        public string InstitutionCode { get; set; }
        public string SetResourcesWarehouses { get; set; }
        public string BlockStockNegativeQuantity { get; set; }
        public string UseParentWIPInComponents { get; set; }
        public string EnableUpdateBAPriceAndPlannedAmount { get; set; }
        public string AutoAssignOnlyValidAPBA { get; set; }
        public string AutoAssignOnlyValidARBA { get; set; }
        public string ActionWhenDeviateFromBAForPO { get; set; }
        public string ActionWhenDeviateFromBAForGRPO { get; set; }
        public string ActionWhenDeviateFromBAForAccounting { get; set; }
        public string Series { get; set; }
        public string Account { get; set; }
        public string EnableMultipleSchedulings { get; set; }
        public string DisplayBatchQtyUoMBy { get; set; }
        public string AllowInBoundPostingWithZeroPrice { get; set; }
        public float InventoryPostingHighlightVariance { get; set; }
        public string InventoryPostingReleaseOnlySerialAndBatch { get; set; }
        public float InventoryCountingHighlightVariance { get; set; }
        public float InventoryCountingHighlightMaxVariance { get; set; }
        public float InventoryCountingHighlightCountersDifference { get; set; }
        public string CopySingleCounterToIndividualCounter { get; set; }
        public string CloseCountedRowsWithZeroDifference { get; set; }
        public string CloseCountedRowsWithoutConfirmation { get; set; }
        public string CalculateInWhseQtyBasedOnPostingDate { get; set; }
        public string RefreshInWhseQtyInDI { get; set; }
        public string SEPACreditorID { get; set; }
        public string DataOwnershipManageBy { get; set; }
        public string AllowBPWithNoOwner { get; set; }
        public string EnableSeparatePriceMode { get; set; }
        public string EnableExternalTax { get; set; }
        public string NumberOfCharInMonth { get; set; }
        public Extendedadmininfo ExtendedAdminInfo { get; set; }
    }

    public class Extendedadmininfo
    {
        public string AddressType { get; set; }
        public string StreetNo { get; set; }
        public string STDCode { get; set; }
        public string STDCodeForeign { get; set; }
        public int NatureOfCompanyCode { get; set; }
        public int EconomicActivityTypeCode { get; set; }
        public string CreditContributionOriginCode { get; set; }
        public string IPIPeriodCode { get; set; }
        public int CooperativeAssociationTypeCode { get; set; }
        public int ProfitTaxationCode { get; set; }
        public int CompanyQualificationCode { get; set; }
        public int DeclarerTypeCode { get; set; }
        public string IPITaxContributor { get; set; }
        public string CommercialRegister { get; set; }
        public string DateOfIncorporation { get; set; }
        public string SPEDProfile { get; set; }
        public int EnvironmentType { get; set; }
        public string Opting4ICMS { get; set; }
        public string OKDPNumber { get; set; }
        public string GlobalLocationNumber { get; set; }
        public string EnableIntrastat { get; set; }
        public string AuthorityUser { get; set; }
        public string AuthorityPassword { get; set; }
        public string URLforGoodsTransportService { get; set; }
        public string URLforInvoiceTypeService { get; set; }
        public string ElectronicApprovalForGoodsTransEnabled { get; set; }
        public string ElectronicApprovalForInvoiceEnabled { get; set; }
        public string AllowInactiveItemsInInventoryOpeningBalance { get; set; }
        public string AllowInactiveItemsInInventoryCountingAndPosting { get; set; }
        public string AutoAssignNewBranchToBP { get; set; }
        public string DocumentRemarksInclude { get; set; }
    }

}