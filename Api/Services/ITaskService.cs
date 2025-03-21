using Api.Models;

namespace Api.Services;

public interface ITaskService
{
    Task<TaskModel> CreateTaskAsync(TaskModel task);
    Task<TaskModel?> UpdateTaskAsync(TaskModel task);
    Task <IEnumerable<TaskModel>> GetAllTaskAsync();
    // porque da interrogação? 
}