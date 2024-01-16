using Application.Booking.Ports;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingManager _bookingManager;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IBookingManager bookingManager, ILogger<BookingController> logger)
        {
            _bookingManager = bookingManager;
            _logger = logger;
        }

        [HttpPost("/booking/save")]
        public async Task<ActionResult<BookingDTO>> Post(BookingDTO booking)
        {
            var res = await _bookingManager.CreateBooking(booking);

            if (res.Success)
            { 
                return Created("", res.Data); 
            }
            else if(res.Errors.Count > 0)
            {
                return BadRequest(res.Errors.ToString());
            }
            _logger.LogError("Response with unknown erro", res);
            return BadRequest(500);
        }
    }
}
