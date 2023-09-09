using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas_api_basica_.Data;
using SistemaDeTarefas_api_basica_.Models;
using SistemaDeTarefas_api_basica_.Repositories.Interfaces;

namespace SistemaDeTarefas_api_basica_.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SistemaDeTarefasDBContext _dbContext;

        public UserRepository(SistemaDeTarefasDBContext sistemaDeTarefasDBContext)
        {
            _dbContext = sistemaDeTarefasDBContext;
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> AddUserAsync(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> UpdateUserAsync(UserModel user, int id)
        {
            UserModel userById = await GetUserByIdAsync(id);

            if(userById == null)
            {
                throw new Exception($"User for this ID: {id} was not found in the dataBase.");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            UserModel userById = await GetUserByIdAsync(id);

            if (userById == null)
            {
                throw new Exception($"User for this ID: {id} was not found in the dataBase.");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
