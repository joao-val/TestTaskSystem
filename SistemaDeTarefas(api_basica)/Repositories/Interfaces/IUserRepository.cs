﻿using SistemaDeTarefas_api_basica_.Models;

namespace SistemaDeTarefas_api_basica_.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsersAsync();
        Task<UserModel> GetUserByIdAsync(int id);
        Task<UserModel> AddUserAsync(UserModel user);
        Task<UserModel> UpdateUserAsync(UserModel user, int id);
        Task<bool> DeleteUserAsync(int id);
    }
}
