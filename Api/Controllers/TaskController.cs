using Api.Models;
using Api.Services;
using Api.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
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

    [HttpPost("update")]
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
}