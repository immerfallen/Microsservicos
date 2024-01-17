using Domain.SB1.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.SB1.Objects
{
    public class StockTransfers
    {
        [Key]
        public int? DocEntry { get; set; }
        public int? Series { get; set; }
        public string Printed { get; set; }
        public string DocDate { get; set; }
        public string DueDate { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string Address { get; set; }
        public string Reference1 { get; set; }
        public string Reference2 { get; set; }
        public string Comments { get; set; }
        public string JournalMemo { get; set; }
        public int? PriceList { get; set; }
        public int? SalesPersonCode { get; set; }
        public string FromWarehouse { get; set; }
        public string ToWarehouse { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
        public int? FinancialPeriod { get; set; }
        public int? TransNum { get; set; }
        public int? DocNum { get; set; }
        public string TaxDate { get; set; }
        public int? ContactPerson { get; set; }
        public string FolioPrefixString { get; set; }
        public string FolioNumber { get; set; }
        public string DocstringCode { get; set; }
        public string AuthorizationStatus { get; set; }
        public int? BPLID { get; set; }
        public string BPLName { get; set; }
        public string VATRegNum { get; set; }
        public string AuthorizationCode { get; set; }
        public string StartDeliveryDate { get; set; }
        public string StartDeliveryTime { get; set; }
        public string EndDeliveryDate { get; set; }
        public string EndDeliveryTime { get; set; }
        public string VehiclePlate { get; set; }
        public string ATDocumentType { get; set; }
        public string EDocExportFormat { get; set; }
        public string ElecCommStatus { get; set; }
        public string ElecCommMessage { get; set; }
        public string PointOfIssueCode { get; set; }
        public string Letter { get; set; }
        public string FolioNumberFrom { get; set; }
        public string FolioNumberTo { get; set; }
        public string AttachmentEntry { get; set; }
        public string DocumentStatus { get; set; }
        public string ShipToCode { get; set; }
        public string SAPPassport { get; set; }
        public string[] StockTransfer_ApprovalRequests { get; set; }
        public string[] ElectronicProtocols { get; set; }
        public List<Stocktransferline> StockTransferLines { get; set; }
        public List<DocumentReference> DocumentReferences { get; set; }
        public Stocktransfertaxextension StockTransferTaxExtension { get; set; }

        public StockTransfers()
        {
            StockTransferLines = new List<Stocktransferline>();
            DocumentReferences = new List<DocumentReference>();
        }
    }
    public class Stocktransfertaxextension
    {
        public string SupportVAT { get; set; }
        public string FormNumber { get; set; }
        public string TransactionCategory { get; set; }
    }
    public class Stocktransferline
    {
        public int? LineNum { get; set; }
        public int? DocEntry { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public decimal Quantity { get; set; }
        public decimal? Price { get; set; }
        public string Currency { get; set; }
        public decimal? Rate { get; set; }
        public decimal? DiscountPercent { get; set; }
        public string VendorNum { get; set; }
        public string SerialNumber { get; set; }
        public string WarehouseCode { get; set; }
        public string FromWarehouseCode { get; set; }
        public string ProjectCode { get; set; }
        public decimal? Factor { get; set; }
        public decimal? Factor2 { get; set; }
        public decimal? Factor3 { get; set; }
        public decimal? Factor4 { get; set; }
        public string DistributionRule { get; set; }
        public string DistributionRule2 { get; set; }
        public string DistributionRule3 { get; set; }
        public string DistributionRule4 { get; set; }
        public string DistributionRule5 { get; set; }
        public string UseBaseUnits { get; set; }
        public string MeasureUnit { get; set; }
        public decimal? UnitsOfMeasurment { get; set; }
        public string BaseType { get; set; }
        public int? BaseLine { get; set; }
        public int? BaseEntry { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UoMEntry { get; set; }
        public string UoMCode { get; set; }
        public decimal? InventoryQuantity { get; set; }
        public decimal? RemainingOpenQuantity { get; set; }
        public decimal? RemainingOpenInventoryQuantity { get; set; }
        public string LineStatus { get; set; }
        public List<Serialnumber> SerialNumbers { get; set; }
        public List<Batchnumber> BatchNumbers { get; set; }
        public List<Documentlinesbinallocation> StockTransferLinesBinAllocations { get; set; }
    }

}
