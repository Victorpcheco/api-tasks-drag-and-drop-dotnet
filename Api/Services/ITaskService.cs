using Api.Models;

namespace Api.Services;

public interface ITaskService
{
    Task<TaskModel> CreateTaskAsync(TaskModel task);
}