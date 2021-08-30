using _2_App.Dtos.Department;
using _2_App.Dtos.Employee;
using FluentValidation;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.RequestValidator.Department
{
    public class UpdateDepartmentDtoValidator : AbstractValidator<UpdateDepartmentDto>
    {
        public UpdateDepartmentDtoValidator()
        {
            RuleFor(v => v.Id).NotEmpty().WithMessage("Id can't be empty!");
            RuleFor(v => v.Id).Must(v => v > 0).WithMessage("Id must be greater than 0!");
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name can't be empty!");
            RuleFor(v => v.Name).MinimumLength(3).MaximumLength(100).WithMessage("Name's length must be between from 3 to 100 characters!");
            RuleFor(v => v.Description).NotEmpty().WithMessage("Description can't be empty!");
            RuleFor(v => v.Description).MinimumLength(3).MaximumLength(100).WithMessage("Description's length must be between from 3 to 100 characters!");
        }
    }
}
