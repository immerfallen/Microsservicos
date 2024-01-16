using Domain.Room.Ports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Room
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext _hotelDbContext;
        public RoomRepository(HotelDbContext hotelContext)
        {
            _hotelDbContext = hotelContext;
        }
        public async Task<int> Create(Domain.Room.Entities.Room Room)
        {
            _hotelDbContext.Rooms.Add(Room);
            await _hotelDbContext.SaveChangesAsync();
            return Room.Id;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Room.Entities.Room?> Get(int id)
        {
            return await _hotelDbContext.Rooms.Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Domain.Room.Entities.Room>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Domain.Room.Entities.Room Room)
        {
            throw new NotImplementedException();
        }
    }
}
