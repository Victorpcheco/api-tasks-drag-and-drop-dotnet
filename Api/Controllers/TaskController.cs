using Api.Dto;
using Api.Models;
using Api.Services;
using Api.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/tasks")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskService _service;
    
    public TaskController(ITaskService taskService)
    {
        _service = taskService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTaskAsync([FromBody] TaskModel task)
    {
        try
        {
            var createdTask = await _service.CreateTaskAsync(task);
            //return Created("api/task/create", createdTask);
            return Ok(createdTask);
        }
        catch (ValidationException exception)
        {
            return BadRequest(new { errors = exception.Errors.Select(exception => exception.ErrorMessage)});
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTaskAsync(int id, [FromBody] TaskModel task)
    {

        try
        {
            task.Id = id;
            var updatedTask = await _service.UpdateTaskAsync(task);

            if (updatedTask == null)
            {
                return NotFound("Tarefa não encontrada");
            }

            return Ok(updatedTask);
        }
        catch (ValidationException exception)
        {
            return BadRequest(exception.Errors.Select(exception => exception.ErrorMessage));
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskModel>>> GetAllTasks()
    {
        var tasks = await _service.GetAllTaskAsync();

        if (tasks == null || !tasks.Any())
        {
            return NotFound("Nenhuma tarefa encontrada!");
        }
        return Ok(tasks);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var deletedTask = await _service.DeleteTaskAsync(id);

        if (!deletedTask)
            return NotFound("Nenhuma tarefa encontrada!");
        
        return NoContent();
    }

    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatusAsync(int id, [FromBody] UpdateTaskDto dto)
    {
        var validator = new UpdateTaskStatusValidator();
        var validationResult = validator.Validate(dto);
        
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        
        
        var updated = await _service.UpdateStatusAsync(id, dto.Status);
        
        if  (!updated)
            return NotFound("Nenhuma tarefa encontrada!");
        
        return NoContent();
    }
}