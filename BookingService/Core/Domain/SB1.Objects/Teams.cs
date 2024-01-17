using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.SB1.Objects
{
    public class Teams
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Nullable<int> TeamID { get; set; }
        [Display(Name = "Nome da Equipe")]
        [StringLength(20, ErrorMessage = "O campo {0} deve estar entre {2} e {1} caracteres ", MinimumLength = 3)]
        public string TeamName { get; set; }
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        public virtual List<TeamMember> TeamMembers { get; set; }
    }
}
