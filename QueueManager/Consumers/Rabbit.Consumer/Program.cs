// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client.Events;
using Rabbit.Domain.Entities;

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "admin",
    Password = "123456"
};
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "rabbitmessagequeue",
        durable: false,
        exclusive: false,
        autoDelete: false,
        arguments: null);

    RabbitMessage objeto = new RabbitMessage();

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);

        objeto = JsonSerializer.Deserialize<RabbitMessage>(message);

        Thread.Sleep(5000);

        Console.WriteLine(objeto.Title);

    };

    
    

    channel.BasicConsume(queue: "rabbitmessagequeue",
        autoAck: true,
        consumer: consumer
        );

    Console.Read();
}

