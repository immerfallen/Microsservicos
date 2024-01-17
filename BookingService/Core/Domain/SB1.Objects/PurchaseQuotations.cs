using System.Collections.Generic;

namespace Domain.SB1.Objects
{
    public class PurchaseQuotations : Documents
    {
        public PurchaseQuotations()
        {
            DocObjectCode = "oPurchaseQuotations";
            DocumentLines = new List<DocumentLine>();
        }

        public List<DocumentLine> DocumentLines { get; set; }
        public List<DocumentReference> DocumentReference { get; set; }
    }
}
