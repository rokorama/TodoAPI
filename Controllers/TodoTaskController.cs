using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("api")]
public class TodoTaskController : ControllerBase
{
    private readonly ITodoTaskRepository _todoTaskRepository;

    public TodoTaskController(ITodoTaskRepository todoTaskRepository)
    {
        _todoTaskRepository = todoTaskRepository;
    }


    [HttpGet("task")]
    public ActionResult<IEnumerable<TodoTask>> GetTask()
    {
        var result = _todoTaskRepository.GetTask();
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    
    [HttpGet("task/{id}")]
    public ActionResult<TodoTask> GetTask([FromRoute] Guid id)
    {
        var result = _todoTaskRepository.GetTask(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost("task")]
    public ActionResult<TodoTask> PostTask([FromBody] TodoTaskDto taskDto)
    {
        var result = _todoTaskRepository.PostTask(taskDto);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPut("task/{id}")]
    public ActionResult<TodoTask> PutTask([FromBody] TodoTaskDto taskDto, [FromRoute] Guid id)
    {
        var result = _todoTaskRepository.PutTask(id, taskDto);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpDelete("task/{id}")]
    public ActionResult<TodoTask> DeleteTask([FromRoute] Guid id)
    {
        var result = _todoTaskRepository.DeleteTask(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}