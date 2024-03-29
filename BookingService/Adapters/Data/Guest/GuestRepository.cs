﻿using Domain.Guest.Ports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Guest
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelDbContext _hotelDbContext;
        public GuestRepository(HotelDbContext hotelContext)
        {
            _hotelDbContext = hotelContext;
        }
        public async Task<int> Create(Domain.Guest.Entities.Guest guest)
        {
            _hotelDbContext.Guests.Add(guest);
            await _hotelDbContext.SaveChangesAsync();
            return guest.Id;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Guest.Entities.Guest?> Get(int id)
        {
            return await _hotelDbContext.Guests.Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Domain.Guest.Entities.Guest>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Domain.Guest.Entities.Guest guest)
        {
            throw new NotImplementedException();
        }
    }
}
