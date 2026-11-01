namespace EmployeeService.Application.Interfaces.Repositories;

public interface IRepository<TEntity>
{
    Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> GetAsync(int id, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellation = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
