using Application.DTOs;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Application.Guest.Responses;
using Application.Room.Ports;
using Application.Room.Requests;
using Application.Room.Responses;
using Domain.Guest.Exceptions;
using Domain.Room.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class RoomManager : IRoomManager
    {
        private readonly IRoomRepository _roomRepository;
        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task<RoomResponse> CreateRoom(CreateRoomRequest request)
        {
            try
            {
                var room = RoomDTO.MapToEntity(request.Data);

                await room.Save(_roomRepository);

                request.Data.Id = room.Id;

                return new RoomResponse
                {
                    Success = true,
                    Data = request.Data
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

        public async Task<RoomResponse> GetRoom(int roomId)
        {
           var room = await _roomRepository.Get(roomId);
            if (room == null)
            {
                return new RoomResponse
                {
                    Success = false,
                    //ErrorCode = ErrorCode.ROOM_NOT_FOUND,
                    Message = "Nenhum registro foi encontrado para o id " + roomId.ToString()
                };
            }
            return new RoomResponse { Success = true, Data = RoomDTO.MapToDTO(room) };
        }
    }
}
