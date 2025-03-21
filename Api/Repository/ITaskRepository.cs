using Api.Models;

namespace Api.Repository;

public interface ITaskRepository
{
    Task<TaskModel> AddTaskAsync(TaskModel task); 
    Task<TaskModel> UpdateTaskAsync(TaskModel task);
    Task<IEnumerable<TaskModel>> GetAllTaskAsync();
    Task<TaskModel> GetTaskByIdAsync(int id);
    Task DeleteTaskAsync(TaskModel task);
}