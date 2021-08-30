using FluentValidation;
using _3_1_App.Persistent.Dal.Persistence.Concrets.Cqrs.Models.Duty.CommandQuery;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.RequestValidator.Duty
{
    public class UpdateCommandDutyValidator : AbstractValidator<UpdateCommandDuty>
    {
        public UpdateCommandDutyValidator()
        {
            RuleFor(v => v.Id).NotEmpty().WithMessage("Id can't be empty!");
            RuleFor(v => v.Id).Must(v => v > 0).WithMessage("Id must be greater than 0!");

            RuleFor(v => v.Name).NotEmpty().WithMessage("Name can't be empty!");
            RuleFor(v => v.Name).NotEmpty().MinimumLength(3).MaximumLength(100).WithMessage("Name's length must be between from 3 to 100 characters!");

            RuleFor(v => v.Description).NotEmpty().WithMessage("Description can't be empty!");
            RuleFor(v => v.Description).MinimumLength(3).MaximumLength(100).WithMessage("Description's length must be between from 3 to 100 characters!");

            RuleFor(v => v.Status).NotNull().WithMessage("Status can't be empty!");
            RuleFor(v => v.Status).IsInEnum().WithMessage("Status is enum between 1,2,3 !");
            
            RuleFor(v => v.EmployeeId).NotNull().WithMessage("EmployeeId can't be empty!");
            RuleFor(v => v.EmployeeId).Must(v => v > 0).WithMessage("EmployeeId must be greater than 0!");
        }
    }
}
