using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SB1.Objects
{
    public class UserFieldsMD
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Nullable<int> Size { get; set; }
        public string Description { get; set; }
        public string SubType { get; set; }
        public string LinkedTable { get; set; }
        public string DefaultValue { get; set; }
        public string TableName { get; set; }
        public Nullable<int> FieldID { get; set; }
        public Nullable<int> EditSize { get; set; }
        public string Mandatory { get; set; }
        public string LinkedUDO { get; set; }
        public string LinkedSystemObject { get; set; }
        public List<Validvaluesmd> ValidValuesMD { get; set; }

        public UserFieldsMD()
        {
            ValidValuesMD = new List<Validvaluesmd>();
        }
    }

    public class Validvaluesmd
    {
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
