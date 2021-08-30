using FluentValidation;
using _3_1_App.Persistent.Dal.Persistence.Concrets.Cqrs.Models.Duty.CommandQuery;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.RequestValidator.Duty
{
    public class DeleteCommandDutyValidator : AbstractValidator<DeleteCommandDuty>
    {
        public DeleteCommandDutyValidator()
        {
            RuleFor(v => v.Id).NotEmpty().WithMessage("Id can't be empty!");
            RuleFor(v => v.Id).Must(v => v > 0).WithMessage("Id must be greater than 0!");
        }
    }
}
