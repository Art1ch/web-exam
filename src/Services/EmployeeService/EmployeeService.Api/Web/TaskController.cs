using EmployeeService.Api.Models.Task;
using EmployeeService.Application.Commands.Task.Create;
using EmployeeService.Application.Commands.Task.Delete;
using EmployeeService.Application.Commands.Task.Update;
using EmployeeService.Application.Filters;
using EmployeeService.Application.Pagination;
using EmployeeService.Application.Queries.Task.Get;
using EmployeeService.Application.Queries.Task.GetEntities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Api.Web;

[Route("tasks")]
public sealed class TaskController : Controller
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public TaskController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index(
        PaginationParams paginationParams,
        TaskFilter taskFilter
    )
    {
        var query = new GetTaskEntitiesQuery(taskFilter, paginationParams);

        var queryResult = await _sender.Send(query);

        var model = _mapper.Map<TaskIndexViewModel>(queryResult);

        model.Filter = taskFilter;
        model.Pagination = paginationParams;

        return View(model);
    }

    [HttpGet("create")]
    public IActionResult Create(int employeeId)
    {
        return View(new TaskCreateViewModel()
        {
            EmployeeId = employeeId
        });
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TaskCreateViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var command = _mapper.Map<CreateTaskCommand>(model);

        await _sender.Send(command);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("{id:int}/update")]
    public async Task<IActionResult> Update(int id)
    {
        var query = new GetTaskQuery(id);

        var queryResult = await _sender.Send(query);

        var model = _mapper.Map<TaskUpdateViewModel>(queryResult);

        return View(model);
    }

    [HttpPost("{id:int}/update")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, TaskUpdateViewModel model)
    {
        if (id != model.Id)
            return BadRequest();

        if (!ModelState.IsValid)
            return View(model);

        var command = _mapper.Map<UpdateTaskCommand>(model);

        await _sender.Send(command);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("{id:int}/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new GetTaskQuery(id);

        var queryResult = await _sender.Send(query);

        var model = _mapper.Map<TaskDeleteViewModel>(queryResult);

        return View(model);
    }

    [HttpPost("{id:int}/delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var command = new DeleteTaskCommand(id);

        await _sender.Send(command);

        return RedirectToAction(nameof(Index));
    }
}
