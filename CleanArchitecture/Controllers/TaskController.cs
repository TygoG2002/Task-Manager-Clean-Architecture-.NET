using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Features;
using CleanArchitecture.Application.Features.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Controllers;

public class TaskController : Controller
{
    private readonly ITaskRepository _repo;
    private readonly CreateTaskHandler _createHandler;
    private readonly UpdateTaskHandler _updateTaskHandler;

    public TaskController(ITaskRepository repo, CreateTaskHandler createHandler, UpdateTaskHandler _updateTaskHandler)
    {
        _repo = repo;
        _createHandler = createHandler;
        this._updateTaskHandler = _updateTaskHandler;
    }

    public async Task<IActionResult> Index()
    {
        var tasks = await _repo.GetAllAsync();
        return View(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> Create(string title)
    {
        await _createHandler.Handle(new CreateTaskCommand { Title = title });
        return RedirectToAction("Index");
    }


    [HttpPost]
    public async Task<IActionResult> CompletedTask(int id, bool isCompleted)
    {
        await _updateTaskHandler.Execute(new UpdateTaskCommand { Id = id, IsCompleted = isCompleted });
        return RedirectToAction("Index");
    }
}
