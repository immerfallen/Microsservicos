using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.SB1.Objects
{
    public class BusinessPartnerGroups
    {
        public Nullable<int> Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
    public class BusinessPartners
    {
        [Display(Name = "Código")]
        [Key]
        public string CardCode { get; set; }

        [Display(Name = "Razão Social")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 5)]
        public string CardName { get; set; }

        [Display(Name = "Nome Fantasia")]
        [StringLength(100, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 5)]
        public string AliasName { get; set; }

        [Display(Name = "Tipo do cliente")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        /// Selecionar em lista
        /// C - Cliente / L - Lead
        public string CardType { get; set; }

        [Display(Name = "Grupo do cliente")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        /// Selecionar em lista da tabela OCRG
        /// C - Cliente / L - Lead
        public int GroupCode { get; set; }

        [Display(Name = "Telefone sem DDD")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        [StringLength(20)]
        public string Phone1 { get; set; }

        [Display(Name = "DDD")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        [StringLength(3)]
        public string Phone2 { get; set; }

        [Display(Name = "Contato")]
        /// Selecionar em lista da tabela OCPR
        public string ContactPerson { get; set; }

        [Display(Name = "Condições de pagamento")]
        /// Selecionar em lista da tabela OCTG
        public Nullable<int> PayTermsGrpCode { get; set; }

        [Display(Name = "Limite de crédito")]
        public Nullable<decimal> CreditLimit { get; set; }

        [Display(Name = "Limite de compromisso")]
        public Nullable<decimal> MaxCommitment { get; set; }

        [Display(Name = "% total de desconto")]
        public Nullable<decimal> DiscountPercent { get; set; }

        [Display(Name = "Lista de preços")]
        /// Selecionar em lista da tabela opln
        public Nullable<int> PriceListNum { get; set; }

        [Display(Name = "Vendedor")]
        /// Selecionar em lista da tabela oslp
        public Nullable<int> SalesPersonCode { get; set; }

        [Display(Name = "Moeda")]
        /// Selecionar em lista da tabela OCRN
        public string Currency { get; set; }

        [Display(Name = "E-mail")]
        public string EmailAddress { get; set; }

        [Display(Name = "Imagem")]
        public string Picture { get; set; }

        [Display(Name = "Nome estrangeiro")]
        [StringLength(100)]
        public string CardForeignName { get; set; }

        [Display(Name = "Tipo de envio")]
        /// Selecionar em lista da tabela OSHP
        public string ShippingType { get; set; }

        [Display(Name = "Ativo?")]
        public string Valid { get; set; }

        [Display(Name = "Ativo - De")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida!"),
            DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> ValidFrom { get; set; }

        [Display(Name = "Ativo - Até")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida!"),
            DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> ValidTo { get; set; }

        [Display(Name = "Ativo - Observações")]
        [StringLength(30)]
        public string ValidRemarks { get; set; }

        [Display(Name = "Inativo?")]
        public string Frozen { get; set; }

        [Display(Name = "Inativo - De")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida!"),
            DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> FrozenFrom { get; set; }

        [Display(Name = "Inativo - Até")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida!"),
            DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> FrozenTo { get; set; }

        [Display(Name = "Inativo - Observações")]
        [StringLength(30)]
        public string FrozenRemarks { get; set; }

        [Display(Name = "Endereço de entrega padrão")]
        [StringLength(50)]
        public string ShipToDefault { get; set; }

        [Display(Name = "Endereço de entrega padrão")]
        [StringLength(50)]
        public string BilltoDefault { get; set; }

        [Display(Name = "Território")]
        /// Selecionar em lista da tabela OTER
        public string Territory { get; set; }

        public Nullable<int> Series { get; set; }

        [Display(Name = "Tipo de parceiro de negócios")]
        /// C - Empresa / I - Particular / G - Governo / E - Colaboradores
        public string CompanyPrivate { get; set; }
        public string FatherCard { get; set; }
        public string FreeText { get; set; }

        /// AbsoluteEntry in Attachments2
        public Nullable<int> AttachmentEntry { get; set; }
        public Nullable<int> LanguageCode { get; set; }
        public List<BpAddress> BPAddresses { get; set; }
        public List<ContactEmployees> ContactEmployees { get; set; }
        public List<BpPaymentMethod> BPPaymentMethods { get; set; }
        public List<BpBranchAssignment> BPBranchAssignment { get; set; }
        public List<BpFiscalTaxidCollection> BPFiscalTaxIDCollection { get; set; }
        
        //public List<BusinessPlaces> BusinessPlaces { get; set; }

        public string PO_DELETE { get; set; }

        public BusinessPartners()
        {
            BPAddresses = new List<BpAddress>();
            ContactEmployees = new List<ContactEmployees>();
            BPBranchAssignment = new List<BpBranchAssignment>();
            BPFiscalTaxIDCollection = new List<BpFiscalTaxidCollection>();
            BPPaymentMethods = new List<BpPaymentMethod>();

            //BusinessPlaces = new List<BusinessPlaces>();
        }
    }
    public class BpAddress //: BaseModel
    {
        public Nullable<int> RowNum { get; set; }
        public string BPCode { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 5)]
        public string AddressName { get; set; }
        public string AddressName2 { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        /// 0 - Entrega / 1 - Cobrança
        public string AddressType { get; set; }

        [Display(Name = "Tipo de logradouro")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        [StringLength(100)]
        public string TypeOfAddress { get; set; }


        [Display(Name = "Rua/caixa postal")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        [StringLength(100)]
        public string Street { get; set; }

        [Display(Name = "Rua nº")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        [StringLength(100)]
        public string StreetNo { get; set; }

        [Display(Name = "Complemento")]
        [StringLength(8000)]
        public string BuildingFloorRoom { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        [StringLength(100)]
        public string Block { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        [StringLength(20)]
        public string ZipCode { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        [StringLength(100)]
        public string City { get; set; }

        [Display(Name = "Pais")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        /// Selecionar em lista da tabela OCRY
        public string Country { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        /// Selecionar em lista da tabela OCST
        public string State { get; set; }

        [Display(Name = "Cod. Município")]
        [DefaultValue("")]
        [StringLength(100)]
        /// Selecionar em lista da tabela OCNT
        public string County { get; set; }
        //public string BusinessPartnersCardCode { get; set; }
    }
    public class BpFiscalTaxidCollection
    {
        public string BPCode { get; set; }

        [Display(Name = "ID do endereço")]
        //[Required(ErrorMessage = "{0} é Obrigatório.")]
        //[StringLength(50, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 5)]
        public string Address { get; set; }

        [Display(Name = "Tipo do endereço")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        /// 0 - Entrega / 1 - Cobrança
        public string AddrType { get; set; }

        [Display(Name = "Cód.CNAE")]
        [DefaultValue("")]
        /// Selecionar em lista da tabela OCST
        public string CNAECode { get; set; }

        [Display(Name = "CNPJ")]
        [DefaultValue("")]
        [StringLength(100, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 0)]
        public string TaxId0 { get; set; }

        [Display(Name = "Inscrição Estadual")]
        [DefaultValue("")]
        [StringLength(100, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 0)]
        public string TaxId1 { get; set; } = "ISENTO";

        [Display(Name = "Ins.Est.Substituto Tributário")]
        [DefaultValue("")]
        [StringLength(100, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 0)]
        public string TaxId2 { get; set; }

        [Display(Name = "Inscrição Municipal")]
        [DefaultValue("")]
        [StringLength(100, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 0)]
        public string TaxId3 { get; set; }

        [Display(Name = "CPF")]
        [DefaultValue("")]
        [StringLength(100, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 0)]
        public string TaxId4 { get; set; }
        public string TaxId5 { get; set; }

        public string TaxId12 { get; set; }
    }
    public class BpBranchAssignment
    {

        public string BPCode { get; set; }
        [Display(Name = "Filial do Cliente")]
        public int BPLID { get; set; }
    }
    public class BpPaymentMethod
    {
        public string PaymentMethodCode { get; set; }
        public Nullable<int> RowNumber { get; set; }
        public string BPCode { get; set; }
    }
}
