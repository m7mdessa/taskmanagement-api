using FluentValidation;
using Domain.Aggregates.DeveloperAggregate;

namespace Application.Commands.SprintTaskCommands.CreateSprintTask

{
    public class CreateSprintTaskCommandValidator : AbstractValidator<CreateSprintTaskCommand>
    {


        public CreateSprintTaskCommandValidator()
        {
            RuleFor(p => p.TaskName)
            .NotEmpty().WithMessage("{TaskName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{TaskName} must not exceed 50 characters.");

            RuleFor(p => p.TaskDescription)
            .NotEmpty().WithMessage("{TaskDescription} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{TaskDescription} must not exceed 50 characters.");
        }

       
    }
}
