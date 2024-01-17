using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.SB1.Objects 
{ 
    public class ContactEmployees
    {
        public Nullable<int> InternalCode { get; set; }

        [Display(Name = "Código")]
        //[Required(ErrorMessage = "{0} é Obrigatório.")]
        [StringLength(15, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 3)]
        public string CardCode { get; set; }

        [Display(Name = "Name")]
        //[Required(ErrorMessage = "{0} é Obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "Primeiro nome")]
        //[Required(ErrorMessage = "{0} é Obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Display(Name = "Segundo nome")]
        [StringLength(50, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 0)]
        public string MiddleName { get; set; }

        [Display(Name = "Sobrenome")]
        //[Required(ErrorMessage = "{0} é Obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 0)]
        public string LastName { get; set; }

        [Display(Name = "Posição")]
        [StringLength(90, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 0)]
        public string Position { get; set; }

        [Display(Name = "Profissão")]
        [StringLength(50, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 0)]
        public string Profession { get; set; }

        [Display(Name = "Telefone sem DDD")]
        [StringLength(20)]
        public string Phone1 { get; set; }

        [Display(Name = "DDD")]
        [StringLength(3)]
        public string Phone2 { get; set; }

        [Display(Name = "Tel Celular")]
        [StringLength(20)]
        public string MobilePhone { get; set; }

        [Display(Name = "Fax")]
        [StringLength(20)]
        public string Fax { get; set; }

        [Display(Name = "E-mail")]
        [StringLength(100)]
        public string E_Mail { get; set; }

        [Display(Name = "Skype")]
        [StringLength(20, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 0)]
        public string Pager { get; set; }

        [Display(Name = "Sexo")]
        public string Gender { get; set; }

        [Display(Name = "País de nascimento")]
        /// Selecionar em lista da tabela OCRY
        public string PlaceOfBirth { get; set; }

        [Display(Name = "Local de nascimento")]
        /// Selecionar em lista da tabela OCRY
        public string CityOfBirth { get; set; }

        [Display(Name = "Data de Aniversário", Description = "Selecione a data de aniverário!")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida!"),
            DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //[Required(AllowEmptyStrings = true, ErrorMessage = "{0} campo obrigátorio")]
        public Nullable<DateTime> DateOfBirth { get; set; }
    }
}
