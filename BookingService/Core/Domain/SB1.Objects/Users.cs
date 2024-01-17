using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.SB1.Objects
{
    public class Users
    {
        [Key]
        public int InternalKey { get; set; }
        public object UserPassword { get; set; }
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Superuser { get; set; }        
    }

}
