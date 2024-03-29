﻿using Application.Booking.DTOs;
using Application.Booking.Responses;
using Application.Payment.DTOs;
using Application.Payment.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking.Ports
{
    public interface IBookingManager
    {
        Task<BookingResponse> CreateBooking(BookingDTO booking);
        Task<BookingResponse> GetBooking(int bookingID);        
        Task<PaymentResponse> PayForBooking(PaymentRequestDTO payment);
    }
}
