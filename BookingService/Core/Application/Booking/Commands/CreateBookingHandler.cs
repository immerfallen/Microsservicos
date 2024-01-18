using Application.Booking.Responses;
using MediatR;
using Application.Booking.Ports;
using Domain.Booking.Ports;
using Domain.Guest.Ports;
using Domain.Room.Ports;
using Application.Booking.DTOs;

namespace Application.Booking.Commands
{
    public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, BookingResponse>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IRoomRepository _roomRepository;

        public CreateBookingHandler(IBookingRepository bookingRepository, IGuestRepository guestRepository, IRoomRepository roomRepository)
        {
            _bookingRepository = bookingRepository;
            _guestRepository = guestRepository;
            _roomRepository = roomRepository;
        }
        public async Task<BookingResponse> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var booking = BookingDTO.MapToEntity(request.bookingDTO);
                booking.Guest = await _guestRepository.Get(request.bookingDTO.GuestId);
                booking.Room = await _roomRepository.Get(request.bookingDTO.RoomId);
                await booking.Save(_bookingRepository);
                request.bookingDTO.Id = booking.Id;

                return new BookingResponse
                {
                    Data = request.bookingDTO,
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                // implementação das exceções personalizadas
                throw;
            }
        }
    }
}
