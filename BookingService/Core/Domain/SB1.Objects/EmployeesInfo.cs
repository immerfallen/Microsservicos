using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.SB1.Objects
{
    public class EmployeesInfo
    {
        [Key]
        public Nullable<int> EmployeeID { get; set; }
        public Nullable<int> EmployeeCode { get; set; }

        [Display(Name = "Primeiro nome")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Display(Name = "Segundo nome")]
        [StringLength(50, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 0)]
        public string MiddleName { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 3)]
        public string LastName { get; set; }

        [Display(Name = "Departamento")]
        public Nullable<int> Department { get; set; }

        [Display(Name = "Sexo")]
        public string Gender { get; set; }

        [Display(Name = "Data de Aniversário", Description = "Selecione a data de aniverário!")]
        [DataType(DataType.Date, ErrorMessage = "Data Inválida!"),
            DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> DateOfBirth { get; set; }

        [Display(Name = "Foto")]
        public string Picture { get; set; }

        [Display(Name = "Vendedor")]
        public Nullable<int> SalesPersonCode { get; set; }

        [Display(Name = "Título do cargo")]
        [StringLength(20, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 0)]
        public string JobTitle { get; set; }

        [Display(Name = "Telefone do escritório")]
        [StringLength(20, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 0)]
        public string OfficePhone { get; set; }

        [Display(Name = "Ramal")]
        [StringLength(20, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 0)]
        public string OfficeExtension { get; set; }

        [Display(Name = "Telefone celular")]
        [StringLength(20, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 0)]
        public string MobilePhone { get; set; }

        [Display(Name = "Skype")]
        [StringLength(20, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 0)]
        public string Pager { get; set; }

        [Display(Name = "Telefone de casa")]
        [StringLength(20, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 0)]

        public string Active { get; set; }
        public string HomePhone { get; set; }   
        public string HomeStreet { get; set; }
        public string HomeStreetNumber { get; set; }
        public string HomeBuildingFloorRoom { get; set; }
        public string HomeBlock { get; set; }
        public string HomeZipCode { get; set; }
        public string HomeCity { get; set; }
        public string HomeCounty { get; set; }
        public string HomeCountry { get; set; }
        public string HomeState { get; set; }
        public string WorkStreet { get; set; }
        public string WorkStreetNumber { get; set; }
        public string WorkBuildingFloorRoom { get; set; }
        public string WorkBlock { get; set; }
        public string WorkZipCode { get; set; }
        public string WorkCity { get; set; }
        public string WorkCounty { get; set; }
        public string WorkCountryCode { get; set; }
        public string WorkStateCode { get; set; }
        public string CreateDate { get; set; }
        public string CreateTime { get; set; }
        public string UpdateDate { get; set; }
        public string UpdateTime { get; set; }

        [Display(Name = "E-mail")]
        [StringLength(100, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 0)]
        public string eMail { get; set; }
        public List<EmployeeBranchAssignment> EmployeeBranchAssignment { get; set; }

        [Display(Name = "Comissão do vendedor")]
        public Nullable<decimal> PO_CommissionForSalesEmployee { get; set; }

        public EmployeesInfo()
        {
            EmployeeBranchAssignment = new List<EmployeeBranchAssignment>();
        }
    }
    public class Departments
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
