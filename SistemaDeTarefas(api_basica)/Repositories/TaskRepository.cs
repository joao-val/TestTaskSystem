using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas_api_basica_.Data;
using SistemaDeTarefas_api_basica_.Models;
using SistemaDeTarefas_api_basica_.Repositories.Interfaces;

namespace SistemaDeTarefas_api_basica_.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly SistemaDeTarefasDBContext _dbContext;

        public TaskRepository(SistemaDeTarefasDBContext sistemaDeTarefasDBContext)
        {
            _dbContext = sistemaDeTarefasDBContext;
        }

        public async Task<TaskModel> GetTaskByIdAsync(int id)
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TaskModel>> GetAllTasksAsync()
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<TaskModel> AddTaskAsync(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<TaskModel> UpdateTaskAsync(TaskModel task, int id)
        {
            TaskModel taskById = await GetTaskByIdAsync(id);

            if (taskById == null)
            {
                throw new Exception($"Task for this ID: {id} was not found in the dataBase.");
            }

            taskById.Name = task.Name;
            taskById.Description = task.Description;
            taskById.Status = task.Status;
            taskById.UserId = task.UserId;

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            TaskModel taskById = await GetTaskByIdAsync(id);

            if (taskById == null)
            {
                throw new Exception($"Task for this ID: {id} was not found in the dataBase.");
            }

            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}