using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas_api_basica_.Models;
using SistemaDeTarefas_api_basica_.Repositories.Interfaces;

namespace SistemaDeTarefas_api_basica_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> SearchAllTasks()
        {
            List<TaskModel> tasks = await _taskRepository.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> SearchTaskById(int id)
        {
            TaskModel task = await _taskRepository.GetTaskByIdAsync(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> RegisterTask([FromBody] TaskModel taskModel)
        {
            TaskModel task = await _taskRepository.AddTaskAsync(taskModel);
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> UpdateTask([FromBody] TaskModel taskModel, int id)
        {
            taskModel.Id = id;
            TaskModel task = await _taskRepository.UpdateTaskAsync(taskModel, id);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> DeleteTask(int id)
        {
            bool delete = await _taskRepository.DeleteTaskAsync(id);
            return Ok(delete);
        }
    }
}
