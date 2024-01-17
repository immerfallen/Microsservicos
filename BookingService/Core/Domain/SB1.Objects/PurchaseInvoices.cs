using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SB1.Objects
{
    public class PurchaseInvoices : Documents
    {
        public PurchaseInvoices()
        {
            DocObjectCode = "oPurchaseInvoices";
            DocumentLines = new List<DocumentLine>();
            DocumentReferences = new List<DocumentReference>();
            DownPaymentsToDraw = new List<Downpaymentstodraw>();
            DocumentInstallments = new List<Documentinstallments>();
        }
        public List<DocumentLine> DocumentLines { get; set; }
        public TaxExtension TaxExtension { get; set; }
        public AddressExtension AddressExtension { get; set; }
        public List<DocumentReference> DocumentReferences { get; set; }
        public List<Downpaymentstodraw> DownPaymentsToDraw { get; set; }
        public List<Documentinstallments> DocumentInstallments { get; set; }
    }
}
