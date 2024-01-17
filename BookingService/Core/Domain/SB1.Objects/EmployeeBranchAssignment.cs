using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.SB1.Objects
{
    public class EmployeeBranchAssignment
  {
    [Display(Name = "Código do colaborador")]
    public Nullable<int> EmployeeID { get; set; }
    //public virtual EmployeesInfo EmployeesInfo { get; set; }

    [Display(Name = "Nome da filial")]
    public int BPLID { get; set; }
    //public virtual BusinessPlaces BusinessPlace { get; set; }
  }
}
