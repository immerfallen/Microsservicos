using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.SB1.Objects
{
    public class PickLists
    {
        [Key]
        public int Absoluteentry { get; set; }
        public string Name { get; set; }
        public int OwnerCode { get; set; }
        public string OwnerName { get; set; }
        public string PickDate { get; set; }
        public object Remarks { get; set; }
        public string Status { get; set; }
        public string ObjectType { get; set; }
        public string UseBaseUnits { get; set; }
        public List<Picklistsline> PickListsLines { get; set; }
    }

    public class Picklistsline
    {
        public int AbsoluteEntry { get; set; }
        public int LineNumber { get; set; }
        public int OrderEntry { get; set; }
        public int OrderRowID { get; set; }
        public decimal? PickedQuantity { get; set; }
        public string PickStatus { get; set; }
        public decimal? ReleasedQuantity { get; set; }
        public decimal? PreviouslyReleasedQuantity { get; set; }
        public int BaseObjectType { get; set; }
        public List<Serialnumber> SerialNumbers { get; set; }
        public List<Batchnumber> BatchNumbers { get; set; }
        public List<Documentlinesbinallocation> DocumentLinesBinAllocations { get; set; }
    }

}
