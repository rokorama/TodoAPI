using TodoApi.Models;

namespace TodoApi.Services;

public interface ITodoTaskRepository
{
    public TodoTask PostTask(TodoTaskDto taskDto);
    public IEnumerable<TodoTask> GetTask();
    public TodoTask GetTask(Guid id);
    public TodoTask PutTask(Guid id, TodoTaskDto taskDto);
    public TodoTask DeleteTask(Guid id);
}