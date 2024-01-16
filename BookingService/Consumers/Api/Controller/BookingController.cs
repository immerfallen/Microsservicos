using Application.Booking.Ports;
using Application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingManager _bookingManager;

        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }

        [HttpPost("/booking/save")]
        public async Task<ActionResult<BookingDTO>> Post(BookingDTO booking)
        {
            await _bookingManager.CreateBooking(booking);
        }
    }
}
