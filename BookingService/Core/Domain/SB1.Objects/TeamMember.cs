using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.SB1.Objects
{
    public class TeamMember
    {
        [Display(Name = "Equipe")]
        public Nullable<int> TeamID { get; set; }

        [Display(Name = "Colaborador")]
        public Nullable<int> EmployeeID { get; set; }

        [Display(Name = "Função na equipe")]
        [Required(ErrorMessage = "{0} é Obrigatório.")]
        /// borit_Member = Membro
        /// borit_Leader = Lider
        public string RoleInTeam { get; set; }
    }
}
