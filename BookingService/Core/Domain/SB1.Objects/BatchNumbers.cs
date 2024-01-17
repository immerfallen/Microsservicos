using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SB1.Objects
{
    public class Batchnumber
    {
        public string BatchNumber { get; set; }
        public string ManufacturerSerialNumber { get; set; }
        public string InternalSerialNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string ManufacturingDate { get; set; }
        public string AddmisionDate { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public decimal? Quantity { get; set; }
        public int? BaseLineNumber { get; set; }
        public string TrackingNote { get; set; }
        public string TrackingNoteLine { get; set; }
        public string ItemCode { get; set; }
        public int? SystemSerialNumber { get; set; }
    }
}
