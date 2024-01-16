using Auth.Domain;
using Auth.Interfaces;
using Auth.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{

    public class UserRepository : IUserRepository
    {

        private readonly UserDbContext _userDbContext;
        private readonly IConfiguration _configuration;

        public UserRepository(UserDbContext userDbContext, IConfiguration configuration)
        {
            _userDbContext = userDbContext;
            _configuration = configuration;
        }

        public async Task<User> Get(string username, string password)
        {
            var crypt = new Crypt();
            password = crypt.Encrypt(password);
            var passwordDecrypted = crypt.Decrypt(password);

            var user = await _userDbContext.Users.Where(u => u.UserName.ToLower() == username.ToLower() && u.Password == password).FirstOrDefaultAsync();
            
            return user;

            //var users = new List<User>();
            //users.Add(new User { Id = 1, UserName = "batman", Password = "batman", Role = "manager" });
            //users.Add(new User { Id = 2, UserName = "robin", Password = "robin", Role = "employee" });
            //return users.Where(x => x.UserName.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
        }

        
    }

}
