using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.SB1.Objects
{
    public class InventoryTransferRequests
    {
        [Key]
        public int DocEntry { get; set; }
        public int Series { get; set; }
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
        public string FromWarehouse { get; set; }
        public string ToWarehouse { get; set; }
        public string CreationDate { get; set; }
        public string UpdateDate { get; set; }
         public int DocNum { get; set; }
        public string TaxDate { get; set; }
        public int BPLID { get; set; }
        public string BPLName { get; set; }
        public List<StockTransferLine> StockTransferLines { get; set; }
        public List<DocumentReference> DocumentReferences { get; set; }

        public InventoryTransferRequests()
        {
            StockTransferLines = new List<StockTransferLine>();
            DocumentReferences = new List<DocumentReference>();
        }
    }
    public class StockTransferLine
    {
        public int LineNum { get; set; }
        public int DocEntry { get; set; }
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
        public string BaseLine { get; set; }
        public string BaseEntry { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UoMEntry { get; set; }
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
