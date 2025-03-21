using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

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

    public async Task<TaskModel> UpdateTaskAsync(TaskModel task)
    {
        var existingTask = await _context.Tb_Tasks.FindAsync(task.Id);
        if (existingTask == null)
        {
            return null;
        }
        
        existingTask.Titulo = task.Titulo;
        existingTask.Status = task.Status;
        existingTask.Descricao = task.Descricao;
        
        await _context.SaveChangesAsync();
        return existingTask;
    }

    public async Task<IEnumerable<TaskModel>> GetAllTaskAsync()
    {
        return await _context.Tb_Tasks.ToListAsync();
    }
    
}