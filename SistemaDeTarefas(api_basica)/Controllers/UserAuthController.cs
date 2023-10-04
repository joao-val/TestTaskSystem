using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas_api_basica_.Models;
using SistemaDeTarefas_api_basica_.Repositories;
using SistemaDeTarefas_api_basica_.Repositories.Interfaces;

namespace SistemaDeTarefas_api_basica_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly UserAuthRepository _userAuthRepository;

        public UserAuthController(UserAuthRepository userRepository)
        {
            _userAuthRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserAuthModel>>> SearchAllUserAuths()
        {
            List<UserAuthModel> users = await _userAuthRepository.GetAllUserAuthAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserAuthModel>> SearchUserAuthById(int id)
        {
            UserAuthModel user = await _userAuthRepository.GetUserAuthByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserAuthModel>> RegisterUserAuth([FromBody] UserAuthModel userAuthModel)
        {
            UserAuthModel user = await _userAuthRepository.AddUserAuthAsync(userAuthModel);
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<UserAuthModel>> UpdateUserAuth([FromBody] UserAuthModel userAuthModel, string username, string password)
        {
            userAuthModel.Username = username;
            userAuthModel.Password = password;
            UserAuthModel user = await _userAuthRepository.UpdateUserAuthAsync(userAuthModel, username, password);
            return Ok(user);
        }

        [HttpDelete]
        public async Task<ActionResult<UserAuthModel>> DeleteUser(string username, string password)
        {
            bool delete = await _userAuthRepository.DeleteUserAuthAsync(username, password);
            return Ok(delete);
        }
    }
}