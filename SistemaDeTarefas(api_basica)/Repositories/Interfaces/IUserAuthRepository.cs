using SistemaDeTarefas_api_basica_.Models;

namespace SistemaDeTarefas_api_basica_.Repositories.Interfaces
{
    public interface IUserAuthRepository
    {
        Task<List<UserAuthModel>> GetAllUserAuthAsync();

        Task<UserAuthModel> GetUserAuthAsync(string username, string password);
        Task<UserAuthModel> GetUserAuthByIdAsync(int id);

        Task<UserAuthModel> AddUserAuthAsync(UserAuthModel task);

        Task<UserAuthModel> UpdateUserAuthAsync(UserAuthModel task, string username, string password);

        Task<bool> DeleteUserAuthAsync(string username, string password);
    }
}