using Api.Models;

namespace Api.Repository;

public interface ITaskRepository
{
    Task<TaskModel> AddTaskAsync(TaskModel task); 
}