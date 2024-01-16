using Domain.Guest.Enums;
using Domain.Room.ValueObjects;
using System.ComponentModel.DataAnnotations;
using Entities = Domain.Room;

namespace Application.DTOs
{
    public class RoomDTO
    {      
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public bool IsMaintenance { get; set; }
        public Price? Price { get; set; }
        public bool IsAvailable { get; set; }

        public static Entities.Entities.Room MapToEntity(RoomDTO roomDTO)
        {
            return new Entities.Entities.Room
            {
                Id = roomDTO.Id,
                Name = roomDTO.Name,
                IsMaintenance = roomDTO.IsMaintenance,
                Level = roomDTO.Level,
                Price = new Price
                {
                    Currency = roomDTO.Price.Currency,
                    Value = roomDTO.Price.Value,
                }
            };
        }

        public static RoomDTO MapToDTO(Domain.Room.Entities.Room room)
        {
            return new RoomDTO
            {
                IsAvailable = room.IsAvailable,
                Id = room.Id,
                Name = room.Name,
                IsMaintenance = room.IsMaintenance,
                Level = room.Level,
                Price = room.Price
            };
        }
    }
}
