using Domain.Guest.Exceptions;
using Domain.Room.Ports;
using Domain.Room.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Room.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Level { get; set; }
        public bool IsMaintenance { get; set; }
        public Price Price { get; set; }
        public bool IsAvailable
        {
            get
            {
                if (IsMaintenance || HasGuest)
                {
                    return false;
                }
                return true;
            }
        }

        public bool HasGuest
        {
            get
            {
                return true;
            }
        }

        private void ValidateState()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new MissingRequiredException();
            }
        }

        public async Task Save(IRoomRepository roomRepository)
        {
            ValidateState();
            if (Id == 0)
            {
                Id = await roomRepository.Create(this);
            }
            else
            {
                await roomRepository.Update(this);
            }
        }
    }
}
