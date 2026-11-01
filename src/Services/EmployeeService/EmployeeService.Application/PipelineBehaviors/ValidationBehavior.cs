using FluentValidation;
using MediatR;

namespace EmployeeService.Application.PipelineBehaviors;

public sealed class ValidationBehavior<TRequest, TResponse>(
    IValidator<TRequest> validator
) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        if (validator == null)
        {
            return await next();
        }

        validator.ValidateAndThrow(request);

        return await next();
    }
}