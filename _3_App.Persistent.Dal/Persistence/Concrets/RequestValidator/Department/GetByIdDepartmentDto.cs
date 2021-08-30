using _2_App.Dtos.Department;
using FluentValidation;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.RequestValidator.Department
{
    public class GetByIdDepartmentDtoValidator : AbstractValidator<GetByIdDepartmentDto>
    {
        public GetByIdDepartmentDtoValidator()
        {           
            RuleFor(v => v.Id).NotEmpty().WithMessage("Id can't be empty!");
            RuleFor(v => v.Id).Must(v=> v>0).WithMessage("Id must be greater than 0!");          
        }
    }
}
