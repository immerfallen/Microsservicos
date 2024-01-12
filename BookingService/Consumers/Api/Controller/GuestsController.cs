﻿using Application.DTOs;
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

            if(res.ErrorCode == ErrorCode.NOT_FOUND)
            {
                return BadRequest(res);
            }
            _logger.LogError("Response with unknokwn erro returned", res);
            return BadRequest(500);
        }

    }
}
