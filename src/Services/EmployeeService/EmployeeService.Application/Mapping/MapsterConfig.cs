using EmployeeService.Application.Pagination;
using EmployeeService.Application.Queries.Employee.GetEntities;
using EmployeeService.Application.Queries.Task.GetEntities;
using EmployeeService.Core.Entities;
using Mapster;

namespace EmployeeService.Application.Mapping;

public sealed class MapsterConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PaginationResult<EmployeeEntity>, GetEmployeeEntitiesQueryResult>()
              .Map(dest => dest.Items, src => src.Entities);

        config.NewConfig<PaginationResult<TaskEntity>, GetTaskEntitiesQueryResult>()
              .Map(dest => dest.Items, src => src.Entities);
    }
}
