using Entities = Domain.Guest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Guest.Ports
{
    public interface IGuestRepository
    {
        Task<Entities.Guest> Get(int id);
        Task<List<Entities.Guest>> GetAll();
        Task Delete(int id);
        Task<int> Create(Entities.Guest guest);
        Task<int> Update(Entities.Guest guest);
    }
}
