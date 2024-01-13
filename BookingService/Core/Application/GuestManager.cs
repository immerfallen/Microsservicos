using Application.DTOs;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Application.Guest.Responses;
using Domain.Exceptions;
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

                await guest.Save(_guestRepository);

                request.Data.Id = guest.Id;

                return new GuestResponse
                {
                    Success = true,
                    Data = request.Data
                };
            }
            catch (InvalidDocumentException e)
            {
                return new GuestResponse
                {
                    Success = false,
                    Message = "Document Id is not valid",
                    ErrorCode = Guest.ErrorCode.INVALID_DOCUMENT

                };
            }
            catch (MissingRequiredException e)
            {
                return new GuestResponse
                {
                    Success = false,
                    Message = "Missing required information",
                    ErrorCode = Guest.ErrorCode.MISSING_REQUIRED_INFORMATION

                };
            }
            catch (InvalidEmailException e)
            {
                return new GuestResponse
                {
                    Success = false,
                    Message = "Invalid Email",
                    ErrorCode = Guest.ErrorCode.INVALID_EMAIL

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
