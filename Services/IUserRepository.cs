using TodoApi.Contexts;
using TodoApi.Models;

namespace TodoApi.Services;

public interface IUserRepository
{
    public User PostTask(UserDto userDto);
    public User GetTask(Guid id);
}