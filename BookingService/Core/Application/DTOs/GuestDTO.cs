using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using Entities = Domain.Entities;

namespace Application.DTOs
{
    public class GuestDTO
    {
       
        public int Id { get; set; }        
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Email { get; set; }
        public string? IdNumber { get; set; }
        public int IdTypeCode { get; set; }

        public static Entities.Guest MapToEntity(GuestDTO guestDTO)
        {
            return new Entities.Guest
            {
                Id = guestDTO.Id,
                Name = guestDTO.Name,
                SurName = guestDTO.SurName,
                Email = guestDTO.Email,
                Document = new Domain.ValueObjects.PersonId
                {
                    Idnumber = guestDTO.IdNumber,
                    DocumentType = (DocumentType)guestDTO.IdTypeCode
                }
            };
        }

        public static GuestDTO MapToDTO(Entities.Guest guest)
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
