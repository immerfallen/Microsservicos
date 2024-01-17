using System.ComponentModel.DataAnnotations;

namespace Domain.SB1.Objects
{
    public class WeightMeasures
    {
        [Key]
        public int UnitCode { get; set; }
        public string UnitDisplay { get; set; }
        public string UnitName { get; set; }
        public decimal UnitWeightinmg { get; set; }
    }

}
