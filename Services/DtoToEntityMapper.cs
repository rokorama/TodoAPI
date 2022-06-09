using TodoApi.Models;

namespace TodoApi.Services;

static public class DtoToEntityMapper
{
    static public TodoTask MapDtoToEntity(TodoTaskDto taskDto, Guid id = default)
    {
        var result = new TodoTask
        {
            Title = taskDto.Title,
            Content = taskDto.Content,
            EndDate = taskDto.EndDate,
            Completed = taskDto.Completed
        };

        if (id == default)
        {
            result.Id = Guid.NewGuid();
        }
        else
        {
            result.Id = id;
        }

        return result;
    }
}