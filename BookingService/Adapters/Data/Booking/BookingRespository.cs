﻿using Domain.Booking.Ports;
using Microsoft.EntityFrameworkCore;

namespace Data.Booking
{
    public class BookingRespository : IBookingRepository
    {
        private readonly HotelDbContext _dbContext;

        public BookingRespository(HotelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Domain.Booking.Entities.Booking> CreateBookingAsync(Domain.Booking.Entities.Booking booking)
        {
            _dbContext.Bookings.Add(booking);
            await _dbContext.SaveChangesAsync();
            return booking;
        }

        public async Task<Domain.Booking.Entities.Booking> GetBookingAsync(int bookingId)
        {
            return await _dbContext.Bookings.Where(b => b.Id == bookingId).FirstOrDefaultAsync();
        }
    }
}
