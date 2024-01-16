using Auth.Domain;
using Auth.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Auth
{
    public class UserDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public UserDbContext(DbContextOptions<UserDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = new User
            {
                Id = 1,
                Password = "password",
                UserName = "admin",
                Role = "admin"
            };

            var crypt = new Crypt();

            user.Password = crypt.Encrypt(user.Password);

            modelBuilder.Entity<User>().HasData(user);

        }

        public virtual DbSet<User> Users { get; set; }
    }



}
