using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SB1.Objects
{
    public class PurchaseRequests : Documents
    {
        public PurchaseRequests()
        {
            DocObjectCode = "oPurchaseRequest";
            DocumentLines = new List<DocumentLine>();
            DocumentReferences = new List<DocumentReference>();
        }
        public List<DocumentLine> DocumentLines { get; set; }
        public List<DocumentReference> DocumentReferences { get; set; }
    }
}
