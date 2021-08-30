using _2_App.Dtos.Employee;
using FluentValidation;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.RequestValidator.Employee
{
    public class DeleteEmployeeDtoValidator : AbstractValidator<DeleteEmployeeDto>
    {
        public DeleteEmployeeDtoValidator()
        {
            RuleFor(v => v.Id).NotEmpty().WithMessage("Id can't be empty!");
            RuleFor(v => v.Id).Must(v => v > 0).WithMessage("Id must be a positive number!");
        }
    }
}
