namespace TodoApi.Models;

public class TodoTaskDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime EndDate { get; set; }
    public bool Completed { get; set; }
    public Guid UserId { get; set; }
}