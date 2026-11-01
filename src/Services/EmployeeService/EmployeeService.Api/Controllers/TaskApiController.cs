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
public class TaskApiController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public TaskApiController(IMapper mapper, ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetTaskResponse>> Get([FromRoute] int id)
    {
        var query = new GetTaskQuery(id);

        var queryResult = await _sender.Send(query);

        var response = _mapper.Map<GetTaskResponse>(queryResult);

        return response;
    }

    [HttpGet]
    public async Task<ActionResult<GetTaskEntitiesResponse>> GetEntities([FromQuery] GetTaskEntitiesRequest request)
    {
        var query = _mapper.Map<GetTaskEntitiesQuery>(request);

        var queryResult = await _sender.Send(query);

        var response = _mapper.Map<GetTaskEntitiesResponse>(queryResult);

        return response;
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreateTaskResponse>> Create([FromBody] CreateTaskRequest request)
    {
        var command = _mapper.Map<CreateTaskCommand>(request);

        var commandResult = await _sender.Send(command);

        var response = _mapper.Map<CreateTaskResponse>(commandResult);

        return response;
    }

    [HttpPatch("{id:int}/update")]
    public async Task<ActionResult<UpdateTaskResponse>> Update(int id, [FromBody] UpdateTaskRequest request)
    {
        var command = _mapper.Map<UpdateTaskCommand>(request) with { Id = id };

        var commandResult = await _sender.Send(command);

        var response = _mapper.Map<UpdateTaskResponse>(commandResult);

        return response;
    }

    [HttpDelete("{id:int}/delete")]
    public async Task<ActionResult<DeleteTaskResponse>> Delete([FromRoute] int id)
    {
        var command = new DeleteTaskCommand(id);

        var commandResult = await _sender.Send(command);

        var response = _mapper.Map<DeleteTaskResponse>(commandResult);

        return response;
    }
}