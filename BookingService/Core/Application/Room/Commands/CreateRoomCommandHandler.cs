using Application.Room.DTOs;
using Application.Room.Responses;
using Domain.Guest.Exceptions;
using Domain.Room.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Room.Commands
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, RoomResponse>
    {
        private readonly IRoomRepository _roomRepository;
        public CreateRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<RoomResponse> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var room = RoomDTO.MapToEntity(request.RoomDTO);

                await room.Save(_roomRepository);

                request.RoomDTO.Id = room.Id;

                return new RoomResponse
                {
                    Success = true,
                    Data = request.RoomDTO
                };
            }
            catch (MissingRequiredException e)
            {
                return new RoomResponse
                {
                    Success = false,
                    Message = "Missing required information",
                    //ErrorCode = ErrorCode.ROOM_MISSING_REQUIRED_INFORMATION

                };
            }
            catch (Exception ex)
            {
                return new RoomResponse
                {
                    Success = false,
                    Message = ex.Message,
                    //ErrorCode = ErrorCode.ROOM_COULD_NOT_STORE_DATA

                };
            }
        }
    }
}
