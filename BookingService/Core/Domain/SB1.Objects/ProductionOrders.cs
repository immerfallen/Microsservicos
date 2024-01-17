using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.SB1.Objects
{
    public class ProductionOrders
    {
        [Key]
        public int? AbsoluteEntry { get; set; }
        public int? DocumentNumber { get; set; }
        public int? Series { get; set; }
        public string ItemNo { get; set; }
        public string ProductionOrderStatus { get; set; }
        public string ProductionOrderType { get; set; }
        public decimal? PlannedQuantity { get; set; }
        public decimal? CompletedQuantity { get; set; }
        public decimal? RejectedQuantity { get; set; }
        public string PostingDate { get; set; }
        public string DueDate { get; set; }
        public int? ProductionOrderOriginEntry { get; set; }
        public int? ProductionOrderOriginNumber { get; set; }
        public string ProductionOrderOrigin { get; set; }
        public int? UserSignature { get; set; }
        public string Remarks { get; set; }

        public static void AsQueryable()
        {
            throw new NotImplementedException();
        }

        public string ClosingDate { get; set; }
        public string ReleaseDate { get; set; }
        public string CustomerCode { get; set; }
        public string Warehouse { get; set; }
        public string InventoryUOM { get; set; }
        public string JournalRemarks { get; set; }
        public string TransactionNumber { get; set; }
        public string CreationDate { get; set; }
        public string Printed { get; set; }
        public string DistributionRule { get; set; }
        public string Project { get; set; }
        public string DistributionRule2 { get; set; }
        public string DistributionRule3 { get; set; }
        public string DistributionRule4 { get; set; }
        public string DistributionRule5 { get; set; }
        public int? UoMEntry { get; set; }
        public string StartDate { get; set; }
        public string ProductDescription { get; set; }
        public int? Priority { get; set; }
        public string RoutingDateCalculation { get; set; }
        public string UpdateAllocation { get; set; }
        public string SAPPassport { get; set; }
        public string AttachmentEntry { get; set; }
        public List<Productionorderline> ProductionOrderLines { get; set; }
        public Productionorderssalesorderline[] ProductionOrdersSalesOrderLines { get; set; }
        public Productionordersstage[] ProductionOrdersStages { get; set; }
        public List<DocumentReference> ProductionOrdersDocumentReferences { get; set; }
        public ProductionOrders()
        {
            ProductionOrderLines = new List<Productionorderline>();
        }
    }

    public class Productionorderline
    {
        public int? DocumentAbsoluteEntry { get; set; }
        public int? LineNumber { get; set; }
        public string ItemNo { get; set; }
        public decimal? BaseQuantity { get; set; }
        public decimal? PlannedQuantity { get; set; }
        public decimal? IssuedQuantity { get; set; }
        public string ProductionOrderIssueType { get; set; }
        public string Warehouse { get; set; }
        public int? VisualOrder { get; set; }
        public string DistributionRule { get; set; }
        public string LocationCode { get; set; }
        public string Project { get; set; }
        public string DistributionRule2 { get; set; }
        public string DistributionRule3 { get; set; }
        public string DistributionRule4 { get; set; }
        public string DistributionRule5 { get; set; }
        public int? UoMEntry { get; set; }
        public int? UoMCode { get; set; }
        public string WipAccount { get; set; }
        public string ItemType { get; set; }
        public string LineText { get; set; }
        public decimal? AdditionalQuantity { get; set; }
        public string ResourceAllocation { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? StageID { get; set; }
        public decimal? RequiredDays { get; set; }
        public string ItemName { get; set; }
        public string[] SerialNumbers { get; set; }
        public List<Batchnumber> BatchNumbers { get; set; }
    }
    public class Productionorderssalesorderline
    {
        public int? DocEntry { get; set; }
        public int? BaseNumber { get; set; }
        public int? BaseAbsEntry { get; set; }
        public int? BaseLine { get; set; }
    }
    public class Productionordersstage
    {
        public int? DocEntry { get; set; }
        public int? StageID { get; set; }
        public int? SequenceNumber { get; set; }
        public int? StageEntry { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal? RequiredDays { get; set; }
        public decimal? WaitingDays { get; set; }
        public decimal? CalculationProportion { get; set; }
    }

}
