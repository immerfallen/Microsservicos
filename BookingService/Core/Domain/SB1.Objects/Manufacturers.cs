using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.SB1.Objects
{
    public class Manufacturers
    {
        [Key]
        public int Code { get; set; }
        public string ManufacturerName { get; set; }
    }

}
