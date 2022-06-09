using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("todo/api")]
public class TodoTaskController : ControllerBase
{
    private readonly ITodoTaskRepository _todoTaskRepository;

    public TodoTaskController(ITodoTaskRepository todoTaskRepository)
    {
        _todoTaskRepository = todoTaskRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TodoTask>> GetTask()
    {
        var result = _todoTaskRepository.GetTask();
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
    
    [HttpGet("id")]
    public ActionResult<TodoTask> GetTask([FromQuery] Guid id)
    {
        var result = _todoTaskRepository.GetTask(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<TodoTask> PostTask(TodoTaskDto taskDto)
    {
        var result = _todoTaskRepository.PostTask(taskDto);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPut("id")]
    public ActionResult<TodoTask> PutTask(TodoTaskDto taskDto, Guid id)
    {
        var result = _todoTaskRepository.PutTask(id, taskDto);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }



    [HttpDelete("id")]
    public ActionResult<TodoTask> DeleteTask([FromQuery] Guid id)
    {
        var result = _todoTaskRepository.DeleteTask(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}