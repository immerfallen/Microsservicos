using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.SB1.Objects
{
    public class BusinessPlaces
    {
        [Key]
        [Display(Name = "Código da filial")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        public int BPLId { get; set; }

        [Display(Name = "Nome da filial")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 5)]
        public string BPLName { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        [StringLength(32, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 14)]
        public string FederalTaxID { get; set; }

        [Display(Name = "Nome fantasia")]
        [StringLength(100, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 5)]
        public string AliasName { get; set; }

        [Display(Name = "Negócio")]
        public string Business { get; set; }

        [Display(Name = "Setor industrial")]
        public string Industry { get; set; }

        [Display(Name = "Empresa principal")]
        public string MainBPL { get; set; }
        public string Disabled { get; set; }

        [Display(Name = "Inscrição Estadual")]
        public string FederalTaxID2 { get; set; }

        [Display(Name = "Inscrição Municipal")]
        public string FederalTaxID3 { get; set; }

        [Display(Name = "Inscrição Municipal")]
        public string AdditionalIdNumber { get; set; }

        [Display(Name = "Tipo de logradouro")]
        public string AddressType { get; set; }

        [Display(Name = "Rua/caixa postal")]
        public string Street { get; set; }

        [Display(Name = "Número")]
        public string StreetNo { get; set; }

        [Display(Name = "Complemento")]
        public string Building { get; set; }

        [Display(Name = "CEP")]
        public string ZipCode { get; set; }

        [Display(Name = "Bairro")]
        public string Block { get; set; }

        [Display(Name = "Cidade")]
        public string City { get; set; }

        [Display(Name = "Estado")]
        public string State { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public List<BusinessplaceIENumber> BusinessPlaceIENumbers { get; set; }

        public string DefaultWarehouseID { get; set; }
        //public string[] BusinessPlaceTributaryInfos { get; set; }
    }

    public class BusinessplaceIENumber
    {
        public int BPLID { get; set; }
        public string State { get; set; }
        public string IENumber { get; set; }
    }

}
