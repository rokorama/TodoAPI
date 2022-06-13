using AutoFixture.Xunit2;
using Microsoft.Extensions.Logging;
using Moq;
using TodoApi.Contexts;
using TodoApi.Controllers;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Tests;

public class UnitTest1
{
    [Theory, AutoData]
    public void Repository_GetTask_Returns_TodoTask_Object(TodoTask todoTask)
    {
        // Assert
        var contextMock = new Mock<TodoTaskContext>();
        var repoMock = new Mock<ITodoTaskRepository>();
        var loggerMock = new Mock<ILogger<TodoTaskController>>();
        var sut = new TodoTaskController(repoMock.Object, loggerMock.Object);
        repoMock.Setup(x => x.GetTask(It.IsAny<Guid>())).Returns(todoTask);
        // Act
        var testResponse = sut.GetTask(It.IsAny<Guid>()).Value;
        //Assert
        Assert.Equal(testResponse, todoTask);
    }
}