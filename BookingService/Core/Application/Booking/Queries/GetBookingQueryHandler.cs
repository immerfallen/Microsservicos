using Application.Booking.DTOs;
using Application.Booking.Responses;
using Domain.Booking.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking.Queries
{
    internal class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, BookingResponse>
    {
        private readonly IBookingRepository _bookingRepository;

        public GetBookingQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<BookingResponse> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            var booking =  await _bookingRepository.GetBookingAsync(request.Id);

            var bookingDTO = BookingDTO.MapToDTO(booking);

            return new BookingResponse
            {
                Success = true,
                Errors = new List<string>(),
                Data = bookingDTO                
            };
        }
    }
}
