using System.Collections.Generic;

namespace Domain.SB1.Objects
{
    public class Orders : Documents
    {
        public Orders()
        {
            DocObjectCode = "oOrders";
            DocumentLines = new List<OrdersLines>();
            //TaxExtension = new TaxExtension();
            //AddressExtension = new AddressExtension();
            //DocumentAdditionalExpenses = new List<DocumentAdditionalExpens>();
        }

        public decimal? PO_AdditionalExpens { get; set; }
        public string PO_TransportationName { get; set; }
        public List<OrdersLines> DocumentLines { get; set; }
        public TaxExtension TaxExtension { get; set; }
        public AddressExtension AddressExtension { get; set; }
        public List<DocumentAdditionalExpens> DocumentAdditionalExpenses { get; set; }
    }

    public class OrdersLines : DocumentLine
    {
        public string PO_JsonProduction { get; set; }
    }
}
