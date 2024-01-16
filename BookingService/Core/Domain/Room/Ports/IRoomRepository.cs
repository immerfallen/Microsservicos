using Entities = Domain.Room.Entities;

namespace Domain.Room.Ports
{
    public interface IRoomRepository
    {
        Task<Entities.Room> Get(int id);
        Task<List<Entities.Room>> GetAll();
        Task Delete(int id);
        Task<int> Create(Entities.Room room);
        Task<int> Update(Entities.Room room);
    }
}
