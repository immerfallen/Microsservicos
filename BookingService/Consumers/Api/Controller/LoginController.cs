using Auth.Domain;
using Auth.Interfaces;
using Auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{

    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public LoginController(IUserRepository userManager, IConfiguration configuration)
        {
            _userRepository = userManager;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            // Recupera o usuário
            var user = await _userRepository.Get(model.UserName, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = new TokenService(_configuration).GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }
    }
}
