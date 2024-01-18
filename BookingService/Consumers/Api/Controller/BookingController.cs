using Application.Booking.Commands;
using Application.Booking.DTOs;
using Application.Booking.Ports;
using Application.Booking.Queries;
using Application.Payment.DTOs;
using Application.Payment.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingManager _bookingManager;
        private readonly ILogger<BookingController> _logger;
        private readonly IMediator _mediator;

        public BookingController(IBookingManager bookingManager, ILogger<BookingController> logger, IMediator mediator)
        {
            _bookingManager = bookingManager;
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("/booking/save")]
        public async Task<ActionResult<BookingDTO>> Post(BookingDTO booking)
        {
            var command = new CreateBookingCommand()
            {
                bookingDTO = booking
            };
            var res = await _mediator.Send(command);

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

        [HttpPost("(bookingId)/Pay")]
        public async Task<ActionResult<PaymentResponse>> Pay(PaymentRequestDTO dto, int bookingId)
        {
            dto.BookingId = bookingId;
            var res = await _bookingManager.PayForBooking(dto);

            if (res.Success) { return Ok(res.Data); }

            return BadRequest(res);
        }

        [HttpGet]
        public async Task<ActionResult<BookingDTO>> Get(int id)
        {
            var query = new GetBookingQuery
            {
                Id = id
            };
            var res = await _mediator.Send(query);

            if (res.Success) return Created("", res.Data);

            _logger.LogError("Could not proecss the request", res);
            return BadRequest();
        } 


    }
}
