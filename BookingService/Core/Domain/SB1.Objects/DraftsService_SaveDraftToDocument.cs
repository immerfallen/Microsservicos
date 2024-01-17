using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SB1.Objects
{
    public class DraftsService_SaveDraftToDocument
    {
        public Document Document { get; set; }
        public DraftsService_SaveDraftToDocument()
        {
            Document = new Document();
        }
    }

    public class Document
    {
        //public string DocDueDate { get; set; }
        public string DocEntry { get; set; }
    }

}
