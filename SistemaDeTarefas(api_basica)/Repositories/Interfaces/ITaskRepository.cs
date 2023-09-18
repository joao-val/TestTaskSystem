using SistemaDeTarefas_api_basica_.Models;

namespace SistemaDeTarefas_api_basica_.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> GetAllTasksAsync();

        Task<TaskModel> GetTaskByIdAsync(int id);

        Task<TaskModel> AddTaskAsync(TaskModel task);

        Task<TaskModel> UpdateTaskAsync(TaskModel task, int id);

        Task<bool> DeleteTaskAsync(int id);
    }
}