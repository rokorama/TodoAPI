using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("api")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    private readonly ILogger<UserController> _logger;

    public UserController(IUserRepository userRepository, ILogger<UserController> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }
    
    [HttpGet("user/{id}")]
    public ActionResult<User> GetUser([FromRoute] Guid id)
    {
        var result = _userRepository.GetUser(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost("user")]
    public ActionResult<User> PostUser([FromBody] UserDto userDto)
    {
        var result = _userRepository.PostUser(userDto);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}