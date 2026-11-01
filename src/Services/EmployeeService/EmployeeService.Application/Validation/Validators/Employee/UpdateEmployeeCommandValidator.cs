using EmployeeService.Application.Commands.Employee.Update;

namespace EmployeeService.Application.Validation.Validators.Employee;

public sealed class UpdateEmployeeCommandValidator : EmployeeValidatorBase<UpdateEmployeeCommand>
{
    public UpdateEmployeeCommandValidator()
    {
        ValidateId(x => x.Id);
        ValidateEmployeeName(x => x.Name);
        ValidateAge(x => x.Age);
        ValidateSpeciality(x => x.Speciality);
        ValidateEmploymentDate(x => x.EmploymentDate);
        ValidateAvatarFormFile(x => x.NewAvatar);
    }
}
