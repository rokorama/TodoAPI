using TodoApi.Models;

namespace TodoApi.Services;

static public class DtoToEntityMapper
{
    static public TodoTask MapDtoToEntity(TodoTaskDto taskDto, Guid taskId = default)
    {
        var result = new TodoTask
        {
            Title = taskDto.Title,
            Content = taskDto.Content,
            EndDate = taskDto.EndDate,
            Completed = taskDto.Completed,
            UserId = taskDto.UserId
        };

        // if (taskId == default)
        // {
        //     result.Id = Guid.NewGuid();
        // }
        // else
        // {
        //     result.Id = taskId;
        // }

        return result;
    }

    static public User MapDtoToEntity(UserDto userDto)
    {
        var result = new User
        {
            // Id = Guid.NewGuid(),
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
        };

        return result;
    }
}