using System;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Features.Tasks;
using CleanArchitecture.Domain.Entities;
using Moq;
using Xunit;

namespace CleanArchitecture.Tests.Application.Features.Tasks
{
    public class CreateTaskHandlerTests
    {
        [Fact]
        public async Task Should_Create_Task_Successfully()
        {
            // Arrange
            var mockRepo = new Mock<ITaskRepository>();
            var handler = new CreateTaskHandler(mockRepo.Object);
            var command = new CreateTaskCommand { Title = "Workout" };

            // Act
            var result = await handler.Handle(command);

            // Assert
            Assert.Equal("Workout", result.Title);
            mockRepo.Verify(r => r.AddAsync(It.IsAny<TaskItem>()), Times.Once);
        }

        [Fact]
        public async Task Should_Throw_When_Title_Is_Empty()
        {
            // Arrange
            var mockRepo = new Mock<ITaskRepository>();
            var handler = new CreateTaskHandler(mockRepo.Object);
            var command = new CreateTaskCommand { Title = "" };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(command));
        }
    }
}
