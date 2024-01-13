using Domain.Exceptions;
using Domain.Ports;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Guest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Email { get; set; }
        public PersonId Document { get; set; }

        private void ValidateState()
        {
            if (Document == null ||
               Document.Idnumber.Length < 3 ||
               Document.DocumentType == 0
                )
            {
                throw new InvalidDocumentException();
            }

            if (string.IsNullOrEmpty(Name) ||
               string.IsNullOrEmpty(SurName) ||
               string.IsNullOrEmpty(Email))
            {
                throw new MissingRequiredException();
            }

            if (Utils.ValidateEmail(Email) == false)
            {
                throw new InvalidEmailException();
            }             
        }

        public async Task Save(IGuestRepository guestRepository)
        {
            ValidateState();
            if(Id == 0)
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
