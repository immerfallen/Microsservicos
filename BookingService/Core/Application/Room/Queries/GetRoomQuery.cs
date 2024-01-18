using Application.Room.DTOs;
using Application.Room.Responses;
using Domain.Room.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Room.Queries
{
    public class GetRoomQuery : IRequest<RoomResponse>
    {
        public int Id { get; set; }

    }

    public class GetRoomQueryHandler : IRequestHandler<GetRoomQuery, RoomResponse>
    {
        private readonly IRoomRepository _roomRepository;
        public GetRoomQueryHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<RoomResponse> Handle(GetRoomQuery request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.Get(request.Id);
            if (room == null)
            {
                return new RoomResponse
                {
                    Success = false,
                    //ErrorCode = ErrorCode.ROOM_NOT_FOUND,
                    Message = "Nenhum registro foi encontrado para o id " + request.Id.ToString()
                };
            }
            return new RoomResponse { Success = true, Data = RoomDTO.MapToDTO(room) };
        }
    }
}
