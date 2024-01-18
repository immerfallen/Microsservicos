using Application;
using Application.Guest.DTOs;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Application.Guest.Responses;
using Application.Room.Requests;
using Application.Room.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/controller")]
    [Produces("application/json")]
    public class GuestsController : ControllerBase
    {
        private readonly ILogger<GuestsController> _logger;
        private readonly IGuestManager _guestManager;

        public GuestsController(ILogger<GuestsController> logger, IGuestManager guestManager)
        {
            _logger = logger;
            _guestManager = guestManager;
        }


        /// <summary>
        ///  Creates a new Guest
        /// </summary>
        /// <param name="guest"></param>
        /// <returns>Returns the newly added Guest</returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///{       
        ///     
        ///"name": "string",
        ///
        ///"surName": "string",
        ///
        ///"email": "string",
        ///
        ///"idNumber": "string",
        ///
        ///"idTypeCode": 0
        ///
        ///}
        ///    
        /// </remarks>
        /// <response code="201">Returns the newly created guest</response>
        /// <response code="400"> 
        /// Lista de erros codes:
        /// 
        /// COULD_NOT_STORE_DATA = 2 Houve um erro desconhecido ao inserir os dados
        /// 
        /// INVALID_DOCUMENT = 3 = Validação de documento não passou - document.length >= 3
        /// 
        /// MISSING_REQUIRED_INFORMATION = 4 Nome, sobrenome e email obrigatórios
        /// 
        /// INVALID_EMAIL = 5 Email inválido
        /// 
        /// </response>
        [ProducesResponseType(typeof(GuestResponse), 201)]
        [ProducesResponseType(typeof(GuestResponse), 400)]
        [ProducesResponseType(500)]
        [HttpPost("/guest/save")]
        public async Task<ActionResult<GuestDTO>> Post(GuestDTO guest)
        {
            var request = new CreateGuestRequest
            {
                Data = guest
            };

            var res = await _guestManager.CreateGuest(request);

            if (res.Success) return Created("", res);

            //if (res.ErrorCode == ErrorCode.GUEST_COULD_NOT_STORE_DATA)
            //{
            //    return BadRequest(res);
            //}
            //if (res.ErrorCode == ErrorCode.GUEST_INVALID_EMAIL)
            //{
            //    return BadRequest(res);
            //}
            //if (res.ErrorCode == ErrorCode.GUEST_MISSING_REQUIRED_INFORMATION)
            //{
            //    return BadRequest(res);
            //}
            //if (res.ErrorCode == ErrorCode.GUEST_INVALID_DOCUMENT)
            //{
            //    return BadRequest(res);
            //}
            //if (res.ErrorCode == ErrorCode.GUEST_NOT_FOUND)
            //{
            //    return NotFound(res);
            //}
            _logger.LogError("Response with unknokwn error returned", res);
            return BadRequest(500);
        }


        /// <summary>
        ///  Get Guest by id
        /// </summary>
        /// <param name="guestId">Id guest</param>
        /// <returns>Returns the Guest with given id</returns>
        /// 
        /// <response code="200">Returns the guest with given id</response>
        /// <response code="404"> 
        ///Guest with the given id was not found
        /// </response>
        [ProducesResponseType(typeof(RoomResponse), 200)]
        [ProducesResponseType(typeof(RoomResponse), 404)]
        [HttpGet("guest/get")]
        public async Task<ActionResult<GuestDTO>> Get(int guestId)
        {
            var res = await _guestManager.GetGuest(guestId);

            if (res.Success) return Ok(res.Data);

            return NotFound(res);
        }

        public class ValidateModelAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext actionContext)
            {
                if (actionContext.ModelState.IsValid == false)
                {
                    if (actionContext.ModelState.IsValid) return;
                    string errors = actionContext.ModelState.SelectMany(state => state.Value.Errors).Aggregate("", (current, error) => current + (error.ErrorMessage + ". "));
                }
            }
        }

    }
}
