using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Features.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web.Controllers;

public class TaskController : Controller
{
    private readonly ITaskRepository _repo;
    private readonly CreateTaskHandler _createHandler;

    public TaskController(ITaskRepository repo, CreateTaskHandler createHandler)
    {
        _repo = repo;
        _createHandler = createHandler;
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
}
