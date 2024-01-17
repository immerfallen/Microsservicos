using Application.Booking.Responses;
using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking.Commands
{
    public class CreateBookingCommand : IRequest<BookingResponse>
    {
      public BookingDTO bookingDTO { get; set; }
    }
}
