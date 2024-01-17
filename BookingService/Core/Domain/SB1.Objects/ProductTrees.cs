using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MCD.SAPAPI.Domain.Entities
{
    public class ProductTrees
    {
        [Key]
        public string TreeCode { get; set; }
        public string TreeType { get; set; }
        public float Quantity { get; set; }
        //public string DistributionRule { get; set; }
        //public object Project { get; set; }
        //public string DistributionRule2 { get; set; }
        //public string DistributionRule3 { get; set; }
        //public string DistributionRule4 { get; set; }
        //public string DistributionRule5 { get; set; }
        public Nullable<int> PriceList { get; set; }
        public string Warehouse { get; set; }
        //public float PlanAvgProdSize { get; set; }
        //public string HideBOMComponentsInPrintout { get; set; }
        public string ProductDescription { get; set; }
        public List<ProductTreeLine> ProductTreeLines { get; set; }
        public List<ProductTreeStage> ProductTreeStages { get; set; }

        public ProductTrees()
        {
            ProductTreeLines = new List<ProductTreeLine>();
            ProductTreeStages = new List<ProductTreeStage>();
        }
    }

    public class ProductTreeLine
    {
        public string ItemCode { get; set; }
        public decimal Quantity { get; set; }
        public string Warehouse { get; set; }
        public Nullable<float> Price { get; set; }
        public string Currency { get; set; }
        public string IssueMethod { get; set; }
        public string InventoryUOM { get; set; }
        public string Comment { get; set; }
        public string ParentItem { get; set; }
        public Nullable<int> PriceList { get; set; }
        //public object DistributionRule { get; set; }
        //public object Project { get; set; }
        //public object DistributionRule2 { get; set; }
        //public object DistributionRule3 { get; set; }
        //public object DistributionRule4 { get; set; }
        //public object DistributionRule5 { get; set; }
        //public object WipAccount { get; set; }
        public string ItemType { get; set; }
        public string LineText { get; set; }
        //public float AdditionalQuantity { get; set; }
        public Nullable<int> StageID { get; set; }
        public Nullable<int> ChildNum { get; set; }
        public Nullable<int> VisualOrder { get; set; }
    }

    public class ProductTreeStage
    {
        public string Father { get; set; }
        public int StageID { get; set; }
        public Nullable<int> SequenceNumber { get; set; }
        public int StageEntry { get; set; }
        public string Name { get; set; }
        public Nullable<float> WaitingDays { get; set; }
    }

}
