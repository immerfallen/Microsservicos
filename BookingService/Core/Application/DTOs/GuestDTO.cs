﻿using Domain.Enums;
using Entities = Domain.Entities;

namespace Application.DTOs
{
    public class GuestDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Email { get; set; }
        public string IdNumber { get; set; }
        public int idTypeCode { get; set; }

        public static Entities.Guest MapToEntity(GuestDTO guestDTO)
        {
            return new Entities.Guest
            {
                Id = guestDTO.Id,
                Name = guestDTO.Name,
                Email = guestDTO.Email,
                Document = new Domain.ValueObjects.PersonId
                {
                    Idnumber = guestDTO.IdNumber,
                    DocumentType = (DocumentType)guestDTO.idTypeCode
                }
            };
        }
    }
}
