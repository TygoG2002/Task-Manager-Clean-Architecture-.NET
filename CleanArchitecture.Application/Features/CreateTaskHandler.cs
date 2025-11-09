using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Tasks;

public class CreateTaskCommand
{
    public string Title { get; set; } = string.Empty;
}

public class CreateTaskHandler
{
    private readonly ITaskRepository _repo;

    public CreateTaskHandler(ITaskRepository repo)
    {
        _repo = repo;
    }

    public async Task<TaskItem> Handle(CreateTaskCommand command)
    {
        var task = new TaskItem { Title = command.Title };
        await _repo.AddAsync(task);
        return task;
    }
}
