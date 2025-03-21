using Api.Models;
using Api.Repository;
using Api.Validators;
using FluentValidation;

namespace Api.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;
    private readonly IValidator<TaskModel> _validator;


    public TaskService(ITaskRepository repository, IValidator<TaskModel> validator)
    {
        _repository = repository;
        _validator = validator;
    }


    public async Task<TaskModel> CreateTaskAsync(TaskModel task)
    {
        var validationResult = _validator.Validate(task);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors); 
        }
        return await _repository.AddTaskAsync(task);
    }

    public async Task<TaskModel?> UpdateTaskAsync(TaskModel task)
    {
        var validator = new TaskModelValidator();
        var validationResult = validator.Validate(task);
    
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        return await _repository.UpdateTaskAsync(task);
    }
    
}