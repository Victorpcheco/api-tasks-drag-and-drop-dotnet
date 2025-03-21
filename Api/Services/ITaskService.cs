using Api.Models;

namespace Api.Services;

public interface ITaskService
{
    Task<TaskModel> CreateTaskAsync(TaskModel task);
    // ? = valor url 
    Task<TaskModel?> UpdateTaskAsync(TaskModel task);
    Task <IEnumerable<TaskModel>> GetAllTaskAsync();
    Task<bool> DeleteTaskAsync(int id);
    
}