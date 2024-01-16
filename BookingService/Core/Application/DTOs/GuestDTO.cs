using Domain.Guest.Enums;
using System.ComponentModel.DataAnnotations;
using Entities = Domain.Guest.Entities;

namespace Application.DTOs
{
    public class GuestDTO
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name => É obrigatório")]
        [MaxLength(256, ErrorMessage = "Name => Tamanho máximo  permitido é de 256")]
        [MinLength(3, ErrorMessage = "Name => Tamanho mínimo deve ser 3")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "SurName => É obrigatório")]        
        [MaxLength(256, ErrorMessage = "SurName => Tamanho máximo permitido é de 256")]
        [MinLength(3, ErrorMessage = "SurName => Tamanho mínimo deve ser 3")]
        public string? SurName { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        [EmailAddress(ErrorMessage ="Informar um email válido")]
        public string? Email { get; set; }

        public string? IdNumber { get; set; }

        [Required(ErrorMessage = "O campo IdTypeCode é obrigatório")]
        [Range(1,2, ErrorMessage = "O tipo deve estar entre 1 e 2")]
        public int IdTypeCode { get; set; }

        public static Domain.Guest.Entities.Guest MapToEntity(GuestDTO guestDTO)
        {
            return new Entities.Guest
            {
                Id = guestDTO.Id,
                Name = guestDTO.Name,
                SurName = guestDTO.SurName,
                Email = guestDTO.Email,
                Document = new Domain.Guest.ValueObjects.PersonId
                {
                    Idnumber = guestDTO.IdNumber,
                    DocumentType = (DocumentType)guestDTO.IdTypeCode
                }
            };
        }

        public static GuestDTO MapToDTO(Domain.Guest.Entities.Guest guest)
        {
            return new GuestDTO
            {
                Email = guest.Email,
                Id = guest.Id,
                Name = guest.Name,
                SurName = guest.SurName,
                IdNumber = guest.Document.Idnumber,
                IdTypeCode = (int)guest.Document.DocumentType
            };
        }
    }
}
