using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.SB1.Objects
{
    public class InventoryCountings
    {
        [Key]
        public int DocumentEntry { get; set; }
        public int DocumentNumber { get; set; }
        public int Series { get; set; }
        public string CountDate { get; set; }
        public string CountTime { get; set; }
        public string SingleCounterType { get; set; } = "ctUser";
        public int SingleCounterID { get; set; }
        public string DocumentStatus { get; set; }
        public string Remarks { get; set; }
        public string Reference2 { get; set; }
        public string BranchID { get; set; }
        public string DocstringCodeEx { get; set; }
        public int FinancialPeriod { get; set; }
        public string PeriodIndicator { get; set; }
        public string CountingType { get; set; } = "ctSingleCounter";
        public string U_RBH_Assinatura { get; set; }
        public string[] TeamCounters { get; set; }
        public string[] IndividualCounters { get; set; }
        public List<Inventorycountingline> InventoryCountingLines { get; set; }

        public InventoryCountings()
        {
            InventoryCountingLines = new List<Inventorycountingline>();
        }
    }

    public class Inventorycountingline
    {
        public int DocumentEntry { get; set; }
        public int LineNumber { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string Freeze { get; set; }
        public string WarehouseCode { get; set; }
        public string BinEntry { get; set; }
        public decimal? InWarehouseQuantity { get; set; }
        public string Counted { get; set; } = "tYES";
        public string UoMCode { get; set; }
        public string BarCode { get; set; }
        public string UoMCountedQuantity { get; set; }
        public string ItemsPerUnit { get; set; }
        public decimal? CountedQuantity { get; set; }
        public decimal? Variance { get; set; }
        public decimal? VariancePercentage { get; set; }
        public int VisualOrder { get; set; }
        public string TargetEntry { get; set; }
        public string TargetLine { get; set; }
        public int TargetType { get; set; }
        public string TargetReference { get; set; }
        public string ProjectCode { get; set; }
        public int Manufacturer { get; set; }
        public string SupplierCatalogNo { get; set; }
        public string PreferredVendor { get; set; }
        public string CostingCode { get; set; }
        public string CostingCode2 { get; set; }
        public string CostingCode3 { get; set; }
        public string CostingCode4 { get; set; }
        public string CostingCode5 { get; set; }
        public string Remarks { get; set; }
        public string LineStatus { get; set; }
        public string CounterType { get; set; }
        public int CounterID { get; set; }
        public string MultipleCounterRole { get; set; }
        public string[] InventoryCountingLineUoMs { get; set; }
        public string[] InventoryCountingSerialNumbers { get; set; }
        public List<Inventorycountingbatchnumber> InventoryCountingBatchNumbers { get; set; }

        public Inventorycountingline()
        {
            InventoryCountingBatchNumbers = new List<Inventorycountingbatchnumber>();
        }
    }

    public class Inventorycountingbatchnumber
    {
        public string BatchNumber { get; set; }
        public string ManufacturerSerialNumber { get; set; }
        public string InternalSerialNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string ManufactureDate { get; set; }
        public string AddmisionDate { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public decimal Quantity { get; set; }
        public int BaseLineNumber { get; set; }
        public int DocumentEntry { get; set; }
        public string CounterType { get; set; }
        public int CounterID { get; set; }
        public string MultipleCounterRole { get; set; }
        public string TrackingNote { get; set; }
        public string TrackingNoteLine { get; set; }
        public string ItemCode { get; set; }
        public int SystemSerialNumber { get; set; }
    }


}
