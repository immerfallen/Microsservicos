using Application;
using Application.Room.DTOs;
using Application.Room.Ports;
using Application.Room.Requests;
using Application.Room.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/controller")]
    [Produces("application/json")]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRoomManager _roomManager;

        public RoomController(ILogger<RoomController> logger, IRoomManager RoomManager)
        {
            _logger = logger;
            _roomManager = RoomManager;
        }


        /// <summary>
        ///  Creates a new Room
        /// </summary>
        /// <param name="Room"></param>
        /// <returns>Returns the newly added Room</returns>
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
        /// <response code="201">Returns the newly created Room</response>
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
        [ProducesResponseType(typeof(RoomResponse), 201)]
        [ProducesResponseType(typeof(RoomResponse), 400)]
        [ProducesResponseType(500)]
        [HttpPost("room/save")]
        public async Task<ActionResult<RoomDTO>> Post(RoomDTO Room)
        {
            var request = new CreateRoomRequest
            {
                Data = Room
            };

            var res = await _roomManager.CreateRoom(request);

            if (res.Success) return Created("", res);

            //if (res.ErrorCode == ErrorCode.ROOM_COULD_NOT_STORE_DATA)
            //{
            //    return BadRequest(res);
            //}                    
            //if (res.ErrorCode == ErrorCode.ROOM_MISSING_REQUIRED_INFORMATION)
            //{
            //    return BadRequest(res);
            //}           
            _logger.LogError("Response with unknokwn error returned", res);
            return BadRequest(500);
        }


        /// <summary>
        ///  Get Room by id
        /// </summary>
        /// <param name="RoomId">Id Room</param>
        /// <returns>Returns the Room with given id</returns>
        /// 
        /// <response code="200">Returns the Room with given id</response>
        /// <response code="404"> 
        ///Room with the given id was not found
        /// </response>
        [ProducesResponseType(typeof(RoomResponse), 200)]
        [ProducesResponseType(typeof(RoomResponse), 404)]
        [HttpGet("room/get")]
        public async Task<ActionResult<RoomDTO>> Get(int roomId)
        {
            var res = await _roomManager.GetRoom(roomId);

            if (res.Success) return Ok(res.Data);

            return NotFound(res);
        }

    }
}
