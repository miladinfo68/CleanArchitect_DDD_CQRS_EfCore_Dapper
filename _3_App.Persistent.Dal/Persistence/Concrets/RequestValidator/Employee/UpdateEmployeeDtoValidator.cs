using _1_App.Core.Domain.Common.Middlewares;
using _2_App.Dtos.Employee;
using FluentValidation;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.RequestValidator.Employee
{
    public class UpdateEmployeeDtoValidator : AbstractValidator<UpdateEmployeeDto>
    {
        public UpdateEmployeeDtoValidator()
        {
            RuleFor(v => v.Id).NotEmpty().WithMessage("Id can't be empty!");
            RuleFor(v => v.Id).Must(v => v > 0).WithMessage("Id must be a positive number!");
            
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name can't be empty!");
            RuleFor(v => v.Name).NotEmpty().MinimumLength(3).MaximumLength(100).WithMessage("Name's length must be between from 3 to 100 characters!");
            
            RuleFor(v => v.Email).NotEmpty().WithMessage("Email can't be empty!");
            //RuleFor(v => v.Email).EmailAddress().WithMessage("Invalid email address!");
            RuleFor(v => v.Email).MatchEmailRule().WithMessage("Invalid email address!");

            RuleFor(v => v.DepartmentId).NotNull().WithMessage("DepartmentId can't be empty!");
            RuleFor(v => v.DepartmentId).GreaterThan(0).WithMessage("DepartmentId must be greater than 0!");
        }
    }
}
