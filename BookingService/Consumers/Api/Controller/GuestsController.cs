using Application.DTOs;
using Application.Guest;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{
    [ApiController]
    [Route("controller")]
    public class GuestsController : ControllerBase
    {
        private readonly ILogger<GuestsController> _logger;
        private readonly IGuestManager _guestManager;

        public GuestsController(ILogger<GuestsController> logger, IGuestManager guestManager)
        {
            _logger = logger;
            _guestManager = guestManager;
        }

        [HttpPost]
        public async Task<ActionResult<GuestDTO>> Post(GuestDTO guest)
        {
            var request = new CreateGuestRequest
            {
                Data = guest
            };                   

            var res = await _guestManager.CreateGuest(request);

            if(res.Success) return Created("", res);

            if(res.ErrorCode == ErrorCode.COULD_NOT_STORE_DATA)
            {
                return BadRequest(res);
            }
            if (res.ErrorCode == ErrorCode.INVALID_EMAIL)
            {
                return BadRequest(res);
            }
            if (res.ErrorCode == ErrorCode.MISSING_REQUIRED_INFORMATION)
            {
                return BadRequest(res);
            }
            if (res.ErrorCode == ErrorCode.INVALID_DOCUMENT)
            {
                return BadRequest(res);
            }
            if (res.ErrorCode == ErrorCode.NOT_FOUND)
            {
                return NotFound(res);
            }
            _logger.LogError("Response with unknokwn error returned", res);
            return BadRequest(500);
        }

        [HttpGet]
        public async Task<ActionResult<GuestDTO>> Get(int guestId)
        {
            var res = await _guestManager.GetGuest(guestId);

            if (res.Success) return Ok(res.Data);

            return NotFound(res);
        }

    }
}
