using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SB1.Objects
{
    public class PurchaseCreditNotes : Documents
    {
        public PurchaseCreditNotes()
        {
            DocObjectCode = "oPurchaseCreditNotes";
            DocumentLines = new List<DocumentLine>();
            DocumentReferences = new List<DocumentReference>();
        }
        public List<DocumentLine> DocumentLines { get; set; }
        public TaxExtension TaxExtension { get; set; }
        public AddressExtension AddressExtension { get; set; }
        public List<DocumentReference> DocumentReferences { get; set; }
    }
}
