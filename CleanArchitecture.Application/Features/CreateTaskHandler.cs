using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Tasks;

public class CreateTaskCommand
{
    public string Title { get; set; } = string.Empty;
}

public class CreateTaskHandler
{
    private readonly ITaskRepository ITaskRepository;

    public CreateTaskHandler(ITaskRepository repo)
    {
        ITaskRepository = repo;
    }

    public async Task<TaskItem> Execute(CreateTaskCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Title))
        {
            throw new ArgumentException("Task title cannot be empty.");
        }
        var task = new TaskItem { Title = command.Title };
        await ITaskRepository.AddAsync(task);
        return task;
    }
}
