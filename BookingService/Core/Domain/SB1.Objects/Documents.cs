﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.SB1.Objects
{
    public class InventoryGenEntries : Documents
    {
        public InventoryGenEntries()
        {
            DocstringCode = "oInventoryGenEntry";
            DocumentLines = new List<DocumentLine>();
        }

        public List<DocumentLine> DocumentLines { get; set; }
    }
    public class InventoryGenExits : Documents
    {
        public InventoryGenExits()
        {
            DocstringCode = "oInventoryGenExit";
            DocumentLines = new List<DocumentLine>();
        }

        public List<DocumentLine> DocumentLines { get; set; }
    }
    public class Documents
    {
        [Key]
        public Nullable<int> DocEntry { get; set; }
        public Nullable<int> DocNum { get; set; }
        public string DocType { get; set; }
        public string DocstringCode { get; set; }
        public string HandWritten { get; set; }
        public string Printed { get; set; }
        public string DocDate { get; set; }
        public string DocDueDate { get; set; }
        public string TaxDate { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string Address { get; set; }
        public string NumAtCard { get; set; }
        public Nullable<double> DocTotal { get; set; }

        /// AbsoluteEntry in Attachments2
        public Nullable<int> AttachmentEntry { get; set; }
        public string DocCurrency { get; set; }
        public Nullable<double> DocRate { get; set; }
        public string Reference1 { get; set; }
        public string Reference2 { get; set; }
        public string Comments { get; set; }
        public string JournalMemo { get; set; }
        public Nullable<int> PaymentGroupCode { get; set; }
        public string DocTime { get; set; }
        public Nullable<int> SalesPersonCode { get; set; }
        public Nullable<int> TransportationCode { get; set; }
        public string Confirmed { get; set; }
        public Nullable<Int64> ImportFileNum { get; set; }
        public string SummeryType { get; set; }
        public Nullable<int> ContactPersonCode { get; set; }
        public string ShowSCN { get; set; }
        public Nullable<int> Series { get; set; }

        public string PartialSupply { get; set; }
        public string DocObjectCode { get; set; }
        public string ShipToCode { get; set; }
        public string Indicator { get; set; }
        public string FederalTaxID { get; set; }
        public Nullable<double> DiscountPercent { get; set; }
        public string PaymentReference { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public Nullable<int> FinancialPeriod { get; set; }
        public string TransNum { get; set; }
        public Nullable<double> VatSum { get; set; }
        public Nullable<double> VatSumSys { get; set; }
        public Nullable<double> VatSumFc { get; set; }
        public string NetProcedure { get; set; }
        public Nullable<double> DocTotalFc { get; set; }
        public Nullable<double> DocTotalSys { get; set; }
        public string Form1099 { get; set; }
        public string Box1099 { get; set; }
        public string RevisionPo { get; set; }
        public string RequriedDate { get; set; }
        public string CancelDate { get; set; }
        public string BlockDunning { get; set; }
        public string Submitted { get; set; }
        public Nullable<int> Segment { get; set; }
        public string PickStatus { get; set; }
        public string Pick { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentBlock { get; set; }
        public string PaymentBlockEntry { get; set; }
        public string CentralBankIndicator { get; set; }
        public string MaximumCashDiscount { get; set; }
        public string Reserve { get; set; }
        public string Project { get; set; }
        public string ExemptionValidityDateFrom { get; set; }
        public string ExemptionValidityDateTo { get; set; }
        public string WareHouseUpdateType { get; set; }
        public string Rounding { get; set; }
        public string ExternalCorrectedDocNum { get; set; }
        public string InternalCorrectedDocNum { get; set; }
        public string NextCorrectingDocument { get; set; }
        public string DeferredTax { get; set; }
        public string TaxExemptionLetterNum { get; set; }
        public Nullable<double> WTApplied { get; set; }
        public Nullable<double> WTAppliedFC { get; set; }
        public string BillOfExchangeReserved { get; set; }
        public string AgentCode { get; set; }
        public Nullable<double> WTAppliedSC { get; set; }
        public Nullable<double> TotalEqualizationTax { get; set; }
        public Nullable<double> TotalEqualizationTaxFC { get; set; }
        public Nullable<double> TotalEqualizationTaxSC { get; set; }
        public Nullable<int> NumberOfInstallments { get; set; }
        public string ApplyTaxOnFirstInstallment { get; set; }
        public Nullable<double> WTNonSubjectAmount { get; set; }
        public Nullable<double> WTNonSubjectAmountSC { get; set; }
        public Nullable<double> WTNonSubjectAmountFC { get; set; }
        public Nullable<double> WTExemptedAmount { get; set; }
        public Nullable<double> WTExemptedAmountSC { get; set; }
        public Nullable<double> WTExemptedAmountFC { get; set; }
        public Nullable<double> BaseAmount { get; set; }
        public Nullable<double> BaseAmountSC { get; set; }
        public Nullable<double> BaseAmountFC { get; set; }
        public Nullable<double> WTAmount { get; set; }
        public Nullable<double> WTAmountSC { get; set; }
        public Nullable<double> WTAmountFC { get; set; }
        public string VatDate { get; set; }
        public Nullable<int> DocumentsOwner { get; set; }
        public string FolioPrefixString { get; set; }
        public string FolioNumber { get; set; }
        public string DocumentSubType { get; set; }
        public string BPChannelCode { get; set; }
        public Nullable<int> BPChannelContact { get; set; }
        public string Address2 { get; set; }
        public string DocumentStatus { get; set; }
        public string PeriodIndicator { get; set; }
        public string PayToCode { get; set; }
        public string ManualNumber { get; set; }
        public string UseShpdGoodsAct { get; set; }
        public string IsPayToBank { get; set; }
        public string PayToBankCountry { get; set; }
        public string PayToBankCode { get; set; }
        public string PayToBankAccountNo { get; set; }
        public string PayToBankBranch { get; set; }
        public Nullable<int> BPL_IDAssignedToInvoice { get; set; }
        public Nullable<double> DownPayment { get; set; }
        public string ReserveInvoice { get; set; }
        public Nullable<int> LanguageCode { get; set; }
        public string TrackingNumber { get; set; }
        public string PickRemark { get; set; }
        public string ClosingDate { get; set; }
        public string SequenceCode { get; set; }
        public string SequenceSerial { get; set; }
        public string SeriesString { get; set; }
        public string SubSeriesString { get; set; }
        public string SequenceModel { get; set; }
        public string UseCorrectionVATGroup { get; set; }
        public Nullable<double> TotalDiscount { get; set; }
        public Nullable<double> DownPaymentAmount { get; set; }
        public Nullable<double> DownPaymentPercentage { get; set; }
        public string DownPaymentType { get; set; }
        public Nullable<double> DownPaymentAmountSC { get; set; }
        public Nullable<double> DownPaymentAmountFC { get; set; }
        public Nullable<double> VatPercent { get; set; }
        public Nullable<double> ServiceGrossProfitPercent { get; set; }
        public string OpeningRemarks { get; set; }
        public string ClosingRemarks { get; set; }
        public Nullable<double> RoundingDiffAmount { get; set; }
        public Nullable<double> RoundingDiffAmountFC { get; set; }
        public Nullable<double> RoundingDiffAmountSC { get; set; }
        public string Cancelled { get; set; }
        public string SignatureInputMessage { get; set; }
        public string SignatureDigest { get; set; }
        public string CertificationNumber { get; set; }
        public string PrivateKeyVersion { get; set; }
        public string ControlAccount { get; set; }
        public string InsuranceOperation347 { get; set; }
        public string ArchiveNonremovableSalesQuotation { get; set; }
        public string GTSChecker { get; set; }
        public string GTSPayee { get; set; }
        public Nullable<int> ExtMCDnth { get; set; }
        public Nullable<int> ExtraDays { get; set; }
        public Nullable<int> CashDiscountDateOffset { get; set; }
        public string StartFrom { get; set; }
        public string NTSApproved { get; set; }
        public string ETaxWebSite { get; set; }
        public string ETaxNumber { get; set; }
        public string NTSApprovedNumber { get; set; }
        public string EDocGenerationType { get; set; }
        public string EDocSeries { get; set; }
        public string EDocNum { get; set; }
        public string EDocExportFormat { get; set; }
        public string EDocStatus { get; set; }
        public string EDocErrorCode { get; set; }
        public string EDocErrorMessage { get; set; }
        public string DownPaymentStatus { get; set; }
        public string GroupSeries { get; set; }
        public string GroupNumber { get; set; }
        public string GroupHandWritten { get; set; }
        public string ReopenOriginalDocument { get; set; }
        public string ReopenManuallyClosedOrCanceledDocument { get; set; }
        public string CreateOnlineQuotation { get; set; }
        public string POSEquipmentNumber { get; set; }
        public string POSManufacturerSerialNumber { get; set; }
        public string POSCashierNumber { get; set; }
        public string ApplyCurrentVATRatesForDownPaymentsToDraw { get; set; }
        public string ClosingOption { get; set; }
        public string SpecifiedClosingDate { get; set; }
        public string OpenForLandedCosts { get; set; }
        public string AuthorizationStatus { get; set; }
        public Nullable<double> TotalDiscountFC { get; set; }
        public Nullable<double> TotalDiscountSC { get; set; }
        public string RelevantToGTS { get; set; }
        public string BPLName { get; set; }
        public string VATRegNum { get; set; }
        public string AnnualInvoiceDeclarationReference { get; set; }
        public string Supplier { get; set; }
        public string Releaser { get; set; }
        public string Receiver { get; set; }
        public string BlanketAgreementNumber { get; set; }
        public string IsAlteration { get; set; }
        public string CancelStatus { get; set; }
        public string AssetValueDate { get; set; }
        public string DocumentDelivery { get; set; }
        public string AuthorizationCode { get; set; }
        public string StartDeliveryDate { get; set; }
        public string StartDeliveryTime { get; set; }
        public string EndDeliveryDate { get; set; }
        public string EndDeliveryTime { get; set; }
        public string VehiclePlate { get; set; }
        public string ATDocumentType { get; set; }
        public string ElecCommStatus { get; set; }
        public string ElecCommMessage { get; set; }
        public string ReuseDocumentNum { get; set; }
        public string ReuseNotaFiscalNum { get; set; }
        public string PrintSEPADirect { get; set; }
        public string FiscalDocNum { get; set; }
        public string POSDailySummaryNo { get; set; }
        public string POSReceiptNo { get; set; }
        public string PointOfIssueCode { get; set; }
        public string Letter { get; set; }
        public string FolioNumberFrom { get; set; }
        public string FolioNumberTo { get; set; }
        public string InterimType { get; set; }
        public Nullable<int> RelatedType { get; set; }
        public string RelatedEntry { get; set; }
        public string SAPPassport { get; set; }
        public string DocumentTaxID { get; set; }
        public string DateOfReportingControlStatementVAT { get; set; }
        public string ReportingSectionControlStatementVAT { get; set; }
        public string ExcludeFromTaxReportControlStatementVAT { get; set; }
        public string POS_CashRegister { get; set; }
        public string UpdateTime { get; set; }
        public string PriceMode { get; set; }
        public string ShipFrom { get; set; }
        public string CommissionTrade { get; set; }
        public string CommissionTradeReturn { get; set; }
        public string UseBillToAddrToDetermineTax { get; set; }
        public string Cig { get; set; }
        public string Cup { get; set; }
        public string ReqType { get; set; }
        public string Requester { get; set; }

        
    }
    public class TaxExtension
    {
        public int? DocEntry { get; set; }
        public string TaxId0 { get; set; }
        public string TaxId1 { get; set; }
        public string TaxId2 { get; set; }
        public string TaxId3 { get; set; }
        public string TaxId4 { get; set; }
        public string TaxId5 { get; set; }
        public string TaxId6 { get; set; }
        public string TaxId7 { get; set; }
        public string TaxId8 { get; set; }
        public string TaxId9 { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string Incoterms { get; set; }
        public string Vehicle { get; set; }
        public string VehicleState { get; set; }
        public string NFRef { get; set; }
        public string Carrier { get; set; }
        public string PackQuantity { get; set; }
        public string PackDescription { get; set; }
        public string Brand { get; set; }
        public string ShipUnitNo { get; set; }
        public Nullable<double> NetWeight { get; set; }
        public Nullable<double> GrossWeight { get; set; }
        public string StreetS { get; set; }
        public string BlockS { get; set; }
        public string BuildingS { get; set; }
        public string CityS { get; set; }
        public string ZipCodeS { get; set; }
        public string CountyS { get; set; }
        public string StateS { get; set; }
        public string CountryS { get; set; }
        public string StreetB { get; set; }
        public string BlockB { get; set; }
        public string BuildingB { get; set; }
        public string CityB { get; set; }
        public string ZipCodeB { get; set; }
        public string CountyB { get; set; }
        public string StateB { get; set; }
        public string CountryB { get; set; }
        public string ImportOrExport { get; set; }
        public Nullable<int> MainUsage { get; set; }
        public string GlobalLocationNumberS { get; set; }
        public string GlobalLocationNumberB { get; set; }
        public string TaxId12 { get; set; }
        public string TaxId13 { get; set; }
        public string BillOfEntryNo { get; set; }
        public string BillOfEntryDate { get; set; }
        public string OriginalBillOfEntryNo { get; set; }
        public string OriginalBillOfEntryDate { get; set; }
        public string ImportOrExportType { get; set; }
        public string PortCode { get; set; }
    }
    public class AddressExtension
    {
        public int? DocEntry { get; set; }
        public string ShipToStreet { get; set; }
        public string ShipToStreetNo { get; set; }
        public string ShipToBlock { get; set; }
        public string ShipToBuilding { get; set; }
        public string ShipToCity { get; set; }
        public string ShipToZipCode { get; set; }
        public string ShipToCounty { get; set; }
        public string ShipToState { get; set; }
        public string ShipToCountry { get; set; }
        public string ShipToAddressType { get; set; }
        public string BillToStreet { get; set; }
        public string BillToStreetNo { get; set; }
        public string BillToBlock { get; set; }
        public string BillToBuilding { get; set; }
        public string BillToCity { get; set; }
        public string BillToZipCode { get; set; }
        public string BillToCounty { get; set; }
        public string BillToState { get; set; }
        public string BillToCountry { get; set; }
        public string BillToAddressType { get; set; }
        public string ShipToGlobalLocationNumber { get; set; }
        public string BillToGlobalLocationNumber { get; set; }
        public string ShipToAddress2 { get; set; }
        public string ShipToAddress3 { get; set; }
        public string BillToAddress2 { get; set; }
        public string BillToAddress3 { get; set; }
        public string PlaceOfSupply { get; set; }
        public string PurchasePlaceOfSupply { get; set; }

    }
    public class DocumentLine
    {
        public int? DocEntry { get; set; }
        public int? LineNum { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public Nullable<double> Quantity { get; set; }
        public string ShipDate { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> PriceAfterVAT { get; set; }
        public string PriceSource { get; set; }// = "dpsManual";
        public string Currency { get; set; }
        public Nullable<double> Rate { get; set; }
        public Nullable<double> DiscountPercent { get; set; }
        public string VendorNum { get; set; }
        public string SerialNum { get; set; }
        public string WarehouseCode { get; set; }
        public Nullable<int> SalesPersonCode { get; set; }
        public Nullable<double> CommisionPercent { get; set; }
        public string TreeType { get; set; }
        public string AccountCode { get; set; }
        public string UseBaseUnits { get; set; }
        public string SupplierCatNum { get; set; }
        public string CostingCode { get; set; }
        public string ProjectCode { get; set; }
        public string BarCode { get; set; }
        public string VatGroup { get; set; }
        public Nullable<double> Height1 { get; set; }
        public string Hight1Unit { get; set; }
        public Nullable<double> Height2 { get; set; }
        public string Height2Unit { get; set; }
        public Nullable<double> Lengh1 { get; set; }
        public string Lengh1Unit { get; set; }
        public Nullable<double> Lengh2 { get; set; }
        public string Lengh2Unit { get; set; }
        public Nullable<double> Weight1 { get; set; }
        public string Weight1Unit { get; set; }
        public Nullable<double> Weight2 { get; set; }
        public string Weight2Unit { get; set; }
        public Nullable<double> Factor1 { get; set; }
        public Nullable<double> Factor2 { get; set; }
        public Nullable<double> Factor3 { get; set; }
        public Nullable<double> Factor4 { get; set; }
        public string BaseType { get; set; }
        public Nullable<int> BaseEntry { get; set; }
        public Nullable<int> BaseLine { get; set; }
        public Nullable<double> Volume { get; set; }
        public Nullable<int> VolumeUnit { get; set; }
        public Nullable<double> Width1 { get; set; }
        public string Width1Unit { get; set; }
        public Nullable<double> Width2 { get; set; }
        public string Width2Unit { get; set; }
        public string Address { get; set; }
        public string TaxCode { get; set; }
        public string TaxType { get; set; }
        public string TaxLiable { get; set; }
        public string PickStatus { get; set; }
        public Nullable<double> PickQuantity { get; set; }
        public string PickListIdNumber { get; set; }
        public string OriginalItem { get; set; }
        public string BackOrder { get; set; }
        public string FreeText { get; set; }
        public Nullable<int> ShippingMethod { get; set; }
        public string POTargetNum { get; set; }
        public string POTargetEntry { get; set; }
        public string POTargetRowNum { get; set; }
        public string CorrectionInvoiceItem { get; set; }
        public Nullable<double> CorrInvAmountToStock { get; set; }
        public Nullable<double> CorrInvAmountToDiffAcct { get; set; }
        public Nullable<double> AppliedTax { get; set; }
        public Nullable<double> AppliedTaxFC { get; set; }
        public Nullable<double> AppliedTaxSC { get; set; }
        public string WTLiable { get; set; }
        public string DeferredTax { get; set; }
        public Nullable<double> EqualizationTaxPercent { get; set; }
        public Nullable<double> TotalEqualizationTax { get; set; }
        public Nullable<double> TotalEqualizationTaxFC { get; set; }
        public Nullable<double> TotalEqualizationTaxSC { get; set; }
        public Nullable<double> NetTaxAmount { get; set; }
        public Nullable<double> NetTaxAmountFC { get; set; }
        public Nullable<double> NetTaxAmountSC { get; set; }
        public string MeasureUnit { get; set; }
        public Nullable<double> UnitsOfMeasurment { get; set; }
        public Nullable<double> LineTotal { get; set; }
        public Nullable<double> TaxPercentagePerRow { get; set; }
        public Nullable<double> TaxTotal { get; set; }
        public string ConsumerSalesForecast { get; set; }
        public Nullable<double> ExciseAmount { get; set; }
        public Nullable<double> TaxPerUnit { get; set; }
        public Nullable<double> TotalInclTax { get; set; }
        public string CountryOrg { get; set; }
        public string SWW { get; set; }
        public string TransactionType { get; set; }
        public string DistributeExpense { get; set; }
        public Nullable<double> RowTotalFC { get; set; }
        public Nullable<double> RowTotalSC { get; set; }
        public Nullable<double> LastBuyInmPrice { get; set; }
        public Nullable<double> LastBuyDistributeSumFc { get; set; }
        public Nullable<double> LastBuyDistributeSumSc { get; set; }
        public Nullable<double> LastBuyDistributeSum { get; set; }
        public Nullable<double> StockDistributesumForeign { get; set; }
        public Nullable<double> StockDistributesumSystem { get; set; }
        public Nullable<double> StockDistributesum { get; set; }
        public Nullable<double> StockInmPrice { get; set; }
        public string PickStatusEx { get; set; }
        public Nullable<double> TaxBeforeDPM { get; set; }
        public Nullable<double> TaxBeforeDPMFC { get; set; }
        public Nullable<double> TaxBeforeDPMSC { get; set; }
        public string CFOPCode { get; set; }
        public string CSTCode { get; set; }
        public Nullable<int> Usage { get; set; }
        public string TaxOnly { get; set; }
        public Nullable<int> VisualOrder { get; set; }
        public Nullable<double> BaseOpenQuantity { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public string LineStatus { get; set; }
        public Nullable<double> PackageQuantity { get; set; }
        public string Text { get; set; }
        public string LineType { get; set; }
        public string COGSCostingCode { get; set; }
        public string COGSAccountCode { get; set; }
        public string ChangeAssemlyBoMWarehouse { get; set; }
        public Nullable<double> GrossBuyPrice { get; set; }
        public Nullable<int> GrossBase { get; set; }
        public Nullable<double> GrossProfitTotalBasePrice { get; set; }
        public string CostingCode2 { get; set; }
        public string CostingCode3 { get; set; }
        public string CostingCode4 { get; set; }
        public string CostingCode5 { get; set; }
        public string ItemDetails { get; set; }
        public string LocationCode { get; set; }
        public string ActualDeliveryDate { get; set; }
        public Nullable<double> RemainingOpenQuantity { get; set; }
        public Nullable<double> OpenAmount { get; set; }
        public Nullable<double> OpenAmountFC { get; set; }
        public Nullable<double> OpenAmountSC { get; set; }
        public string ExLineNo { get; set; }
        public string RequiredDate { get; set; }
        public Nullable<double> RequiredQuantity { get; set; }
        public string COGSCostingCode2 { get; set; }
        public string COGSCostingCode3 { get; set; }
        public string COGSCostingCode4 { get; set; }
        public string COGSCostingCode5 { get; set; }
        public string CSTforIPI { get; set; }
        public string CSTforPIS { get; set; }
        public string CSTforCOFINS { get; set; }
        public string CreditOriginCode { get; set; }
        public string WithoutInventoryMovement { get; set; }
        public string AgreementNo { get; set; }
        public string AgreementRowNumber { get; set; }
        public string ActualBaseEntry { get; set; }
        public string ActualBaseLine { get; set; }

        public Nullable<double> Surpluses { get; set; }
        public Nullable<double> DefectAndBreakup { get; set; }
        public Nullable<double> Shortages { get; set; }
        public string ConsiderQuantity { get; set; }
        public string PartialRetirement { get; set; }
        public Nullable<double> RetirementQuantity { get; set; }
        public Nullable<double> RetirementAPC { get; set; }
        public string ThirdParty { get; set; }
        public string ExpenseType { get; set; }
        public string ReceiptNumber { get; set; }
        public string ExpenseOperationType { get; set; }
        public string FederalTaxID { get; set; }
        public string StgSeqNum { get; set; }
        public string StgEntry { get; set; }
        public string StgDesc { get; set; }
        public Nullable<int> UoMEntry { get; set; }
        public string UoMCode { get; set; }
        public Nullable<double> InventoryQuantity { get; set; }
        public Nullable<double> RemainingOpenInventoryQuantity { get; set; }
        public string ParentLineNum { get; set; }
        public Nullable<int> Incoterms { get; set; }
        public Nullable<int> TransportMode { get; set; }
        public string ItemType { get; set; }
        public string ChangeInventoryQuantityIndependently { get; set; }
        public string FreeOfChargeBP { get; set; }
        public string SACEntry { get; set; }
        public string HSNEntry { get; set; }
        public Nullable<double> GrossPrice { get; set; }
        public Nullable<double> GrossTotal { get; set; }
        public Nullable<double> GrossTotalFC { get; set; }
        public Nullable<double> GrossTotalSC { get; set; }
        public Nullable<int> NCMCode { get; set; }
        public string ShipToCode { get; set; }
        public string ShipToDescription { get; set; }
        public List<Serialnumber> SerialNumbers { get; set; }
        public List<Batchnumber> BatchNumbers { get; set; }
        public List<Documentlinesbinallocation> DocumentLinesBinAllocations { get; set; }
        //public BatchNumbers[] BatchNumbers { get; set; }
        //public string[] DocumentLinesBinAllocations { get; set; }
    }
    public class DocumentAdditionalExpens
    {
        public int? ExpenseCode { get; set; }
        public double LineTotal { get; set; }
        //public float LineTotalFC { get; set; }
        //public float LineTotalSys { get; set; }
        //public float PaidToDate { get; set; }
        //public float PaidToDateFC { get; set; }
        //public float PaidToDateSys { get; set; }
        //public object Remarks { get; set; }
        public string DistributionMethod { get; set; }
        //public string TaxLiable { get; set; }
        //public object VatGroup { get; set; }
        //public float TaxPercent { get; set; }
        //public float TaxSum { get; set; }
        //public float TaxSumFC { get; set; }
        //public float TaxSumSys { get; set; }
        //public float DeductibleTaxSum { get; set; }
        //public float DeductibleTaxSumFC { get; set; }
        //public float DeductibleTaxSumSys { get; set; }
        //public string AquisitionTax { get; set; }
        //public object TaxCode { get; set; }
        //public string TaxType { get; set; }
        //public float TaxPaid { get; set; }
        //public float TaxPaidFC { get; set; }
        //public float TaxPaidSys { get; set; }
        //public float EqualizationTaxPercent { get; set; }
        //public float EqualizationTaxSum { get; set; }
        //public float EqualizationTaxFC { get; set; }
        //public float EqualizationTaxSys { get; set; }
        //public float TaxTotalSum { get; set; }
        //public float TaxTotalSumFC { get; set; }
        //public float TaxTotalSumSys { get; set; }
        //public int BaseDocEntry { get; set; }
        //public int BaseDocLine { get; set; }
        //public int BaseDocType { get; set; }
        //public object BaseDocumentReference { get; set; }
        public int? LineNum { get; set; }
        //public string LastPurchasePrice { get; set; }
        public string Status { get; set; }
        //public string Stock { get; set; }
        //public int TargetAbsEntry { get; set; }
        //public object TargetType { get; set; }
        //public string WTLiable { get; set; }
        //public object DistributionRule { get; set; }
        //public object Project { get; set; }
        //public object DistributionRule2 { get; set; }
        //public object DistributionRule3 { get; set; }
        //public object DistributionRule4 { get; set; }
        //public object DistributionRule5 { get; set; }
        //public float LineGross { get; set; }
        //public float LineGrossSys { get; set; }
        //public float LineGrossFC { get; set; }
        //public object[] DocExpenseTaxJurisdictions { get; set; }
    }
    public class DocumentReference
    {
        public int? DocEntry { get; set; }
        public int? LineNumber { get; set; }
        public int? RefDocEntr { get; set; }
        public int? RefDocNum { get; set; }
        public string ExtDocNum { get; set; }
        public string RefObjType { get; set; }
        public string AccessKey { get; set; }
        public string IssueDate { get; set; }
        public string IssuerCNPJ { get; set; }
        public string IssuerCode { get; set; }
        public string Model { get; set; }
        public string Series { get; set; }
        public string Number { get; set; }
        public string RefAccKey { get; set; }
        public Nullable<double> RefAmount { get; set; }
        public string SubSeries { get; set; }
        public string Remark { get; set; }
        public string LinkRefTyp { get; set; }
    }
    public class Documentlinesbinallocation
    {
        public int? BinAbsEntry { get; set; }
        public double Quantity { get; set; }
        public string AllowNegativeQuantity { get; set; }
        public string BinActionType { get; set; }
        public int? SerialAndBatchNumbersBaseLine { get; set; }
        public int? BaseLineNumber { get; set; }
    }
    public class Downpaymentstodraw
    {
        public int? DocEntry { get; set; }
        public string PostingDate { get; set; }
        public string DueDate { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public double? AmountToDraw { get; set; }
        public string DownPaymentType { get; set; } = "dptInvoice";
        public string AmountToDrawFC { get; set; }
        public double? AmountToDrawSC { get; set; }
        public int? DocInternalID { get; set; }
        public int? RowNum { get; set; }
        public int? DocNumber { get; set; }
        public double? Tax { get; set; }
        public double? TaxFC { get; set; }
        public double? TaxSC { get; set; }
        public double? GrossAmountToDraw { get; set; }
        public double? GrossAmountToDrawFC { get; set; }
        public double? GrossAmountToDrawSC { get; set; }
        public string IsGrossLine { get; set; }
        public List<Downpaymentstodrawdetail> DownPaymentsToDrawDetails { get; set; }

        public Downpaymentstodraw()
        {
            DownPaymentsToDrawDetails = new List<Downpaymentstodrawdetail>();
        }
    }
    public class Downpaymentstodrawdetail
    {
        public int? DocInternalID { get; set; }
        public int? RowNum { get; set; }
        public int? SeqNum { get; set; }
        public int? DocEntry { get; set; }
        public string VatGroupCode { get; set; }
        public double VatPercent { get; set; }
        public double AmountToDraw { get; set; }
        public string AmountToDrawFC { get; set; }
        public double AmountToDrawSC { get; set; }
        public double Tax { get; set; }
        public string TaxFC { get; set; }
        public double TaxSC { get; set; }
        public string IsGrossLine { get; set; }
        public double GrossAmountToDraw { get; set; }
        public double GrossAmountToDrawFC { get; set; }
        public double GrossAmountToDrawSC { get; set; }
        public string LineType { get; set; }
        public string TaxAdjust { get; set; }
    }
    public class Documentinstallments
    {
        public string DueDate { get; set; }
        public double? Percentage { get; set; }
        public double? Total { get; set; }
        public string LastDunningDate { get; set; }
        public int? DunningLevel { get; set; }
        public double? TotalFC { get; set; }
        public int? InstallmentId { get; set; }
        public string PaymentOrdered { get; set; }
    }

}
