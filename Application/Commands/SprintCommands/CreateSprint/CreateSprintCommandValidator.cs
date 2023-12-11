using Domain.Aggregates.ProjectAggregate;
using FluentValidation;

namespace Application.Commands.SprintCommands.CreateSprint

{
    public class CreateSprintCommandValidator : AbstractValidator<CreateSprintCommand>
    {

        private readonly IProjectRepository _projectRepository;

        public CreateSprintCommandValidator(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;

            RuleFor(p => p.ProjectId)
               .NotNull()
               .MustAsync(ProjectMustExist)
               .WithMessage("{ProjectId} must be present");

            RuleFor(p => p.SprintName)
                .NotEmpty().WithMessage("{SprintName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{SprintName} must not exceed 50 characters.");


        }
        private async Task<bool> ProjectMustExist(int id, CancellationToken arg2)
        {
            var project = await _projectRepository.GetAsync(id);
            return project != null;
        }

    }








}
