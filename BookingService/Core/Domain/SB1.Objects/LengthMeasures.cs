using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.SB1.Objects
{
    public class LengthMeasures
    {
        [Key]
        public int UnitCode { get; set; }
        public string UnitDisplay { get; set; }
        public string UnitName { get; set; }
        public string UnitCodeforQuantityDisplay { get; set; }
        public decimal UnitLengthinmm { get; set; }
    }

}
