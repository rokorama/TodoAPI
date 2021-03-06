using Microsoft.EntityFrameworkCore;
using TodoApi.Contexts;
using TodoApi.Models;

namespace TodoApi.Services;

public class TodoTaskRepository : ITodoTaskRepository
{
    private readonly TodoTaskContext _todoTaskContext;

    public TodoTaskRepository(TodoTaskContext todoTaskContext)
    {
        _todoTaskContext = todoTaskContext;
    }
    
    public IEnumerable<TodoTask> GetTask()
    {
        return _todoTaskContext.TodoTasks;
    }

    public TodoTask GetTask(Guid id)
    {
        return _todoTaskContext.TodoTasks.Find(id);
    }

    public TodoTask PostTask(TodoTaskDto taskDto)
    {
        var newEntry = DtoToEntityMapper.MapDtoToEntity(taskDto);
        var parentUser = _todoTaskContext.Users.Where(u => u.Id == taskDto.UserId).First();    

        if (parentUser.Tasks == null)
        {
            parentUser.Tasks = new List<TodoTask>();
        }
        parentUser.Tasks.Add(newEntry);
        // _todoTaskContext.Entry(taskDto.UserId).CurrentValues.SetValues(parentUser);

        // _todoTaskContext.Entry(parentUser).State = EntityState.Modified;
        _todoTaskContext.SaveChanges();
        return newEntry;
    }

    public TodoTask PutTask(Guid id, TodoTaskDto taskDto)
    {
        var updatedEntry = DtoToEntityMapper.MapDtoToEntity(taskDto, id);
        var databaseEntry = _todoTaskContext.TodoTasks.Find(id);
        _todoTaskContext.Entry(databaseEntry).CurrentValues.SetValues(updatedEntry);
        _todoTaskContext.SaveChanges();
        return updatedEntry;
    }

    public TodoTask DeleteTask(Guid id)
    {
        var entryToDelete = _todoTaskContext.TodoTasks.Find(id);
        // error handling needed
        _todoTaskContext.TodoTasks.Remove(entryToDelete);
        _todoTaskContext.SaveChanges();
        return entryToDelete;
    }
}