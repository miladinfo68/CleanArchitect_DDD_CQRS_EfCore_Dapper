using FluentValidation;
using _3_1_App.Persistent.Dal.Persistence.Concrets.Cqrs.Models.Duty.CommandQuery;

namespace _3_1_App.Persistent.Dal.Persistence.Concrets.RequestValidator.Duty
{
    public class CreateCommandDutyValidator: AbstractValidator<CreateCommandDuty>
    {
        public CreateCommandDutyValidator()
        {
            /*
            RuleFor(m => m.FirstName).NotEmpty().When(m => string.IsNullOrEmpty(m.LastName)).WithMessage("*Either First Name or Last Name is required");
            RuleFor(m => m.LastName).NotEmpty().When(m => string.IsNullOrEmpty(m.FirstName)).WithMessage("*Either First Name or Last Name is required");
            //or 
            RuleFor(m => m.FirstName).NotEmpty().Unless(m => !string.IsNullOrEmpty(m.LastName)).WithMessage("*Either First Name or Last Name is required");
            RuleFor(m => m.LastName).NotEmpty().Unless(m => !string.IsNullOrEmpty(m.FirstName)).WithMessage("*Either First Name or Last Name is required");
            //or
            RuleFor(person => person).Must(person => !string.IsNullOrEmpty(person.FirstName) || !string.IsNullOrEmpty(person.LastName)).WithMessage("*Either First Name or Last Name is required");
            */
            
            
            
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name can't be empty!");
            RuleFor(v => v.Name).NotEmpty().MinimumLength(3).MaximumLength(100).WithMessage("Name's length must be between from 3 to 100 characters!");

            RuleFor(v => v.Description).NotEmpty().WithMessage("Description can't be empty!");
            RuleFor(v => v.Description).MinimumLength(3).MaximumLength(100).WithMessage("Description's length must be between from 3 to 100 characters!");

            //RuleFor(v => v.Status).NotNull().WithMessage("Status can't be empty!");
            //RuleFor(v => v.Status).IsInEnum().WithMessage("Status is enum between 1,2,3 !");

            RuleFor(v => v.EmployeeId).NotNull().WithMessage("EmployeeId can't be empty!");
            RuleFor(v => v.EmployeeId).Must(v => v > 0).WithMessage("EmployeeId must be greater than 0!");
        }
    }
}
