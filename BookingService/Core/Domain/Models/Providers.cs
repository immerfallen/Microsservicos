using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class Providers
    {
        public string LoginUrl { get; set; }
        public string DbServerType { get; set; }
        public string Server { get; set; }
        public string AttachDbFilename { get; set; }
        public string ConnectTimeout { get; set; }
        public string SL { get; set; }
        public string SLVS { get; set; }
        public string CompanyDB { get; set; }
        public string DbUserName { get; set; }
        public string DbPassword { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Language { get; set; }
    }

}
