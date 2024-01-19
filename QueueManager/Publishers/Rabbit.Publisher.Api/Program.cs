using Microsoft.OpenApi.Models;
using Rabbit.Application;
using Rabbit.Application.Interfaces;
using Rabbit.Domain.Entities;
using Rabbit.Respository;
using Rabbit.Respository.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IRabbitMessageRepository, RabbitMessageRepository>();
builder.Services.AddTransient<IRabbitMessageService, RabbitMessageService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Rabbit",
        Version = "v1",
        Description = "Rabbit",
        Contact = new OpenApiContact()
        {
            Name = "Maro de Melo",
            Email = "marodemelo10@gmail.com"
        },
        License = new OpenApiLicense()
        {
            Name = "SB1 Soluções em tecnologia"
        }
    });        
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
