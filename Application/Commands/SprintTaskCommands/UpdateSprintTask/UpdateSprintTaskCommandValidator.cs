using Domain.Aggregates.DeveloperAggregate;
using FluentValidation;


namespace Application.Commands.SprintTaskCommands.UpdateSprintTask
{
   
    public class UpdateSprintTaskCommandValidator : AbstractValidator<UpdateSprintTaskCommand>
    {

        public UpdateSprintTaskCommandValidator()
        {

            RuleFor(p => p.TaskName)
              .NotEmpty().WithMessage("{TaskName} is required.")
              .NotNull()
              .MaximumLength(50).WithMessage("{TaskName} must not exceed 50 characters.");

            RuleFor(p => p.TaskDescription)
               .NotEmpty().WithMessage("{TaskDescription} is required.");

        }

     
    }
}
