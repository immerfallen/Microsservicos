using Rabbit.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Application.Interfaces
{
    public interface IRabbitMessageService
    {
        void SendMessage(RabbitMessage message);
    }
}
