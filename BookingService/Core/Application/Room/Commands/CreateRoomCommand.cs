using Application.Room.DTOs;
using Application.Room.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Room.Commands
{
    public class CreateRoomCommand : IRequest<RoomResponse>
    {
        public RoomDTO RoomDTO { get; set; }
    }
}
