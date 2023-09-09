using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas_api_basica_.Models;
using SistemaDeTarefas_api_basica_.Repositories.Interfaces;

namespace SistemaDeTarefas_api_basica_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> SearchAllUsers()
        {
            List<UserModel> users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> SearchUserById(int id)
        {
            UserModel user = await _userRepository.GetUserByIdAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> RegisterUser([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.AddUserAsync(userModel);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel user = await _userRepository.UpdateUserAsync(userModel, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int id)
        {
            bool delete = await _userRepository.DeleteUserAsync(id);
            return Ok(delete);
        }
    }
}
