using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.SB1.Objects
{
    public class UserTablesMD
    {
        [Key]
        public string TableName { get; set; }
        public string TableDescription { get; set; }
        public string TableType { get; set; }
    }
}
