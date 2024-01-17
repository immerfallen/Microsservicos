using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class LoginToken
    {
        public string Token { get; set; }
        public string CompanyName { get; set; }
        public string DataBase { get; set; }
        public LoginValues Usuario { get; set; }
    }
    public class LoginValues
    {
        public int UserID { get; set; } = 0;
        public string Name { get; set; }
        public string Password { get; set; }
        public string SessionId { get; set; }
        public string Version { get; set; }
        public double? SessionTimeout { get; set; }
        public DateTime? SessionDateTimeOut { get; set; }
        public int Type { get; set; }
        public List<Authorization> Authorizations { get; set; }
        public List<Servers> Servers { get; set; }
        public LoginValues()
        {
            Authorizations = new List<Authorization>();
            Servers = new List<Servers>();
        }
    }
    public class Authorization
    {
        public int USERID { get; set; }
        public string PermId { get; set; }
        public string Permission { get; set; }
    }
    public class Servers
    {
        public string CompanyName { get; set; }
        public string DataBase { get; set; }
        public string PathWebApi { get; set; }
    }
}
