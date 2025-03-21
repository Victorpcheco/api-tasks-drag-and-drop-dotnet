using Api.Data;
using Api.Models;

namespace Api.Repository;

public class TaskRepository : ITaskRepository 
{
    private readonly DataContext _context;

    public TaskRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<TaskModel> AddTaskAsync(TaskModel task)
    {
        _context.Tb_Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }
}