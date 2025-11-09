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
    private readonly DeleteTaskHandler _deleteTaskHandler;

    public TaskController(ITaskRepository repo, CreateTaskHandler createHandler, UpdateTaskHandler _updateTaskHandler, DeleteTaskHandler deleteTaskHandler)
    {
        _repo = repo;
        _createHandler = createHandler;
        this._updateTaskHandler = _updateTaskHandler;
        _deleteTaskHandler = deleteTaskHandler;
    }

    public async Task<IActionResult> Index()
    {
        var tasks = await _repo.GetAllAsync();
        return View(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> Create(string title)
    {
        await _createHandler.Execute(new CreateTaskCommand { Title = title });
        return RedirectToAction("Index");
    }


    [HttpPost]
    public async Task<IActionResult> CompletedTask(int id, bool isCompleted)
    {
        await _updateTaskHandler.Execute(new UpdateTaskCommand { Id = id, IsCompleted = isCompleted });
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _deleteTaskHandler.Execute(new DeleteTaskCommand { Id = id });
        return RedirectToAction("Index");
    }

}
