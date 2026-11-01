using EmployeeService.Api.Models.Employee;
using EmployeeService.Application.Commands.Employee.Create;
using EmployeeService.Application.Commands.Employee.Delete;
using EmployeeService.Application.Commands.Employee.Update;
using EmployeeService.Application.Filters;
using EmployeeService.Application.Pagination;
using EmployeeService.Application.Queries.Employee.Get;
using EmployeeService.Application.Queries.Employee.GetEntities;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Api.Web;

[Route("employees")]
public sealed class EmployeeController(
    IMapper mapper,
    ISender sender
) : Controller
{
    [HttpGet("")]
    public async Task<IActionResult> Index(
        PaginationParams paginationParams,
        EmployeeFilter employeeFilter
    )
    {
        var query = new GetEmployeeEntitiesQuery(paginationParams, employeeFilter);

        var queryResult = await sender.Send(query);

        var model = mapper.Map<EmployeeIndexViewModel>(queryResult);

        model.Filter = employeeFilter;
        model.Pagination = paginationParams;  

        return View(model);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View(new EmployeeCreateViewModel());
    }

    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] EmployeeCreateViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var command = mapper.Map<CreateEmployeeCommand>(model);

        await sender.Send(command);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("{id:int}/update")]
    public async Task<IActionResult> Update(int id)
    {
        var query = new GetEmployeeQuery(id);

        var queryResult = await sender.Send(query);

        var model = mapper.Map<EmployeeUpdateViewModel>(queryResult);

        return View(model);
    }

    [HttpPost("{id:int}/update")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(int id, [FromForm] EmployeeUpdateViewModel model)
    {
        if (id != model.Id) 
            return BadRequest();

        if (!ModelState.IsValid)
            return View(model);

        var command = mapper.Map<UpdateEmployeeCommand>(model);

        await sender.Send(command);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("{id:int}/delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var query = new GetEmployeeQuery(id);

        var queryResult = await sender.Send(query);

        var model = mapper.Map<EmployeeDeleteViewModel>(queryResult);

        return View(model);
    }

    [HttpPost("{id:int}/delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var command = new DeleteEmployeeCommand(id);

        await sender.Send(command);

        return RedirectToAction(nameof(Index));
    }
}
