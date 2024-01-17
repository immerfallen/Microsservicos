using System;
using System.Collections.Generic;

namespace MCD.SAPAPI.L1Common.Models
{
    public class LicenseAuth
    {
        public string NomeUsuario { get; set; } = "";
        public string Logo { get; set; } = "";
        public bool Existe { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdUsuarioSap { get; set; }
        public int? ListaAtividadeAtualizacao { get; set; }
        public int? SistemaWeb { get; set; }
        public int? SistemaAndroid { get; set; }
        public int? SistemaIos { get; set; }
        public List<Servidores> servidores { get; set; }

        public LicenseAuth()
        {
            servidores = new List<Servidores>();
        }
    }

    public class Servidores
    {
        public string Nome { get; set; } = "";
        public string Caminho { get; set; } = "";
    }
    //public class Servers
    //{
    //    public string CompanyName { get; set; }
    //    public string DataBase { get; set; }
    //    public string PathWebApi { get; set; }
    //}

}
