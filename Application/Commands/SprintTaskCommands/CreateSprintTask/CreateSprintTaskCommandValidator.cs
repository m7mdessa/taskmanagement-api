using FluentValidation;
using Domain.Aggregates.DeveloperAggregate;
using Domain.Aggregates.ProjectAggregate;

namespace Application.Commands.SprintTaskCommands.CreateSprintTask

{
    public class CreateSprintTaskCommandValidator : AbstractValidator<CreateSprintTaskCommand>
    {

        private readonly IProjectRepository _projectRepository;

        public CreateSprintTaskCommandValidator(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;

            RuleFor(p => p.ProjectId)
               .NotNull()
               .MustAsync(ProjectMustExist)
               .WithMessage("{ProjectId} must be present");

            RuleFor(p => p.TaskName)
                     .NotEmpty().WithMessage("{TaskName} is required.")
                     .NotNull()
                     .MaximumLength(50).WithMessage("{TaskName} must not exceed 50 characters.");

            RuleFor(p => p.TaskDescription)
            .NotEmpty().WithMessage("{TaskDescription} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{TaskDescription} must not exceed 50 characters.");


        }
        private async Task<bool> ProjectMustExist(int id, CancellationToken arg2)
        {
            var project = await _projectRepository.GetAsync(id);
            return project != null;
        }
    }
}
