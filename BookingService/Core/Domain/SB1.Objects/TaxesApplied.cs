namespace Domain.SB1.Objects
{
    public class TaxesApplied
    {
        public string ItemCode { get; set; }
        public string NCMCode { get; set; }
        public string State { get; set; }
        public int OSTTAbsId { get; set; }
        public string OSTTName { get; set; }
        public double NominalRate { get; set; }
        public double AppliedRate { get; set; }
    }
}
