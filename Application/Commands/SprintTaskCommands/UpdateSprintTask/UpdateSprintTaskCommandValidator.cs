using Domain.Aggregates.DeveloperAggregate;
using Domain.Aggregates.ProjectAggregate;
using FluentValidation;


namespace Application.Commands.SprintTaskCommands.UpdateSprintTask
{
   
    public class UpdateSprintTaskCommandValidator : AbstractValidator<UpdateSprintTaskCommand>
    {

        private readonly IProjectRepository _projectRepository;

        public UpdateSprintTaskCommandValidator(IProjectRepository projectRepository)
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
