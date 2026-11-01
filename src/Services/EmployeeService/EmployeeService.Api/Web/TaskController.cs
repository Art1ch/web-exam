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
public sealed class TaskController(
    IMapper mapper,
    ISender sender
) : Controller
{
    [HttpGet("")]
    public async Task<IActionResult> Index(
        PaginationParams paginationParams,
        TaskFilter taskFilter
    )
    {
        var query = new GetTaskEntitiesQuery(taskFilter, paginationParams);

        var queryResult = await sender.Send(query);

        var model = mapper.Map<TaskIndexViewModel>(queryResult);

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

        var command = mapper.Map<CreateTaskCommand>(model);

        await sender.Send(command);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("{id:int}/update")]
    public async Task<IActionResult> Update(int id)
    {
        var query = new GetTaskQuery(id);

        var queryResult = await sender.Send(query);

        var model = mapper.Map<TaskUpdateViewModel>(queryResult);

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

        var command = mapper.Map<UpdateTaskCommand>(model);

        await sender.Send(command);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("{id:int}/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new GetTaskQuery(id);

        var queryResult = await sender.Send(query);

        var model = mapper.Map<TaskDeleteViewModel>(queryResult);

        return View(model);
    }

    [HttpPost("{id:int}/delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var command = new DeleteTaskCommand(id);

        await sender.Send(command);

        return RedirectToAction(nameof(Index));
    }
}
