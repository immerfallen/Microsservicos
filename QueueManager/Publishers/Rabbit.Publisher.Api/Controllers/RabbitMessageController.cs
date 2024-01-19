using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rabbit.Application.Interfaces;
using Rabbit.Domain.Entities;

namespace Rabbit.Publisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitMessageController : ControllerBase
    {
        private readonly IRabbitMessageService _service;
        public RabbitMessageController(IRabbitMessageService service)
        {
            _service = service;
        }
        [HttpPost]
        public void AddMessage(RabbitMessage message) 
        {
            _service.SendMessage(message);
        }
    }
}
