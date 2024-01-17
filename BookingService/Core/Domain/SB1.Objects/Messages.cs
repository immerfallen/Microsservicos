using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.SB1.Objects
{
    public class Messages
    {
        public Messages()
        {
            MessageDataColumns = new List<Messagedatacolumn>();
            RecipientCollection = new List<Recipientcollection>();
            Subject = "Erro na integração com o Portal.";
        }

        [Key]
        public int? Code { get; set; }
        public int? User { get; set; }
        public string Priority { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
        public string Attachment { get; set; }
        public List<Messagedatacolumn> MessageDataColumns { get; set; }
        public List<Recipientcollection> RecipientCollection { get; set; }
    }

    public class Messagedatacolumn
    {
        public Messagedatacolumn()
        {
            MessageDataLines = new List<Messagedataline>();
            Link = "tYES";
        }
        public string ColumnName { get; set; }
        public string Link { get; set; }
        public List<Messagedataline> MessageDataLines { get; set; }
    }

    public class Messagedataline
    {
        public string Value { get; set; }
        public string Object { get; set; }
        public string ObjectKey { get; set; }
    }

    public class Recipientcollection
    {
        public Recipientcollection()
        {
            UserType = "rt_InternalUser";
            SendInternal = "tYES";
        }
        public string UserCode { get; set; }
        public string UserType { get; set; }
        public string NameTo { get; set; }
        public string SendEmail { get; set; }
        public string EmailAddress { get; set; }
        public string SendSMS { get; set; }
        public string CellularNumber { get; set; }
        public string SendFax { get; set; }
        public string FaxNumber { get; set; }
        public string SendInternal { get; set; }
    }

}
