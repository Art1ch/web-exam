using EmployeeService.Application.Commands.Task.Create;
using EmployeeService.Application.Commands.Task.Delete;
using EmployeeService.Application.Commands.Task.Update;
using EmployeeService.Application.Queries.Task.Get;
using EmployeeService.Application.Queries.Task.GetEntities;
using EmployeeService.Application.Request.Task;
using EmployeeService.Application.Responses.Task;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Api.Controllers;

[Authorize]
[Route("api/v1/tasks")]
[ApiController]
public sealed class TaskApiController(
    IMapper mapper,
    ISender sender
) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetTaskResponse>> Get([FromRoute] int id)
    {
        var query = new GetTaskQuery(id);

        var queryResult = await sender.Send(query);

        var response = mapper.Map<GetTaskResponse>(queryResult);

        return response;
    }

    [HttpGet]
    public async Task<ActionResult<GetTaskEntitiesResponse>> GetEntities([FromQuery] GetTaskEntitiesRequest request)
    {
        var query = mapper.Map<GetTaskEntitiesQuery>(request);

        var queryResult = await sender.Send(query);

        var response = mapper.Map<GetTaskEntitiesResponse>(queryResult);

        return response;
    }

    [HttpPost]
    public async Task<ActionResult<CreateTaskResponse>> Create([FromBody] CreateTaskRequest request)
    {
        var command = mapper.Map<CreateTaskCommand>(request);

        var commandResult = await sender.Send(command);

        var response = mapper.Map<CreateTaskResponse>(commandResult);

        return response;
    }

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<UpdateTaskResponse>> Update(int id, [FromBody] UpdateTaskRequest request)
    {
        var command = mapper.Map<UpdateTaskCommand>(request) with { Id = id };

        var commandResult = await sender.Send(command);

        var response = mapper.Map<UpdateTaskResponse>(commandResult);

        return response;
    }

    [HttpDelete("{id:int")]
    public async Task<ActionResult<DeleteTaskResponse>> Delete([FromRoute] int id)
    {
        var command = new DeleteTaskCommand(id);

        var commandResult = await sender.Send(command);

        return NoContent();
    }
}