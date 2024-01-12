using Application.DTOs;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Application.Guest.Responses;
using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class GuestManager : IGuestManager
    {
        private readonly IGuestRepository _guestRepository;
        public GuestManager(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }
        public async Task<GuestResponse> CreateGuest(CreateGuestRequest request)
        {
            try
            {
                var guest = GuestDTO.MapToEntity(request.Data);
                request.Data.Id = await _guestRepository.Create(guest);

                return new GuestResponse
                {
                    Success = true,
                    Data = request.Data
                };
            }
            catch (Exception ex)
            {
                return new GuestResponse
                {
                    Success = false,                    
                    Message = ex.Message,
                    ErrorCode = Guest.ErrorCode.COULD_NOT_STORE_DATA

                };
            }
           
        }
    }
}
