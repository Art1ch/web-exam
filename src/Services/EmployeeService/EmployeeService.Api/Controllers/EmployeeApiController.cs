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
public class EmployeeApiController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public EmployeeApiController(IMapper mapper, ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetEmployeeResponse>> Get([FromRoute] int id)
    {
        var query = new GetEmployeeQuery(id);

        var queryResult = await _sender.Send(query);

        var response = _mapper.Map<GetEmployeeResponse>(queryResult);

        return response;
    }

    [HttpGet]
    public async Task<ActionResult<GetEmployeeEntitiesResponse>> GetEntities([FromQuery] GetEmployeeEntitiesRequest request)
    {
        var query = _mapper.Map<GetEmployeeEntitiesQuery>(request);

        var queryResult = await _sender.Send(query);

        var response = _mapper.Map<GetEmployeeEntitiesResponse>(queryResult);

        return response;
    }

    [HttpPost("create")]
    public async Task<ActionResult<CreateEmployeeResponse>> Create([FromBody] CreateEmployeeRequest request)
    {
        var command = _mapper.Map<CreateEmployeeCommand>(request);

        var commandResult = await _sender.Send(command);

        var response = _mapper.Map<CreateEmployeeResponse>(commandResult);

        return response;
    }

    [HttpPatch("{id:int}/update")]
    public async Task<ActionResult<UpdateEmployeeResponse>> Update(int id, [FromBody] UpdateEmployeeRequest request)
    {
        var command = _mapper.Map<UpdateEmployeeCommand>(request) with { Id = id};

        var commandResult = await _sender.Send(command);

        var response = _mapper.Map<UpdateEmployeeResponse>(commandResult);

        return response;
    }

    [HttpDelete("{id:int}/delete")]
    public async Task<ActionResult<DeleteEmployeeResponse>> Delete([FromRoute] int id)
    {
        var command = new DeleteEmployeeCommand(id);

        var commandResult = await _sender.Send(command);

        var response = _mapper.Map<DeleteEmployeeResponse>(commandResult);

        return response;
    }
}
