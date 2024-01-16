using Auth.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Interfaces
{
    public interface IUserRepository
    {
         Task<User> Get(string username, string password);
    }
}
