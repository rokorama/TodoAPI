using TodoApi.Contexts;
using TodoApi.Models;

namespace TodoApi.Services;

public class UserRepository : IUserRepository
{
    private readonly TodoTaskContext _todoTaskContext;

    public UserRepository(TodoTaskContext todoTaskContext)
    {
        _todoTaskContext = todoTaskContext;
    }

    public User GetUser(Guid id)
    {
        return _todoTaskContext.Users.Find(id);
    }

    public User PostUser(UserDto userDto)
    {
        var newEntry = DtoToEntityMapper.MapDtoToEntity(userDto);
        _todoTaskContext.Users.Add(newEntry);
        _todoTaskContext.SaveChanges();
        return newEntry;
    }
}