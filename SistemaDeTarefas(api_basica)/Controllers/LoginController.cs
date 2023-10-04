using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas_api_basica_.Authorization;
using SistemaDeTarefas_api_basica_.Data;
using SistemaDeTarefas_api_basica_.Models;
using SistemaDeTarefas_api_basica_.Repositories;

namespace SistemaDeTarefas_api_basica_.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        private readonly SistemaDeTarefasDBContext _dbContext;
        private UserAuthRepository _userAuthRepository;

        public LoginController(SistemaDeTarefasDBContext sistemaDeTarefasDBContext, UserAuthRepository userAuthRepository)
        {
            _dbContext = sistemaDeTarefasDBContext;
            _userAuthRepository = userAuthRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] UserAuthModel model)
        {   
            
            // Recupera o usuário
            var userAuth = await _userAuthRepository.GetUserAuthAsync(model.Username, model.Password);

            // Verifica se o usuário existe
            if (User == null)
                return NotFound(new { message = "Invalid user or password" });

            // Gera o Tokan
            var token = TokenService.GenetareToken(userAuth);

            // Oculta a senha
            userAuth.Password = "";

            // Retorna os dados
            return new
            {
                userAuth = userAuth,
                token = token
            };
        }
    }
}