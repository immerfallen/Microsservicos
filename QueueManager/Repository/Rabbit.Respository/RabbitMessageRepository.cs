using Rabbit.Domain.Entities;
using Rabbit.Respository.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Rabbit.Respository
{
    public class RabbitMessageRepository : IRabbitMessageRepository
    {
        public void SendMessage(RabbitMessage message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "123456"
            };
            using(var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "rabbitmessagequeue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);                

                string json = JsonSerializer.Serialize(message);

                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "",
                    routingKey: "rabbitmessagequeue",
                    basicProperties: null,
                    body: body
                    );                
            }
        }
    }
}
