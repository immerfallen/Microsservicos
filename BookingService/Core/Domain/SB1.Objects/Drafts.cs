using System.Collections.Generic;

namespace Domain.SB1.Objects
{
    public class Drafts : Documents
    {
        public Drafts()
        {
            DocObjectCode = "oDrafts";
            DocumentLines = new List<DraftsLines>();
            TaxExtension = new DraftsTaxExtension();
            AddressExtension = new DraftsAddressExtension();
        }

        public List<DraftsLines> DocumentLines { get; set; }
        public DraftsTaxExtension TaxExtension { get; set; }
        public DraftsAddressExtension AddressExtension { get; set; }
    }

    public class DraftsLines : DocumentLine
    {
    }

    public class DraftsTaxExtension : TaxExtension
    {
    }

    public class DraftsAddressExtension : AddressExtension
    {
    }
}
