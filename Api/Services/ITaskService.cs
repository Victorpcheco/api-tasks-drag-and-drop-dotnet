using Api.Models;

namespace Api.Services;

public interface ITaskService
{
    Task<TaskModel> CreateTaskAsync(TaskModel task);
    Task<TaskModel?> UpdateTaskAsync(TaskModel task);
    
    // porque da interrogação? 
}