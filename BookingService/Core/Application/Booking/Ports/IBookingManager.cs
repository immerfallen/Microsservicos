using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking.Ports
{
    public interface IBookingManager
    {
        Task<BookingDTO> CreateBooking(BookingDTO booking);
        Task<BookingDTO> GetBooking(int bookingID);
    }
}
