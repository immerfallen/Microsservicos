using Application.Booking.Ports;
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

        public async Task<BookingDTO> CreateBooking(BookingDTO bookingDTO)
        {
            var booking = BookingDTO.MapToEntity(bookingDTO);
            booking.Save(_bookingRepository);
        }

        public Task<BookingDTO> GetBooking(int bookingID)
        {
            throw new NotImplementedException();
        }
    }
}
