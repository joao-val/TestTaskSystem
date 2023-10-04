using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas_api_basica_.Data;
using SistemaDeTarefas_api_basica_.Models;
using SistemaDeTarefas_api_basica_.Repositories.Interfaces;

namespace SistemaDeTarefas_api_basica_.Repositories
{
    public class UserAuthRepository : IUserAuthRepository
    {
        
        private readonly SistemaDeTarefasDBContext _dbContext;

        public UserAuthRepository(SistemaDeTarefasDBContext sistemaDeTarefasDBContext)
        {
            _dbContext = sistemaDeTarefasDBContext;
        }
        public static UserAuthModel Get(string username, string password)
        {
            var users = new List<UserAuthModel>
            {
                new() {Id = 1, Username = "batman", Password = "batman", Role = "manager"},
                new() {Id = 2, Username = "robin", Password = "robin", Role = "employee"}
            };
            return users
                .FirstOrDefault(x =>
                x.Username == username && x.Password == password);
        }

        public async Task<List<UserAuthModel>> GetAllUserAuthAsync()
        {
            return await _dbContext.userAuths.ToListAsync();
        }

        public async Task<UserAuthModel> GetUserAuthByIdAsync(int id)
        {
            return await _dbContext.userAuths.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserAuthModel> GetUserAuthAsync(string username, string password)
        {
            return await _dbContext.userAuths
                .FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        }

        public async Task<UserAuthModel> AddUserAuthAsync(UserAuthModel userAuth)
        {
            await _dbContext.userAuths.AddAsync(userAuth);
            await _dbContext.SaveChangesAsync();

            return userAuth;
        }

        public async Task<UserAuthModel> UpdateUserAuthAsync(UserAuthModel userAuth, string username, string password)
        {
            UserAuthModel userAuthById = await GetUserAuthAsync(username, password);

            if (userAuthById == null)
            {
                throw new Exception($"UserAuth: {username} was not found in dataBase.");
            }

            userAuthById.Username = userAuth.Username;
            userAuthById.Password = userAuth.Password;
            userAuthById.Role = userAuth.Role;

            _dbContext.userAuths.Update(userAuthById);
            await _dbContext.SaveChangesAsync();

            return userAuth;
        }

        public async Task<bool> DeleteUserAuthAsync(string username, string password)
        {
            UserAuthModel userAuthById = await GetUserAuthAsync(username, password);

            if (userAuthById == null)
            {
                throw new Exception($"UserAuth: {username} was not found in dataBase.");
            }

            _dbContext.userAuths.Remove(userAuthById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}