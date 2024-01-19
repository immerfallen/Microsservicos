using Rabbit.Application.Interfaces;
using Rabbit.Domain.Entities;
using Rabbit.Respository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Application
{
    public class RabbitMessageService : IRabbitMessageService
    {
        private readonly IRabbitMessageRepository _rabbitMessageRepository;

        public RabbitMessageService(IRabbitMessageRepository rabbitMessageRepository)
        {
            _rabbitMessageRepository = rabbitMessageRepository;
        }

        public void SendMessage(RabbitMessage message)
        {
            _rabbitMessageRepository.SendMessage(message);
        }
    }
}
