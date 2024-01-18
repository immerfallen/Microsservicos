using Domain.Guest.Enums;
using System.Runtime.CompilerServices;

namespace Application.Booking.DTOs
{
    public class BookingDTO
    {
        public BookingDTO()
        {
            PlacedAt = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public DateTime? PlacedAt { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        private Status Status { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }

        public static Domain.Booking.Entities.Booking MapToEntity(BookingDTO bookingDTO)
        {
            return new Domain.Booking.Entities.Booking
            {
                Id = bookingDTO.Id,
                PlacedAt = bookingDTO.PlacedAt,
                Start = bookingDTO.Start,
                End = bookingDTO.End,
                Guest = new Domain.Guest.Entities.Guest() { Id = bookingDTO.GuestId },
                Room = new Domain.Room.Entities.Room() { Id = bookingDTO.RoomId }
            };
        }

        public static BookingDTO MapToDTO(Domain.Booking.Entities.Booking booking)
        {
            return new BookingDTO
            {
                Id = booking.Id,
                PlacedAt = booking.PlacedAt,
                Start = booking.Start,
                End = booking.End,
                GuestId =  booking.Guest.Id ,
                RoomId =  booking.Room.Id 
            };
        }

    }
}
