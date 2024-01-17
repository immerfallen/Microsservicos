using Application.Booking.Ports;
using Application.Booking.Responses;
using Application.DTOs;
using Domain.Booking.Ports;
using Domain.Guest.Ports;
using Domain.Room.Ports;

namespace Application
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IRoomRepository _roomRepository;

        public BookingManager(IBookingRepository bookingRepository, IGuestRepository guestRepository, IRoomRepository roomRepository)
        {
            _bookingRepository = bookingRepository;
            _guestRepository = guestRepository;
            _roomRepository = roomRepository;
        }

        public async Task<BookingResponse> CreateBooking(BookingDTO bookingDTO)
        {
            try
            {
                var booking = BookingDTO.MapToEntity(bookingDTO);
                booking.Guest = await _guestRepository.Get(bookingDTO.GuestId);
                booking.Room = await _roomRepository.Get(bookingDTO.RoomId);
                await booking.Save(_bookingRepository);
                bookingDTO.Id = booking.Id;

                return new BookingResponse
                {
                    Data = bookingDTO,
                    Success = true,
                };
            }
            catch (Exception ex)
            {
            // implementação das exceções personalizadas
                throw;
            }
            
        }

        public Task<BookingResponse> GetBooking(int bookingID)
        {
            throw new NotImplementedException();
        }
    }
}
