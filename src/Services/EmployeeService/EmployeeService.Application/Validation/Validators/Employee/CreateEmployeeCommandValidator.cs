using EmployeeService.Application.Commands.Employee.Create;

namespace EmployeeService.Application.Validation.Validators.Employee;

public sealed class CreateEmployeeCommandValidator : EmployeeValidatorBase<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        ValidateEmployeeName(x => x.Name);
        ValidateAge(x => x.Age);
        ValidateSpeciality(x => x.Speciality);
        ValidateEmploymentDate(x => x.EmploymentDate);
        ValidateAvatarFormFile(x => x.Avatar);
    }
}
