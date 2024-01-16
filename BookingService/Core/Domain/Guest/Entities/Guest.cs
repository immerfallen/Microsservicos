using Domain.Guest.Exceptions;
using Domain.Guest.Ports;
using Domain.Guest.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Guest.Entities
{
    public class Guest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Email { get; set; }
        public PersonId Document { get; set; }

        

        public async Task Save(IGuestRepository guestRepository)
        {            
            if (Id == 0)
            {
                Id = await guestRepository.Create(this);
            }
            else
            {
                await guestRepository.Update(this);
            }
        }
    }
}
