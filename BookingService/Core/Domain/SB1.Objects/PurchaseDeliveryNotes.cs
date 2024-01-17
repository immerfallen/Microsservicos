﻿using System;
using System.Collections.Generic;

namespace Domain.SB1.Objects
{
    public class PurchaseDeliveryNotes:Documents
    {
        public PurchaseDeliveryNotes()
        {
            DocObjectCode = "oPurchaseDeliveryNotes";
            DocumentLines = new List<DocumentLine>();
            DocumentReferences = new List<DocumentReference>();
        }
        public List<DocumentLine> DocumentLines { get; set; }
        public TaxExtension TaxExtension { get; set; }
        public AddressExtension AddressExtension { get; set; }
        public List<DocumentReference> DocumentReferences { get; set; }
    }

    
}
