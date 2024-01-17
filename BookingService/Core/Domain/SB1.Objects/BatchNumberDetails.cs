using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.SB1.Objects
{
    public class BatchNumberDetails

    {
        [Key]
        public int DocEntry { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public string Status { get; set; }
        public string Batch { get; set; }
        public string BatchAttribute1 { get; set; }
        public string BatchAttribute2 { get; set; }
        public string AdmissionDate { get; set; }
        public string ManufacturingDate { get; set; }
        public string ExpirationDate { get; set; }
        public string Details { get; set; }
        public int SystemNumber { get; set; }
    }

}
