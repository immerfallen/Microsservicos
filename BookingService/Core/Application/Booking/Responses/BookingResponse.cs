﻿using Application.Booking.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Booking.Responses
{
    public class BookingResponse : Response
    {
        public BookingDTO Data { get; set; }
    }
}
