using _2_App.Dtos.Department;
using FluentValidation;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.RequestValidator.Department
{
    public class AddDepartmentDtoValidator : AbstractValidator<AddDepartmentDto>
    {
        public AddDepartmentDtoValidator()
        {           
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name can't be empty!");
            RuleFor(v => v.Name).MinimumLength(3).MaximumLength(100).WithMessage("Name's length must be between from 3 to 100 characters!");
            RuleFor(v => v.Description).NotEmpty().WithMessage("Description can't be empty!");
            RuleFor(v => v.Description).MinimumLength(3).MaximumLength(100).WithMessage("Description's length must be between from 3 to 100 characters!");
        }
    }
}
