using EmployeeService.Application.Commands.Employee.Create;
using EmployeeService.Application.Commands.Employee.Delete;
using EmployeeService.Application.Commands.Employee.Update;
using EmployeeService.Application.Queries.Employee.Get;
using EmployeeService.Application.Queries.Employee.GetEntities;
using EmployeeService.Application.Request.Employee;
using EmployeeService.Application.Responses.Employee;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Api.Controllers;

[Authorize]
[Route("api/v1/employees")]
[ApiController]
public sealed class EmployeeApiController(
    IMapper mapper,
    ISender sender
) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetEmployeeResponse>> Get([FromRoute] int id)
    {
        var query = new GetEmployeeQuery(id);

        var queryResult = await sender.Send(query);

        var response = mapper.Map<GetEmployeeResponse>(queryResult);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetEmployeeEntitiesResponse>> GetEntities([FromQuery] GetEmployeeEntitiesRequest request)
    {
        var query = mapper.Map<GetEmployeeEntitiesQuery>(request);

        var queryResult = await sender.Send(query);

        var response = mapper.Map<GetEmployeeEntitiesResponse>(queryResult);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<CreateEmployeeResponse>> Create([FromBody] CreateEmployeeRequest request)
    {
        var command = mapper.Map<CreateEmployeeCommand>(request);

        var commandResult = await sender.Send(command);

        var response = mapper.Map<CreateEmployeeResponse>(commandResult);

        return Ok(response);
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<UpdateEmployeeResponse>> Update(int id, [FromBody] UpdateEmployeeRequest request)
    {
        var command = mapper.Map<UpdateEmployeeCommand>(request) with { Id = id};

        var commandResult = await sender.Send(command);

        var response = mapper.Map<UpdateEmployeeResponse>(commandResult);

        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<DeleteEmployeeResponse>> Delete([FromRoute] int id)
    {
        var command = new DeleteEmployeeCommand(id);

        var commandResult = await sender.Send(command);

        return NoContent();
    }
}
