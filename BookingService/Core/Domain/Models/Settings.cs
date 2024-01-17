using System;

namespace Domain.Models
{
    public class Settings
    {
        public string LoginUrl { get; set; }
        public string LoginType { get; set; }
        public string SeqLogServer { get; set; }
        public Providers Providers { get; set; }
        public string CompanyDB { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Language { get; set; }
        public string Server { get; set; }
    }
}