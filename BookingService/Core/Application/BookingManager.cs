using Application.Booking.Ports;
using Application.Booking.Responses;
using Application.DTOs;
using Domain.Booking.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingManager(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public async Task<BookingResponse> CreateBooking(BookingDTO bookingDTO)
        {
            try
            {
                var booking = BookingDTO.MapToEntity(bookingDTO);
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
