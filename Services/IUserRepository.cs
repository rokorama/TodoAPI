using TodoApi.Contexts;
using TodoApi.Models;

namespace TodoApi.Services;

public interface IUserRepository
{
    public User PostUser(UserDto userDto);
    public User GetUser(Guid id);
}